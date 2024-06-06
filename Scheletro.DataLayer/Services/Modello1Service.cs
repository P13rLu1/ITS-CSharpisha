using System;
using System.Collections.Generic;
using Scheletro.DataLayer.Models;
using Scheletro.DataLayer.Stores;

namespace Scheletro.DataLayer.Services;

public class Modello1Service(Modello1Store modello1Store)
{
    public List<Modello1> Get() // funzione che restituisce una lista di Modello1
    {
        return modello1Store.Get();
    }

    public Modello1 Get(int qualcosaDaPassare) // funzione che restituisce un Modello1
    {
        var modello1Trovato = modello1Store.Get(qualcosaDaPassare);
        if (modello1Trovato == null)
        {
            throw new Exception($"Modello1 con id {qualcosaDaPassare} non trovato");
        }
        return modello1Trovato;
    }

    public bool Create(Modello1CreateModel modello1DaCreare) // funzione che crea un Modello1
    {
        var modello1DaAggiungere = new Modello1(modello1DaCreare.Qualcosa, modello1DaCreare.Altro.ToUpper(),modello1DaCreare.Altro2.ToUpper());
        modello1Store.Create(modello1DaAggiungere);
        return true;
    }

    public bool Update(Modello1 modello1DaModificare) // funzione che modifica un Modello1
    {
        return modello1Store.Update(modello1DaModificare);
    }

    public bool Delete(int id) // funzione che elimina un Modello1
    { 
        return modello1Store.Delete(id);
    }
}