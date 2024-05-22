namespace ITS_CSharpisha;

public class Persona
{
    public string? Nome { get; set; }
    public string? Cognome { get; set; }
    
    public Persona(string? nome, string? cognome)
    {
        Nome = nome;
        Cognome = cognome;
    }
    
    public override string ToString()
    {
        return $"{Nome} {Cognome}";
    }
}