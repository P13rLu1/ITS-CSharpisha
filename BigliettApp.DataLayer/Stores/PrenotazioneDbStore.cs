using BigliettApp.DataLayer.Models;
using BigliettApp.DataLayer.Stores.Interfaces;

namespace BigliettApp.DataLayer.Stores;

public class PrenotazioneDbStore(BiglietteriaDbContext biglietteriaDbContext) : IPrenotazioneStore
{
    public List<Prenotazione> Get()
    {
        return biglietteriaDbContext.Prenotazioni.ToList();
    }
    
    public Prenotazione Get(int id)
    {
        var prenotazioneTrovata = biglietteriaDbContext.Prenotazioni.FirstOrDefault(prenotazione => prenotazione.Id == id);
        
        if (prenotazioneTrovata == null)
        {
            throw new IndexOutOfRangeException($"Prenotazione con id {id} non trovato");
        }
        
        return prenotazioneTrovata;
    }
    
    public bool Create(Prenotazione prenotazioneDaAggiungere)
    {
        biglietteriaDbContext.Prenotazioni.Add(prenotazioneDaAggiungere);
        
        biglietteriaDbContext.SaveChanges();
        
        return true;
    }
    
    public bool Update(PrenotazioneCreateModel nuovaVersione)
    {
        var vecchiaVersione = Get(nuovaVersione.Id);
        
        vecchiaVersione.IdSpettacolo = nuovaVersione.IdSpettacolo;
        vecchiaVersione.IdCliente = nuovaVersione.IdCliente;
        vecchiaVersione.DataOra = nuovaVersione.DataOra;
        vecchiaVersione.Posto = nuovaVersione.Posto;
        vecchiaVersione.PrezzoFinale = nuovaVersione.PrezzoFinale;
        
        biglietteriaDbContext.SaveChanges();
        
        return true;
    }
    
    public bool Delete(int id)
    {
        var prenotazioneDaRimuovere = Get(id);
        
        biglietteriaDbContext.Prenotazioni.Remove(prenotazioneDaRimuovere);
        
        biglietteriaDbContext.SaveChanges();
        
        return true;
    }
}