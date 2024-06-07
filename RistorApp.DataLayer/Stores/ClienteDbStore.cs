using System;
using System.Collections.Generic;
using System.Linq;
using RistorApp.DataLayer.Models;
using RistorApp.DataLayer.Stores.Interfaces;

namespace RistorApp.DataLayer.Stores;

public class ClienteDbStore(RistoranteDbContext ristoranteDbContext) : IClienteStore
{
    public List<Cliente> Get()
    {
        return ristoranteDbContext.Clienti.ToList(); 
    }

    public Cliente Get(int id)
    {
        var clienteTrovato = ristoranteDbContext.Clienti.FirstOrDefault(cliente => cliente.Id == id); 

        if (clienteTrovato == null)
        {
            throw new IndexOutOfRangeException($"Cliente con id {id} non trovato");
        }

        return clienteTrovato;
    }

    public bool Create(Cliente clienteDaAggiungere)
    {
        ristoranteDbContext.Clienti.Add(clienteDaAggiungere);

        ristoranteDbContext.SaveChanges();

        return true;
    }

    public bool Update(ClienteCreateModel nuovaVersione)
    {
        var clienteDaModificare = ristoranteDbContext.Clienti.FirstOrDefault(cliente => cliente.Id == nuovaVersione.Id);

        if (clienteDaModificare == null)
        {
            throw new IndexOutOfRangeException($"Cliente con id {nuovaVersione.Id} non trovato");
        }

        clienteDaModificare.Nome = nuovaVersione.Nome;
        clienteDaModificare.Cognome = nuovaVersione.Cognome;
        clienteDaModificare.DataNascita = nuovaVersione.DataNascita;

        ristoranteDbContext.SaveChanges();

        return true;
    }

    public bool Delete(int id)
    {
        var clienteDaEliminare = ristoranteDbContext.Clienti.FirstOrDefault(cliente => cliente.Id == id);

        if (clienteDaEliminare == null)
        {
            throw new IndexOutOfRangeException($"Cliente con id {id} non trovato");
        }

        ristoranteDbContext.Clienti.Remove(clienteDaEliminare);

        ristoranteDbContext.SaveChanges();

        return true;
    }
}