using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RistorApp.DataLayer.Models
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

        // [ForeignKey(nameof(IdCliente))] public Cliente FkClienteNavigation { get; set; }

        [Required, Column("idTavolo")]
        public int IdTavolo { get; set; }

        // [ForeignKey(nameof(IdTavolo))] public Tavolo FkTavoloNavigation { get; set; }
        
        [Required, Column("dataPrenotazione"), DefaultValue(null), DataType(DataType.Date)]
        public DateTime Data { get; set; }
    }
}