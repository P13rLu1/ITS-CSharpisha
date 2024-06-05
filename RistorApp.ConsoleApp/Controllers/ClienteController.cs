using RistorApp.DataLayer.Services;
using System; 

namespace RistorApp.ConsoleApp.Controllers
{
    internal class ClienteController
    {
        private ClienteService _clienteService;

        public ClienteController(ClienteService clienteService) 
        {
            _clienteService = clienteService;
        }

        public void Menu()
        {
            Console.WriteLine("Menu per la gestione dei clienti...");
            // ...

            Aggiungi();
        }

        private void Aggiungi()
        {
            // ...

            var nome = Console.ReadLine();
            var cognome = Console.ReadLine();
            var dataNascita = DateTime.Parse(Console.ReadLine()??"");

            // _clienteService.Create(nome, cognome, dataNascita);
        }
    }
}