using System; 

namespace RistorApp.ConsoleApp.Controllers
{
    internal class MenuController
    {
        private ClienteController _clienteController;
        private TavoloController _tavoloController;
        private PrenotazioneController _prenotazioneController;

        public MenuController(
            ClienteController clienteController, 
            TavoloController tavoloController,
            PrenotazioneController prenotazioneController
        ) 
        {
            _clienteController = clienteController;
            _tavoloController = tavoloController;
            _prenotazioneController = prenotazioneController;
        }

        public void Menu()
        {
            string scelta;

            do
            {
                Console.Write("[1] Gestisci clienti | ");
                Console.Write("[2] Gestisci tavoli | ");
                Console.Write("[3] Gestisci prenotazioni | ");
                Console.WriteLine("[q] Esci da programma");

                scelta = Console.ReadLine()?.ToLower() ?? "";

                switch (scelta)
                {
                    case "1":
                        _clienteController.Menu();
                        break;
                    case "2":
                        _tavoloController.Menu();
                        break;
                    case "3":
                        _prenotazioneController.Menu();
                        break;
                    default:
                        if (scelta != "q")
                        {
                            Console.WriteLine("Scelta non valida");
                        }
                        break;
                }
            } while (scelta != "q");
        }
    }
}