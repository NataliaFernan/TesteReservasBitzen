using Microsoft.EntityFrameworkCore;
using ReservasRepository.Models;

namespace ReservasRepository;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Reserva> Reservas { get; set; } = null!;
    public DbSet<Usuario> Usuarios { get; set; } = null!;
    public DbSet<Sala> Salas { get; set; } = null!;
}