using RistorApp.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq; 

namespace RistorApp.DataLayer.Stores
{
    public class PrenotazioneStore
    {
        private readonly List<Prenotazione> _prenotazioni =
        [
            new Prenotazione(1, 3, DateTime.Parse("2024/6/7")),
            new Prenotazione(2, 7, DateTime.Parse("2024/6/7")),
            new Prenotazione(3, 3, DateTime.Parse("2024/6/10")),
        ];

        public List<Prenotazione> Get()
        {
            return _prenotazioni;
        }

        public Prenotazione? Get(int id)
        {
            return _prenotazioni.FirstOrDefault(prenotazione => prenotazione.Id == id);
        }

        public bool Create(Prenotazione prenotazioneDaAggiungere)
        {
            _prenotazioni.Add(prenotazioneDaAggiungere);
            return true;
        }
        
        public bool Update(Prenotazione prenotazioneDaAggiornare)
        {
            var index = _prenotazioni.Where( p => p.Id == prenotazioneDaAggiornare.Id).Select((_, i) => i).FirstOrDefault();
            if (index >= 0)
            {
                _prenotazioni[index] = prenotazioneDaAggiornare;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var prenotazioneDaRimuovere = Get(id);
            if (prenotazioneDaRimuovere == null)
            {
                throw new Exception($"Prenotazione con id {id} non trovato");
            }
            return _prenotazioni.Remove(prenotazioneDaRimuovere); 
        }
    }
}