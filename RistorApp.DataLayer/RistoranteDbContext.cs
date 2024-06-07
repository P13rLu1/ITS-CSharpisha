using Microsoft.EntityFrameworkCore;
using RistorApp.DataLayer.Models;

namespace RistorApp.DataLayer;

public class RistoranteDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
            
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }

    public DbSet<Cliente> Clienti => Set<Cliente>();
    public DbSet<Tavolo> Tavoli => Set<Tavolo>();
    public DbSet<Prenotazione> Prenotazioni => Set<Prenotazione>();
}