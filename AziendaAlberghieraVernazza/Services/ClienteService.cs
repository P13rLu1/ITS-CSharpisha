using System;
using AziendaAlberghieraVernazza.Models;
using AziendaAlberghieraVernazza.Stores;
using AziendaAlberghieraVernazza.Utils;

namespace AziendaAlberghieraVernazza.Services;

public class ClienteService
{
    private ClienteStore _clienteStore;
    
    public ClienteService(ClienteStore clienteStore)
    {
        _clienteStore = clienteStore;
    }
    
    public int InserisciNuovoCliente()
    {
        Console.WriteLine("\nInserisci i dati del nuovo cliente");

        string? nome;
        do
        {
            Console.Write("Inserisci il tipo della camera: ");
        } while (AlbergoUtils.CheckString(nome = Console.ReadLine(), "Il tipo non puó essere vuoto!"));
        
        string? cognome;
        do
        {
            Console.Write("Inserisci il tipo della camera: ");
        } while (AlbergoUtils.CheckString(cognome = Console.ReadLine(), "Il tipo non puó essere vuoto!"));
        
        string? email;
        do
        {
            Console.Write("Inserisci il tipo della camera: ");
        } while (AlbergoUtils.CheckString(email = Console.ReadLine(), "Il tipo non puó essere vuoto!"));
        
        var cliente = new Cliente(nome, cognome, email);
        _clienteStore.Aggiungi(cliente);
        Console.WriteLine($"Cliente Aggiunto con successo! Id: {cliente.Id}");
        
        AlbergoUtils.PremiUnTastoPerContinuare();
        
        return cliente.Id;
    }

    public int? SelezionaCliente()
    {
        if (_clienteStore.Get().Count == 0)
        {
            Console.WriteLine("\nNessun cliente presente");
            AlbergoUtils.PremiUnTastoPerContinuare();
            return null;
        }
        
        var ricerca = AlbergoUtils.SearchCliente();

        var cliente = _clienteStore.Get(ricerca);
        if (cliente == null)
        {
            Console.WriteLine("Cliente non trovato");
            AlbergoUtils.PremiUnTastoPerContinuare();
            return null;
        }
        
        Console.WriteLine($"Cliente trovato: Nome:{cliente!.Nome}\nCognome:{cliente.Cognome}\n{cliente.Email}\nId: {cliente.Id}");
        
        AlbergoUtils.PremiUnTastoPerContinuare();
        
        return cliente.Id;
    }
}