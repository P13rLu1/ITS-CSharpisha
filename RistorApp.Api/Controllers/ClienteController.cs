﻿using Microsoft.AspNetCore.Mvc;
using RistorApp.DataLayer.Models;
using RistorApp.DataLayer.Services;

namespace RistorApp.Api.Controllers
{
    /// <summary>
    /// Controller per la gestione dei clienti
    /// </summary>
    /// <param name="clienteService">Controller per la gestione dei clienti</param>
    [ApiController]
    [Route("[controller]")]
    public class ClienteController(ClienteService clienteService) : ControllerBase
    {
        /// <summary>
        /// Questa funzione restituisce tutti i clienti presenti nel database
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Ritorna un messaggio di conferma</response>
        /// <response code="500">Se si è verificato un errore non previsto</response>
        [HttpGet, ProducesResponseType(typeof(List<Cliente>), 200), ProducesResponseType(typeof(string), 500)]
        public IActionResult Get()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, clienteService.Get());
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
        [HttpGet("{id}"), ProducesResponseType(typeof(List<Cliente>), 200), ProducesResponseType(typeof(string), 500)]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, clienteService.Get(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Permette l'inserimento di un nuovo cliente
        /// </summary>
        /// <param name="clienteDaInserire">I dati del cliente da inserire</param>
        /// <returns>Un messaggio di conferma dell'operazione</returns>
        /// <response code="201">Ritorna un messaggio di conferma</response>
        /// <response code="500">Se si è verificato un errore non previsto</response>
        [HttpPost, ProducesResponseType(typeof(string), 201), ProducesResponseType(typeof(string), 500)]
        public IActionResult Insert(ClienteCreateModel clienteDaInserire)
        {
            try
            {
                var esito = clienteService.Create(clienteDaInserire);
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
        /// <param name="clienteDaModificare">Variabile Cliente Da Modificare</param>
        /// <returns>Un messaggio di conferma dell'operazione</returns>
        /// <response code="200">Ritorna un messaggio di conferma</response>
        /// <response code="500">Se si è verificato un errore non previsto</response>
        [HttpPut, ProducesResponseType(typeof(string), 200), ProducesResponseType(typeof(string), 500)]
        public IActionResult Update(Cliente clienteDaModificare) //questa funzione fa un update di un cliente esistente
        {
            try
            {
                var esito = clienteService.Update(clienteDaModificare);
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
                var esito = clienteService.Delete(id);
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