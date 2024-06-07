using RistorApp.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using RistorApp.DataLayer.Stores.Interfaces;

namespace RistorApp.DataLayer.Services
{
    public class PrenotazioneService(
        IPrenotazioneStore prenotazioneStore,
        ClienteService clienteService,
        TavoloService tavoloService)
    {
        public List<Prenotazione> Get()
        {
            return prenotazioneStore.Get();
        }
        
        public List<Prenotazione> Get(DateTime dataPrenotazione)
        {
            return prenotazioneStore.Get().Where(p => p.Data.Date == dataPrenotazione.Date).ToList();
        }

        public Prenotazione Get(int id)
        {
            return prenotazioneStore.Get(id);
        }

        public bool Create(PrenotazioneCreateModel payload)
        {
            clienteService.Get(payload.IdCliente); // Force throw when needed

            List<Prenotazione> coincidenze = Get(payload.Data);
            List<Tavolo> disponibili = [..tavoloService.Get(coincidenze, payload.PostiDesiderati)
                .OrderBy(t => t.NumeroPersone)];

            if (disponibili.Count < 1)
            {
                throw new Exception($"Nessun tavolo disponibile da {payload.PostiDesiderati} posti in data {payload.Data.ToShortDateString()}");
            }

            Prenotazione prenotazioneDaAggiungere = new Prenotazione() {
                IdCliente = payload.IdCliente,
                IdTavolo = disponibili.First().Id,
                Data = payload.Data
            };
            
            return prenotazioneStore.Create(prenotazioneDaAggiungere);
        }

        public bool Update(PrenotazioneCreateModel nuovaVersione)
        {
            return prenotazioneStore.Update(nuovaVersione);
        }

        public bool Delete(int id)
        { 
            return prenotazioneStore.Delete(id);
        }
    }
}