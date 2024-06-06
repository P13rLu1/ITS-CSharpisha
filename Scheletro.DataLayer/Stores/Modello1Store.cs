using System;
using System.Collections.Generic;
using System.Linq;
using Scheletro.DataLayer.Models;

namespace Scheletro.DataLayer.Stores;

public class Modello1Store
{
    private List<Modello1> _modelli =
    [
        new Modello1(9, "Ciao", "Mondo"),
        new Modello1(10, "Hello", "World"),
        new Modello1(11, "Bonjour", "Monde"),
    ];
    
    public List<Modello1> Get()
    {
        return _modelli;
    }
    
    public Modello1? Get(int qualcosaDaCercare)
    {
        return _modelli.FirstOrDefault(modello => modello.Qualcosa == qualcosaDaCercare);
    }
    
    public bool Create(Modello1 modelloDaAggiungere)
    {
        _modelli.Add(modelloDaAggiungere);
        return true;
    }
    
    public bool Update(Modello1 modelloDaModificare)
    {
        var nuovaLista = new List<Modello1>();
        foreach (var modello in _modelli)
        {
            nuovaLista.Add(modello.Qualcosa == modelloDaModificare.Qualcosa ? modelloDaModificare : modello);
        }
        _modelli = nuovaLista;
        return true;
    }
    
    public bool Delete(int qualcosaDaCercare)
    {
        var modelloDaRimuovere = Get(qualcosaDaCercare);
        if (modelloDaRimuovere == null)
        {
            throw new Exception($"Modello con qualcosa {qualcosaDaCercare} non trovato");
        }
        return _modelli.Remove(modelloDaRimuovere);
    }
}