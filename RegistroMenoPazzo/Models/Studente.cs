using System;

namespace RegistroMenoPazzo.Models;

internal class Studente
{
    internal string? Nome { get; set; }
    internal string? Cognome { get; set; }
    internal DateOnly DataDiNascita { get;}
    internal string? Classe { get; set; }
    internal int Id { get;}

    internal Studente(string? nome, string? cognome, DateOnly dataDiNascita, string? classe)
    {
        Nome = nome;
        Cognome = cognome;
        DataDiNascita = dataDiNascita;
        Classe = classe;
        Id = new Random().Next(1, 1000);
    }
}