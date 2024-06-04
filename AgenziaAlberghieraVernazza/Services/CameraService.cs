using System;
using System.Collections.Generic;
using System.Linq;
using AziendaAlberghieraVernazza.Models;
using AziendaAlberghieraVernazza.Stores;
using AziendaAlberghieraVernazza.Utils;

namespace AziendaAlberghieraVernazza.Services;

public class CameraService(CameraStore cameraStore)
{
    private readonly CameraStore _cameraStore = cameraStore;
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
        } while (AlbergoUtils.CheckString(tipo = Console.ReadLine()?.ToUpper(), "Il tipo non puó essere vuoto!"));
        
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
    
    public int? SelezionaCamera(List<Camera> camereDisponibili)
    {
        if (camereDisponibili.Count == 0)
        {
            Console.WriteLine("Nessuna camera disponibile per i criteri selezionati.");
            return null;
        }

        Console.WriteLine("Camere disponibili:");
        foreach (var camera in camereDisponibili)
        {
            Console.WriteLine($"Id: {camera.Id}, Numero Letti: {camera.NumeroLetti}");
        }

        Console.Write("Inserisci l'ID della camera desiderata: ");
        int idCamera;
        while (!int.TryParse(Console.ReadLine(), out idCamera) || camereDisponibili.All(c => c.Id != idCamera))
        {
            Console.WriteLine("ID non valido. Inserisci un ID valido: ");
        }

        return idCamera;
    }
    
    public List<Camera> FiltraCamereDisponibili(DateOnly dataArrivo, DateOnly dataPartenza, int numeroLetti)
    {
        var tutteLeCamere = _cameraStore.Get(); // funzione che restituisce tutte le camere
        var camereDisponibili = tutteLeCamere.Where(camera => camera.NumeroLetti == numeroLetti &&
                                                              !_cameraStore.CameraOccupata(camera.Id, dataArrivo,
                                                                  dataPartenza)).ToList();  //funzione che vede se le camere che ci stanno hanno il numero dei letti richiesti e se sono occupate in quella data richiamando la funzione CameraOccupata del CameraStore
        return camereDisponibili;
    }
}