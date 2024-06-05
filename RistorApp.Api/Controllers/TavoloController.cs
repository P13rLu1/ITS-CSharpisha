using Microsoft.AspNetCore.Mvc;
using RistorApp.DataLayer.Models;
using RistorApp.DataLayer.Services;

namespace RistorApp.Api.Controllers
{
    /// <summary>
    /// Controller per la gestione dei tavoli
    /// </summary>
    /// <param name="tavoloService"></param>
    [ApiController]
    [Route("[controller]")]
    public class TavoloController(TavoloService tavoloService) : ControllerBase
    {
        /// <summary>
        /// Questa funzione restituisce tutti i tavoli
        /// </summary>
        /// <returns></returns>
        [HttpGet] 
        public IEnumerable<Tavolo> Get() //questa funzione restituisce tutti i tavoli
        {
            return tavoloService.Get();
        }

        /// <summary>
        /// Questa funzione inserisce un nuovo tavolo
        /// </summary>
        /// <param name="numeroPersone"></param>
        /// <param name="posizione"></param>
        /// <returns></returns>
        /// <response code="201">Ritorna un messaggio di conferma</response>
        /// <response code="500">Se si è verificato un errore non previsto</response>
        [HttpPost]
        public IActionResult Insert(int numeroPersone, string posizione) //questa funzione inserisce un nuovo tavolo
        {
            try 
            {
                var esito = tavoloService.Create(numeroPersone, posizione);
                if (esito)
                {
                    return StatusCode(StatusCodes.Status201Created, "Tavolo inserito");
                }

                throw new Exception("Si è verificato un errore");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Questa funzione fa un update di un tavolo esistente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="202">Ritorna un messaggio di conferma</response>
        /// <response code="500">Se si è verificato un errore non previsto</response>
        [HttpDelete]
        public  IActionResult Remove(int id) //questa funzione rimuove un tavolo
        {
            try 
            {
                var esito = tavoloService.Delete(id);
                if (esito)
                {
                    return StatusCode(StatusCodes.Status202Accepted, "Tavolo rimosso");
                }

                throw new Exception("Si è verificato un errore");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}