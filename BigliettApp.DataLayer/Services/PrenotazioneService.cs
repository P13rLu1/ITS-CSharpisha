using BigliettApp.DataLayer.Models;
using BigliettApp.DataLayer.Stores.Interfaces;

namespace BigliettApp.DataLayer.Services
{
    public class PrenotazioneService(IPrenotazioneStore prenotazioneStore)
    {

        public List<Prenotazione> Get()
        {
            return prenotazioneStore.Get();
        }
        
        public List<Prenotazione> Get(DateTime dataPrenotazione)
        {
            return prenotazioneStore.Get().Where(p => p.DataOra.Date == dataPrenotazione.Date).ToList();
        }

        public Prenotazione Get(int id)
        {
            return prenotazioneStore.Get(id);
        }

        // Gestire casistica di errore in cui uno spettacolo é sold out
        public bool Create(PrenotazioneCreateModel payload)
        {
            var prenotazioniPerSpettacolo = prenotazioneStore.Get()
                .Count(p => p.IdSpettacolo == payload.IdSpettacolo);

            // Se lo spettacolo ha più di 50 prenotazioni, restituisce false indicando "sold out"
            if (prenotazioniPerSpettacolo >= 50)
            {
                throw new ArgumentOutOfRangeException($" Lo spettacolo {payload.IdSpettacolo} è sold out");
            }

            // Se non è sold out, crea la prenotazione
            return prenotazioneStore.Create(new Prenotazione
            {
                IdCliente = payload.IdCliente,
                IdSpettacolo = payload.IdSpettacolo,
                Posto = payload.Posto,
                PrezzoFinale = payload.PrezzoFinale,
                DataOra = DateTime.Now
            });
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