using System;

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

    public string Nome { get; set; }

    public string Cognome { get; set; }

    public DateTime DataNascita { get; set; }
}