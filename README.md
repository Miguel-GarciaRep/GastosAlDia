# Integrante 2: Servicios

## Responsabilidad
Implementar la lógica de negocio en `ServicioGastos`, usando el repositorio inyectado por constructor. Aquí van las validaciones de reglas de negocio y los reportes LINQ.

## Archivos incluidos

### GastosAlDia.Servicios/
- `ServicioGastos.cs` - Lógica de negocio completa
- `GastosAlDia.Servicios.csproj` - Proyecto con referencia a Modelos

## Qué implementa `ServicioGastos`

### Métodos CRUD
```csharp
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
```

### Reportes LINQ (mínimo 1 requerido - hay 3)
```csharp
// 1. Gastos de hoy
public List<Gasto> GastosDeHoy() =>
    Listar().Where(g => g.Fecha.Date == DateTime.Today).ToList();

// 2. Total por categoría (GroupBy)
public List<ResumenCategoria> TotalPorCategoria() =>
    _repositorio.ObtenerGastos()
        .GroupBy(g => g.CategoriaGasto?.Nombre ?? "Sin categoría")
        .Select(grp => new ResumenCategoria(grp.Key, grp.Count(), grp.Sum(g => g.Monto)))
        .OrderByDescending(r => r.Total)
        .ToList();

// 3. Total del mes actual
public decimal TotalMesActual() =>
    Listar()
        .Where(g => g.Fecha.Month == DateTime.Today.Month && g.Fecha.Year == DateTime.Today.Year)
        .Sum(g => g.Monto);
```

### Record para reportes
```csharp
public record ResumenCategoria(string Categoria, int Cantidad, decimal Total);
```

## Reglas a seguir
- **No tocar** Modelos, Datos, ni Ventanas
- **Validaciones de negocio aquí** (no en el constructor de la entidad):
  - Fecha no futura
  - Monto > 0
  - Descripción obligatoria
  - Categoría seleccionada
- El constructor de `Gasto` solo valida reglas que **siempre** se cumplen (ej: "nombre no vacío")
- Reglas como "fecha no pasada" van en el **servicio** para no fallar al cargar datos históricos
- Inyección de dependencias: `ServicioGastos(IRepositorioGastos repositorio)`
- Compilar antes de confirmar
- Mensajes de commit: `Agrega reporte TotalPorCategoria`, `Valida fecha no futura en Actualizar`, etc.

## Cómo probar
La UI (Integrante 3) llama a estos métodos. Para probar aislado, crear test unitario o consola temporal.