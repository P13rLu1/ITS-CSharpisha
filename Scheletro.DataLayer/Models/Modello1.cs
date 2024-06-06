using System.ComponentModel.DataAnnotations;

namespace Scheletro.DataLayer.Models;

public class Modello1
{
    public int Qualcosa { get; set; }
    [StringLength(20, ErrorMessage = "Il nome non può avere più di 20 caratteri.")] public string Altro { get; set; }
    [StringLength(20, ErrorMessage = "Il nome non può avere più di 20 caratteri.")] public string Altro2 { get; set; }
    
    public Modello1(int qualcosa, string altro, string altro2)
    {
        Qualcosa = qualcosa;
        Altro = altro;
        Altro2 = altro2;
    }
}