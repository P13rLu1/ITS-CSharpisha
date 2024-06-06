using System.ComponentModel.DataAnnotations;

namespace Scheletro.DataLayer.Models;

public class Modello1CreateModel(int qualcosa, string altro, string altro2)
{
    public int Qualcosa { get; set; } = qualcosa;
    
    [StringLength(20, ErrorMessage = "Il nome non può avere più di 20 caratteri.")]public string Altro { get; set; } = altro;
    
    [StringLength(20, ErrorMessage = "Il cognome non può avere più di 20 caratteri.")]public string Altro2 { get; set; } = altro2;
}