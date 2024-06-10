using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigliettApp.DataLayer.Models;

[Table("spettacolo")]public class Spettacolo(string titolo, string descrizione, DateTime dataOra, int durata, decimal prezzoBase)
{
    // Id = _contatore++;

    [Key, Column("id")]public int Id { get; set; }
    // private static int _contatore = 1;
    
    [Required, Column("titolo"), StringLength(200, ErrorMessage = "Il nome non può avere più di 20 caratteri.")]public string Titolo { get; set; } = titolo;

    [Column("descrizione"), StringLength(1000, ErrorMessage = "Descrizione troppo lunga!")]public string? Descrizione { get; set; } = descrizione;
    
    [Required, Column("dataOra"), DataType(DataType.Date)]public DateTime DataOra { get; set; } = dataOra;
    
    [Required,Column("durata")]public int Durata { get; set; } = durata;
    
    [Required, Column("prezzo"), Range(0, 1000, ErrorMessage = "Il prezzo deve essere compreso tra 0 e 1000.")]public decimal PrezzoBase { get; set; } = prezzoBase;
}