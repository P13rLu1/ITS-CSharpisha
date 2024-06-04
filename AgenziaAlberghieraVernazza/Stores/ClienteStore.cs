using System.Collections.Generic;
using System.Linq;
using AziendaAlberghieraVernazza.Models;
using AziendaAlberghieraVernazza.Stores.Interfaces;

namespace AziendaAlberghieraVernazza.Stores;

public class ClienteStore : IStore<Cliente>
{
    private readonly List<Cliente> _clienti = new();
    
    public List<Cliente> Get()
    {
        return _clienti;
    }
    
    public Cliente? Get(string input)
    {
        return _clienti.FirstOrDefault(cliente => cliente.Nome == input || cliente.Cognome == input || cliente.Id.ToString() == input);
    }
    
    public bool Aggiungi(Cliente cliente)
    {
        _clienti.Add(cliente);
        return true;
    }
    
    public bool Cancella(int id)
    {
        var daEliminare = _clienti.FirstOrDefault(cliente => cliente.Id == id);
        return daEliminare != null && _clienti.Remove(daEliminare);
    }
}