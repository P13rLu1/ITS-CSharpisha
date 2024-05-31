using System;
using System.Linq;
using RegistroMenoPazzo.Models;
using RegistroMenoPazzo.Stores;
using RegistroMenoPazzo.Utils;

namespace RegistroMenoPazzo.Services;

public class StudenteService
{
    private readonly StudenteStore _studenteStore; //crea un'istanza di StudenteStore e la assegna a _studenteStore
    internal StudenteService(StudenteStore studenteStore) //costruttore di StudenteService
    {
        _studenteStore = studenteStore; //assegna a _studenteStore il valore di studenteStore
    }
    private readonly RegistroUtils _registroUtils = new(); //crea un'istanza di RegistroUtils e la assegna a _registroUtils
    
    
    internal void AggiungiStudente() //metodo AggiungiStudente di StudenteService
    {
        string? nome; //crea una variabile nome di tipo string 
        do //ciclo do-while che continua finché il nome non é vuoto
        { 
            Console.Write("Nome: "); //stampa a schermo "Nome: "
        } while (_registroUtils.CheckString( nome = Console.ReadLine()?.ToUpper(), "Il nome non puó essere vuoto!")); //assegna a nome il valore inserito dall'utente e chiama il metodo CheckString di _registroUtils passando nome e il messaggio "Il nome non puó essere vuoto!" come argomenti, se il metodo restituisce true il ciclo continua
        
        string? cognome; //crea una variabile cognome di tipo string 
        do //ciclo do-while che continua finché il cognome non é vuoto
        {
            Console.Write("Cognome: "); //stampa a schermo "Cognome: "
        } while (_registroUtils.CheckString( cognome = Console.ReadLine()?.ToUpper(), "Il cognome non puó essere vuoto!")); //assegna a cognome il valore inserito dall'utente e chiama il metodo CheckString di _registroUtils passando cognome e il messaggio "Il cognome non puó essere vuoto!" come argomenti, se il metodo restituisce true il ciclo continua
        
        DateOnly dataDiNascita; //crea una variabile dataDiNascita di tipo DateOnly
        do //ciclo do-while che continua finché la data di nascita non é valida
        {
            Console.Write("Data di nascita: "); //stampa a schermo "Data di nascita: "
        } while (_registroUtils.CheckDates(dataDiNascita = DateOnly.TryParse( Console.ReadLine(), out var data) ? data : DateOnly.MinValue, "Data non valida!") ); //assegna a dataDiNascita il valore di data se la conversione riesce, altrimenti DateOnly.MinValue e quindi andando dentro CheckDates restituisce true e il ciclo continua
        
        string? classe; //crea una variabile classe di tipo string
        do //ciclo do-while che continua finché la classe non é vuota
        {
            Console.Write("Classe: "); //stampa a schermo "Classe: "
        } while (_registroUtils.CheckString( classe = Console.ReadLine()?.ToUpper(), "La classe non puó essere vuota!")); //assegna a classe il valore inserito dall'utente e chiama il metodo CheckString di _registroUtils passando classe e il messaggio "La classe non puó essere vuota!" come argomenti, se il metodo restituisce true il ciclo continua
        
        var studente = new Studente(nome, cognome, dataDiNascita, classe); //crea un'istanza di Studente con i valori di nome, cognome, dataDiNascita e classe e la assegna a studente
        _studenteStore.AggiungiStudente(studente); //chiama il metodo AggiungiStudente di _studenteStore passando studente come argomento
        Console.WriteLine("Studente aggiunto con successo!"); //stampa a schermo il messaggio "Studente aggiunto con successo!"
        _registroUtils.PremiUnTastoPerContinuare(); //chiama il metodo PremiUnTastoPerContinuare di _registroUtils
    }

    internal void ModificaStudente() //metodo ModificaStudente di StudenteService
    {
        if ( _studenteStore.Get().Count == 0) //controlla se il numero di studenti é uguale a 0
        {
            Console.WriteLine("\nNessuno studente presente nel registro!"); //stampa a schermo il messaggio "Nessuno studente presente nel registro!"
            _registroUtils.PremiUnTastoPerContinuare(); //chiama il metodo PremiUnTastoPerContinuare di _registroUtils
            return; //esce dal metodo
        }

        var ricerca = _registroUtils.SearchStudent(); //chiama il metodo SearchStudent di _registroUtils e assegna il valore restituito a ricerca

        var studente = _studenteStore.Get(ricerca); //chiama il metodo Get di _studenteStore passando ricerca come argomento e assegna il valore restituito a studente
        if (studente == null) //controlla se studente é uguale a null 
        {
            Console.WriteLine("Studente non trovato!"); //stampa a schermo il messaggio "Studente non trovato!"
            _registroUtils.PremiUnTastoPerContinuare(); //chiama il metodo PremiUnTastoPerContinuare di _registroUtils
            return;
        }
        Console.WriteLine($"\nStai Modificando lo studente:\nNome: {studente.Nome}\nCognome: {studente.Cognome}\nData di nascita: {studente.DataDiNascita}\nClasse: {studente.Classe}\nID: {studente.Id}"); //stampa a schermo i dati dello studente che si sta modificando
        var sceltaValida = true; //crea una variabile sceltaValida di tipo bool e le assegna il valore true
        do //ciclo do-while che continua finché sceltaValida é uguale a true
        {
            Console.Write("1. Modifica nome\n2. Modifica cognome\n3. Modifica classe\n4. Esci\nScelta: "); //stampa a schermo il menu di modifica dello studente
            var scelta = Console.ReadLine() ?? ""; //assegna a scelta il valore inserito dall'utente, se é null assegna una stringa vuota
            switch (scelta) //switch che controlla il valore di scelta
            {
                case "1":
                    string? nuovoNome; //crea una variabile nuovoNome di tipo string
                    do //ciclo do-while che continua finché nuovoNome non é vuoto
                    {
                        Console.Write("Nuovo nome: "); //stampa a schermo "Nuovo nome: "
                    } while (_registroUtils.CheckString( nuovoNome = Console.ReadLine()?.ToUpper(), "Il nome non puó essere vuoto!")); //assegna a nuovoNome il valore inserito dall'utente e chiama il metodo CheckString di _registroUtils passando nuovoNome e il messaggio "Il nome non puó essere vuoto!" come argomenti, se il metodo restituisce true il ciclo continua
                    studente.Nome = nuovoNome; //assegna a studente.Nome il valore di nuovoNome
                    Console.WriteLine($"Nome modificato con successo! Nuovo nome: {studente.Nome}"); //stampa a schermo il messaggio "Nome modificato con successo! Nuovo nome:" seguito dal valore di studente.Nome
                    break; //esce dallo switch
                case "2":
                    string? nuovoCognome; //crea una variabile nuovoCognome di tipo string
                    do //ciclo do-while che continua finché nuovoCognome non é vuoto
                    {
                        Console.Write("Nuovo cognome: "); //stampa a schermo "Nuovo cognome: "
                    } while (_registroUtils.CheckString( nuovoCognome = Console.ReadLine()?.ToUpper(), "Il cognome non puó essere vuoto!")); //assegna a nuovoCognome il valore inserito dall'utente e chiama il metodo CheckString di _registroUtils passando nuovoCognome e il messaggio "Il cognome non puó essere vuoto!" come argomenti, se il metodo restituisce true il ciclo continua
                    studente.Cognome = nuovoCognome; //assegna a studente.Cognome il valore di nuovoCognome
                    Console.WriteLine($"Nome modificato con successo! Nuovo nome: {studente.Cognome}"); //stampa a schermo il messaggio "Nome modificato con successo! Nuovo nome:" seguito dal valore di studente.Cognome
                    break; //esce dallo switch
                case "3":
                    string? nuovaClasse; //crea una variabile nuovaClasse di tipo string
                    do //ciclo do-while che continua finché nuovaClasse non é vuota
                    {
                        Console.Write("Nuova classe: "); //stampa a schermo "Nuova classe: "
                    } while (_registroUtils.CheckString( nuovaClasse = Console.ReadLine()?.ToUpper(), "Il nome non puó essere vuoto!")); //assegna a nuovaClasse il valore inserito dall'utente e chiama il metodo CheckString di _registroUtils passando nuovaClasse e il messaggio "Il nome non puó essere vuoto!" come argomenti, se il metodo restituisce true il ciclo continua
                    studente.Classe = nuovaClasse; //assegna a studente.Classe il valore di nuovaClasse
                    Console.WriteLine($"Nome modificato con successo! Nuovo nome: {studente.Classe}"); //stampa a schermo il messaggio "Nome modificato con successo! Nuovo nome:" seguito dal valore di studente.Classe
                    break; //esce dallo switch
                case "4":
                    Console.WriteLine("Modifica completata!"); //stampa a schermo il messaggio "Modifica completata!"
                    sceltaValida = false; //assegna a sceltaValida il valore false
                    break; //esce dallo switch
                default:
                    Console.WriteLine("Scelta non valida"); //stampa a schermo il messaggio "Scelta non valida"
                    break; //esce dallo switch
            }
        } while (sceltaValida); //condizione del ciclo do-while che ripete il ciclo finché sceltaValida é uguale a true
    }
    
    internal void CancellaStudente() //metodo CancellaStudente di StudenteService
    {
        if (_studenteStore.Get().Count == 0) //controlla se il numero di studenti é uguale a 0 tramite il metodo Get di _studenteStore
        {
            Console.WriteLine("\nNessuno studente presente nel registro!"); //stampa a schermo il messaggio "Nessuno studente presente nel registro!"
            _registroUtils.PremiUnTastoPerContinuare(); //chiama il metodo PremiUnTastoPerContinuare di _registroUtils
            return; //esce dal metodo
        }
        
        var ricerca = _registroUtils.SearchStudent(); //chiama il metodo SearchStudent di _registroUtils e assegna il valore restituito a ricerca
        
        var studente = _studenteStore.Get(ricerca); //chiama il metodo Get di _studenteStore passando ricerca come argomento e assegna il valore restituito a studente
        if (studente == null) //controlla se studente é uguale a null
        {
            Console.WriteLine("Studente non trovato!"); //stampa a schermo il messaggio "Studente non trovato!"
            return; //esce dal metodo
        }
        
        Console.WriteLine($"Nome: {studente.Nome} Cognome: {studente.Cognome} Data di nascita: {studente.DataDiNascita} Classe: {studente.Classe} ID: {studente.Id}"); //stampa a schermo i dati dello studente che si sta cancellando 
        
        string? conferma; //crea una variabile conferma di tipo string
        do
        {
            Console.Write("Sei sicuro di voler cancellare lo studente? (s/n): ");
        } while (_registroUtils.CheckString( conferma = Console.ReadLine()?.ToLower(), "La risposta non puó essere vuota!"));
        if (conferma != "s") return;
        _studenteStore.CancellaStudente(studente.Id);
        
        Console.WriteLine("Studente cancellato con successo!");
        _registroUtils.PremiUnTastoPerContinuare();
    }

    internal void VisualizzazioneStudenti()
    {
        Console.WriteLine();

        if (_studenteStore.Get().Count == 0)
        {
            Console.WriteLine("\nNessuno studente presente nel registro!");
            _registroUtils.PremiUnTastoPerContinuare();
            return;
        }

        Console.Write("Vuoi ordinare gli studenti per nome, cognome o ID (e per non ordinarli)? (n/c/i/e): ");
        var scelta = Console.ReadLine() ?? "";
        var studentiOrdinati = _studenteStore.Get();
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