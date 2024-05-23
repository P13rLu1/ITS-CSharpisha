using System;
using System.Collections.Generic;

namespace RegistroMenoPazzo;

internal class Registro
{
    internal static readonly List<Studente> Studenti = [];
    internal void VisualizzaRegistro()
    {
        if (Studenti.Count == 0)
        {
            Console.WriteLine("\nNessuno studente presente nel registro!");
            PremiUnTastoPerContinuare();
            return;
        }
        
        VisualizzazioneStudenti(Studenti);
        
        Console.Write("Vuoi ordinare gli studenti per nome, cognome o ID (e per uscire)? (n/c/i/e): ");
        var scelta = Console.ReadLine() ?? "";
        switch (scelta)
        {
            case "n":
                Studenti.Sort((s1, s2) => string.Compare(s1.Nome, s2.Nome, StringComparison.Ordinal));
                break;
            case "c":
                Studenti.Sort((s1, s2) => string.Compare(s1.Cognome, s2.Cognome, StringComparison.Ordinal));
                break;
            case "i":
                Studenti.Sort((s1, s2) => s1.Id.CompareTo(s2.Id));
                break;
            case "e":
                return;
            default:
                Console.WriteLine("Scelta non valida");
                break;
        }
        
        VisualizzazioneStudenti(Studenti);
        PremiUnTastoPerContinuare();
    }
    
    private static void VisualizzazioneStudenti(List<Studente> studenti)
    {
        Console.WriteLine();
        foreach (var studente in studenti)
        {
            Console.WriteLine($"Nome: {studente.Nome}\nCognome: {studente.Cognome}\nData di nascita: {studente.DataDiNascita}\nClasse: {studente.Classe}\nID: {studente.Id}\n-----------------");
        }
    }
    
    internal static void PremiUnTastoPerContinuare()
    {
        Console.WriteLine("Premi un tasto per continuare...");
        Console.ReadKey();
    }
}