using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigliettApp.DataLayer.Models;

[Table("cliente")]
public class Cliente(string nome, string cognome, string email, string telefono)
{
    // Id = _contatore++;

    [Key, Column("id")]public int Id { get; set; } 
    // private static int _contatore = 1;

    [Required, Column("nome"), MaxLength(100), StringLength(20, ErrorMessage = "Il nome non può avere più di 20 caratteri.")]public string Nome { get; set; } = nome;

    [Required, Column("cognome"), MaxLength(100), StringLength(20, ErrorMessage = "Il cognome non può avere più di 20 caratteri.")]public string Cognome { get; set; } = cognome;
    
    [Required, Column("email")]public string Email { get; set; } = email;
    
    [Required, Column("telefono")]public string Telefono { get; set; } = telefono;
}