using System;
using System.Text.RegularExpressions;

namespace AziendaAlberghieraVernazza.Utils;

public static class AlbergoUtils
{
    internal static void PremiUnTastoPerContinuare()
    {
        Console.WriteLine("Premi un tasto per continuare...");
        Console.ReadKey();
    }
    
    internal static bool CheckString(string? input, string message)
    {
        if (!string.IsNullOrWhiteSpace(input)) return false;
        Console.WriteLine(message);
        return true;
    }

    internal static bool CheckInt(string? input, string message)
    {
        if (int.TryParse(input, out _)) return false;
        Console.WriteLine(message);
        return true;
    }
    
    internal static bool CheckDate(string? input, string message)
    {
        if (DateOnly.TryParse(input, out _)) return false;
        Console.WriteLine(message);
        return true;
    }
    
    internal static bool CheckEmail(string? input, string message)
    {
        if (Regex.IsMatch(input ?? "", @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")) return false;
        Console.WriteLine(message);
        return true;
    }
    
    internal static string SearchCliente()
    {
        string ricerca;
        do
        {
            Console.Write("Inserisci il nome, cognome o ID dello studente da modificare: ");
        } while (CheckString(ricerca = Console.ReadLine()?.ToUpper() ?? "", "La ricerca non puó essere vuota!"));
        return ricerca;
    }
}