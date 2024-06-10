using System;
using BigliettApp.DataLayer.Models;
using BigliettApp.DataLayer.Services;

namespace BigliettApp.ConsoleApp.Controllers
{
    internal class SpettacoloController
    {
        private SpettacoloService _tavoloService;

        public SpettacoloController(SpettacoloService tavoloService)
        {
            _tavoloService = tavoloService;
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

                switch (scelta)
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

        private void Aggiungi()
        {
            Console.Write("Inserisci il titolo dello spettacolo: ");
            var titolo = Console.ReadLine() ?? "";
            
            Console.Write("Inserisci la descrizione dello spettacolo: ");
            var descrizione = Console.ReadLine() ?? "";
            
            Console.Write("Inserisci la data dello spettacolo: ");
            var data = Console.ReadLine() ?? "";
            
            Console.Write("Inserisci la durata dello spettacolo: ");
            var durata = Console.ReadLine() ?? "";
            
            Console.Write("Inserisci il prezzo base dello spettacolo: ");
            var prezzoBase = Console.ReadLine() ?? "";

            SpettacoloCreateModel nuovoTavolo = new(titolo, descrizione, DateTime.Parse(data), int.Parse(durata), decimal.Parse(prezzoBase));
            var esito = _tavoloService.Create(nuovoTavolo);

            if (esito)
            {
                Console.WriteLine("Aggiunto nuovo tavolo con successo!");
            }
        }

        private void Modifica()
        {
            try
            {
                Console.Write("Inserire ID tavolo: ");
                var id = int.Parse(Console.ReadLine() ?? "");
                Spettacolo vecchiaVersione = _tavoloService.Get(id);

                SpettacoloCreateModel nuovaVersione = new(vecchiaVersione.Titolo,
                    vecchiaVersione.Descrizione,
                    vecchiaVersione.DataOra,
                    vecchiaVersione.Durata,
                    vecchiaVersione.PrezzoBase);

                nuovaVersione.Id = vecchiaVersione.Id;

                string scelta;
                do
                {
                    Console.Write("[1] Titolo | ");
                    Console.Write("[2] Descrizione | ");
                    Console.Write("[3] DataOra | ");
                    Console.Write("[4] Durata | ");
                    Console.Write("[5] Prezzo Base | ");
                    Console.WriteLine("[q] Torna indietro");

                    scelta = Console.ReadLine() ?? "";

                    switch (scelta)
                    {
                        case "1":
                            Console.Write("Inserire nuovo titolo: ");
                            nuovaVersione.Titolo = Console.ReadLine() ?? "";
                            break;
                        case "2":
                            Console.Write("Inserire nuova descrizione: ");
                            nuovaVersione.Descrizione = Console.ReadLine() ?? "";
                            break;
                        case "3":
                            Console.Write("Inserire nuova data: ");
                            nuovaVersione.DataOra = DateTime.Parse(Console.ReadLine() ?? "");
                            break;
                        case "4":
                            Console.Write("Inserire nuova durata: ");
                            nuovaVersione.Durata = int.Parse(Console.ReadLine() ?? "");
                            break;
                        case "5":
                            Console.Write("Inserire nuovo prezzo base: ");
                            nuovaVersione.PrezzoBase = decimal.Parse(Console.ReadLine() ?? "");
                            break;
                        default:
                            if (scelta != "q")
                            {
                                Console.WriteLine("Operazione annullata");
                            }
                            break;
                    }

                    _tavoloService.Update(nuovaVersione);
                } while (scelta != "q");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Elimina()
        {
            Console.Write("Inserire ID tavolo: ");
            var output = int.Parse(Console.ReadLine() ?? "");

            try
            {
                bool esito = _tavoloService.Delete(output);

                if (esito)
                {
                    Console.WriteLine("Tavolo rimosso con successo!");
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Visualizza()
        {
            var tavoli = _tavoloService.Get();

            foreach (var tavolo in tavoli)
            {
                Console.WriteLine(
                    $"ID: {tavolo.Id} | Titolo: {tavolo.Titolo} | Descrizione: {tavolo.Descrizione} | DataOra: {tavolo.DataOra} | Durata: {tavolo.Durata} | PrezzoBase: {tavolo.PrezzoBase}");
            }
        }
    }
}
