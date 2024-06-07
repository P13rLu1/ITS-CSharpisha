using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RistorApp.DataLayer.Models;

public class PrenotazioneCreateModel
{
    [JsonIgnore] public int Id { get; set; }
    
    [Required] public int IdCliente { get; set; }
    
    [JsonIgnore] public int IdTavolo { get; set; }
    
    [Required, DataType(DataType.Date)] public DateTime Data { get; set; }
    
    [Required] public int PostiDesiderati { get; set; }
}