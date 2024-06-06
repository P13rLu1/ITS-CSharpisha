using System;
using System.ComponentModel.DataAnnotations;

namespace RistorApp.DataLayer.Models;

public class Cliente
{
    public Cliente(string nome, string cognome, DateTime dataNascita)
    {
        Nome = nome;
        Cognome = cognome;
        DataNascita = dataNascita;
        Id = _contatore++;
    }

    public int Id { get; set; } 
    private static int _contatore = 1;

    [StringLength(20, ErrorMessage = "Il nome non può avere più di 20 caratteri.")]
    public string Nome { get; set; }

    [StringLength(20, ErrorMessage = "Il nome non può avere più di 20 caratteri.")]
    public string Cognome { get; set; }

    public DateTime DataNascita { get; set; }
}