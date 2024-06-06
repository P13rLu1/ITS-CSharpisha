using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scheletro.DataLayer.Models;
using Scheletro.DataLayer.Services;

namespace Scheletro.Api.Controllers
{
    /// <summary>
    /// Controller per la gestione dei clienti
    /// </summary>
    /// <param name="modello1Service">Controller per la gestione dei del modello1</param>
    [ApiController]
    [Route("[controller]")]
    public class Modello1Controller(Modello1Service modello1Service) : ControllerBase
    {
        /// <summary>
        /// Questa funzione restituisce tutti i clienti presenti nel database
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Ritorna un messaggio di conferma</response>
        /// <response code="500">Se si è verificato un errore non previsto</response>
        [HttpGet, ProducesResponseType(typeof(List<Modello1>), 200), ProducesResponseType(typeof(string), 500)]
        public IActionResult Get()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, modello1Service.Get());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Questa funzione restituisce un cliente in base all'id
        /// </summary>
        /// <param name="id">id che si vuole cercare</param>
        /// <returns></returns>
        /// <response code="200">Ritorna un messaggio di conferma</response>
        /// <response code="500">Se si è verificato un errore non previsto</response>
        [HttpGet("{id}"), ProducesResponseType(typeof(List<Modello1>), 200), ProducesResponseType(typeof(string), 500)]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, modello1Service.Get(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Permette l'inserimento di un nuovo cliente
        /// </summary>
        /// <param name="modello1DaInserire">I dati del modello da inserire</param>
        /// <returns>Un messaggio di conferma dell'operazione</returns>
        /// <response code="201">Ritorna un messaggio di conferma</response>
        /// <response code="500">Se si è verificato un errore non previsto</response>
        [HttpPost, ProducesResponseType(typeof(string), 201), ProducesResponseType(typeof(string), 500)]
        public IActionResult Insert(Modello1CreateModel modello1DaInserire)
        {
            try
            {
                var esito = modello1Service.Create(modello1DaInserire);
                if (esito)
                {
                    return StatusCode(StatusCodes.Status201Created, "Cliente inserito");
                }

                throw new Exception("Si è verificato un errore");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Questa funzione modifica un cliente esistente
        /// </summary>
        /// <param name="modello1DaModificare">Variabile Modello Da Modificare</param>
        /// <returns>Un messaggio di conferma dell'operazione</returns>
        /// <response code="200">Ritorna un messaggio di conferma</response>
        /// <response code="500">Se si è verificato un errore non previsto</response>
        [HttpPut, ProducesResponseType(typeof(string), 200), ProducesResponseType(typeof(string), 500)]
        public IActionResult Update(Modello1 modello1DaModificare) //questa funzione fa un update di un cliente esistente
        {
            try
            {
                var esito = modello1Service.Update(modello1DaModificare);
                if (esito)
                {
                    return StatusCode(StatusCodes.Status200OK, "Cliente modificato correttamente");
                }

                throw new Exception("Cliente non presente nel database");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Questa funzione rimuove un cliente esistente
        /// </summary>
        /// <param name="id">l'id del cliente da eliminare</param>
        /// <returns></returns>
        /// <response code="200">Ritorna un messaggio di conferma</response>
        /// <response code="500">Se si è verificato un errore non previsto</response>
        [HttpDelete("{id}"), ProducesResponseType(typeof(string), 200), ProducesResponseType(typeof(string), 500)]
        public IActionResult Remove(int id) //questa funzione rimuove un cliente in base all'id
        {
            try
            {
                var esito = modello1Service.Delete(id);
                if (esito)
                {
                    return StatusCode(StatusCodes.Status200OK, "Cliente eliminato correttamente");
                }

                throw new Exception("Cliente non presente nel database");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}