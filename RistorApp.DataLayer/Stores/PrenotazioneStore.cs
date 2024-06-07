using RistorApp.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using RistorApp.DataLayer.Stores.Interfaces;

namespace RistorApp.DataLayer.Stores
{
    public class PrenotazioneStore : IPrenotazioneStore
    {
        private readonly List<Prenotazione> _store =
        [
            // new Prenotazione(1, 3, DateTime.Parse("2024/6/7")),
            // new Prenotazione(2, 7, DateTime.Parse("2024/6/7")),
            // new Prenotazione(3, 3, DateTime.Parse("2024/6/10")),
        ];

        public List<Prenotazione> Get()
        {
            return _store;
        }

        public Prenotazione Get(int id)
        {
            var prenotazioneTrovata = Get().FirstOrDefault(p => p.Id == id);
            
            if (prenotazioneTrovata == null)
            {
                throw new Exception($"Prenotazione con id {id} non trovato");
            }
            
            return prenotazioneTrovata;
        }

        public bool Create(Prenotazione prenotazioneDaAggiungere)
        {
            _store.Add(prenotazioneDaAggiungere);
            
            return true;
        }
        
        public bool Update(PrenotazioneCreateModel nuovaVersione)
        {
            var vecchiaVersione = Get(nuovaVersione.Id);

            vecchiaVersione.IdTavolo = nuovaVersione.IdTavolo;
            vecchiaVersione.IdCliente = nuovaVersione.IdCliente;

            return true;
        }

        public bool Delete(int id)
        {
            var prenotazioneDaRimuovere = Get(id);

            _store.Remove(prenotazioneDaRimuovere);
            return true;
        }
    }
}