using System;
using System.ComponentModel.DataAnnotations;

namespace RistorApp.DataLayer.Models
{
    public class ClienteCreateModel(string nome, string cognome, DateTime? dataNascita)
    {
        [StringLength(20, ErrorMessage = "Il nome non può avere più di 20 caratteri.")]
        public string Nome { get; set; } = nome;

        [StringLength(20, ErrorMessage = "Il cognome non può avere più di 20 caratteri.")]
        public string Cognome { get; set; } = cognome;

        public DateTime? DataNascita { get; set; } = dataNascita;
    }
}