//fatto dall'esercizio 9 perché il 10 ancora é da finire

using Microsoft.Extensions.DependencyInjection;
using RegistroMenoPazzo.Services; //aggiunto per poter usare RegistroService in Program.cs 

namespace RegistroMenoPazzo; 

public static class Program
{
    public static void Main() //metodo Main che avvia il programma
    {
        // var registro = new RegistroService(); //crea un'istanza di RegistroService e la assegna a registro 
        // registro.MenuPrincipale(); //chiama il metodo MenuPrincipale di registro

        var sc = new ServiceCollection();
        sc.AddScoped<RegistroService>();
        
        var sp = sc.BuildServiceProvider();
        var registro = sp.GetService<RegistroService>();
        
        registro?.MenuPrincipale();
    }
}