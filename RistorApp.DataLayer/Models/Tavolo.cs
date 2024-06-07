using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RistorApp.DataLayer.Models;

[Table("tavoli")]public class Tavolo(int numeroPersone, string posizione)
{
    // Id = _contatore++;

    [Key, Column("id")]public int Id { get; set; }
    // private static int _contatore = 1;
    
    [Required, Column("numero_persone"), Range(1, 10, ErrorMessage = "Il numero di persone deve essere compreso tra 1 e 10.")] public int NumeroPersone { get; set; } = numeroPersone;

    [Required, Column("posizione"), MaxLength(50)]public string Posizione { get; set; } = posizione;
}