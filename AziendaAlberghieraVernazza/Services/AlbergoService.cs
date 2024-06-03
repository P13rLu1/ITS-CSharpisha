using System;

namespace AziendaAlberghieraVernazza.Services;

public class AlbergoService(
    CameraService cameraService,
    PrenotazioneService prenotazioneService)
{
    private CameraService _cameraService = cameraService;
    private PrenotazioneService _prenotazioneService = prenotazioneService;

    public void MenuPrincipale()
    {
        Console.WriteLine("Benvenuto <Albergatore> Nell'Agenzia Alberghiera Vernazza!!");
        string? scelta;
        do
        {
            Console.Write("\nCosa Vuoi Fare?\n1. Gestione camere\n2. Gestione prenotazioni\n0. Esci\nScegli un'opzione: ");
            scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    _cameraService.GestioneCamere();
                    break;
                case "2":
                    _prenotazioneService.GestionePrenotazioni();
                    break;
                case "0":
                    Console.WriteLine("Arrivederci!");
                    break;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }
        } while (scelta != "0");
    }
}