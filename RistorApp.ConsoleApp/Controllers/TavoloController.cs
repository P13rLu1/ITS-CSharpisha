using RistorApp.DataLayer.Services;
using System;
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
            Console.WriteLine("Menu per la gestione dei tavoli...");
            // ...

            Visualizza();
        }

        private void Visualizza()
        {
            // ...

            foreach (var tavolo in _tavoloService.Get())
            {
                Console.WriteLine($"[{tavolo.Id}] {tavolo.Posizione} per {tavolo.NumeroPersone} persone");
            }
        }
    }
}