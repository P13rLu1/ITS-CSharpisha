using BigliettApp.DataLayer.Models;
using BigliettApp.DataLayer.Stores.Interfaces;

namespace BigliettApp.DataLayer.Stores;

public class ClienteDbStore(BiglietteriaDbContext biglietteriaDbContext) : IClienteStore
{
    public List<Cliente> Get()
    {
        return biglietteriaDbContext.Clienti.ToList();
    }

    public Cliente Get(int id)
    {
        var clienteTrovato = biglietteriaDbContext.Clienti.FirstOrDefault(cliente => cliente.Id == id); 

        if (clienteTrovato == null)
        {
            throw new IndexOutOfRangeException($"Cliente con id {id} non trovato");
        }

        return clienteTrovato;
    }

    public bool Create(Cliente clienteDaAggiungere)
    {
        biglietteriaDbContext.Clienti.Add(clienteDaAggiungere);

        biglietteriaDbContext.SaveChanges();

        return true;
    }

    public bool Update(ClienteCreateModel nuovaVersione)
    {
        var clienteDaModificare = biglietteriaDbContext.Clienti.FirstOrDefault(cliente => cliente.Id == nuovaVersione.Id);

        if (clienteDaModificare == null)
        {
            throw new IndexOutOfRangeException($"Cliente con id {nuovaVersione.Id} non trovato");
        }

        clienteDaModificare.Nome = nuovaVersione.Nome;
        clienteDaModificare.Cognome = nuovaVersione.Cognome;
        clienteDaModificare.Email = nuovaVersione.Email;
        clienteDaModificare.Telefono = nuovaVersione.Telefono;

        biglietteriaDbContext.SaveChanges();

        return true;
    }

    public bool Delete(int id)
    {
        var clienteDaEliminare = biglietteriaDbContext.Clienti.FirstOrDefault(cliente => cliente.Id == id);

        if (clienteDaEliminare == null)
        {
            throw new IndexOutOfRangeException($"Cliente con id {id} non trovato");
        }

        biglietteriaDbContext.Clienti.Remove(clienteDaEliminare);

        biglietteriaDbContext.SaveChanges();

        return true;
    }
}