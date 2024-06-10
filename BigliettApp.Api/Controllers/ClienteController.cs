using BigliettApp.DataLayer.Models;
using BigliettApp.DataLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BigliettApp.Api.Controllers;

/// <summary>
/// Controller per la gestione dei clienti
/// </summary>
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
    [HttpGet("{id}"), ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK), ProducesResponseType(typeof(string), StatusCodes.Status404NotFound), ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public IActionResult GetById([FromRoute] int id)
    {
        try
        {
            return StatusCode(StatusCodes.Status200OK, clienteService.Get(id));
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
    /// Permette l'inserimento di un nuovo cliente
    /// </summary>
    /// <param name="clienteDaCreare">Cliente da inserire</param>
    /// <returns></returns>
    /// <response code="200">Ritorna un messaggio di conferma</response>
    /// <response code="500">Se si è verificato un errore non previsto</response>
    [HttpPost, ProducesResponseType(typeof(string), StatusCodes.Status200OK), ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public IActionResult Create([FromBody] ClienteCreateModel clienteDaCreare)
    {
        try
        {
            return StatusCode(StatusCodes.Status200OK, clienteService.Create(clienteDaCreare));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    
    /// <summary>
    /// Permette l'aggiornamento di un cliente
    /// </summary>
    /// <param name="id">ID del cliente da modificare</param>
    /// <param name="nuovaVersione">Versione aggiornata del cliente</param>
    /// <returns>Codice risultato dell'operazione</returns>
    /// <response code="200">Messaggio di conferma</response>
    /// <response code="404">Cliente inesistente</response>
    /// <response code="500">Errore non previsto</response>
    [HttpPut("{id}"), ProducesResponseType(typeof(string), 200), ProducesResponseType(typeof(string), 404), ProducesResponseType(typeof(string), 500)]
    public IActionResult Update([FromRoute] int id, [FromBody] ClienteCreateModel nuovaVersione) 
    {
        try
        {
            var vecchiaVersione = clienteService.Get(id);

            nuovaVersione.Id = vecchiaVersione.Id;

            var esito = clienteService.Update(nuovaVersione);
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
    /// Questa funzione rimuove un cliente esistente
    /// </summary>
    /// <param name="id">l'id del cliente da eliminare</param>
    /// <returns></returns>
    /// <response code="200">Corretta rimozione del cliente</response>
    /// <response code="404">Impossibile trovare cliente con ID specificato</response>
    /// <response code="500">Errore non previsto</response>
    [HttpDelete("{id}"), ProducesResponseType(typeof(string), 200), ProducesResponseType(typeof(string), 404), ProducesResponseType(typeof(string), 500)]
    public IActionResult Remove([FromRoute] int id)
    {
        try
        {
            var esito = clienteService.Delete(id);

            if (esito)
            {
                return StatusCode(StatusCodes.Status200OK, "Cliente rimosso");
            }

            throw new Exception("Impossibile rimuovere cliente");
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