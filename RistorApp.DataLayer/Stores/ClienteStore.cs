﻿using RistorApp.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq; 

namespace RistorApp.DataLayer.Stores
{
    public class ClienteStore
    {
        private List<Cliente> _clienti =
        [
            new Cliente("Tizio", "Caio", DateTime.Parse("1990/01/01")),
            new Cliente("Mario", "Rossi", DateTime.Parse("1984/11/27")),
            new Cliente("Davide", "Botrugno", DateTime.Parse("1995/05/10")),
        ];

        public List<Cliente> Get()
        {
            return _clienti;
        }

        public Cliente? Get(int id)
        {
            return _clienti.FirstOrDefault(cliente => cliente.Id == id);
        }

        public bool Create(Cliente clienteDaAggiungere)
        {
            _clienti.Add(clienteDaAggiungere);
            return true;
        }

        public bool Update(Cliente clienteDaModificare)
        {
            var nuovaLista = new List<Cliente>();
            foreach (var cliente in _clienti)
            {
                nuovaLista.Add(cliente.Id == clienteDaModificare.Id ? clienteDaModificare : cliente);
            }
            _clienti = nuovaLista; 
            return true;
        }

        public bool Delete(int id)
        {
            var clienteDaRimuovere = Get(id);
            if (clienteDaRimuovere == null)
            {
                throw new Exception($"Cliente con id {id} non trovato");
            }
            return _clienti.Remove(clienteDaRimuovere); 
        }
    }
}