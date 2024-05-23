// Crea una consoleApp per la gestione di un registro elettronico.
// 1. Visualizza registro
// 2. Aggiungi studente
// 2. Modifica studente
// 3. Cancella Studente
// 4. Esci
//
//
// VISUALIZZA REGISTRO:
// - Mostra una lista di tutti gli studenti nel registro
//     - Opzione per ordinare gli studente nome, o cognome o per ID studente
//     - possibilità di visualizzare dettagli aggiuntivi per ciascuno studente
//
//     AGGIUNGI STUDENTE:
// - Nome, cognome, data di nascita (dateTime), classe. (genera un ID univoco per lo studente)
//
// MODIFICA STUDENTE:
// - Ricerca dello studente per nome, cognome o ID univoco
//     - Opzioni per modificare le informazioni come nome, cognome, classe
//
// CANCELLA STUDENTE:
// - Ricerca dello studente per nome, cognome o ID univoco
//     - Conferma dell'eliminazione prima dell'operazione
//
//     Gestisci tutti gli errori ed eccezioni
//     Utilizza classi e metodi per separare la logica

using System;
using RegistroMenoPazzo.Models;
using RegistroMenoPazzo.Services;

namespace RegistroMenoPazzo;

public abstract class Program
{
    public static void Main()
    {
        Console.WriteLine("Benvenuto nel registro elettronico!");
        var registro = new Registro();
        string? scelta;
        do
        {
            Console.Write(
                "1. Visualizza registro\n2. Aggiungi studente\n3. Modifica studente\n4. Cancella studente\n5. Esci\nScelta: ");
            scelta = Console.ReadLine();
            switch (scelta)
            {
                case "1":
                    registro.VisualizzaRegistro();
                    break;
                case "2":
                    Studente.AggiungiStudente();
                    break;
                case "3":
                    Studente.ModificaStudente();
                    break;
                case "4":
                    Studente.CancellaStudente();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }
        } while (scelta != "5");
    }
}