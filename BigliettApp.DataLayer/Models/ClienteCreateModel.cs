using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BigliettApp.DataLayer.Models
{
    public class ClienteCreateModel(string nome, string cognome, string email, string telefono)
    {
        [JsonIgnore]public int Id { get; set; }
        
        [Required, StringLength(20, ErrorMessage = "Il nome non può avere più di 20 caratteri.")] public string Nome { get; set; } = nome;

        [Required, StringLength(20, ErrorMessage = "Il cognome non può avere più di 20 caratteri.")] public string Cognome { get; set; } = cognome;
        
        [Required] public string Email { get; set; } = email;
        
        [Required] public string Telefono { get; set; } = telefono;
    }
}