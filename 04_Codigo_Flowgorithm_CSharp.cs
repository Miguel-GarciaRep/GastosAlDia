using System;

// ============================================================================
// PROYECTO INTEGRADOR SEMANA 8 - HERRAMIENTAS TIC (ADSO - SENA)
// Aplicacion: GastosAlDia
// Equipo: Equipo GastosAlDia
// Analista Logico: David Velasquez Alarcon
// Codigo generado desde el visor de codigo de Flowgorithm (C#) con comentarios
// ============================================================================

public class GastosAlDiaProgram
{
    public static void Main(string[] args)
    {
        // 1. Declaracion de variables principales
        double presupuestoInicial;
        double ingresoExtra;
        double montoGasto;
        double totalIngresos;
        double totalGastos;
        double saldo;
        double gastoTransporte;
        double gastoComida;
        double gastoInternet;
        double gastoEstudio;
        double gastoDiversion;
        double mayorGasto;
        double porcentajeGastado;
        int opcion;
        int categoria;
        string categoriaMayor;

        // 2. Inicializacion de acumuladores en cero
        totalGastos = 0;
        gastoTransporte = 0;
        gastoComida = 0;
        gastoInternet = 0;
        gastoEstudio = 0;
        gastoDiversion = 0;
        opcion = -1;

        // 3. Pantalla de bienvenida intuitiva
        Console.WriteLine("==================================================");
        Console.WriteLine("            BIENVENIDO A: GastosAlDia");
        Console.WriteLine("         Equipo GastosAlDia - ADSO SENA");
        Console.WriteLine("==================================================");
        Console.WriteLine("Controla tus ingresos y gastos del mes de forma facil.");
        Console.WriteLine("PASO 1: Ingresa tu presupuesto inicial del mes en pesos (ejemplo: 250000):");
        presupuestoInicial = inputValue();

        // === CICLO (WHILE) #1: Validacion de presupuesto inicial ===
        // Evita que el usuario ingrese valores negativos o cero.
        while (presupuestoInicial <= 0)
        {
            Console.WriteLine("ERROR: El presupuesto debe ser mayor a $0. Escribe un valor valido (ej: 250000):");
            presupuestoInicial = inputValue();
        }

        totalIngresos = presupuestoInicial;
        saldo = presupuestoInicial;

        // === CICLO (WHILE) #2: Ciclo principal del menu interactivo ===
        // Mantiene la aplicacion activa permitiendo registrar multiples movimientos
        // hasta que el usuario elija la opcion 0 (Finalizar y ver reporte).
        while (opcion != 0)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("MENU PRINCIPAL GastosAlDia | Saldo disponible: $" + saldo);
            Console.WriteLine("1. Registrar un gasto");
            Console.WriteLine("2. Agregar un ingreso extra");
            Console.WriteLine("3. Ver resumen parcial por categorias");
            Console.WriteLine("0. Finalizar y ver reporte final del mes");
            Console.WriteLine("Escribe el numero de tu opcion (0 a 3):");
            opcion = (int)inputValue();

            // === DECISION (IF / ELSE) #1: Evaluacion de la opcion del menu ===
            if (opcion == 1)
            {
                Console.WriteLine("--- CATEGORIAS DE GASTO ---");
                Console.WriteLine("1. Transporte | 2. Comida | 3. Internet/Datos | 4. Estudio | 5. Diversion");
                Console.WriteLine("Elige el numero de la categoria (1 a 5):");
                categoria = (int)inputValue();

                // === CICLO (WHILE) #3: Validacion de categoria (rango 1 a 5) ===
                while (categoria < 1 || categoria > 5)
                {
                    Console.WriteLine("Categoria invalida. Escribe un numero entre 1 y 5:");
                    categoria = (int)inputValue();
                }

                Console.WriteLine("Ingresa el valor del gasto en pesos (ejemplo: 15000):");
                montoGasto = inputValue();

                // === CICLO (WHILE) #4: Validacion de monto de gasto positivo ===
                while (montoGasto <= 0)
                {
                    Console.WriteLine("ERROR: El gasto debe ser mayor a $0. Ingresa un monto valido:");
                    montoGasto = inputValue();
                }

                // === DECISION (IF / ELSE) #2: Clasificacion del gasto por categoria ===
                if (categoria == 1)
                {
                    gastoTransporte = gastoTransporte + montoGasto;
                }
                else
                {
                    if (categoria == 2)
                    {
                        gastoComida = gastoComida + montoGasto;
                    }
                    else
                    {
                        if (categoria == 3)
                        {
                            gastoInternet = gastoInternet + montoGasto;
                        }
                        else
                        {
                            if (categoria == 4)
                            {
                                gastoEstudio = gastoEstudio + montoGasto;
                            }
                            else
                            {
                                gastoDiversion = gastoDiversion + montoGasto;
                            }
                        }
                    }
                }

                totalGastos = totalGastos + montoGasto;
                saldo = totalIngresos - totalGastos;
                Console.WriteLine("Gasto registrado con exito. Saldo restante: $" + saldo);

                // === DECISION (IF) #3: Alerta inmediata si el saldo queda negativo ===
                if (saldo < 0)
                {
                    Console.WriteLine("ALERTA: Superaste tu presupuesto por $" + (saldo * -1));
                }
            }
            else
            {
                if (opcion == 2)
                {
                    Console.WriteLine("Ingresa el valor del ingreso extra en pesos (ejemplo: 50000):");
                    ingresoExtra = inputValue();

                    // === CICLO (WHILE) #5: Validacion de ingreso extra positivo ===
                    while (ingresoExtra <= 0)
                    {
                        Console.WriteLine("ERROR: El ingreso debe ser mayor a $0. Ingresa un valor valido:");
                        ingresoExtra = inputValue();
                    }

                    totalIngresos = totalIngresos + ingresoExtra;
                    saldo = totalIngresos - totalGastos;
                    Console.WriteLine("Ingreso agregado. Nuevo saldo disponible: $" + saldo);
                }
                else
                {
                    if (opcion == 3)
                    {
                        Console.WriteLine("--- RESUMEN PARCIAL GastosAlDia ---");
                        Console.WriteLine("Ingresos totales: $" + totalIngresos + " | Gastos totales: $" + totalGastos + " | Saldo: $" + saldo);
                        Console.WriteLine("Transporte: $" + gastoTransporte + " | Comida: $" + gastoComida + " | Internet: $" + gastoInternet + " | Estudio: $" + gastoEstudio + " | Diversion: $" + gastoDiversion);
                    }
                    else
                    {
                        // === DECISION (IF) #4: Control de opciones de menu inexistentes ===
                        if (opcion != 0)
                        {
                            Console.WriteLine("Opcion no valida. Por favor escribe 1, 2, 3 o 0 para salir.");
                        }
                    }
                }
            }
        }

        // === DECISIONES (IF) #5: Identificacion de la categoria con mayor gasto ===
        mayorGasto = gastoTransporte;
        categoriaMayor = "Transporte";
        if (gastoComida > mayorGasto)
        {
            mayorGasto = gastoComida;
            categoriaMayor = "Comida";
        }
        if (gastoInternet > mayorGasto)
        {
            mayorGasto = gastoInternet;
            categoriaMayor = "Internet / Datos";
        }
        if (gastoEstudio > mayorGasto)
        {
            mayorGasto = gastoEstudio;
            categoriaMayor = "Estudio / Materiales";
        }
        if (gastoDiversion > mayorGasto)
        {
            mayorGasto = gastoDiversion;
            categoriaMayor = "Diversion";
        }

        porcentajeGastado = (totalGastos * 100) / totalIngresos;

        // 4. Impresion del reporte final del mes
        Console.WriteLine("==================================================");
        Console.WriteLine("           REPORTE FINAL - GastosAlDia");
        Console.WriteLine("==================================================");
        Console.WriteLine("Total Ingresos del mes: $" + totalIngresos);
        Console.WriteLine("Total Gastado del mes:  $" + totalGastos + " (" + porcentajeGastado + "% del presupuesto)");
        Console.WriteLine("Saldo Final Disponible: $" + saldo);
        Console.WriteLine("--- Desglose por Categoria ---");
        Console.WriteLine("1. Transporte: $" + gastoTransporte);
        Console.WriteLine("2. Comida: $" + gastoComida);
        Console.WriteLine("3. Internet/Datos: $" + gastoInternet);
        Console.WriteLine("4. Estudio: $" + gastoEstudio);
        Console.WriteLine("5. Diversion: $" + gastoDiversion);

        // === DECISION (IF / ELSE) #6: Mostrar mayor gasto y recomendacion final ===
        if (mayorGasto > 0)
        {
            Console.WriteLine("CATEGORIA CON MAYOR GASTO: " + categoriaMayor + " ($" + mayorGasto + ")");
        }
        else
        {
            Console.WriteLine("No registraste gastos durante este mes.");
        }

        if (saldo < 0)
        {
            Console.WriteLine("CONSEJO: Terminaste el mes en deficit. Revisa tus gastos en " + categoriaMayor + ".");
        }
        else
        {
            if (porcentajeGastado >= 80)
            {
                Console.WriteLine("CONSEJO: Estuviste muy cerca del limite (80% o mas). Intenta ahorrar un poco mas.");
            }
            else
            {
                Console.WriteLine("FELICITACIONES: Manejaste muy bien tu presupuesto mensual en GastosAlDia.");
            }
        }
        Console.WriteLine("Gracias por usar GastosAlDia.");
    }

    // Funcion auxiliar generada por Flowgorithm para lectura segura de numeros
    private static double inputValue()
    {
        double result;
        while (!double.TryParse(Console.ReadLine(), out result))
        {
            Console.WriteLine("Entrada invalida: por favor ingresa un valor numerico:");
        }
        return result;
    }
}
