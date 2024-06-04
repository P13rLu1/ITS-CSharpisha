using System;
using System.Collections.Generic;
using System.Linq;
using AziendaAlberghieraVernazza.Models;
using AziendaAlberghieraVernazza.Stores.Interfaces;

namespace AziendaAlberghieraVernazza.Stores;

public class CameraStore(List<Prenotazione> prenotazioni) : IStore<Camera>
{
    private readonly List<Camera> _camere = [];

    public List<Camera> Get()
    {
        return _camere;
    }
    
    public Camera? Get(int id)
    {
        return _camere.FirstOrDefault(camera => camera.Id == id);
    }
    
    public bool Aggiungi(Camera camera)
    {
        _camere.Add(camera);
        return true;
    }
    
    public bool CameraOccupata(int idCamera, DateOnly dataArrivo, DateOnly dataPartenza)
    {
        return prenotazioni.Any(p => p.IdCamera == idCamera && 
                                      p.DataArrivo < dataPartenza && 
                                      p.DataPartenza > dataArrivo);
    }
    
    public bool Cancella(int id)
    {
        var daEliminare = _camere.FirstOrDefault(camera => camera.Id == id);
        return daEliminare != null && _camere.Remove(daEliminare);
    }
}