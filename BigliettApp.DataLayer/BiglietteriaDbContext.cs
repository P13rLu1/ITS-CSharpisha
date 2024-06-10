using BigliettApp.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BigliettApp.DataLayer;

public class BiglietteriaDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
    
    public DbSet<Cliente> Clienti { get; set; }
    public DbSet<Spettacolo> Spettacoli { get; set; }
    public DbSet<Prenotazione> Prenotazioni { get; set; }
}