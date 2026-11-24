namespace GastosAlDia.Modelos;

public class CategoriaGasto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public List<Gasto> Gastos { get; set; } = [];
    public override string ToString() => Nombre;
}