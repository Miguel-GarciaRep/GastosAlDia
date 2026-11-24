# GastosAlDia - Separado por Integrantes

Estructura para trabajo en equipo según la guía de la Sesión 12.

## 📁 Estructura de carpetas

```
GastosAlDia_Integrantes/
├── 1_Modelos_y_Datos/          → Miguel Angel

│   ├── GastosAlDia.Modelos/
│   │   ├── CategoriaGasto.cs
│   │   ├── Gasto.cs
│   │   ├── IRepositorioGastos.cs
│   │   └── GastosAlDia.Modelos.csproj
│   ├── GastosAlDia.Datos/
│   │   ├── GastosAlDiaContext.cs
│   │   ├── RepositorioEf.cs
│   │   └── GastosAlDia.Datos.csproj
│   └── README.md
│
├── 2_Servicios/                → Esteban Ramirez
│   ├── GastosAlDia.Servicios/
│   │   ├── ServicioGastos.cs
│   │   └── GastosAlDia.Servicios.csproj
│   └── README.md
│
└── 3_Ventanas_y_Documentacion/ → David Velasquez
    ├── GastosAlDia.Escritorio/
    │   ├── FormPrincipal.cs
    │   ├── FormPrincipal.Designer.cs
    │   ├── FormGasto.cs
    │   ├── FormGasto.Designer.cs
    │   ├── Program.cs
    │   └── GastosAlDia.Escritorio.csproj
    ├── 01_Requerimientos_GastosAlDia.docx
    ├── 02_Cronograma_GastosAlDia.xlsx
    ├── 03_GastosAlDia.fprg
    ├── 04_Codigo_Flowgorithm_CSharp.cs
    ├── 05_Afiche_GastosAlDia.pptx
    ├── boceto_pantalla_app.png
    ├── captura_diagrama_flowgorithm.png
    └── README.md
```

## 🔗 Cómo integrar

Cada integrante trabaja en su carpeta. Para unir todo en la solución completa:

1. El **líder** clona el repositorio del equipo y crea la solución base `GastosAlDia.sln` con 4 proyectos
2. Cada integrante **copia sus archivos** a los proyectos correspondientes en la solución compartida
3. **Solo el líder** agrega referencias entre proyectos y paquetes NuGet
4. Todos compilan, confirman y sincronizan

## ⚠️ Reglas de oro (recordatorio)

| Regla | Descripción |
|-------|-------------|
| **Un archivo por persona** | Un formulario = 3 archivos (`.cs`, `.Designer.cs`, `.resx`) |
| **Solo el líder** | Agrega proyectos, referencias y paquetes NuGet |
| **Sincronizar** | Al llegar, tras cada avance, al irse |
| **Compilar antes de confirmar** | `Ctrl+Mayús+B` - si no compila, no se confirma |
| **Mensajes claros** | `Agrega entidad Gasto`, no `cambios` o `asdf` |
| **Conflictos** | No borrar nada, avisar al instructor |

## ✅ Lista de verificación del jueves 26

- [ ] Se puede **registrar** gasto eligiendo categoría en ComboBox
- [ ] Se puede **eliminar** y **editar** un registro
- [ ] Ningún dato inválido cierra la aplicación (ErrorProvider + try/catch)
- [ ] Al menos **1 reporte LINQ** visible (hay 3: Hoy, Por categoría, Mes actual)
- [ ] Cada integrante tiene **commits propios**