using System;
using System.Collections.Generic;

namespace ITS_CSharpisha;

public class Docente : Persona
{
    public List<ClasseFrequentata> ClassiInsegnate { get; set; }
    
    public Docente(string? nome, string? cognome) : base(nome, cognome)
    {
        ClassiInsegnate = new List<ClasseFrequentata>();
    }
    
    public void AggiungiClasse(ClasseFrequentata classe)
    {
        ClassiInsegnate.Add(classe);
    }
    
    public override string ToString()
    {
        return $"Docente {Nome} {Cognome}";
    }
    
    public void InserisciVoto(Alunno alunno, Voto voto)
    {
        Console.WriteLine($"Il docente {Nome} {Cognome} ha inserito il voto {voto} all'alunno {alunno}");
        
        alunno.AggiungiVoto(voto);
    }
    
    public void InserisciVoti(Alunno alunno, List<Voto> voti)
    {
        foreach (var voto in voti)
        {
            InserisciVoto(alunno, voto);
        }
    }
}