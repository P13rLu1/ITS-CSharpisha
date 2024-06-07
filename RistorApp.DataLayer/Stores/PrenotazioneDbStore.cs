using System;
using System.Collections.Generic;
using System.Linq;
using RistorApp.DataLayer.Models;
using RistorApp.DataLayer.Stores.Interfaces;

namespace RistorApp.DataLayer.Stores;

public class PrenotazioneDbStore(RistoranteDbContext ristoranteDbContext) : IPrenotazioneStore
{
    public List<Prenotazione> Get()
    {
        return ristoranteDbContext.Prenotazioni.ToList();
    }
    
    public Prenotazione Get(int id)
    {
        var prenotazioneTrovata = ristoranteDbContext.Prenotazioni.FirstOrDefault(prenotazione => prenotazione.Id == id);
        
        if (prenotazioneTrovata == null)
        {
            throw new IndexOutOfRangeException($"Prenotazione con id {id} non trovato");
        }
        
        return prenotazioneTrovata;
    }
    
    public bool Create(Prenotazione prenotazioneDaAggiungere)
    {
        ristoranteDbContext.Prenotazioni.Add(prenotazioneDaAggiungere);
        
        ristoranteDbContext.SaveChanges();
        
        return true;
    }
    
    public bool Update(PrenotazioneCreateModel nuovaVersione)
    {
        var vecchiaVersione = Get(nuovaVersione.Id);
        
        vecchiaVersione.IdTavolo = nuovaVersione.IdTavolo;
        vecchiaVersione.IdCliente = nuovaVersione.IdCliente;
        
        ristoranteDbContext.SaveChanges();
        
        return true;
    }
    
    public bool Delete(int id)
    {
        var prenotazioneDaRimuovere = Get(id);
        
        ristoranteDbContext.Prenotazioni.Remove(prenotazioneDaRimuovere);
        
        ristoranteDbContext.SaveChanges();
        
        return true;
    }
}