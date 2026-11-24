namespace GastosAlDia.Modelos;

public class Gasto
{
    public int Id { get; private set; }
    public string Descripcion { get; private set; }
    public decimal Monto { get; private set; }
    public DateTime Fecha { get; private set; }
    public int CategoriaGastoId { get; private set; }
    public CategoriaGasto? CategoriaGasto { get; private set; }

    public Gasto(string descripcion, decimal monto, DateTime fecha, int categoriaGastoId)
    {
        if (string.IsNullOrWhiteSpace(descripcion))
            throw new ArgumentException("La descripción es obligatoria.");
        if (monto <= 0)
            throw new ArgumentException("El monto debe ser mayor a cero.");
        if (fecha > DateTime.Now)
            throw new ArgumentException("La fecha no puede ser futura.");

        Descripcion = descripcion.Trim();
        Monto = monto;
        Fecha = fecha;
        CategoriaGastoId = categoriaGastoId;
    }

    public void CambiarDescripcion(string descripcion)
    {
        if (string.IsNullOrWhiteSpace(descripcion))
            throw new ArgumentException("La descripción es obligatoria.");
        Descripcion = descripcion.Trim();
    }

    public void CambiarMonto(decimal monto)
    {
        if (monto <= 0)
            throw new ArgumentException("El monto debe ser mayor a cero.");
        Monto = monto;
    }

    public void CambiarFecha(DateTime fecha)
    {
        if (fecha > DateTime.Now)
            throw new ArgumentException("La fecha no puede ser futura.");
        Fecha = fecha;
    }

    public void CambiarCategoria(int categoriaGastoId) => CategoriaGastoId = categoriaGastoId;
}