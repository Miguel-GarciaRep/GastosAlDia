using GastosAlDia.Modelos;
using Microsoft.EntityFrameworkCore;

namespace GastosAlDia.Datos;

public class GastosAlDiaContext : DbContext
{
    public DbSet<CategoriaGasto> CategoriasGasto => Set<CategoriaGasto>();
    public DbSet<Gasto> Gastos => Set<Gasto>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=gastosaldia.db");
}