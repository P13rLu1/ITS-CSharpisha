using RistorApp.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using RistorApp.DataLayer.Stores.Interfaces;

namespace RistorApp.DataLayer.Stores
{
    public class TavoloStore : ITavoloStore
    {
        private readonly List<Tavolo> _tavoli =
        [
            new Tavolo(4, "Nord"),
            new Tavolo(2, "Sud"),
            new Tavolo(6, "Est"),
            new Tavolo(1, "Ovest"),
            new Tavolo(8, "Ovest"),
            new Tavolo(4, "Sud"),
            new Tavolo(2, "Nord"),
            new Tavolo(6, "Est"),
        ];

        public List<Tavolo> Get()
        {
            return _tavoli;
        }

        public Tavolo Get(int id)
        {
            return _tavoli.FirstOrDefault(tavolo => tavolo.Id == id) ?? throw new Exception($"Tavolo con id {id} non trovato");
        }
        
        public List<Tavolo> Get(List<Prenotazione> coincidenze, int postiRichiesti)
        {
            return [..Get().Where(t => t.NumeroPersone >= postiRichiesti
                                       && coincidenze.Any(p => p.IdTavolo == t.Id) == false)];
        }

        public bool Create(Tavolo tavoloDaAggiungere)
        {
            _tavoli.Add(tavoloDaAggiungere);
            return true;
        }
        
        public bool Update(TavoloCreateModel nuovaVersione)
        {
            var vecchiaVersione = Get(nuovaVersione.Id);
            
            if (vecchiaVersione == null)
            {
                throw new Exception($"Tavolo con id {nuovaVersione.Id} non trovato");
            }
            
            vecchiaVersione.NumeroPersone = nuovaVersione.NumeroPersone;
            vecchiaVersione.Posizione = nuovaVersione.Posizione;

            return true;
        }

        public bool Delete(int id)
        {
            var tavoloDaRimuovere = Get(id);
            if (tavoloDaRimuovere == null)
            {
                throw new Exception($"Tavolo con id {id} non trovato");
            }
            return _tavoli.Remove(tavoloDaRimuovere);
        }
    }
}