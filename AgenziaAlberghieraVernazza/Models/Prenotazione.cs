using System;

namespace AziendaAlberghieraVernazza.Models;

public class Prenotazione
{
    public int Id { get; set; }
    private static int _contatore = 1;
    public int IdCliente { get; set; }
    public int IdCamera { get; set; }
    public DateOnly DataArrivo { get; set; }
    public DateOnly DataPartenza { get; set; }
    public string Note { get; set; }
    
    public Prenotazione(int idCliente, int idCamera, DateOnly dataArrivo, DateOnly dataPartenza, string note)
    {
        IdCliente = idCliente;
        IdCamera = idCamera;
        DataArrivo = dataArrivo;
        DataPartenza = dataPartenza;
        Note = note;
        Id = _contatore++;
    }
}