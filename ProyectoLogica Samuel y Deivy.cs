using System;
using System.Collections.Generic;

public class Producto
{
    public string Nombre;
    public double Precio;
}

public class Program
{
    // ─────────────────────────────────────────
    //  UI — Entrada / Salida por consola
    // ─────────────────────────────────────────

    /// <summary>
    /// Muestra el encabezado de bienvenida de la tienda.
    /// </summary>
    static void MostrarEncabezado()
    {
        Console.WriteLine("==================================");
        Console.WriteLine("      TIENDA VALLE VERDE");
        Console.WriteLine("==================================");
    }

    /// <summary>
    /// Muestra la lista de productos disponibles numerados con su precio.
    /// </summary>
    /// <param name="productos">Lista de productos a mostrar.</param>
    static void MostrarProductos(List<Producto> productos)
    {
        Console.WriteLine("\n======= PRODUCTOS DISPONIBLES =======");
        for (int i = 0; i < productos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {productos[i].Nombre} - ${productos[i].Precio}");
        }
    }

    /// <summary>
    /// Lee la entrada del usuario para seleccionar un producto (número o nombre).
    /// </summary>
    /// <returns>Texto ingresado por el usuario en minúsculas.</returns>
    static string LeerEntradaProducto()
    {
        Console.WriteLine("\nPuedes escribir el NUMERO o el NOMBRE del producto:");
        return Console.ReadLine().ToLower();
    }

    /// <summary>
    /// Lee la cantidad deseada del producto seleccionado.
    /// </summary>
    /// <returns>Cantidad ingresada por el usuario.</returns>
    static int LeerCantidad()
    {
        Console.WriteLine("Ingrese la cantidad:");
        return Convert.ToInt32(Console.ReadLine());
    }

    /// <summary>
    /// Muestra el resumen del producto agregado y su subtotal.
    /// </summary>
    /// <param name="producto">Producto seleccionado.</param>
    /// <param name="subtotal">Subtotal calculado para ese producto.</param>
    static void MostrarSubtotal(Producto producto, double subtotal)
    {
        Console.WriteLine($"\nProducto: {producto.Nombre}");
        Console.WriteLine($"Subtotal: ${subtotal}");
    }

    /// <summary>
    /// Pregunta al usuario si desea seguir agregando productos.
    /// </summary>
    /// <returns>True si el usuario responde "si".</returns>
    static bool PreguntarContinuar()
    {
        Console.WriteLine("\n¿Desea agregar otro producto? (si/no)");
        return Console.ReadLine().ToLower() == "si";
    }

    /// <summary>
    /// Muestra el resumen final con totales, descuentos y costo de domicilio.
    /// </summary>
    /// <param name="totalParcial">Total antes de descuento y domicilio.</param>
    /// <param name="descuento">Valor del descuento aplicado (0 si no aplica).</param>
    /// <param name="domicilio">Costo del domicilio (0 si es gratis).</param>
    /// <param name="totalFinal">Total final a pagar.</param>
    static void MostrarResumenFinal(double totalParcial, double descuento, double domicilio, double totalFinal)
    {
        Console.WriteLine("\n==============================");
        Console.WriteLine($"TOTAL PARCIAL: ${totalParcial}");

        if (descuento > 0)
            Console.WriteLine($"Descuento aplicado (5%): ${descuento}");
        else
            Console.WriteLine("No aplica descuento.");

        if (domicilio == 0)
            Console.WriteLine("Domicilio GRATIS.");
        else
            Console.WriteLine($"Costo domicilio: ${domicilio}");

        Console.WriteLine($"\nTOTAL FINAL: ${totalFinal}");
    }

    /// <summary>
    /// Solicita y lee la confirmación del método de pago.
    /// </summary>
    /// <returns>True si el usuario confirma el pago.</returns>
    static bool ConfirmarPago()
    {
        Console.WriteLine("\n¿Confirma método de pago? (si/no)");
        return Console.ReadLine().ToLower() == "si";
    }

    /// <summary>
    /// Muestra el mensaje de cierre del pedido según si fue confirmado o no.
    /// </summary>
    /// <param name="confirmado">True si el pago fue confirmado.</param>
    static void MostrarCierrePedido(bool confirmado)
    {
        Console.WriteLine(confirmado ? "Pedido confirmado." : "Pedido pendiente de pago.");
        Console.WriteLine("\nGracias por comprar en TIENDA VALLE VERDE.");
    }

    // ─────────────────────────────────────────
    //  LÓGICA DE CÁLCULO — sin Console
    // ─────────────────────────────────────────

    /// <summary>
    /// Inicializa y retorna la lista de productos de la tienda.
    /// </summary>
    /// <returns>Lista de productos disponibles.</returns>
    static List<Producto> InicializarProductos()
    {
        return new List<Producto>
        {
            new Producto { Nombre = "Arroz Diana 1Kg",    Precio = 3500  },
            new Producto { Nombre = "Leche Alqueria",     Precio = 4500  },
            new Producto { Nombre = "Huevos AA x30",      Precio = 18000 },
            new Producto { Nombre = "Pan Bimbo Grande",   Precio = 7000  },
            new Producto { Nombre = "Aceite Premier 1L",  Precio = 12000 },

            new Producto { Nombre = "Coca Cola 3L",       Precio = 11000 },
            new Producto { Nombre = "Pepsi 3L",           Precio = 10000 },
            new Producto { Nombre = "Postobon Manzana 3L",Precio = 9500  },
            new Producto { Nombre = "Sprite 2L",          Precio = 8500  },
            new Producto { Nombre = "Colombiana 3L",      Precio = 9500  },
            new Producto { Nombre = "Gatorade",           Precio = 4500  },
            new Producto { Nombre = "Agua Cristal",       Precio = 2500  },

            new Producto { Nombre = "Chocoramo",          Precio = 3000  },
            new Producto { Nombre = "Doritos",            Precio = 5000  },
            new Producto { Nombre = "Papas Margarita",    Precio = 4500  },
            new Producto { Nombre = "Oreo",               Precio = 4000  },
            new Producto { Nombre = "Jet Chocolate",      Precio = 2500  },
            new Producto { Nombre = "Bom Bom Bum",        Precio = 700   },
        };
    }

    /// <summary>
    /// Busca un producto en la lista por número de opción o por nombre.
    /// </summary>
    /// <param name="entrada">Texto ingresado por el usuario.</param>
    /// <param name="productos">Lista de productos disponibles.</param>
    /// <returns>El producto encontrado, o null si no existe.</returns>
    static Producto BuscarProducto(string entrada, List<Producto> productos)
    {
        if (int.TryParse(entrada, out int opcion))
        {
            if (opcion >= 1 && opcion <= productos.Count)
                return productos[opcion - 1];
        }
        else
        {
            foreach (Producto p in productos)
            {
                if (p.Nombre.ToLower() == entrada)
                    return p;
            }
        }
        return null;
    }

    /// <summary>
    /// Calcula el subtotal de un producto según la cantidad.
    /// </summary>
    /// <param name="precio">Precio unitario del producto.</param>
    /// <param name="cantidad">Cantidad de unidades.</param>
    /// <returns>Subtotal (precio × cantidad).</returns>
    static double CalcularSubtotal(double precio, int cantidad)
    {
        return precio * cantidad;
    }

    /// <summary>
    /// Calcula el descuento del 5% si el total supera $100.000.
    /// </summary>
    /// <param name="total">Total parcial de la compra.</param>
    /// <returns>Valor del descuento a aplicar (0 si no aplica).</returns>
    static double CalcularDescuento(double total)
    {
        return total >= 100000 ? total * 0.05 : 0;
    }

    /// <summary>
    /// Calcula el costo de domicilio: gratis si el total es mayor a $20.000.
    /// </summary>
    /// <param name="total">Total de la compra tras descuento.</param>
    /// <returns>Costo del domicilio (0 o 5000).</returns>
    static double CalcularDomicilio(double total)
    {
        return total >= 20000 ? 0 : 5000;
    }

    // ─────────────────────────────────────────
    //  ORQUESTACIÓN
    // ─────────────────────────────────────────

    /// <summary>
    /// Ejecuta el ciclo principal de compra: muestra productos, recibe selección
    /// y acumula el total hasta que el usuario decide terminar.
    /// </summary>
    /// <param name="productos">Lista de productos disponibles.</param>
    /// <returns>Total parcial acumulado de la compra.</returns>
    static double EjecutarCicloCompra(List<Producto> productos)
    {
        double totalCompra = 0;

        do
        {
            MostrarProductos(productos);

            string entrada = LeerEntradaProducto();
            Producto seleccionado = BuscarProducto(entrada, productos);

            if (seleccionado != null)
            {
                int cantidad = LeerCantidad();
                double subtotal = CalcularSubtotal(seleccionado.Precio, cantidad);
                totalCompra += subtotal;
                MostrarSubtotal(seleccionado, subtotal);
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }

        } while (PreguntarContinuar());

        return totalCompra;
    }

    /// <summary>
    /// Calcula el total final aplicando descuento y domicilio.
    /// </summary>
    /// <param name="totalParcial">Total acumulado antes de ajustes.</param>
    /// <param name="descuento">Salida: valor del descuento aplicado.</param>
    /// <param name="domicilio">Salida: costo del domicilio.</param>
    /// <returns>Total final a pagar.</returns>
    static double CalcularTotalFinal(double totalParcial, out double descuento, out double domicilio)
    {
        descuento = CalcularDescuento(totalParcial);
        double totalConDescuento = totalParcial - descuento;
        domicilio = CalcularDomicilio(totalConDescuento);
        return totalConDescuento + domicilio;
    }

    // ─────────────────────────────────────────
    //  MAIN — solo coordina
    // ─────────────────────────────────────────

    static void Main(string[] args)
    {
        List<Producto> productos = InicializarProductos();

        MostrarEncabezado();

        double totalParcial = EjecutarCicloCompra(productos);

        double totalFinal = CalcularTotalFinal(totalParcial, out double descuento, out double domicilio);

        MostrarResumenFinal(totalParcial, descuento, domicilio, totalFinal);

        bool pagado = ConfirmarPago();
        MostrarCierrePedido(pagado);

        Console.ReadKey();
    }
}
