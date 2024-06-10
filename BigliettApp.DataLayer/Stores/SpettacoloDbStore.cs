using BigliettApp.DataLayer.Models;
using BigliettApp.DataLayer.Stores.Interfaces;

namespace BigliettApp.DataLayer.Stores;

public class SpettacoloDbStore(BiglietteriaDbContext biglietteriaDbContext) : ISpettacoloStore
{
    public List<Spettacolo> Get()
    {
        return biglietteriaDbContext.Spettacoli.ToList(); 
    }
    
    public Spettacolo Get(int id)
    {
        var spettacoloTrovato = biglietteriaDbContext.Spettacoli.FirstOrDefault(tavolo => tavolo.Id == id);
        
        if (spettacoloTrovato == null)
        {
            throw new IndexOutOfRangeException($"Spettacolo con id {id} non trovato");
        }
        
        return spettacoloTrovato;
    }
    
    public bool Create(Spettacolo tavoloDaAggiungere)
    {
        biglietteriaDbContext.Spettacoli.Add(tavoloDaAggiungere);
        
        biglietteriaDbContext.SaveChanges();
        
        return true;
    }
    
    public bool Update(SpettacoloCreateModel nuovaVersione)
    {
        var spettacoloDaModificare = biglietteriaDbContext.Spettacoli.FirstOrDefault(tavolo => tavolo.Id == nuovaVersione.Id);
        
        if (spettacoloDaModificare == null)
        {
            throw new IndexOutOfRangeException($"Spettacolo con id {nuovaVersione.Id} non trovato");
        }
        
        spettacoloDaModificare.Titolo = nuovaVersione.Titolo;
        spettacoloDaModificare.Descrizione = nuovaVersione.Descrizione;
        spettacoloDaModificare.DataOra = nuovaVersione.DataOra;
        spettacoloDaModificare.Durata = nuovaVersione.Durata;
        spettacoloDaModificare.PrezzoBase = nuovaVersione.PrezzoBase;
        
        biglietteriaDbContext.SaveChanges();
        
        return true;
    }
    
    public bool Delete(int id)
    {
        var spettacoloDaEliminare = biglietteriaDbContext.Spettacoli.FirstOrDefault(tavolo => tavolo.Id == id);
        
        if (spettacoloDaEliminare == null)
        {
            throw new IndexOutOfRangeException($"Spettacolo con id {id} non trovato");
        }
        
        biglietteriaDbContext.Spettacoli.Remove(spettacoloDaEliminare);
        
        biglietteriaDbContext.SaveChanges();
        
        return true;
    }
}