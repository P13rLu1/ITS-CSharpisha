using System.ComponentModel.DataAnnotations;

namespace RistorApp.DataLayer.Models;

public class Tavolo
{
    public Tavolo(int numeroPersone, string posizione) 
    {
        NumeroPersone = numeroPersone;
        Posizione = posizione;
        Id = _contatore++;
    }

    public int Id { get; set; }
    private static int _contatore = 1;
    
    public int NumeroPersone { get; set; }
    public string Posizione { get; set; }
}