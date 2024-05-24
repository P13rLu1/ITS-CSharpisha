//fatto dall'esercizio 9 perché il 10 ancora é da finire
using System.Collections.Generic;
using RegistroMenoPazzo.Models;
using RegistroMenoPazzo.Services;

namespace RegistroMenoPazzo;

public abstract class Program
{
    internal static readonly List<Studente> Studenti = [];
    public static void Main()
    {
        RegistroService.MenuPrincipale();
    }
}