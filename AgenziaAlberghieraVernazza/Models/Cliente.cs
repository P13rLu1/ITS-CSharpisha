namespace AziendaAlberghieraVernazza.Models;

public class Cliente
{
    public int Id { get; set; }
    private static int _contatore = 1;
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string Email { get; set; }
    
    public Cliente(string nome, string cognome, string email)
    {
        Nome = nome;
        Cognome = cognome;
        Email = email;
        Id = _contatore++;
    }
}