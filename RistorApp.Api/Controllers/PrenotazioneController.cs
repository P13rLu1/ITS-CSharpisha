﻿using Microsoft.AspNetCore.Mvc;
using RistorApp.DataLayer.Models;
using RistorApp.DataLayer.Services;

namespace RistorApp.Api.Controllers
{
    /// <summary>
    /// Controller per la gestione delle prenotazioni
    /// </summary>
    /// <param name="prenotazioneService">classe dove faccio tutte le operazioni per le prenotazioni</param>
    /// <param name="clienteService">classe dove faccio tutte le operazioni per le clienti</param>
    /// <param name="tavoloService">classe dove faccio tutte le operazioni per le tavoli</param>
    [ApiController]
    [Route("[controller]")]
    public class PrenotazioneController(
        PrenotazioneService prenotazioneService,
        ClienteService clienteService,
        TavoloService tavoloService)
        : ControllerBase
    {
        /// <summary>
        /// Questa funzione restituisce tutte le prenotazioni
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Ritorna un messaggio di conferma</response>
        /// <response code="500">Se si è verificato un errore non previsto</response>
        [HttpGet, ProducesResponseType(typeof(List<Prenotazione>), 200), ProducesResponseType(typeof(string), 500)]
        public IActionResult Get() //questa funzione restituisce tutte le prenotazioni
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, prenotazioneService.Get());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Questa funzione restituisce se ci sono tavoli disponibili in base al numero di posti desiderati e alla data della prenotazione
        /// </summary>
        /// <param name="postiDesiderati">variabile per i posti desiderati</param>
        /// <param name="dataPrenotazione">variabile per la data di prenotazione</param>
        /// <returns></returns>
        /// <response code="200">Ritorna un messaggio di conferma</response>
        /// <response code="500">Se si è verificato un errore non previsto</response>
        [HttpGet("tavoli-disponibili"), ProducesResponseType(typeof(List<Tavolo>), 200), ProducesResponseType(typeof(string), 500)]
        public IActionResult GetTavoliDisponibili(int postiDesiderati, DateTime dataPrenotazione)
        {
            try
            {
                var tavoli = tavoloService.Get();
                var prenotazioni = prenotazioneService.Get(dataPrenotazione);
                var tavoliOccupati = prenotazioni.Select(p => p.IdTavolo).Distinct();
                var tavoliDisponibili = tavoli.Where(t => !tavoliOccupati.Contains(t.Id) && t.NumeroPersone >= postiDesiderati);
                return StatusCode(StatusCodes.Status200OK, tavoliDisponibili);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Inserisce una nuova prenotazione.
        /// </summary>
        /// <param name="idCliente">Il codice identificativo univoco del cliente.</param>
        /// <param name="idTavolo">Il codice identificativo univoco del tavolo.</param>
        /// <param name="dataPrenotazione">La data della prenotazione.</param>
        /// <returns>Un messaggio che conferma l'avvenuta creazione della prenotazione.</returns>
        /// <response code="201">Ritorna un messaggio di conferma della creazione della prenotazione.</response>
        /// <response code="404">Se il cliente con l'id in input non esiste.</response>
        /// <response code="409">Se il tavolo è già occupato per la data della prenotazione.</response>
        /// <response code="500">Se si è verificato un errore non previsto.</response>
        [HttpPost, ProducesResponseType(typeof(string), 201), ProducesResponseType(typeof(string), 404), ProducesResponseType(typeof(string), 409), ProducesResponseType(typeof(string), 500)]
        public IActionResult Insert(int idCliente, int idTavolo, DateTime dataPrenotazione)
        {
            try
            {
                if (clienteService.Get(idCliente) == null!)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Cliente {idCliente} non trovato");
                }

                var coincidenze = prenotazioneService.Get(dataPrenotazione);
                var occupato = coincidenze.Any(c => c.IdTavolo == idTavolo);

                if (occupato)
                {
                    return StatusCode(StatusCodes.Status409Conflict, $"Tavolo {idTavolo} non disponibile per {dataPrenotazione.ToShortDateString()}");
                }

                var esito = prenotazioneService.Create(idCliente, idTavolo, dataPrenotazione);
                if (esito)
                {
                    return StatusCode(StatusCodes.Status201Created, "Prenotazione inserita");
                }

                throw new Exception("Si è verificato un errore");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
        /// <summary>
        /// Aggiorna la prenotazione con i dati in input
        /// </summary>
        /// <param name="id">id della prenotazione</param>
        /// <param name="idCliente">id del cliente della nuova prenotazione</param>
        /// <param name="idTavolo">id del tavolo della nuova prenotazione</param>
        /// <param name="dataPrenotazione">dalla della nuova prenotazione</param>
        /// <returns></returns>
        /// <response code="200">Ritorna un messaggio di conferma della creazione della prenotazione.</response>
        /// <response code="404">Se il cliente con l'id in input non esiste.</response>
        /// <response code="409">Se il tavolo è già occupato per la data della prenotazione.</response>
        /// <response code="500">Se si è verificato un errore non previsto.</response>
        [HttpPut, ProducesResponseType(typeof(string), 200), ProducesResponseType(typeof(string), 404), ProducesResponseType(typeof(string), 409), ProducesResponseType(typeof(string), 500)]
        public IActionResult Update(int id, int idCliente, int idTavolo, DateTime dataPrenotazione)
        {
            try
            {

                var coincidenze = prenotazioneService.Get(dataPrenotazione);
                var occupato = coincidenze.Any(c => c.IdTavolo == idTavolo && c.Id != id);

                if (occupato)
                {
                    return StatusCode(StatusCodes.Status409Conflict, $"Tavolo {idTavolo} non disponibile per {dataPrenotazione.ToShortDateString()}");
                }

                var esito = prenotazioneService.Update(id, idCliente, idTavolo, dataPrenotazione);
                if (esito)
                {
                    return StatusCode(StatusCodes.Status200OK, "Prenotazione aggiornata");
                }

                throw new Exception("Si è verificato un errore");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Elimina la prenotazione (se presente)
        /// </summary>
        /// <param name="id">Il codice identificativo univoco della prenotazione</param>
        /// <returns>Un messaggio che conferma l'avvenuta rimozione della prenotazione</returns>
        /// <response code="200">Ritorna un messaggio di conferma</response>
        /// <response code="404">Se la prenotazione con l'id in input non esiste</response>
        /// <response code="500">Se si è verificato un errore non previsto</response>
        [HttpDelete, ProducesResponseType(typeof(string), 200), ProducesResponseType(typeof(string), 404), ProducesResponseType(typeof(string), 500)]
        public IActionResult Remove(int id)
        {
            try
            { 
                var esito = prenotazioneService.Delete(id);
                if (esito)
                {
                    return StatusCode(StatusCodes.Status200OK, "Prenotazione rimossa");
                }

                throw new ArgumentOutOfRangeException(nameof(id), "Prenotazione non presente nel database");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
