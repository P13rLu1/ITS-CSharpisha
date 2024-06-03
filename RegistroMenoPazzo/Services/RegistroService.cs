using System;
using RegistroMenoPazzo.Stores;

namespace RegistroMenoPazzo.Services;

internal class RegistroService
{
    private readonly StudenteService _studenteService; //crea un'istanza di StudenteService e la assegna a _studenteService

    internal RegistroService() //costruttore di RegistroService 
    {
        StudenteStore studenteStore = new(); //crea un'istanza di StudenteStore e la assegna a studenteStore
        _studenteService = new StudenteService(studenteStore); //crea un'istanza di StudenteService e la assegna a _studenteService
    }

    internal void MenuPrincipale() //metodo MenuPrincipale di RegistroService
    {
        Console.WriteLine("Benvenuto nel registro elettronico!"); //stampa a schermo il messaggio di benvenuto
        string? scelta; //crea una variabile scelta di tipo string 
        do //ciclo do-while che continua finché la scelta non é uguale a "5"
        {
            Console.Write(
                "1. Visualizza registro\n2. Aggiungi studente\n3. Modifica studente\n4. Cancella studente\n5. Esci\nScelta: "); //stampa a schermo il menu principale del registro
            scelta = Console.ReadLine(); //assegna a scelta il valore inserito dall'utente 
            switch (scelta) //switch che controlla il valore di scelta 
            {
                case "1":
                    _studenteService.VisualizzazioneStudenti(); //chiama il metodo VisualizzazioneStudenti di _studenteService
                    break; //esce dallo switch
                case "2": 
                    _studenteService.AggiungiStudente(); //chiama il metodo AggiungiStudente di _studenteService
                    break;
                case "3":
                    _studenteService.ModificaStudente(); //chiama il metodo ModificaStudente di _studenteService
                    break;
                case "4":
                    _studenteService.CancellaStudente(); //chiama il metodo CancellaStudente di _studenteService
                    break;
                case "5":
                    return; //esce dallo switch
                default:
                    Console.WriteLine("Scelta non valida"); //stampa a schermo il messaggio di errore 
                    break; //esce dallo switch
            }
        } while (scelta != "5"); //condizione del ciclo do-while che ripete il ciclo finché la scelta non é uguale a "5"
    } 
}