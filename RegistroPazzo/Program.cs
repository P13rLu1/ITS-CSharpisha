//Creare una .NET Console App in C# che permetta la gestione di un registro elettronico.
//
//All'avvio verrà chiesto all'utente di accedere come docente o alunno.
//Se si tratta di un docente potrà:
//- Inserire, Modifica, Eliminare l'anagrafica di un alunno;
//- Inserire, Modificare o Eliminare la valutazione per la propria materia, per una certa data e per uno specifico alunno (selezionandolo per matricola); 
//- Visualizzare l'elenco degli alunni e di tutte le valutazioni assegnate, filtrandoli per anno e per classe di appartenenza;
//- Visualizzare la media di uno specifico alunno (filtrando per anno).
//Se si tratta di un alunno potrà:
//- Visualizzare le proprie valutazioni, filtrandole per anno e (opzionalmente) per materia. Altrimenti le visualizzerà raggruppate per materia e ordinate per data (infatti un docente può inserire voti con qualsiasi data precedente, quindi le valutazioni dell'alunno potrebbero non essere ordinate per data);
//- Visualizzare la media per materia (filtrando per anno);
//- Visualizzare la media di tutte le materie (filtrando per anno).
//
//Esempio di anagrafica Alunno:
//- Nome;
//- Cognome;
//- Matricola;
//- Password (sola lettura, randomica, 8 cifre);
//- Codice fiscale;
//- Data di nascita;
//- Classe di appartenenza;
//
//Esempio di anagrafica Docente:
//- Nome;
//- Cognome;
//- Matricola;
//- Password (sola lettura, randomica, 8 cifre);
//- Codice fiscale;
//- Data di nascita;
//- Materia insegnata;

using System;

namespace ITS_CSharpisha;

public abstract class Program
{
    public static void Main()
    {
        Console.WriteLine("Benvenuto Nel Registro");
        GenerazioneDatiRandom();
        Menu();
    }
    
    private static void GenerazioneDatiRandom()
    {
        var alunno1 = new Alunno("Mario", "Rossi");
        var alunno2 = new Alunno("Luca", "Verdi");
        var alunno3 = new Alunno("Paolo", "Bianchi");
        
        var docente1 = new Docente("Anna", "Neri");
        var docente2 = new Docente("Maria", "Gialli");
        
        var classe1 = new ClasseFrequentata("1A", "2021");
        var classe2 = new ClasseFrequentata("2A", "2021");
        
        alunno1.AggiungiClasse(classe1);
        alunno2.AggiungiClasse(classe1);
        alunno3.AggiungiClasse(classe2);
        
        docente1.AggiungiClasse(classe1);
        docente2.AggiungiClasse(classe2);
        
        var voto1 = new Voto("Matematica", 8, "01/01/2021");
        var voto2 = new Voto("Italiano", 7, "01/01/2021");
        var voto3 = new Voto("Matematica", 9, "01/01/2021");
        var voto4 = new Voto("Italiano", 6, "01/01/2021");
        var voto5 = new Voto("Matematica", 7, "01/01/2021");
        var voto6 = new Voto("Italiano", 8, "01/01/2021");
        
        docente1.InserisciVoto(alunno1, voto1);
        docente1.InserisciVoto(alunno1, voto2);
        docente1.InserisciVoto(alunno2, voto3);
        docente1.InserisciVoto(alunno2, voto4);
        docente2.InserisciVoto(alunno3, voto5);
        docente2.InserisciVoto(alunno3, voto6);
    }
    
    private static void Menu()
    {
        Console.Write("Seleziona il tuo ruolo:\n1. Docente\n2. Alunno\nScelta: ");
        
        var scelta = Console.ReadLine();
        
        switch (scelta)
        {
            case "1":
                MenuDocente();
                break;
            case "2":
                //MenuAlunno();
                break;
            default:
                Console.WriteLine("Scelta non valida");
                Menu();
                break;
        }
    }
    
    private static void MenuDocente()
    {
        Console.WriteLine("Benvenuto Docente\n1. Inserisci Anagrafica Alunno\n2. Modifica Anagrafica Alunno\n3. Elimina Anagrafica Alunno\n4. Inserisci Valutazione\n5. Modifica Valutazione\n6. Elimina Valutazione\n7. Visualizza Elenco Alunni\n8. Visualizza Valutazioni\n9. Visualizza Media Alunno");
        
        var scelta = Console.ReadLine();
        
        switch (scelta)
        {
            case "1":
                InserisciAnagraficaAlunno();
                break;
            case "2":
                ModificaAnagraficaAlunno();
                break;
            case "3":
                //EliminaAnagraficaAlunno();
                break;
            case "4":
                //InserisciValutazione();
                break;
            case "5":
                //ModificaValutazione();
                break;
            case "6":
                //EliminaValutazione();
                break;
            case "7":
                //VisualizzaElencoAlunni();
                break;
            case "8":
                //VisualizzaValutazioni();
                break;
            case "9":
                //VisualizzaMediaAlunno();
                break;
            default:
                Console.WriteLine("Scelta non valida");
                MenuDocente();
                break;
        }
    }
    
    private static void InserisciAnagraficaAlunno()
    {
        Console.Write("Inserisci Nome: ");
        var nome = Console.ReadLine();
        
        Console.Write("Inserisci Cognome: ");
        var cognome = Console.ReadLine();
        
        var alunno = new Alunno(nome, cognome);
        
        Console.WriteLine($"Anagrafica Alunno {alunno} inserita correttamente");
        
        MenuDocente();
    }
    
    private static void ModificaAnagraficaAlunno()
    {
        Console.Write("Inserisci Matricola Alunno: ");
        // var matricola = Console.ReadLine();
        
        // var alunno = CercaAlunno(matricola);
        
        //if (alunno == null)
        //{
        //    Console.WriteLine("Alunno non trovato");
        //    MenuDocente();
        //}
        
        Console.Write("Inserisci Nome: ");
        var nome = Console.ReadLine();
        
        Console.Write("Inserisci Cognome: ");
        var cognome = Console.ReadLine();
        
        //alunno.Nome = nome;
        //alunno.Cognome = cognome;
        
        Console.WriteLine($"Anagrafica Alunno {nome} {cognome} modificata correttamente");
        
        MenuDocente();
    }
}