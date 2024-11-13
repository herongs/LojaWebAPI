// Data/LojaContext.cs
using Microsoft.EntityFrameworkCore;

public class LojaContext : DbContext
{
    public LojaContext(DbContextOptions<LojaContext> options) : base(options) { }

    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Produto> Produtos { get; set; }
}
