using RistorApp.DataLayer.Models;
using RistorApp.DataLayer.Stores;
using System;
using System.Collections.Generic;

namespace RistorApp.DataLayer.Services
{
    public class ClienteService(ClienteStore clienteStore)
    {
        public List<Cliente> Get()
        {
            return clienteStore.Get();
        }

        public Cliente Get(int id)
        {
            var clienteTrovato = clienteStore.Get(id);
            if (clienteTrovato == null)
            {
                throw new Exception($"Cliente con id {id} non trovato");
            }
            return clienteTrovato;
        }

        public bool Create(string nome, string cognome, DateTime dataNascita)
        {
            var clienteDaAggiungere = new Cliente(nome.ToUpper(), cognome.ToUpper(), dataNascita);
            clienteStore.Create(clienteDaAggiungere);
            return true;
        }

        public bool Update(Cliente clienteDaModificare)
        {
            return clienteStore.Update(clienteDaModificare);
        }

        public bool Delete(int id)
        { 
            return clienteStore.Delete(id);
        }
    }
}