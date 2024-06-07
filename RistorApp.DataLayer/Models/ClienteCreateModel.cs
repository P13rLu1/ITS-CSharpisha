using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RistorApp.DataLayer.Models
{
    public class ClienteCreateModel(string nome, string cognome, DateTime dataNascita)
    {
        [JsonIgnore]public int Id { get; set; }
        
        [Required, StringLength(20, ErrorMessage = "Il nome non può avere più di 20 caratteri.")] public string Nome { get; set; } = nome;

        [Required, StringLength(20, ErrorMessage = "Il cognome non può avere più di 20 caratteri.")] public string Cognome { get; set; } = cognome;

        [Required, DataType(DataType.Date)] public DateTime DataNascita { get; set; } = dataNascita;
    }
}