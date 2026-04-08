sing System;

class Program
{
    static void Main()
    {
        // ===== CAPA DE DATOS: declarada FUERA del ciclo para persistir =====
        List<string>  nombresProductos = new List<string>();
        List<double>  preciosProductos = new List<double>();
        List<int>     cantidades       = new List<int>();
        List<double>  subtotales       = new List<double>();

        const double DESCUENTO_MINIMO  = 100000.0;
        const double DOMICILIO_MINIMO  = 10000.0;
        const double COSTO_DOMICILIO   = 1000.0;
        const double TASA_DESCUENTO    = 0.05;

        bool sistemaActivo = true;

        // ===== CAPA DE CONTROL: menú do-while =====
        do
        {
            Console.Clear();
            Console.WriteLine("===== TIENDA VALLE VERDE =====");
            Console.WriteLine("1. Registrar producto");
            Console.WriteLine("2. Ver reporte de compra");
            Console.WriteLine("3. Confirmar pedido y pagar");
            Console.WriteLine("0. Salir");
            Console.Write("\nOpción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                // ─── OPCIÓN 1: Registrar producto ───────────────────────────
                case "1":
                    Console.Write("Nombre del producto: ");
                    string nombre = Console.ReadLine();

                    // Guardia 1: formato numérico
                    Console.Write("Precio del producto: ");
                    string entradaPrecio = Console.ReadLine();
                    double precio;
                    if (!double.TryParse(entradaPrecio, out precio))
                    {
                        Console.WriteLine("Formato inválido. Solo se aceptan valores numéricos.");
                        Console.WriteLine("Presione Enter para continuar.");
                        Console.ReadLine();
                        break;
                    }
                    // Guardia 2: dominio del negocio
                    if (precio <= 0)
                    {
                        Console.WriteLine("El precio debe ser mayor a cero.");
                        Console.WriteLine("Presione Enter para continuar.");
                        Console.ReadLine();
                        break;
                    }

                    Console.Write("Cantidad: ");
                    string entradaCantidad = Console.ReadLine();
                    int cantidad;
                    if (!int.TryParse(entradaCantidad, out cantidad))
                    {
                        Console.WriteLine("Formato inválido. Solo se aceptan números enteros.");
                        Console.WriteLine("Presione Enter para continuar.");
                        Console.ReadLine();
                        break;
                    }
                    if (cantidad <= 0)
                    {
                        Console.WriteLine("La cantidad debe ser mayor a cero.");
                        Console.WriteLine("Presione Enter para continuar.");
                        Console.ReadLine();
                        break;
                    }

                    double subtotal = precio * cantidad;

                    // Almacenar en las listas
                    nombresProductos.Add(nombre);
                    preciosProductos.Add(precio);
                    cantidades.Add(cantidad);
                    subtotales.Add(subtotal);

                    Console.WriteLine($"Producto #{subtotales.Count} registrado: {nombre} — Subtotal: ${subtotal:F2}");
                    Console.WriteLine("Presione Enter para continuar.");
                    Console.ReadLine();
                    break;

                // ─── OPCIÓN 2: Reporte estadístico ──────────────────────────
                case "2":
                    if (subtotales.Count == 0)
                    {
                        Console.WriteLine("No hay productos registrados aún.");
                        Console.WriteLine("Presione Enter para continuar.");
                        Console.ReadLine();
                        break;
                    }

                    // Acumuladores locales — se reinician en cada reporte
                    double totalCompra    = 0.0;
                    double subtotalMaximo = double.MinValue;
                    double subtotalMinimo = double.MaxValue;
                    int    productosMas2  = 0;

                    for (int i = 0; i < subtotales.Count; i++)
                    {
                        double val = subtotales[i];
                        totalCompra += val;
                        if (val > subtotalMaximo) subtotalMaximo = val;
                        if (val < subtotalMinimo) subtotalMinimo = val;
                        if (cantidades[i] > 2)    productosMas2++;
                    }

                    double promedio = totalCompra / subtotales.Count;

                    Console.WriteLine("\n===== RESUMEN DE PRODUCTOS =====");
                    for (int i = 0; i < subtotales.Count; i++)
                    {
                        Console.WriteLine($"  {i + 1}. {nombresProductos[i]} " +
                                          $"| Precio: ${preciosProductos[i]:F2} " +
                                          $"| Cantidad: {cantidades[i]} " +
                                          $"| Subtotal: ${subtotales[i]:F2}");
                    }

                    Console.WriteLine($"\nTotal de productos registrados : {subtotales.Count}");
                    Console.WriteLine($"Total parcial de la compra     : ${totalCompra:F2}");
                    Console.WriteLine($"Subtotal promedio              : ${promedio:F2}");
                    Console.WriteLine($"Subtotal más alto              : ${subtotalMaximo:F2}");
                    Console.WriteLine($"Subtotal más bajo              : ${subtotalMinimo:F2}");
                    Console.WriteLine($"Productos con cantidad > 2     : {productosMas2}");

                    if (totalCompra >= DESCUENTO_MINIMO)
                        Console.WriteLine($"[DESCUENTO] Aplica 5% por compra >= $100.000");
                    if (totalCompra >= DOMICILIO_MINIMO)
                        Console.WriteLine("[DOMICILIO] Aplica domicilio GRATIS");
                    else
                        Console.WriteLine("[DOMICILIO] Costo de domicilio: $1.000");

                    Console.WriteLine("Presione Enter para continuar.");
                    Console.ReadLine();
                    break;

                // ─── OPCIÓN 3: Confirmar pedido ─────────────────────────────
                case "3":
                    if (subtotales.Count == 0)
                    {
                        Console.WriteLine("No hay productos en el carrito.");
                        Console.WriteLine("Presione Enter para continuar.");
                        Console.ReadLine();
                        break;
                    }

                    double totalFinal = 0.0;
                    for (int i = 0; i < subtotales.Count; i++)
                        totalFinal += subtotales[i];

                    Console.WriteLine($"\nTotal parcial: ${totalFinal:F2}");

                    if (totalFinal >= DESCUENTO_MINIMO)
                    {
                        double descuento = totalFinal * TASA_DESCUENTO;
                        totalFinal -= descuento;
                        Console.WriteLine($"Descuento del 5% aplicado: -${descuento:F2}");
                    }

                    if (totalFinal >= DOMICILIO_MINIMO)
                    {
                        Console.WriteLine("Domicilio GRATIS.");
                    }
                    else
                    {
                        totalFinal += COSTO_DOMICILIO;
                        Console.WriteLine($"Domicilio con costo de ${COSTO_DOMICILIO:F2}.");
                    }

                    Console.Write($"\nTOTAL A PAGAR: ${totalFinal:F2}");
                    Console.Write("\n¿Confirma método de pago? (si/no): ");
                    string confirmaPago = Console.ReadLine();

                    if (confirmaPago == "si")
                    {
                        Console.WriteLine("Pedido confirmado. ¡Gracias por comprar en TIENDA VALLE VERDE!");
                        sistemaActivo = false;
                    }
                    else if (confirmaPago == "no")
                    {
                        Console.WriteLine("El pedido queda en espera hasta confirmar el método de pago.");
                        Console.WriteLine("Presione Enter para continuar.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Respuesta no válida. Presione Enter.");
                        Console.ReadLine();
                    }
                    break;

                // ─── OPCIÓN 0: Salir ─────────────────────────────────────────
                case "0":
                    sistemaActivo = false;
                    Console.WriteLine("Gracias por comprar en TIENDA VALLE VERDE.");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Presione Enter.");
                    Console.ReadLine();
                    break;
            }

        } while (sistemaActivo);
    }
}
