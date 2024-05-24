﻿using System;

namespace RegistroMenoPazzo.Services;

internal class RegistroService
{ 
    private readonly StudenteService _studenteService = new StudenteService();

    internal void MenuPrincipale()
    {
        Console.WriteLine("Benvenuto nel registro elettronico!");
        string? scelta;
        do
        {
            Console.Write(
                "1. Visualizza registro\n2. Aggiungi studente\n3. Modifica studente\n4. Cancella studente\n5. Esci\nScelta: ");
            scelta = Console.ReadLine();
            switch (scelta)
            {
                case "1":
                    _studenteService.VisualizzazioneStudenti();
                    break;
                case "2": 
                    _studenteService.AggiungiStudente();
                    break;
                case "3":
                    _studenteService.ModificaStudente();
                    break;
                case "4":
                    _studenteService.CancellaStudente();
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