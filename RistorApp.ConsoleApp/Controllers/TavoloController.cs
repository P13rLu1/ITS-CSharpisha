﻿using RistorApp.DataLayer.Services;
using RistorApp.ConsoleApp.Utilities;
using System;
using RistorApp.DataLayer.Models;

namespace RistorApp.ConsoleApp.Controllers
{
    internal class TavoloController
    {
        private TavoloService _tavoloService;

        public TavoloController(TavoloService tavoloService)
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
            var numeroPersone = ReadUtility.Intero("Inserire numero persone: ");
            Console.Write("Inserire posizione: ");
            var posizione = Console.ReadLine() ?? "";

            TavoloCreateModel nuovoTavolo = new(numeroPersone, posizione);
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
                int id = ReadUtility.Intero("Inserire ID tavolo: ");
                Tavolo vecchiaVersione = _tavoloService.Get(id);

                TavoloCreateModel nuovaVersione = new(
                    vecchiaVersione.NumeroPersone,
                    vecchiaVersione.Posizione
                    );

                nuovaVersione.Id = vecchiaVersione.Id;

                string scelta;
                do
                {
                    Console.Write("[1] Numero persone | ");
                    Console.Write("[2] Posizione | ");
                    Console.WriteLine("[q] Torna indietro");

                    scelta = Console.ReadLine() ?? "";

                    switch (scelta)
                    {
                        case "1":
                            nuovaVersione.NumeroPersone = ReadUtility.Intero("Inserire nuovo numero persone: ");
                            break;
                        case "2":
                            Console.Write("Inserire nuova posizione: ");
                            nuovaVersione.Posizione = Console.ReadLine() ?? "";
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
            int output = ReadUtility.Intero("Inserire ID tavolo: ", true);

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
                Console.WriteLine($"ID: {tavolo.Id} | Persone: {tavolo.NumeroPersone} | Posizione: {tavolo.Posizione}");
            }
        }
    }
}
