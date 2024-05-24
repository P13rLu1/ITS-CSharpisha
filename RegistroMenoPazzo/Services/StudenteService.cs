using System;
using System.Collections.Generic;
using System.Linq;
using RegistroMenoPazzo.Models;
using RegistroMenoPazzo.Utils;

namespace RegistroMenoPazzo.Services;

public class StudenteService
{
    private readonly List<Studente> _studenti = [];
    private readonly RegistroUtils _registroUtils = new();
    internal void AggiungiStudente()
    {
        string? nome;  
        do
        { 
            Console.Write("Nome: ");
        } while (_registroUtils.CheckString( nome = Console.ReadLine()?.ToUpper(), "Il nome non puó essere vuoto!"));
        
        string? cognome;
        do
        {
            Console.Write("Cognome: ");
        } while (_registroUtils.CheckString( cognome = Console.ReadLine()?.ToUpper(), "Il cognome non puó essere vuoto!"));
        
        DateOnly dataDiNascita;
        do
        {
            Console.Write("Data di nascita: ");
        } while (_registroUtils.CheckDates(dataDiNascita = DateOnly.TryParse( Console.ReadLine(), out var data) ? data : DateOnly.MinValue, "Data non valida!") ); //assegna a dataDiNascita il valore di data se la conversione riesce, altrimenti DateOnly.MinValue e quindi andando dentro CheckDates restituisce true e il ciclo continua
        
        string? classe;
        do
        {
            Console.Write("Classe: ");
        } while (_registroUtils.CheckString( classe = Console.ReadLine()?.ToUpper(), "La classe non puó essere vuota!"));
        
        var studente = new Studente(nome, cognome, dataDiNascita, classe);
        _studenti.Add(studente);
        Console.WriteLine("Studente aggiunto con successo!");
        _registroUtils.PremiUnTastoPerContinuare(); 
    }

    internal void ModificaStudente()
    {
        if (_studenti.Count == 0)
        {
            Console.WriteLine("\nNessuno studente presente nel registro!");
            _registroUtils.PremiUnTastoPerContinuare();
            return;
        }

        var ricerca = _registroUtils.SearchStudent();
        
        var studente = _studenti.Find(studente => studente.Nome == ricerca || studente.Cognome == ricerca || studente.Id.ToString() == ricerca);
        if (studente == null)
        {
            Console.WriteLine("Studente non trovato!");
            _registroUtils.PremiUnTastoPerContinuare();
            return;
        }
        Console.WriteLine($"\nStai Modificando lo studente:\nNome: {studente.Nome}\nCognome: {studente.Cognome}\nData di nascita: {studente.DataDiNascita}\nClasse: {studente.Classe}\nID: {studente.Id}");
        var sceltaValida = true;
        do
        {
            Console.Write("1. Modifica nome\n2. Modifica cognome\n3. Modifica classe\n4. Esci\nScelta: ");
            var scelta = Console.ReadLine() ?? "";
            switch (scelta)
            {
                case "1":
                    string? nuovoNome;
                    do
                    {
                        Console.Write("Nuovo nome: ");
                    } while (_registroUtils.CheckString( nuovoNome = Console.ReadLine()?.ToUpper(), "Il nome non puó essere vuoto!"));
                    studente.Nome = nuovoNome;
                    Console.WriteLine($"Nome modificato con successo! Nuovo nome: {studente.Nome}");
                    break;
                case "2":
                    string? nuovoCognome;
                    do
                    {
                        Console.Write("Nuovo cognome: ");
                    } while (_registroUtils.CheckString( nuovoCognome = Console.ReadLine()?.ToUpper(), "Il cognome non puó essere vuoto!"));
                    studente.Cognome = nuovoCognome;
                    Console.WriteLine($"Nome modificato con successo! Nuovo nome: {studente.Cognome}"); 
                    break;
                case "3":
                    string? nuovaClasse;
                    do
                    {
                        Console.Write("Nuova classe: ");
                    } while (_registroUtils.CheckString( nuovaClasse = Console.ReadLine()?.ToUpper(), "Il nome non puó essere vuoto!"));
                    studente.Classe = nuovaClasse;
                    Console.WriteLine($"Nome modificato con successo! Nuovo nome: {studente.Classe}");
                    break;
                case "4":
                    Console.WriteLine("Modifica completata!");
                    sceltaValida = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }
        } while (sceltaValida);
    }
    
    internal void CancellaStudente()
    {
        if (_studenti.Count == 0)
        {
            Console.WriteLine("\nNessuno studente presente nel registro!");
            _registroUtils.PremiUnTastoPerContinuare();
            return;
        }
        
        var ricerca = _registroUtils.SearchStudent();
        
        var studente = _studenti.Find(studente => studente.Nome == ricerca || studente.Cognome == ricerca || studente.Id.ToString() == ricerca);
        if (studente == null)
        {
            Console.WriteLine("Studente non trovato!");
            return;
        }
        
        Console.WriteLine($"Nome: {studente.Nome} Cognome: {studente.Cognome} Data di nascita: {studente.DataDiNascita} Classe: {studente.Classe} ID: {studente.Id}");
        
        string? conferma;
        do
        {
            Console.Write("Sei sicuro di voler cancellare lo studente? (s/n): ");
        } while (_registroUtils.CheckString( conferma = Console.ReadLine()?.ToLower(), "La risposta non puó essere vuota!"));
        if (conferma != "s") return;
        _studenti.Remove(studente);
        Console.WriteLine("Studente cancellato con successo!");
        _registroUtils.PremiUnTastoPerContinuare();
    }

    internal void VisualizzazioneStudenti()
    {
        Console.WriteLine();

        if (_studenti.Count == 0)
        {
            Console.WriteLine("\nNessuno studente presente nel registro!");
            _registroUtils.PremiUnTastoPerContinuare();
            return;
        }

        Console.Write("Vuoi ordinare gli studenti per nome, cognome o ID (e per non ordinarli)? (n/c/i/e): ");
        var scelta = Console.ReadLine() ?? "";
        var studentiOrdinati = _studenti;
        switch (scelta)
        {
            case "n":
                studentiOrdinati = studentiOrdinati.OrderBy(studente => studente.Nome).ToList();
                break;
            case "c":
                studentiOrdinati = studentiOrdinati.OrderBy(studente => studente.Cognome).ToList();
                break;
            case "i":
                studentiOrdinati = studentiOrdinati.OrderBy(studente => studente.Id).ToList();
                break;
            case "e":
                break;
            default:
                Console.WriteLine("Scelta non valida");
                break;
        }
        
        Console.WriteLine();
        foreach (var studente in studentiOrdinati)
        {
            Console.WriteLine($"Nome: {studente.Nome}\nCognome: {studente.Cognome}\nData di nascita: {studente.DataDiNascita}\nClasse: {studente.Classe}\nID: {studente.Id}\n-----------------");
        }
        _registroUtils.PremiUnTastoPerContinuare();
    }
}