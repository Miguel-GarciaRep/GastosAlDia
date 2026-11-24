# Integrante 3: Ventanas y Documentación

## Responsabilidad
Implementar la interfaz de usuario (Windows Forms) y mantener la documentación del proyecto.

## Archivos incluidos

### GastosAlDia.Escritorio/
- `FormPrincipal.cs` + `FormPrincipal.Designer.cs` - Ventana principal
- `FormGasto.cs` + `FormGasto.Designer.cs` - Formulario registrar/editar gasto
- `Program.cs` - Punto de entrada
- `GastosAlDia.Escritorio.csproj` - Proyecto Windows Forms (OutputType WinExe)

### Documentación (en carpeta raíz del proyecto original)
- `01_Requerimientos_GastosAlDia.docx` - Documento de requerimientos
- `02_Cronograma_GastosAlDia.xlsx` - Cronograma en Excel
- `03_GastosAlDia.fprg` - Diagrama en Flowgorithm
- `04_Codigo_Flowgorithm_CSharp.cs` - Código generado desde Flowgorithm
- `05_Afiche_GastosAlDia.pptx` - Afiche del proyecto
- `boceto_pantalla_app.png` - Boceto de pantallas
- `captura_diagrama_flowgorithm.png` - Captura del diagrama

## Qué implementa la UI

### FormPrincipal
- `DataGridView` (`dgvGastos`) muestra lista de gastos
- Botones: **Registrar gasto**, **Editar**, **Eliminar**
- Labels de resumen: **Total por categoría** + **Total mes actual**
- `DataBindingComplete` oculta columnas técnicas (`CategoriaGastoId`, `CategoriaGasto`) y formatea `Monto` (C2) y `Fecha` (dd/MM/yyyy)

### FormGasto
- `txtDescripcion` - Texto obligatorio
- `numMonto` - Decimal > 0
- `dtpFecha` - DateTimePicker (formato dd/MM/yyyy, max hoy)
- `cmbCategoria` - ComboBox bound a `CategoriaGasto` (DisplayMember="Nombre", ValueMember="Id")
- `ErrorProvider` para validaciones sin cerrar la app
- Constructor overload: `new FormGasto(categorias)` para nuevo, `new FormGasto(categorias, gastoExistente)` para editar

### Patrón de uso
```csharp
// En FormPrincipal
private readonly ServicioGastos _servicio = new(new RepositorioEf());

// Registrar
using var form = new FormGasto(_servicio.Categorias());
if (form.ShowDialog(this) == DialogResult.OK && form.GastoCreado is not null)
{
    _servicio.Registrar(form.GastoCreado.Descripcion, form.GastoCreado.Monto, form.GastoCreado.Fecha, form.GastoCreado.CategoriaGastoId);
    CargarGastos();
    ActualizarResumenes();
}

// Editar
using var form = new FormGasto(_servicio.Categorias(), gastoSeleccionado);
if (form.ShowDialog(this) == DialogResult.OK && form.GastoCreado is not null)
{
    _servicio.Actualizar(form.GastoCreado);
    CargarGastos();
    ActualizarResumenes();
}
```

## Reglas a seguir
- **Un formulario = 3 archivos** (`.cs`, `.Designer.cs`, `.resx`): solo tú tocas estos
- **No tocar** Modelos, Datos, ni Servicios
- `DbContext` **nunca** en formularios (solo `ServicioGastos` + `RepositorioEf`)
- Validaciones en UI con `ErrorProvider` + try/catch → no cierra la app con datos inválidos
- Compilar antes de confirmar (`Ctrl+Mayús+B`)
- Mensajes de commit: `Agrega botón Editar en FormPrincipal`, `Valida categoria obligatoria en FormGasto`, etc.

## Git - Rutina diaria
1. **Al llegar**: Sincronizar
2. Trabajar solo en tus archivos
3. Compilar (`Ctrl+Mayús+B`)
4. Confirmar con mensaje claro
5. Sincronizar para enviar
6. **Al irse**: Sincronizar

## Documentación a mantener
- Actualizar `02_Cronograma_GastosAlDia.xlsx` con avances del equipo
- Verificar que `01_Requerimientos_GastosAlDia.docx` coincida con lo implementado
- `03_GastosAlDia.fprg` y `05_Afiche_GastosAlDia.pptx` para entrega final