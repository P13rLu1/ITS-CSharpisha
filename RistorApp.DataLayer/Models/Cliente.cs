using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RistorApp.DataLayer.Models;

[Table("cliente")]
public class Cliente(string nome, string cognome, DateTime dataNascita)
{
    // Id = _contatore++;

    [Key, Column("id")]public int Id { get; set; } 
    // private static int _contatore = 1;

    [Required, Column("nome"), MaxLength(100), StringLength(20, ErrorMessage = "Il nome non può avere più di 20 caratteri.")]public string Nome { get; set; } = nome;

    [Required, Column("cognome"), MaxLength(100), StringLength(20, ErrorMessage = "Il cognome non può avere più di 20 caratteri.")]public string Cognome { get; set; } = cognome;

    [Required, Column("data_nascita")]public DateTime DataNascita { get; set; } = dataNascita;
}