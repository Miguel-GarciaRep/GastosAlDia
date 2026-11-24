# Integrante 1: Modelos y Datos

## Responsabilidad
Implementar las entidades del dominio, la interfaz del repositorio, el DbContext y la implementación con Entity Framework Core.

## Archivos incluidos

### GastosAlDia.Modelos/
- `CategoriaGasto.cs` - Entidad de la tabla 1 (la que se elige en ComboBox)
- `Gasto.cs` - Entidad de la tabla 2 (la que guarda los movimientos, con relación a CategoriaGasto)
- `IRepositorioGastos.cs` - Contrato del repositorio (interfaz)
- `GastosAlDia.Modelos.csproj` - Proyecto de biblioteca de clases

### GastosAlDia.Datos/
- `GastosAlDiaContext.cs` - DbContext con DbSet<CategoriaGasto> y DbSet<Gasto>, configuración SQLite
- `RepositorioEf.cs` - Implementación de IRepositorioGastos usando EF Core
  - `ObtenerGastos()` con Include para cargar CategoriaGasto
  - `ObtenerCategorias()` ordenadas por nombre
  - `Agregar()`, `Actualizar()`, `Eliminar()`
  - Datos iniciales: 5 categorías (Alimentación, Transporte, Entretenimiento, Salud, Otros)
- `GastosAlDia.Datos.csproj` - Proyecto con referencia a Modelos + paquete `Microsoft.EntityFrameworkCore.Sqlite`

## Reglas a seguir
- **Un archivo por persona**: No tocar archivos de Servicios ni Ventanas
- **Solo el líder** agrega paquetes NuGet (ya está instalado `Microsoft.EntityFrameworkCore.Sqlite` 9.0.0)
- Compilar antes de confirmar: `Ctrl+Mayús+B`
- Mensajes de commit claros: `Agrega entidad Gasto`, `Implementa RepositorioEf`, etc.

## Cómo probar localmente
1. Abrir la solución completa `GastosAlDia.sln` (en la carpeta padre)
2. Compilar: debe compilar sin errores
3. Ejecutar: la app crea `gastosaldia.db` automáticamente

## Referencia rápida - Entidades

```csharp
// Tabla 1: CategoriaGasto (se elige en ComboBox)
public class CategoriaGasto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public List<Gasto> Gastos { get; set; } = [];
    public override string ToString() => Nombre;
}

// Tabla 2: Gasto (con relación)
public class Gasto
{
    public int Id { get; private set; }
    public string Descripcion { get; private set; }
    public decimal Monto { get; private set; }
    public DateTime Fecha { get; private set; }
    public int CategoriaGastoId { get; private set; }
    public CategoriaGasto? CategoriaGasto { get; private set; }
    
    public Gasto(string descripcion, decimal monto, DateTime fecha, int categoriaGastoId) { ... }
    public void CambiarDescripcion(string descripcion) { ... }
    public void CambiarMonto(decimal monto) { ... }
    public void CambiarFecha(DateTime fecha) { ... }
    public void CambiarCategoria(int categoriaGastoId) => CategoriaGastoId = categoriaGastoId;
}
```