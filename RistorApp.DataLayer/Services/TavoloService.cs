using RistorApp.DataLayer.Models;
using RistorApp.DataLayer.Stores;
using System.Collections.Generic;

namespace RistorApp.DataLayer.Services
{
    public class TavoloService(TavoloStore tavoloStore)
    {
        public List<Tavolo> Get()
        {
            return tavoloStore.Get();
        }

        public bool Create(TavoloCreateModel tavoloDaInserire)
        {
            var tavoloDaAggiungere = new Tavolo(tavoloDaInserire.NumeroPersone, tavoloDaInserire.Posizione);
            tavoloStore.Create(tavoloDaAggiungere);
            return true;
        }

        public bool Delete(int id)
        {
            return tavoloStore.Delete(id);
        }
    }
}