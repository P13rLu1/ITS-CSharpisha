using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RistorApp.DataLayer.Models
{
    public class Prenotazione
    {
        public Prenotazione(int idCliente, int idTavolo, DateTime dataPrenotazione)
        {
            IdCliente = idCliente;
            IdTavolo = idTavolo;
            Data = dataPrenotazione;

            Id = ++_contatore;
        }

        private static int _contatore;

        public int Id { get; set; } 

        public int IdCliente { get; set; }

        public int IdTavolo { get; set; }
        
        [Required, DefaultValue(null)]public DateTime Data { get; set; }
    }
}