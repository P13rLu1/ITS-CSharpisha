using System;
using AziendaAlberghieraVernazza.Models;
using AziendaAlberghieraVernazza.Stores;
using AziendaAlberghieraVernazza.Utils;

namespace AziendaAlberghieraVernazza.Services;

public class PrenotazioneService(
    PrenotazioneStore prenotazioneStore,
    ClienteService clienteService,
    CameraService cameraService)
{
    public void GestionePrenotazioni()
    {
        Console.WriteLine("\nGestione Prenotazioni");
        int scelta;
        do
        {
            Console.Write("Cosa Vuoi Fare?\n1. Visualizza prenotazioni\n2. Aggiungi prenotazione\n3. Cancella prenotazione\n0. Torna al menu principale\nScegli un'opzione: ");
            scelta = int.Parse(Console.ReadLine()??"");
            switch (scelta)
            {
                case 1:
                    VisualizzaPrenotazioni();
                    break;
                case 2:
                    AggiungiPrenotazione();
                    break;
                case 3:
                    //CancellaPrenotazione();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }
        } while (scelta != 0);
    }

    private void VisualizzaPrenotazioni()
    {
        if (prenotazioneStore.Get().Count == 0)
        {
            Console.WriteLine("\nNessuna prenotazione presente");
            AlbergoUtils.PremiUnTastoPerContinuare();
            return;
        }

        Console.WriteLine("\nPrenotazioni:");
        var prenotazioni = prenotazioneStore.Get();
        foreach (var prenotazione in prenotazioni)
        {
            Console.WriteLine(
                $"Id: {prenotazione.Id}, IdCliente: {prenotazione.IdCliente}, IdCamera: {prenotazione.IdCamera}, DataArrivo: {prenotazione.DataArrivo}, DataPartenza: {prenotazione.DataPartenza}, Note: {prenotazione.Note}\n-----------------");
        }
    }
    
    private void AggiungiPrenotazione()
    {
        Console.WriteLine("Aggiungi Prenotazione");

        string? dataArrivo;
        do
        {
            Console.Write("Inserisci la data di arrivo (yyyy-MM-dd): ");
        } while (AlbergoUtils.CheckDate(dataArrivo = Console.ReadLine() ?? "", "Data non valida!"));

        string? dataPartenza;
        do
        {
            Console.Write("Inserisci la data di partenza (yyyy-MM-dd): ");
        } while (AlbergoUtils.CheckDate(dataPartenza = Console.ReadLine() ?? "", "Data non valida!"));

        int? idCliente = RicavaIdCliente();

        Console.Write("Inserisci il numero di letti che servono al cliente: ");
        string? numeroLetti;
        do
        {
            Console.Write("Inserisci il numero di letti che servono al cliente: ");
        } while (AlbergoUtils.CheckInt(numeroLetti = Console.ReadLine() ?? "", "Il numero di letti non puó essere vuoto!"));

        var camereDisponibili = cameraService.FiltraCamereDisponibili(DateOnly.Parse(dataArrivo), DateOnly.Parse(dataPartenza), int.Parse(numeroLetti)); // funzione che restituisce le camere disponibili in base ai parametri passati (data arrivo, data partenza, numero letti)
        var idCamera = cameraService.SelezionaCamera(camereDisponibili); // funzione che restituisce l'id della camera selezionata dall'utente se presente, altrimenti null

        if (idCamera == null)
        {
            Console.WriteLine("Nessuna camera disponibile per i criteri selezionati.");
            return;
        }

        string? note;
        do
        {
            Console.Write("Inserisci le note: ");
        } while (AlbergoUtils.CheckString(note = Console.ReadLine() ?? "", "Le note non possono essere vuote!"));

        var prenotazione = new Prenotazione(idCliente, idCamera.Value, DateOnly.Parse(dataArrivo), DateOnly.Parse(dataPartenza), note);
        prenotazioneStore.Aggiungi(prenotazione);

        Console.WriteLine("Prenotazione aggiunta con successo!");
    }
    
    private int? RicavaIdCliente()
    {
        string? scelta;
        int? idCliente = null;
        do
        {
            Console.Write("Vuoi inserire un nuovo cliente o selezionarne uno esistente?\n1. Nuovo\n2. Esistente\nScelta: ");
            scelta = Console.ReadLine();
            switch (scelta)
            {
                case "1":
                    idCliente = clienteService.InserisciNuovoCliente();
                    break;
                case "2":
                    idCliente = clienteService.SelezionaCliente();
                    break;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }
        } while (scelta != "1" && scelta != "2");
        return idCliente;
    }
}