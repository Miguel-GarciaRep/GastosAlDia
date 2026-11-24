using GastosAlDia.Modelos;
using Microsoft.EntityFrameworkCore;

namespace GastosAlDia.Datos;

public class RepositorioEf : IRepositorioGastos
{
    private readonly GastosAlDiaContext _db = new();

    public RepositorioEf()
    {
        _db.Database.EnsureCreated();
        if (!_db.CategoriasGasto.Any())
        {
            _db.CategoriasGasto.AddRange(
                new CategoriaGasto { Nombre = "Alimentación" },
                new CategoriaGasto { Nombre = "Transporte" },
                new CategoriaGasto { Nombre = "Entretenimiento" },
                new CategoriaGasto { Nombre = "Salud" },
                new CategoriaGasto { Nombre = "Otros" });
            _db.SaveChanges();
        }
    }

    public List<Gasto> ObtenerGastos() => _db.Gastos.Include(g => g.CategoriaGasto).OrderByDescending(g => g.Fecha).ToList();

    public List<CategoriaGasto> ObtenerCategorias() => _db.CategoriasGasto.OrderBy(c => c.Nombre).ToList();

    public void Agregar(Gasto gasto) { _db.Gastos.Add(gasto); _db.SaveChanges(); }

    public void Actualizar(Gasto gasto) { _db.Gastos.Update(gasto); _db.SaveChanges(); }

    public void Eliminar(int id)
    {
        var gasto = _db.Gastos.Find(id);
        if (gasto is null) return;
        _db.Gastos.Remove(gasto);
        _db.SaveChanges();
    }
}