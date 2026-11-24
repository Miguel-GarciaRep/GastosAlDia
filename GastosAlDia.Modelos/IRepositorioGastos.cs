namespace GastosAlDia.Modelos;

public interface IRepositorioGastos
{
    List<Gasto> ObtenerGastos();
    List<CategoriaGasto> ObtenerCategorias();
    void Agregar(Gasto gasto);
    void Actualizar(Gasto gasto);
    void Eliminar(int id);
}