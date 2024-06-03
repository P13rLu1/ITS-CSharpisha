// Creare una .NET Console App in C# che permetta la gestione di un sistema di prenotazione alberghiera. 
//
// Camera:
// - Id (numerico, incrementale)
// - Numero (numerico)
// - Tipo (testo)
// - NumeroLetti (numerico)
//
// Cliente:
// - Id (numerico, incrementale)
// - Nome (testo)
// - Cognome (testo)
// - Email (testo)
// 
// Prenotazione:
// - Id (numerico, incrementale)
// - IdCliente (fk, numerico)
// - IdCamera (fk, numerico)
// - DataArrivo (data)
// - DataPartenza (data)
// - Note (testo) "Non pulire per la durata del mio soggiorno", "non voglio neri"
//
// L'operatore potrà inserire una prenotazione, inserendo i dati di un nuovo cliente oppure selezionando
// un cliente già presente. Inoltre, potrà gestire il censimento delle camere nell'applicazione.
//
// In fase di inserimento di una prenotazione, filtrare l'elenco delle camere in base al numero di letti e alle date richieste dal cliente.
//
// Ricordarsi di gestire tutti i possibili casi d'errore e di separare il codice in diversi metodi atomici.
using AziendaAlberghieraVernazza.Services;
using AziendaAlberghieraVernazza.Stores;
using Microsoft.Extensions.DependencyInjection;

namespace AziendaAlberghieraVernazza;

public static class Program
{
    public static void Main()
    {
        var sc = new ServiceCollection();
        sc.AddScoped<AlbergoService>();
        sc.AddScoped<CameraService>();
        sc.AddScoped<ClienteService>();
        sc.AddScoped<PrenotazioneService>();
        sc.AddScoped<CameraStore>();
        sc.AddScoped<ClienteStore>();
        sc.AddScoped<PrenotazioneStore>();
        
        var sp = sc.BuildServiceProvider();
        var albergo = sp.GetService<AlbergoService>();
        
        albergo?.MenuPrincipale();
    }
}