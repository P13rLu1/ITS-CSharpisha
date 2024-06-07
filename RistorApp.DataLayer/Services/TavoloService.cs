using RistorApp.DataLayer.Models;
using System.Collections.Generic;
using RistorApp.DataLayer.Stores.Interfaces;

namespace RistorApp.DataLayer.Services
{
    public class TavoloService(ITavoloStore tavoloStore)
    {
        public List<Tavolo> Get()
        {
            return tavoloStore.Get();
        }

        public Tavolo Get(int id)
        {
            return tavoloStore.Get(id);
        }
        
        public List<Tavolo> Get(List<Prenotazione> coincidenze, int postiDesiderati)
        {
            return tavoloStore.Get(coincidenze, postiDesiderati);
        }

        public bool Create(TavoloCreateModel payload)
        {
            var tavoloDaAggiungere = new Tavolo(payload.NumeroPersone, payload.Posizione);

            return tavoloStore.Create(tavoloDaAggiungere);
        }

        public bool Update(TavoloCreateModel nuovaVersione)
        {
            return tavoloStore.Update(nuovaVersione);
        }

        public bool Delete(int id)
        {
            return tavoloStore.Delete(id);
        }
    }
}