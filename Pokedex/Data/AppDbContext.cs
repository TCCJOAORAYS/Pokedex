using Microsoft.EntityFrameworkCore;
using Pokedex.Models;

namespace Pokedex.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
    }

    public DbSet<Genero> Generos { get; set; }
    public DbSet<Pokemon> Pokemons { get; set; }
    public DbSet<PokemonTipo> PokemonTipos { get; set; }
    public DbSet<Regiao> Regioes { get; set; }
    public DbSet<Tipo> Tipos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PokemonTipo>()
            .HasKey(pt => new { pt.PokemonNumero, pt.TipoId });

        modelBuilder.Entity<PokemonTipo>()
            .HasOne(pt => pt.Pokemon)
            .WithMany(p => p.Tipos)
            .HasForeignKey(pt => pt.PokemonNumero);
        
        modelBuilder.Entity<PokemonTipo>()
            .HasOne(pt => pt.Tipo)
            .WithMany(t => t.Pokemons)
            .HasForeignKey(pt => pt.TipoId);
    }
}
