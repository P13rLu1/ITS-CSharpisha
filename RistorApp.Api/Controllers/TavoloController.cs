using Microsoft.AspNetCore.Mvc;
using RistorApp.DataLayer.Models;
using RistorApp.DataLayer.Services;

namespace RistorApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TavoloController(TavoloService tavoloService) : ControllerBase
    {
        [HttpGet] 
        public IEnumerable<Tavolo> Get() //questa funzione restituisce tutti i tavoli
        {
            return tavoloService.Get();
        }

        [HttpPost]
        public string Insert(int numeroPersone, string posizione) //questa funzione inserisce un nuovo tavolo
        {
            var esito = tavoloService.Create(numeroPersone, posizione);
            if (esito)
            {
                return "Tavolo inserito";
            }

            throw new Exception("Si è verificato un errore");
        }

        [HttpDelete]
        public string Remove(int id) //questa funzione rimuove un tavolo
        {
            var esito = tavoloService.Delete(id);
            if (esito)
            {
                return "Cliente rimosso";
            }

            throw new Exception("Tavolo non presente nel database");
        }
    }
}