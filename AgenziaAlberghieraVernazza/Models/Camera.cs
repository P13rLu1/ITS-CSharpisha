namespace AziendaAlberghieraVernazza.Models;

public class Camera
{
    public int Id { get; set; }
    private static int _contatore = 1;
    public int Numero { get; set; }
    public string Tipo { get; set; }
    public int NumeroLetti { get; set; }
    
    public Camera(int numero, string tipo, int numeroLetti)
    {
        Numero = numero;
        Tipo = tipo;
        NumeroLetti = numeroLetti;
        Id = _contatore++;
    }
}