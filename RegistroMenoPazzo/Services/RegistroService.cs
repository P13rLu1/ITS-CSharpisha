using System;
using System.Collections.Generic;
using RegistroMenoPazzo.Models;
using RegistroMenoPazzo.Utils;

namespace RegistroMenoPazzo.Services;

internal static class RegistroService
{
    
    internal static void MenuPrincipale()
    {
        Console.WriteLine("Benvenuto nel registro elettronico!");
        string? scelta;
        do
        {
            Console.Write(
                "1. Visualizza registro\n2. Aggiungi studente\n3. Modifica studente\n4. Cancella studente\n5. Esci\nScelta: ");
            scelta = Console.ReadLine();
            switch (scelta)
            {
                case "1":
                    VisualizzaRegistro();
                    break;
                case "2":
                    StudenteService.AggiungiStudente();
                    break;
                case "3":
                    StudenteService.ModificaStudente();
                    break;
                case "4":
                    StudenteService.CancellaStudente();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }
        } while (scelta != "5");
    }

    private static void VisualizzaRegistro()
    {
        if (Program.Studenti.Count == 0)
        {
            Console.WriteLine("\nNessuno studente presente nel registro!");
            RegistroUtils.PremiUnTastoPerContinuare();
            return;
        }
        
        VisualizzazioneStudenti(Program.Studenti);
        
        Console.Write("Vuoi ordinare gli studenti per nome, cognome o ID (e per uscire)? (n/c/i/e): ");
        var scelta = Console.ReadLine() ?? "";
        switch (scelta)
        {
            case "n":
                Program.Studenti.Sort((s1, s2) => string.Compare(s1.Nome, s2.Nome, StringComparison.Ordinal));
                break;
            case "c":
                Program.Studenti.Sort((s1, s2) => string.Compare(s1.Cognome, s2.Cognome, StringComparison.Ordinal));
                break;
            case "i":
                Program.Studenti.Sort((s1, s2) => s1.Id.CompareTo(s2.Id));
                break;
            case "e":
                return;
            default:
                Console.WriteLine("Scelta non valida");
                break;
        }
        
        VisualizzazioneStudenti(Program.Studenti);
        RegistroUtils.PremiUnTastoPerContinuare();
    }
    
    private static void VisualizzazioneStudenti(List<Studente> studenti)
    {
        Console.WriteLine();
        foreach (var studente in studenti)
        {
            Console.WriteLine($"Nome: {studente.Nome}\nCognome: {studente.Cognome}\nData di nascita: {studente.DataDiNascita}\nClasse: {studente.Classe}\nID: {studente.Id}\n-----------------");
        }
    }
}