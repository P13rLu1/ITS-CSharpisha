using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BigliettApp.DataLayer.Models;

public class SpettacoloCreateModel (string titolo, string? descrizione, DateTime dataOra, int durata, decimal prezzoBase)
{
    [JsonIgnore]public int Id { get; set; }
    
    [Required, StringLength(200, ErrorMessage = "Il titolo non può avere più di 20 caratteri")] public string Titolo { get; set; } = titolo;
    
    [StringLength(1000, ErrorMessage = "Descrizione Troppo Lunga!")]public string? Descrizione { get; set; } = descrizione;
    
    [Required, DataType(DataType.Date)] public DateTime DataOra { get; set; } = dataOra;
    
    [Required] public int Durata { get; set; } = durata;
    
    [Required] public decimal PrezzoBase { get; set; } = prezzoBase;
}