using System;
using AziendaAlberghieraVernazza.Models;
using AziendaAlberghieraVernazza.Stores;
using AziendaAlberghieraVernazza.Utils;

namespace AziendaAlberghieraVernazza.Services;

public class ClienteService(ClienteStore clienteStore)
{
    public int InserisciNuovoCliente()
    {
        Console.WriteLine("\nInserisci i dati del nuovo cliente");

        string? nome;
        do
        {
            Console.Write("Inserisci il nome del cliente: ");
        } while (AlbergoUtils.CheckString(nome = Console.ReadLine()?.ToUpper(), "Il tipo non puó essere vuoto!"));
        
        string? cognome;
        do
        {
            Console.Write("Inserisci il cognome del cliente: ");
        } while (AlbergoUtils.CheckString(cognome = Console.ReadLine()?.ToUpper(), "Il tipo non puó essere vuoto!"));
        
        string? email;
        do
        {
            Console.Write("Inserisci l'email del cliente: ");
        } while (AlbergoUtils.CheckEmail(email = Console.ReadLine(), "Email non valida!"));
        
        var cliente = new Cliente(nome, cognome, email);
        clienteStore.Aggiungi(cliente);
        Console.WriteLine($"Cliente Aggiunto con successo! Id: {cliente.Id}");
        
        AlbergoUtils.PremiUnTastoPerContinuare();
        
        return cliente.Id;
    }

    public int? SelezionaCliente()
    {
        if (clienteStore.Get().Count == 0)
        {
            Console.WriteLine("\nNessun cliente presente");
            AlbergoUtils.PremiUnTastoPerContinuare();
            return null;
        }
        
        var ricerca = AlbergoUtils.SearchCliente();

        var cliente = clienteStore.Get(ricerca);
        if (cliente == null)
        {
            Console.WriteLine("Cliente non trovato");
            AlbergoUtils.PremiUnTastoPerContinuare();
            return null;
        }
        
        Console.WriteLine($"Cliente trovato: Nome:{cliente.Nome}\nCognome:{cliente.Cognome}\n{cliente.Email}\nId: {cliente.Id}");
        
        AlbergoUtils.PremiUnTastoPerContinuare();
        
        return cliente.Id;
    }
}