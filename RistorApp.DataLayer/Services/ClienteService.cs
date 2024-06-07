using RistorApp.DataLayer.Models;
using System.Collections.Generic;
using RistorApp.DataLayer.Stores.Interfaces;

namespace RistorApp.DataLayer.Services
{
    public class ClienteService(IClienteStore clienteStore)
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
            var clienteDaAggiungere = new Cliente(clienteDaCreare.Nome.ToUpper(), clienteDaCreare.Cognome.ToUpper(), clienteDaCreare.DataNascita);
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
}