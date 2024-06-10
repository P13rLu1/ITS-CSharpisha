using BigliettApp.DataLayer.Models;
using BigliettApp.DataLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BigliettApp.Api.Controllers;

/// <summary>
/// Controller per la gestione delle prenotazioni
/// </summary>
/// <param name="prenotazioneService">classe dove faccio tutte le operazioni per le prenotazioni</param>
[ApiController]
[Route("[controller]")]
public class PrenotazioneController(PrenotazioneService prenotazioneService) : ControllerBase
{
    /// <summary>
    /// Questa funzione restituisce tutte le prenotazioni
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Ritorna un messaggio di conferma</response>
    /// <response code="500">Se si è verificato un errore non previsto</response>
    [HttpGet, ProducesResponseType(typeof(List<Prenotazione>), 200), ProducesResponseType(typeof(string), 500)]
    public IActionResult Get()
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
    /// Permette la ricerca di una specifica prenotazione
    /// </summary>
    /// <param name="id">L'ID della prenotazione da cercare</param>
    /// <returns>Prenotazione trovata se presente nel database</returns>
    [HttpGet("{id}")]
    public Prenotazione? GetById([FromRoute] int id)
    {
        try
        {
            return prenotazioneService.Get(id);
        }
        catch (IndexOutOfRangeException)
        {
            return null;
        }
    }
    
    /// <summary>
    /// Permette l'inserimento di una nuova prenotazione
    /// </summary>
    /// <param name="model">I dati della prenotazione da inserire</param>
    /// <returns>Codice risultato dell'operazione</returns>
    /// <response code="201">Messaggio di conferma</response>
    /// <response code="404">Impossibile trovare cliente con ID specificato</response>
    /// <response code="500">Errore non previsto</response>
    [HttpPost, ProducesResponseType(typeof(List<PrenotazioneCreateModel>), 201), ProducesResponseType(typeof(string), 404), ProducesResponseType(typeof(string), 500)]
    public IActionResult Insert([FromBody] PrenotazioneCreateModel model)
    {
        try
        {
            var esito = prenotazioneService.Create(model);

            if (esito)
            {
                return StatusCode(StatusCodes.Status201Created, "Prenotazione inserita");
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
    /// Permette l'aggiornamento di una prenotazione
    /// </summary>
    /// <param name="id">ID della prenotazione da modificare</param>
    /// <param name="nuovaVersione">Versione aggiornata della prenotazione</param>
    /// <returns>Codice risultato dell'operazione</returns>
    /// <response code="201">Messaggio di conferma</response>
    /// <response code="404">Prenotazione inesistente</response>
    /// <response code="500">Errore non previsto</response>
    [HttpPut("{id}"), ProducesResponseType(typeof(List<PrenotazioneCreateModel>), 201), ProducesResponseType(typeof(string), 404), ProducesResponseType(typeof(string), 500)]
    public IActionResult Update([FromRoute] int id, [FromBody] PrenotazioneCreateModel nuovaVersione)
    {
        try
        {
            var vecchiaVersione = prenotazioneService.Get(id);

            nuovaVersione.Id = vecchiaVersione.Id;

            var esito = prenotazioneService.Update(nuovaVersione);
            if (esito)
            {
                return StatusCode(StatusCodes.Status200OK, "Prenotazione aggiornata");
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
    /// Elimina la prenotazione (se presente)
    /// </summary>
    /// <param name="id">Il codice identificativo univoco della prenotazione</param>
    /// <returns>Un messaggio che conferma l'avvenuta rimozione della prenotazione</returns>
    /// <response code="200">Ritorna un messaggio di conferma</response>
    /// <response code="404">Se la prenotazione con l'id in input non esiste</response>
    /// <response code="500">Se si è verificato un errore non previsto</response>
    [HttpDelete("{id}"), ProducesResponseType(typeof(string), 200), ProducesResponseType(typeof(string), 404), ProducesResponseType(typeof(string), 500)]
    public IActionResult Remove([FromRoute]int id)
    {
        try
        {
            var esito = prenotazioneService.Delete(id);

            if (esito)
            {
                return StatusCode(StatusCodes.Status200OK, "Prenotazione rimossa");
            }

            throw new Exception("Impossibile rimuovere prenotazione");
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