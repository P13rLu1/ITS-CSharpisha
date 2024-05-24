using System;

namespace RegistroMenoPazzo.Utils;

public static class RegistroUtils
{
    internal static void PremiUnTastoPerContinuare()
    {
        Console.WriteLine("Premi un tasto per continuare...");
        Console.ReadKey();
    }
}