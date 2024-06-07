using RistorApp.DataLayer.Services;
using RistorApp.ConsoleApp.Utilities;
using System;
using RistorApp.DataLayer.Models;

namespace RistorApp.ConsoleApp.Controllers
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
            int idCliente = ReadUtility.Intero("Inserire ID cliente: ");
            int postiDesiderati = ReadUtility.Intero("Inserire numero posti: ");
            DateTime dataPrenotazione = ReadUtility.Data("Inserire data prenotazione (YYYY/MM/DD): ");

            try
            {
                PrenotazioneCreateModel nuovaPrenotazione = new();
                nuovaPrenotazione.IdCliente = idCliente;
                nuovaPrenotazione.PostiDesiderati = postiDesiderati;
                nuovaPrenotazione.Data = dataPrenotazione;
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
                int id = ReadUtility.Intero("Inserire ID prenotazoine: ");
                Prenotazione vecchiaVersione = _prenotazioneService.Get(id);

                PrenotazioneCreateModel nuovaVersione = new();
                nuovaVersione.IdCliente = vecchiaVersione.IdCliente;
                nuovaVersione.IdTavolo = vecchiaVersione.IdTavolo;
                nuovaVersione.Data = vecchiaVersione.Data;
                nuovaVersione.Id = vecchiaVersione.Id;

                string scelta;
                do
                {
                    Console.Write("[1] ID tavolo | ");
                    Console.Write("[2] Data prenotazione | ");
                    Console.WriteLine("[q] Torna indietro");

                    scelta = Console.ReadLine() ?? "";

                    switch (scelta)
                    {
                        case "1":
                            nuovaVersione.IdTavolo = ReadUtility.Intero("Inserire nuovo ID tavolo: ");
                            break;
                        case "2":
                            nuovaVersione.Data = ReadUtility.Data("Inserire nuvoa data: ");
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
            int scelta = ReadUtility.Intero("Inserire ID prenotazione: ", true);

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
