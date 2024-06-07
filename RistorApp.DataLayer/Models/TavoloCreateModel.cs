using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RistorApp.DataLayer.Models;

public class TavoloCreateModel(int numeroPersone, string posizione)
{
    [JsonIgnore] public int Id { get; set; }
    
    [Required, Range(1, 10, ErrorMessage = "Il numero di persone deve essere compreso tra 1 e 10.")] public int NumeroPersone { get; set; } = numeroPersone;
    [Required, StringLength(10, ErrorMessage = "la posizione non puó avere piú di 10 caratteri")]public string Posizione { get; set; } = posizione;
}