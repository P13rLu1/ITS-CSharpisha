using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RistorApp.DataLayer.Models
{
    [Table("prenotazione")]public sealed class Prenotazione(int idCliente, int idTavolo, DateTime dataPrenotazione)
    {
        // Id = ++_contatore;

        // private static int _contatore;

        [Key, Column("id")]public int Id { get; set; } 

        [Required, Column("fk_cliente")]public int IdCliente { get; set; } = idCliente;

        // [ForeignKey(nameof(IdCliente))] public Cliente FkClienteNavigation { get; set; }

        [Required, Column("fk_tavolo")]public int IdTavolo { get; set; } = idTavolo;

        // [ForeignKey(nameof(IdTavolo))] public Tavolo FkTavoloNavigation { get; set; }
        
        [Required, Column("data"), DefaultValue(null)]public DateTime Data { get; set; } = dataPrenotazione;
    }
}