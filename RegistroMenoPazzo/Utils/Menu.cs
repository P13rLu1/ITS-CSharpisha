using System;
using RegistroMenoPazzo.Models;
using RegistroMenoPazzo.Services;

namespace RegistroMenoPazzo.Utils;

public abstract class Menu
{
    internal static void MenuPrincipale()
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
                    Registro.VisualizzaRegistro();
                    break;
                case "2":
                    Studente.AggiungiStudente();
                    break;
                case "3":
                    Studente.ModificaStudente();
                    break;
                case "4":
                    Studente.CancellaStudente();
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