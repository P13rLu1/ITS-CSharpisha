using Microsoft.AspNetCore.Mvc;
using RistorApp.DataLayer.Models;
using RistorApp.DataLayer.Services;

namespace RistorApp.Api.Controllers
{
    /// <summary>
    /// Controller per la gestione dei tavoli
    /// </summary>
    /// <param name="tavoloService">utilizzo della classe tavoloservice</param>
    [ApiController]
    [Route("[controller]")]
    public class TavoloController(TavoloService tavoloService) : ControllerBase
    {
        /// <summary>
        /// Questa funzione restituisce tutti i tavoli
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Ritorna un messaggio di conferma</response>
        /// <response code="500">Se si è verificato un errore non previsto</response>
        [HttpGet, ProducesResponseType(typeof(List<Tavolo>), 200), ProducesResponseType(typeof(string), 500)] 
        public IActionResult Get() //questa funzione restituisce tutti i tavoli
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, tavoloService.Get());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        
        /// <summary>
        /// Questa funzione inserisce un nuovo tavolo
        /// </summary>
        /// <param name="tavoloDaInserire">Oggetto del tavolo da inserire</param>
        /// <returns></returns>
        /// <response code="201">Ritorna un messaggio di conferma</response>
        /// <response code="500">Se si è verificato un errore non previsto</response>
        [HttpPost, ProducesResponseType(typeof(string), 201), ProducesResponseType(typeof(string), 500)]
        public IActionResult Insert(TavoloCreateModel tavoloDaInserire) //questa funzione inserisce un nuovo tavolo
        {
            try 
            {
                var esito = tavoloService.Create(tavoloDaInserire);
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
        /// Questa funzione modifica un tavolo esistente
        /// </summary>
        /// <param name="tavoloDaModificare">oggetto del tavolo da modificare</param>
        /// <returns></returns>
        /// <response code="200">Ritorna un messaggio di conferma</response>
        /// <response code="500">Se si è verificato un errore non previsto</response>
        [HttpPut, ProducesResponseType(typeof(string), 200), ProducesResponseType(typeof(string), 500)]
        public IActionResult Update(Tavolo tavoloDaModificare) 
        {
            try 
            {
                var esito = tavoloService.Update(tavoloDaModificare);
                if (esito)
                {
                    return StatusCode(StatusCodes.Status200OK, "Tavolo modificato");
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
        /// <param name="id">id del tavolo da rimuovere</param>
        /// <returns></returns>
        /// <response code="200">Ritorna un messaggio di conferma</response>
        /// <response code="500">Se si è verificato un errore non previsto</response>
        [HttpDelete, ProducesResponseType(typeof(string), 200), ProducesResponseType(typeof(string), 500)]
        public  IActionResult Remove(int id) //questa funzione rimuove un tavolo
        {
            try 
            {
                var esito = tavoloService.Delete(id);
                if (esito)
                {
                    return StatusCode(StatusCodes.Status200OK, "Tavolo rimosso");
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