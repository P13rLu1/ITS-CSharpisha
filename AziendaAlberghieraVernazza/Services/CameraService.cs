using System;
using AziendaAlberghieraVernazza.Models;
using AziendaAlberghieraVernazza.Stores;
using AziendaAlberghieraVernazza.Utils;

namespace AziendaAlberghieraVernazza.Services;

public class CameraService(CameraStore cameraStore)
{
    private CameraStore _cameraStore = cameraStore;
    public void GestioneCamere()
    {
        Console.WriteLine("\nGestione Camere");
        int scelta;
        do
        {
            Console.Write("Cosa Vuoi Fare?\n1. Visualizza camere\n2. Aggiungi camera\n3. Cancella camera\n0. Torna al menu principale\nScegli un'opzione: ");
            scelta = int.Parse(Console.ReadLine()??"");
            switch (scelta)
            {
                case 1:
                    VisualizzaCamere();
                    break;
                case 2:
                    AggiungiCamera();
                    break;
                case 3:
                    CancellaCamera();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }
        } while (scelta != 0);
    }

    private void VisualizzaCamere()
    {
        if (_cameraStore.Get().Count == 0)
        {
            Console.WriteLine("\nNessuna camera presente");
            AlbergoUtils.PremiUnTastoPerContinuare();
            return;
        }
        
        Console.WriteLine("\nCamere:");
        var camere = _cameraStore.Get();
        foreach (var camera in camere)
        {
            Console.WriteLine($"Id: {camera.Id}, Numero: {camera.Numero}, Tipo: {camera.Tipo}, NumeroLetti: {camera.NumeroLetti}\n-----------------");
        }
        
        AlbergoUtils.PremiUnTastoPerContinuare();
    }
    
    private void AggiungiCamera()
    {
        string? numero;
        do
        {
            Console.Write("Inserisci il numero della camera: ");
        } while (AlbergoUtils.CheckInt(numero = Console.ReadLine()??"", "Il numero della camera non puó essere vuoto!"));

        string? tipo;
        do
        {
            Console.Write("Inserisci il tipo della camera: ");
        } while (AlbergoUtils.CheckString(tipo = Console.ReadLine(), "Il tipo non puó essere vuoto!"));
        
        string? numeroLetti;
        do
        {
            Console.Write("Inserisci il numero di letti della camera: ");
        } while (AlbergoUtils.CheckInt(numeroLetti = Console.ReadLine()??"", "Il numero di letti non puó essere vuoto!"));

        var camera = new Camera(int.Parse(numero), tipo, int.Parse(numeroLetti));
        _cameraStore.Aggiungi(camera);
        Console.WriteLine("Camera aggiunta con successo!");
        AlbergoUtils.PremiUnTastoPerContinuare();
    }
    
    private void CancellaCamera()
    {
        string? id;
        do
        {
            Console.Write("Inserisci l'id della camera da cancellare: ");
        } while (AlbergoUtils.CheckInt(id = Console.ReadLine()??"", "L'id della camera non puó essere vuoto!"));

        Console.WriteLine(_cameraStore.Cancella(int.Parse(id))
            ? "Camera cancellata con successo!"
            : "Camera non trovata!");
        AlbergoUtils.PremiUnTastoPerContinuare();
    }
}