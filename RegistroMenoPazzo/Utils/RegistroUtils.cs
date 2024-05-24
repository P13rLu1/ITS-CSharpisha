using System;

namespace RegistroMenoPazzo.Utils;

public static class RegistroUtils
{
    internal static void PremiUnTastoPerContinuare()
    {
        Console.WriteLine("Premi un tasto per continuare...");
        Console.ReadKey();
    }
    
    internal static bool CheckString(string? input, string message)
    {
        if (!string.IsNullOrWhiteSpace(input)) return false;
        Console.WriteLine(message);
        return true;

    }
    
    internal static bool CheckDates(DateOnly data, string message)
    {
        if (data != DateOnly.MinValue) return false;
        Console.WriteLine(message);
        return true;
    }
}