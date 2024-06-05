using RistorApp.DataLayer.Models;
using RistorApp.DataLayer.Stores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RistorApp.DataLayer.Services
{
    public class PrenotazioneService(PrenotazioneStore prenotazioneStore)
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
            var prenotazioneTrovata = prenotazioneStore.Get(id);
            if (prenotazioneTrovata == null)
            {
                throw new Exception($"Prenotazione con id {id} non trovata");
            }
            return prenotazioneTrovata;
        }

        public bool Create(int idCliente, int idTavolo, DateTime dataPrenotazione)
        {
            var prenotazioneDaAggiungere = new Prenotazione(idCliente, idTavolo, dataPrenotazione);
            prenotazioneStore.Create(prenotazioneDaAggiungere);
            return true;
        }

        public bool Delete(int id)
        { 
            return prenotazioneStore.Delete(id);
        }
    }
}