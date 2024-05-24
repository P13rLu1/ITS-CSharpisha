//fatto dall'esercizio 9 perché il 10 ancora é da finire
using RegistroMenoPazzo.Services;

namespace RegistroMenoPazzo;

public abstract class Program
{
    public static void Main()
    {
        var registro = new RegistroService();
        RegistroService.MenuPrincipale();
    }
}