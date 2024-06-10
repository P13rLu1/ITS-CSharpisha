using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigliettApp.DataLayer.Models
{
    [Table("prenotazione")]public class Prenotazione
    {
        // Id = ++_contatore;

        // private static int _contatore;

        // public Prenotazione(int idCliente, int idTavolo, DateTime dataPrenotazione)
        // {
        //     // Id = ++_contatore;
        //     IdCliente = idCliente;
        //     IdTavolo = idTavolo;
        //     Data = dataPrenotazione;
        // }
        
        [Key, Column("id")]
        public int Id { get; set; } 

        [Required, Column("idCliente")]
        public int IdCliente { get; set; }

        [ForeignKey(nameof(IdCliente))] public Cliente FkClienteNavigation { get; set; }

        [Required, Column("idSpettacolo")]
        public int IdSpettacolo { get; set; }

        [ForeignKey(nameof(IdSpettacolo))] public Spettacolo FkSpettacoloNavigation { get; set; }
        
        [Required, Column("Posto")] public string Posto { get; set; }
        
        [Required, Column("prezzo"), Range(0, 1000, ErrorMessage = "Il prezzo deve essere compreso tra 0 e 1000.")]public decimal PrezzoFinale { get; set; }
        
        [Required, Column("dataPrenotazione"), DefaultValue(null), DataType(DataType.Date)]
        public DateTime DataOra { get; set; }
    }
}