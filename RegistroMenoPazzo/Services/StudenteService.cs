using System;
using System.Collections.Generic;
using System.Linq;
using RegistroMenoPazzo.Models;
using RegistroMenoPazzo.Utils;

namespace RegistroMenoPazzo.Services;

public class StudenteService
{
    private readonly List<Studente> _studenti = [];

    internal void AggiungiStudente()
    {
        string? nome;  
        do
        { 
            Console.Write("Nome: ");
        } while (RegistroUtils.CheckString( nome = Console.ReadLine()?.ToUpper(), "Il nome non puó essere vuoto!"));
        
        string? cognome;
        do
        {
            Console.Write("Cognome: ");
        } while (RegistroUtils.CheckString( cognome = Console.ReadLine()?.ToUpper(), "Il cognome non puó essere vuoto!"));
        
        DateOnly dataDiNascita;
        do
        {
            Console.Write("Data di nascita: ");
        } while (RegistroUtils.CheckDates(dataDiNascita = DateOnly.TryParse( Console.ReadLine(), out var data) ? data : DateOnly.MinValue, "Data non valida!") ); //assegna a dataDiNascita il valore di data se la conversione riesce, altrimenti DateOnly.MinValue e quindi andando dentro CheckDates restituisce true e il ciclo continua
        
        string? classe;
        do
        {
            Console.Write("Classe: ");
        } while (RegistroUtils.CheckString( classe = Console.ReadLine()?.ToUpper(), "La classe non puó essere vuota!"));
        
        var studente = new Studente(nome, cognome, dataDiNascita, classe);
        _studenti.Add(studente);
        Console.WriteLine("Studente aggiunto con successo!");
        RegistroUtils.PremiUnTastoPerContinuare(); 
    }

    internal void ModificaStudente()
    {
        if (_studenti.Count == 0)
        {
            Console.WriteLine("\nNessuno studente presente nel registro!");
            RegistroUtils.PremiUnTastoPerContinuare();
            return;
        }
        Console.Write("Inserisci il nome, cognome o ID dello studente da modificare: ");
        var ricerca = Console.ReadLine()?.ToUpper();
        
        var studente = _studenti.Find(s => s.Nome == ricerca || s.Cognome == ricerca || s.Id.ToString() == ricerca);
        if (studente == null)
        {
            Console.WriteLine("Studente non trovato!");
            return;
        }
        Console.WriteLine($"\nStai Modificando lo studente: Nome: {studente.Nome} Cognome: {studente.Cognome} Data di nascita: {studente.DataDiNascita} Classe: {studente.Classe} ID: {studente.Id}");
        var sceltaValida = true;
        do
        {
            Console.WriteLine("1. Modifica nome\n2. Modifica cognome\n3. Modifica classe\n4. Esci");
            Console.Write("Scelta: ");
            var scelta = Console.ReadLine() ?? "";
            switch (scelta)
            {
                case "1":
                    var nomeErrore = true;
                    do
                    {
                        Console.Write("Nuovo nome: ");
                        var nuovoNome = Console.ReadLine()?.ToUpper();
                        if (string.IsNullOrWhiteSpace(nuovoNome))
                        {
                            Console.WriteLine("Il cognome non può essere vuoto. Riprova.");
                        }
                        else
                        {
                            studente.Nome = nuovoNome;
                            nomeErrore = false;
                            Console.WriteLine($"Nome modificato con successo! Nuovo nome: {studente.Nome}");
                        }
                    } while (nomeErrore);
                    break;
                case "2":
                    var cognomeErrore = true;
                    do
                    {
                        Console.Write("Nuovo cognome: ");
                        var nuovoCognome = Console.ReadLine()?.ToUpper();
                        if (string.IsNullOrWhiteSpace(nuovoCognome))
                        {
                            Console.WriteLine("Il cognome non può essere vuoto. Riprova.");
                        }
                        else
                        {
                            studente.Cognome = nuovoCognome;
                            cognomeErrore = false;
                            Console.WriteLine($"Cognome modificato con successo! Nuovo cognome: {studente.Cognome}");
                        }
                    } while (cognomeErrore);    
                    break;
                case "3":
                    var classeErrore = true;
                    do
                    {
                        Console.Write("Nuova classe: ");
                        var nuovaClasse = Console.ReadLine()?.ToUpper();
                        if (string.IsNullOrWhiteSpace(nuovaClasse))
                        {
                            Console.WriteLine("Il cognome non può essere vuoto. Riprova.");
                        }
                        else
                        {
                            studente.Classe = nuovaClasse;
                            classeErrore = false;
                            Console.WriteLine($"Classe modificata con successo! Nuova classe: {studente.Classe}");
                        }
                    } while(classeErrore);
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
            RegistroUtils.PremiUnTastoPerContinuare();
            return;
        }
        
        Console.Write("Inserisci il nome, cognome o ID dello studente da cancellare: ");
        var ricerca = Console.ReadLine()?.ToUpper();
        
        var studente = _studenti.Find(s => s.Nome == ricerca || s.Cognome == ricerca || s.Id.ToString() == ricerca);
        if (studente == null)
        {
            Console.WriteLine("Studente non trovato!");
            return;
        }
        
        Console.WriteLine($"Nome: {studente.Nome} Cognome: {studente.Cognome} Data di nascita: {studente.DataDiNascita} Classe: {studente.Classe} ID: {studente.Id}");
        Console.Write("Sei sicuro di voler cancellare questo studente? (s/n): ");
        var conferma = Console.ReadLine() ?? "";
        if (conferma != "s") return;
        _studenti.Remove(studente);
        Console.WriteLine("Studente cancellato con successo!");
        RegistroUtils.PremiUnTastoPerContinuare();
    }

    internal void VisualizzazioneStudenti()
    {
        Console.WriteLine();

        if (_studenti.Count == 0)
        {
            Console.WriteLine("\nNessuno studente presente nel registro!");
            RegistroUtils.PremiUnTastoPerContinuare();
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
                return;
            default:
                Console.WriteLine("Scelta non valida");
                break;
        }

        foreach (var studente in studentiOrdinati)
        {
            Console.WriteLine($"Nome: {studente.Nome}\nCognome: {studente.Cognome}\nData di nascita: {studente.DataDiNascita}\nClasse: {studente.Classe}\nID: {studente.Id}\n-----------------");
        }
    }
}