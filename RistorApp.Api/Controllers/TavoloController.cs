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
        [HttpPost, ProducesResponseType(typeof(TavoloCreateModel), 201), ProducesResponseType(typeof(string), 500)]
        public IActionResult Insert(TavoloCreateModel tavoloDaInserire)
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
        /// Permette l'aggiornamento di un tavolo
        /// </summary>
        /// <param name="id">ID del tavolo da modificare</param>
        /// <param name="nuovaVersione">Versione aggiornata del tavolo</param>
        /// <returns>Codice risultato dell'operazione</returns>
        /// <response code="201">Messaggio di conferma</response>
        /// <response code="404">Tavolo inesistente</response>
        /// <response code="500">Errore non previsto</response>
        [HttpPut("{id}"), ProducesResponseType(typeof(string), 200), ProducesResponseType(typeof(string), 500)]
        public IActionResult Update([FromRoute] int id, [FromBody] TavoloCreateModel nuovaVersione)
        {
            try
            {
                var vecchiaVersione = tavoloService.Get(id);

                nuovaVersione.Id = vecchiaVersione.Id;

                var esito = tavoloService.Update(nuovaVersione);
                if (esito)
                {
                    return StatusCode(StatusCodes.Status200OK, "Cliente aggiornato");
                }

                throw new Exception("Si è verificato un errore");
            }
            catch (IndexOutOfRangeException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
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
        /// <response code="200">Corretta rimozione del tavolo</response>
        /// <response code="404">Impossibile trovare tavolo con ID specificato</response>
        /// <response code="500">Errore non previsto</response>
        [HttpDelete ("{id}"), ProducesResponseType(typeof(string), 200), ProducesResponseType(typeof(string), 404), ProducesResponseType(typeof(string), 500)]
        public  IActionResult Remove([FromRoute]int id)
        {
            try
            {
                var esito = tavoloService.Delete(id);

                if (esito)
                {
                    return StatusCode(StatusCodes.Status200OK, "Tavolo rimosso con successo");
                }

                throw new Exception("Impossibile rimuovere tavolo");
            }
            catch (IndexOutOfRangeException ex)
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