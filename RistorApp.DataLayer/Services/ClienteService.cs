using RistorApp.DataLayer.Models;
using RistorApp.DataLayer.Stores;
using System;
using System.Collections.Generic;

namespace RistorApp.DataLayer.Services
{
    public class ClienteService
    {
        private ClienteStore _store;

        public ClienteService(ClienteStore clienteStore) 
        {
            _store = clienteStore;
        }

        public List<Cliente> Get()
        {
            return _store.Get();
        }

        public Cliente Get(int id)
        {
            var clienteTrovato = _store.Get(id);
            if (clienteTrovato == null)
            {
                throw new Exception($"Cliente con id {id} non trovato");
            }
            return clienteTrovato;
        }

        public bool Create(ClienteCreateModel clienteDaCreare)
        {
            var clienteDaAggiungere = new Cliente(clienteDaCreare.Nome, clienteDaCreare.Cognome, clienteDaCreare.DataNascita ?? DateTime.MinValue);
            _store.Create(clienteDaAggiungere);
            return true;
        }

        public bool Update(Cliente clienteDaModificare)
        {
            return _store.Update(clienteDaModificare);
        }

        public bool Delete(int id)
        { 
            return _store.Delete(id);
        }
    }
}