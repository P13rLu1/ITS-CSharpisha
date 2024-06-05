using System.ComponentModel.DataAnnotations;

namespace RistorApp.DataLayer.Models;

public class TavoloCreateModel(int numeroPersone, string posizione)
{
    [Range(1, 10, ErrorMessage = "Il numero di persone deve essere compreso tra 1 e 10.")] 
    public int NumeroPersone { get; set; } = numeroPersone;
    public string Posizione { get; set; } = posizione;
}