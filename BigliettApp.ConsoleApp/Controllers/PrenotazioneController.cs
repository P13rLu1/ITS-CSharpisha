using System;
using BigliettApp.DataLayer.Models;
using BigliettApp.DataLayer.Services;

namespace BigliettApp.ConsoleApp.Controllers
{
    internal class PrenotazioneController
    {
        private PrenotazioneService _prenotazioneService;

        public PrenotazioneController(PrenotazioneService prenotazioneService) 
        {
            _prenotazioneService = prenotazioneService;
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
                        Visualliza();
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

        private void Aggiungi()
        {
            Console.Write("Inserire ID cliente: ");
            var idCliente = Console.ReadLine() ?? "";
            
            Console.Write("Inserire idSpettacolo: ");
            var idSpettacolo = Console.ReadLine() ?? "";
            
            Console.Write("Inserire posto desiderati: ");
            var postiDesiderati = Console.ReadLine() ?? "";
            
            Console.Write("Inserire data prenotazione: ");
            var dataPrenotazione = Console.ReadLine() ?? "";
            
            Console.Write("Inserire prezzo finale: ");
            var prezzoFinale = Console.ReadLine() ?? "";

            try
            {
                PrenotazioneCreateModel nuovaPrenotazione = new();
                nuovaPrenotazione.IdCliente = int.Parse(idCliente);
                nuovaPrenotazione.IdSpettacolo = int.Parse(idSpettacolo);
                nuovaPrenotazione.Posto = postiDesiderati;
                nuovaPrenotazione.DataOra = DateTime.Parse(dataPrenotazione);
                nuovaPrenotazione.PrezzoFinale = decimal.Parse(prezzoFinale);
                bool esito = _prenotazioneService.Create(nuovaPrenotazione);

                if (esito)
                {
                    Console.WriteLine("Prenotazione effettuata con successo!");
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Modifica()
        {
            try
            {
                Console.Write("Inserire ID prenotazione: ");
                int id = int.Parse(Console.ReadLine() ?? "");
                
                Prenotazione vecchiaVersione = _prenotazioneService.Get(id);

                PrenotazioneCreateModel nuovaVersione = new();
                nuovaVersione.IdCliente = vecchiaVersione.IdCliente;
                nuovaVersione.IdSpettacolo = vecchiaVersione.IdSpettacolo;
                nuovaVersione.Posto = vecchiaVersione.Posto;
                nuovaVersione.DataOra = vecchiaVersione.DataOra;
                nuovaVersione.PrezzoFinale = vecchiaVersione.PrezzoFinale;

                string scelta;
                do
                {
                    Console.Write("[1] ID Cliente | ");
                    Console.Write("[2] ID Spettacolo | ");
                    Console.Write("[3] Posto | ");
                    Console.Write("[4] DataOra | ");
                    Console.Write("[5] PRezzo Finale | ");
                    Console.WriteLine("[q] Torna indietro");

                    scelta = Console.ReadLine() ?? "";

                    switch (scelta)
                    {
                        case "1":
                            Console.Write("Inserire nuovo ID cliente: ");
                            nuovaVersione.IdCliente = int.Parse(Console.ReadLine() ?? "");
                            break;
                        case "2":
                            Console.Write("Inserire nuovo ID spettacolo: ");
                            nuovaVersione.IdSpettacolo = int.Parse(Console.ReadLine() ?? "");
                            break;
                        case "3":
                            Console.Write("Inserire nuovo posto: ");
                            nuovaVersione.Posto = Console.ReadLine() ?? "";
                            break;
                        case "4":
                            Console.Write("Inserire nuova data: ");
                            nuovaVersione.DataOra = DateTime.Parse(Console.ReadLine() ?? "");
                            break;
                        case "5":
                            Console.Write("Inserire nuovo prezzo finale: ");
                            nuovaVersione.PrezzoFinale = decimal.Parse(Console.ReadLine() ?? "");
                            break;
                        default:
                            if (scelta != "q")
                            {
                                Console.WriteLine("Operazione annullata");
                            }
                            break;
                    }

                    _prenotazioneService.Update(nuovaVersione);
                } while (scelta != "q");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Elimina()
        {
            Console.Write("Inserire ID prenotazione: ");
            int scelta = int.Parse(Console.ReadLine() ?? "");

            _prenotazioneService.Delete(scelta);
        }

        private void Visualliza()
        {
            foreach (Prenotazione prenotazione in _prenotazioneService.Get())
            {
                Console.WriteLine(prenotazione);
            }
        }
    }
}
