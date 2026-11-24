using GastosAlDia.Modelos;

namespace GastosAlDia.Servicios;

public class ServicioGastos
{
    private readonly IRepositorioGastos _repositorio;

    public ServicioGastos(IRepositorioGastos repositorio) => _repositorio = repositorio;

    public List<CategoriaGasto> Categorias() => _repositorio.ObtenerCategorias();

    public List<Gasto> Listar() => _repositorio.ObtenerGastos();

    public void Registrar(string descripcion, decimal monto, DateTime fecha, int categoriaGastoId)
    {
        if (fecha > DateTime.Now)
            throw new ArgumentException("La fecha no puede ser futura.");
        _repositorio.Agregar(new Gasto(descripcion, monto, fecha, categoriaGastoId));
    }

    public void Actualizar(Gasto gasto)
    {
        if (gasto.Fecha > DateTime.Now)
            throw new ArgumentException("La fecha no puede ser futura.");
        _repositorio.Actualizar(gasto);
    }

    public void Eliminar(int id) => _repositorio.Eliminar(id);

    // Reporte 1: gastos de hoy
    public List<Gasto> GastosDeHoy() =>
        Listar().Where(g => g.Fecha.Date == DateTime.Today).ToList();

    // Reporte 2: total por categoría
    public List<ResumenCategoria> TotalPorCategoria() =>
        _repositorio.ObtenerGastos()
            .GroupBy(g => g.CategoriaGasto?.Nombre ?? "Sin categoría")
            .Select(grp => new ResumenCategoria(grp.Key, grp.Count(), grp.Sum(g => g.Monto)))
            .OrderByDescending(r => r.Total)
            .ToList();

    // Reporte 3: total del mes actual
    public decimal TotalMesActual() =>
        Listar()
            .Where(g => g.Fecha.Month == DateTime.Today.Month && g.Fecha.Year == DateTime.Today.Year)
            .Sum(g => g.Monto);
}

public record ResumenCategoria(string Categoria, int Cantidad, decimal Total);