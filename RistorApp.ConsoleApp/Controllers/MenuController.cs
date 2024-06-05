using System; 

namespace RistorApp.ConsoleApp.Controllers
{
    internal class MenuController
    {
        private ClienteController _clienteController;

        public MenuController(ClienteController clienteController) 
        {
            _clienteController = clienteController;
        }

        public void Menu()
        {
            Console.WriteLine("Benvenuto nella Console App del RistorApp");

            // ...

            _clienteController.Menu();
        }
    }
}