using Microsoft.AspNetCore.Mvc;
using RistorApp.DataLayer.Models;
using RistorApp.DataLayer.Services;

namespace RistorApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController(ClienteService clienteService) : ControllerBase
    {
        [HttpGet] //questa funzione restituisce tutti i clienti
        public IEnumerable<Cliente> Get()
        {
            return clienteService.Get();
        }

        [HttpGet("{id}")] //questa funzione restituisce un cliente in base all'id
        public Cliente GetById([FromRoute] int id)
        {
            return clienteService.Get(id);
        } 

        [HttpPost]
        public string Insert(string nome, string cognome, DateTime dataNascita)
        {
            var esito = clienteService.Create(nome, cognome, dataNascita);
            if (esito)
            {
                return "Cliente inserito";
            }

            throw new Exception("Si è verificato un errore");
        }
        [HttpPut] 
        public string Update(Cliente clienteDaModificare) //questa funzione fa un update di un cliente esistente
        {
            var esito = clienteService.Update(clienteDaModificare);
            if (esito)
            {
                return "Cliente aggiornato";
            }

            throw new Exception("Si è verificato un errore");
        }

        [HttpDelete("{id}")]
        public string Remove(int id) //questa funzione rimuove un cliente in base all'id
        {
            var esito = clienteService.Delete(id);
            if (esito)
            {
                return "Cliente rimosso";
            }

            throw new Exception("Cliente non presente nel database");
        }
    }
}