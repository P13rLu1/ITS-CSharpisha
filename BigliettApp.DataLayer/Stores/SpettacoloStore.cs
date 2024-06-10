using BigliettApp.DataLayer.Models;
using BigliettApp.DataLayer.Stores.Interfaces;

namespace BigliettApp.DataLayer.Stores
{
    public class SpettacoloStore  : ISpettacoloStore
    {
        private readonly List<Spettacolo> _spettacoli =
        [
            new Spettacolo("Il Signore degli Anelli", "Fantasy", DateTime.Parse("10/06/2024"), 288, 15),
            new Spettacolo("Harry Potter", "Fantasy", DateTime.Parse("10/06/2024"), 288, 15),
            new Spettacolo("Il Padrino", "Drammatico", DateTime.Parse("10/06/2024"), 288, 15)
        ];

        public List<Spettacolo> Get()
        {
            return _spettacoli;
        }

        public Spettacolo Get(int id)
        {
            return _spettacoli.FirstOrDefault(spettacolo => spettacolo.Id == id) ?? throw new Exception($"Spettacolo con id {id} non trovato");
        }

        public bool Create(Spettacolo spettacoloDaAggiungere)
        {
            _spettacoli.Add(spettacoloDaAggiungere);
            return true;
        }
        
        public bool Update(SpettacoloCreateModel nuovaVersione)
        {
            var vecchiaVersione = Get(nuovaVersione.Id);
            
            if (vecchiaVersione == null)
            {
                throw new Exception($"Spettacolo con id {nuovaVersione.Id} non trovato");
            }
            
            vecchiaVersione.Titolo = nuovaVersione.Titolo;
            vecchiaVersione.Descrizione = nuovaVersione.Descrizione;
            vecchiaVersione.DataOra = nuovaVersione.DataOra;
            vecchiaVersione.Durata = nuovaVersione.Durata;
            vecchiaVersione.PrezzoBase = nuovaVersione.PrezzoBase;

            return true;
        }

        public bool Delete(int id)
        {
            var spettacoloDaRimuovere = Get(id);
            if (spettacoloDaRimuovere == null)
            {
                throw new Exception($"Spettacolo con id {id} non trovato");
            }
            return _spettacoli.Remove(spettacoloDaRimuovere);
        }
    }
}