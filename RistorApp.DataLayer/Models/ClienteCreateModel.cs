using System;
using System.ComponentModel.DataAnnotations;

namespace RistorApp.DataLayer.Models
{
    public class ClienteCreateModel(string nome, string cognome, DateTime? dataNascita)
    {
        [StringLength(6, ErrorMessage = "Il nome non può avere più di 6 caratteri.")]
        public string Nome { get; set; } = nome;

        [StringLength(6, ErrorMessage = "Il cognome non può avere più di 6 caratteri.")]
        public string Cognome { get; set; } = cognome;

        public DateTime? DataNascita { get; set; } = dataNascita;
    }
}