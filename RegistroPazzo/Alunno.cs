using System;
using System.Collections.Generic;

namespace ITS_CSharpisha;

public class Alunno : Persona
{
    internal List<ClasseFrequentata> ClassiFrequentate { get; set; }
    
    public Alunno(string? nome, string? cognome) : base(nome, cognome)
    {
        ClassiFrequentate = new List<ClasseFrequentata>();
    }
    
    public void AggiungiClasse(ClasseFrequentata classe)
    {
        ClassiFrequentate.Add(classe);
    }
    
    public override string ToString()
    {
        return $"Alunno {Nome} {Cognome}";
    }
    
    public void AggiungiVoto(Voto voto)
    {
        Console.WriteLine($"L'alunno {Nome} {Cognome} ha ricevuto il voto {voto}");
    }
    
    public void AggiungiVoti(List<Voto> voti)
    {
        foreach (var voto in voti)
        {
            AggiungiVoto(voto);
        }
    }
}