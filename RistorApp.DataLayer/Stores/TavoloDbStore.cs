using System;
using System.Collections.Generic;
using System.Linq;
using RistorApp.DataLayer.Models;
using RistorApp.DataLayer.Stores.Interfaces;

namespace RistorApp.DataLayer.Stores;

public class TavoloDbStore(RistoranteDbContext ristoranteDbContext) : ITavoloStore
{
    public List<Tavolo> Get()
    {
        return ristoranteDbContext.Tavoli.ToList(); 
    }
    
    public Tavolo Get(int id)
    {
        var tavoloTrovato = ristoranteDbContext.Tavoli.FirstOrDefault(tavolo => tavolo.Id == id);
        
        if (tavoloTrovato == null)
        {
            throw new IndexOutOfRangeException($"Tavolo con id {id} non trovato");
        }
        
        return tavoloTrovato;
    }
    
    public List<Tavolo> Get(List<Prenotazione> coincidenze, int postiRichiesti)
    {
        return [..Get().Where(t => t.NumeroPersone >= postiRichiesti
                                   && coincidenze.Any(p => p.IdTavolo == t.Id) == false)];
    }
    
    public bool Create(Tavolo tavoloDaAggiungere)
    {
        ristoranteDbContext.Tavoli.Add(tavoloDaAggiungere);
        
        ristoranteDbContext.SaveChanges();
        
        return true;
    }
    
    public bool Update(TavoloCreateModel nuovaVersione)
    {
        var tavoloDaModificare = ristoranteDbContext.Tavoli.FirstOrDefault(tavolo => tavolo.Id == nuovaVersione.Id);
        
        if (tavoloDaModificare == null)
        {
            throw new IndexOutOfRangeException($"Tavolo con id {nuovaVersione.Id} non trovato");
        }
        
        tavoloDaModificare.NumeroPersone = nuovaVersione.NumeroPersone;
        tavoloDaModificare.Posizione = nuovaVersione.Posizione;
        
        ristoranteDbContext.SaveChanges();
        
        return true;
    }
    
    public bool Delete(int id)
    {
        var tavoloDaEliminare = ristoranteDbContext.Tavoli.FirstOrDefault(tavolo => tavolo.Id == id);
        
        if (tavoloDaEliminare == null)
        {
            throw new IndexOutOfRangeException($"Tavolo con id {id} non trovato");
        }
        
        ristoranteDbContext.Tavoli.Remove(tavoloDaEliminare);
        
        ristoranteDbContext.SaveChanges();
        
        return true;
    }
}