using System.Collections.Generic;
using System.Linq;
using AziendaAlberghieraVernazza.Models;
using AziendaAlberghieraVernazza.Stores.Interfaces;

namespace AziendaAlberghieraVernazza.Stores;

public class PrenotazioneStore : IStore<Prenotazione>
{
    private readonly List<Prenotazione> _prenotazioni = [];
    
    public List<Prenotazione> Get()
    {
        return _prenotazioni;
    }
    
    public Prenotazione? Get(int id)
    {
        return _prenotazioni.FirstOrDefault(prenotazione => prenotazione.Id == id);
    }
    
    public bool Aggiungi(Prenotazione prenotazione)
    {
        _prenotazioni.Add(prenotazione);
        return true;
    }
    
    public bool Cancella(int id)
    {
        var daEliminare = _prenotazioni.FirstOrDefault(prenotazione => prenotazione.Id == id);
        return daEliminare != null && _prenotazioni.Remove(daEliminare);
    }
}