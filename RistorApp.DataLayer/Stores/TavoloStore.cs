using RistorApp.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RistorApp.DataLayer.Stores
{
    public class TavoloStore
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

        public Tavolo? Get(int id)
        {
            return _tavoli.FirstOrDefault(tavolo => tavolo.Id == id);
        }

        public bool Create(Tavolo tavoloDaAggiungere)
        {
            _tavoli.Add(tavoloDaAggiungere);
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