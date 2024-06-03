using System;
using AziendaAlberghieraVernazza.Stores;
using AziendaAlberghieraVernazza.Utils;

namespace AziendaAlberghieraVernazza.Services;

public class PrenotazioneService
{
    private PrenotazioneStore _prenotazioneStore;
    private ClienteService _clienteService;
    
    public PrenotazioneService(PrenotazioneStore prenotazioneStore, ClienteService clienteService)
    {
        _prenotazioneStore = prenotazioneStore;
        _clienteService = clienteService;
    }
    
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
        if (_prenotazioneStore.Get().Count == 0)
        {
            Console.WriteLine("\nNessuna prenotazione presente");
            AlbergoUtils.PremiUnTastoPerContinuare();
            return;
        }

        Console.WriteLine("\nPrenotazioni:");
        var prenotazioni = _prenotazioneStore.Get();
        foreach (var prenotazione in prenotazioni)
        {
            Console.WriteLine(
                $"Id: {prenotazione.Id}, IdCliente: {prenotazione.IdCliente}, IdCamera: {prenotazione.IdCamera}, DataArrivo: {prenotazione.DataArrivo}, DataPartenza: {prenotazione.DataPartenza}, Note: {prenotazione.Note}\n-----------------");
        }
    }
    
    private void AggiungiPrenotazione()
    {
        Console.WriteLine("Aggiungi Prenotazione");
        string? scelta;
        int? idCliente;
        do
        {
            Console.Write("Vuoi inserire un nuovo cliente o selezionarne uno esistente? [nuovo/esistente]: ");
            scelta = Console.ReadLine();
            switch (scelta)
            {
                case "nuovo":
                    idCliente = _clienteService.InserisciNuovoCliente();
                    break;
                case "esistente":
                    idCliente = _clienteService.SelezionaCliente();
                    break;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }
        } while (scelta != "nuovo" && scelta != "esistente");
        
        // TODO Aggiungi prenotazione con la possibilitá di cercare la camera per l'idCamera
        // TODO Filtra camere in base al numero di letti e alle date richieste dal cliente
        
        
        
        
        
        // TODO FINALE Vedere se la camera selezionata é giá prenotata in quelle date
    }
}