using System;

namespace RegistroMenoPazzo.Utils;

public class RegistroUtils
{
    internal  void PremiUnTastoPerContinuare()
    {
        Console.WriteLine("Premi un tasto per continuare...");
        Console.ReadKey();
    }
    
    internal  bool CheckString(string? input, string message)
    {
        if (!string.IsNullOrWhiteSpace(input)) return false;
        Console.WriteLine(message);
        return true;

    }
    
    internal  bool CheckDates(DateOnly data, string message)
    {
        if (data != DateOnly.MinValue) return false;
        Console.WriteLine(message);
        return true;
    }
}