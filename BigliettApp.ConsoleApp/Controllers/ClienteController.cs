using System;
using BigliettApp.DataLayer.Models;
using BigliettApp.DataLayer.Services;

namespace BigliettApp.ConsoleApp.Controllers
{
    internal abstract class ClienteController
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService) 
        {
            _clienteService = clienteService;
        }

        public void Menu()
        {
            string scelta;

            do
            {
                Console.Write("[1] Aggiungi | ");
                Console.Write("[2] Modifica | ");
                Console.Write("[3] Elimina | ");
                Console.Write("[4] Visualizza | ");
                Console.WriteLine("[q] Torna indietro");

                scelta = Console.ReadLine()?.ToLower() ?? "";

                switch(scelta)
                {
                    case "1":
                        Aggiungi();
                        break;
                    case "2":
                        Modifica();
                        break;
                    case "3":
                        Elimina();
                        break;
                    case "4":
                        Visualizza();
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

        public void Aggiungi()
        {
            Console.Write("Inserire nome: ");
            var nome = Console.ReadLine() ?? "";
            Console.Write("Inserire cognome: ");
            var cognome = Console.ReadLine() ?? "";
            Console.Write("Inserire email: ");
            var email = Console.ReadLine() ?? "";
            Console.Write("Inserire telefono: ");
            var telefono = Console.ReadLine() ?? "";
            

            ClienteCreateModel nuovoCliente = new(nome, cognome, email, telefono);
            var esito = _clienteService.Create(nuovoCliente);

            if (esito)
            {
                Console.WriteLine("Aggiunto nuovo cliente con successo!");
            }
        }

        private void Modifica()
        {
            try
            {
                Console.Write("Inserire ID cliente:");
                var id = Console.ReadLine() ?? "";
                Cliente vecchiaVersione = _clienteService.Get(int.Parse(id));

                ClienteCreateModel nuovaVersione = new(
                    vecchiaVersione.Nome,
                    vecchiaVersione.Cognome,
                    vecchiaVersione.Email,
                    vecchiaVersione.Telefono
                    );

                nuovaVersione.Id = vecchiaVersione.Id;

                string scelta;
                do
                {
                    Console.Write("[1] Nome | ");
                    Console.Write("[2] Cognome | ");
                    Console.Write("[3] Email | ");
                    Console.Write("[4] Telefono | ");
                    Console.WriteLine("[q] Torna indietro");

                    scelta = Console.ReadLine() ?? "";

                    switch (scelta)
                    {
                        case "1":
                            Console.Write("Inserire nuovo nome: ");
                            nuovaVersione.Nome = Console.ReadLine() ?? "";
                            break;
                        case "2":
                            Console.Write("Inserire nuovo cognome: ");
                            nuovaVersione.Cognome = Console.ReadLine() ?? "";
                            break;
                        case "3":
                            Console.Write("Inserire nuova email: ");
                            nuovaVersione.Email = Console.ReadLine() ?? "";
                            break;
                        case "4":
                            Console.Write("Inserire nuovo telefono: ");
                            nuovaVersione.Telefono = Console.ReadLine() ?? "";
                            break;
                        default:
                            if (scelta != "q")
                            {
                                Console.WriteLine("Operazione annullata");
                            }
                            break;
                    }

                    _clienteService.Update(nuovaVersione);
                } while (scelta != "q");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Elimina()
        {
            Console.Write("Inserire ID cliente:");
            var id = Console.ReadLine() ?? "";

            try
            {
                bool esito = _clienteService.Delete(int.Parse(id));

                if (esito)
                {
                    Console.WriteLine("Cliente rimosso con successo!");
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Visualizza()
        {
            var listaClienti = _clienteService.Get();
            foreach (var cliente in listaClienti)
            {
                Console.WriteLine(cliente);
            }
        }
    }
}