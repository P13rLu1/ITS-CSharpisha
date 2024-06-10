using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BigliettApp.DataLayer.Models;

public class PrenotazioneCreateModel
{
    [JsonIgnore] public int Id { get; set; }
    
    [Required] public int IdCliente { get; set; }
    
    [Required] public int IdSpettacolo { get; set; }
    
    [Required] public string Posto { get; set; }
    
    [Required] public decimal PrezzoFinale { get; set; }
    
    [Required] public DateTime DataOra { get; set; }
}