using Microsoft.AspNetCore.Mvc;
using RistorApp.DataLayer.Models;
using RistorApp.DataLayer.Services;

namespace RistorApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrenotazioneController(
        PrenotazioneService prenotazioneService,
        ClienteService clienteService,
        TavoloService tavoloService)
        : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Prenotazione> Get() //questa funzione restituisce tutte le prenotazioni
        {
            return prenotazioneService.Get();
        }

        [HttpGet("tavoli-disponibili")] //questa funzione restituisce i tavoli disponibili in base al numero di posti desiderati e alla data della prenotazione
        public IEnumerable<Tavolo> GetTavoliDisponibili(int postiDesiderati, DateTime dataPrenotazione)
        {
            var coincidenze = prenotazioneService.Get(dataPrenotazione);
            return tavoloService.Get().Where(t =>
                t.NumeroPersone >= postiDesiderati &&
                coincidenze.Any(c => c.IdTavolo == t.Id) == false).ToList();
        }

        [HttpPost]
        public string Insert(int idCliente, int idTavolo, DateTime dataPrenotazione) //questa funzione inserisce una nuova prenotazione
        {
            if (clienteService.Get(idCliente) == null)
            {
                throw new Exception($"Cliente {idCliente} non trovato");
            }

            var coincidenze = prenotazioneService.Get(dataPrenotazione);
            var occupato = coincidenze.Any(c => c.IdTavolo == idTavolo);

            if (occupato)
            {
                throw new Exception($"Tavolo {idTavolo} non disponibile per {dataPrenotazione.ToShortDateString}");
            }

            var esito = prenotazioneService.Create(idCliente, idTavolo, dataPrenotazione);
            if (esito)
            {
                return "Prenotazione inserita";
            }

            throw new Exception("Si è verificato un errore");
        }

        [HttpDelete]
        public string Remove(int id) //questa funzione rimuove una prenotazione
        {
            var esito = prenotazioneService.Delete(id);
            if (esito)
            {
                return "Prenotazione rimossa";
            }

            throw new Exception("Prenotazione non presente nel database");
        }
    }
}
