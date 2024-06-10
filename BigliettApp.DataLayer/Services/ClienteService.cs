using BigliettApp.DataLayer.Models;
using BigliettApp.DataLayer.Stores.Interfaces;

namespace BigliettApp.DataLayer.Services;

public class ClienteService (IClienteStore clienteStore)
{
    public List<Cliente> Get()
    {
        return clienteStore.Get();
    }

    public Cliente Get(int id)
    {
        return clienteStore.Get(id);
    }

    public bool Create(ClienteCreateModel clienteDaCreare)
    {
        var clienteDaAggiungere = new Cliente(clienteDaCreare.Nome.ToUpper(), clienteDaCreare.Cognome.ToUpper(),clienteDaCreare.Email,clienteDaCreare.Telefono);
        return clienteStore.Create(clienteDaAggiungere);
    }

    public bool Update(ClienteCreateModel nuovaVersione)
    {
        return clienteStore.Update(nuovaVersione);
    }

    public bool Delete(int id)
    { 
        return clienteStore.Delete(id);
    }
}