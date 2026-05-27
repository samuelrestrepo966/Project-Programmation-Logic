using System;
using System.Collections.Generic;
 
public class Producto
{
    public string Nombre;
    public double Precio;
}
 
public class Program
{
    //      Entrada / Salida por consola
    /// Muestra el encabezado de bienvenida de la tienda
    static void MostrarEncabezado()
    {
        Console.WriteLine("==================================");
        Console.WriteLine("      TIENDA VALLE VERDE");
        Console.WriteLine("==================================");
    }

    /// Muestra la lista de productos disponibles numerados con su precio.
    /// Lista de productos a mostrar.
    static void MostrarProductos(List<Producto> productos)
    {
        Console.WriteLine("\n======= PRODUCTOS DISPONIBLES =======");
        for (int i = 0; i < productos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {productos[i].Nombre} - ${productos[i].Precio}");
        }
    }

    /// Lee la entrada del usuario para seleccionar un producto por número.
    /// Texto ingresado por el usuario en minúsculas.
    static string LeerEntradaProducto()
    {
        Console.WriteLine("\nEscribe el NUMERO del producto:");
        return Console.ReadLine().Trim().ToLower();
    }
 
    /// Lee la cantidad deseada del producto seleccionado.
    /// Cantidad ingresada por el usuario.
    static int LeerCantidad()
    {
        Console.WriteLine("Ingrese la cantidad:");
        return Convert.ToInt32(Console.ReadLine());
    }
 
    /// Muestra el resumen del producto agregado y su subtotal.
    /// "producto":Producto seleccionado.
    /// subtotal":Subtotal calculado para ese producto.
    static void MostrarSubtotal(Producto producto, double subtotal)
    {
        Console.WriteLine($"\nProducto: {producto.Nombre}");
        Console.WriteLine($"Subtotal: ${subtotal}");
    }
 
    /// Pregunta al usuario si desea seguir agregando productos.
    /// True si el usuario responde "si".
    static bool PreguntarContinuar()
    {
        Console.WriteLine("\n¿Desea agregar otro producto? (si/no)");
        return Console.ReadLine().Trim().ToLower() == "si";
    }
 
    /// Muestra el resumen final con totales, descuentos y costo de domicilio.
    /// "totalParcial":Total antes de descuento y domicilio.
    /// "descuento":Valor del descuento aplicado (0 si no aplica).
    /// "domicilio":Costo del domicilio (0 si es grati).
    /// "totalFinal":Total final a pagar.
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
 
    /// Muestra las opciones de medio de pago y retorna el elegido.
    /// Nombre del medio de pago seleccionado, o null si es inválido.
    static string SeleccionarMedioPago()
    {
        Console.WriteLine("\n======= MEDIO DE PAGO =======");
        Console.WriteLine("1. Nequi");
        Console.WriteLine("2. Bancolombia");
        Console.WriteLine("3. Efectivo");
        Console.WriteLine("\nSeleccione una opcion (1/2/3):");
 
        string opcion = Console.ReadLine().Trim();
 
        switch (opcion)
        {
            case "1": return "Nequi";
            case "2": return "Bancolombia";
            case "3": return "Efectivo";
            default:  return null;
        }
    }
 
    /// Muestra el mensaje de cierre del pedido con el medio de pago usado.
    /// "confirmado":True si el pago fue confirmado.
    /// "medioPago":Nombre del medio de pago seleccionado.
    static void MostrarCierrePedido(bool confirmado, string medioPago)
    {
        if (confirmado)
            Console.WriteLine($"Pedido confirmado. Pago por {medioPago}.");
        else
            Console.WriteLine("Pedido cancelado.");
 
        Console.WriteLine("\nGracias por comprar en TIENDA VALLE VERDE.");
    }
 
    // ─────────────────────────────────────────
    //  LÓGICA DE CÁLCULO — sin Console
    // ─────────────────────────────────────────
 
    /// Inicializa y retorna la lista de productos de la tienda.
    /// Lista de productos disponibles.
    static List<Producto> InicializarProductos()
    {
        return new List<Producto>
        {
            new Producto { Nombre = "Arroz Diana 1Kg",     Precio = 3500  },
            new Producto { Nombre = "Leche Alqueria",      Precio = 4500  },
            new Producto { Nombre = "Huevos AA x30",       Precio = 18000 },
            new Producto { Nombre = "Pan Bimbo Grande",    Precio = 7000  },
            new Producto { Nombre = "Aceite Premier 1L",   Precio = 12000 },
 
            new Producto { Nombre = "Coca Cola 3L",        Precio = 11000 },
            new Producto { Nombre = "Pepsi 3L",            Precio = 10000 },
            new Producto { Nombre = "Postobon Manzana 3L", Precio = 9500  },
            new Producto { Nombre = "Sprite 2L",           Precio = 8500  },
            new Producto { Nombre = "Colombiana 3L",       Precio = 9500  },
            new Producto { Nombre = "Gatorade",            Precio = 4500  },
            new Producto { Nombre = "Agua Cristal",        Precio = 2500  },
 
            new Producto { Nombre = "Chocoramo",           Precio = 3000  },
            new Producto { Nombre = "Doritos",             Precio = 5000  },
            new Producto { Nombre = "Papas Margarita",     Precio = 4500  },
            new Producto { Nombre = "Oreo",                Precio = 4000  },
            new Producto { Nombre = "Jet Chocolate",       Precio = 2500  },
            new Producto { Nombre = "Bom Bom Bum",         Precio = 700   },
        };
    }
 
    /// Busca un producto en la lista por número de opción.
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
        return null;
    }
 
    /// Calcula el subtotal de un producto según la cantidad.
    /// "precio":Precio unitario del producto.
    /// "cantidad":Cantidad de unidades.
    /// Subtotal (precio × cantidad).
    static double CalcularSubtotal(double precio, int cantidad)
    {
        return precio * cantidad;
    }

    /// Calcula el descuento del 5% si el total supera $100.000.
    /// "total":Total parcial de la compra.
    /// Valor del descuento a aplicar (0 si no aplica).
    static double CalcularDescuento(double total)
    {
        return total >= 100000 ? total * 0.05 : 0;
    }

    /// Calcula el costo de domicilio: gratis si el total es mayor o igual a $20.000.
    /// "total":Total de la compra tras descuento.
    /// Costo del domicilio (0 o 5000).
    static double CalcularDomicilio(double total)
    {
        return total >= 20000 ? 0 : 5000;
    }
 
    // ─────────────────────────────────────────
    //  aca se ejecutan los ciclos
    // ─────────────────────────────────────────
 
    /// Ejecuta el ciclo principal de compra: muestra productos, recibe selección
    /// y acumula el total. Retorna 0 si no se agregó ningún producto.
    /// "productos":Lista de productos disponibles.
    /// Total parcial acumulado de la compra.
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
                Console.WriteLine("Numero invalido. Ingrese un numero de la lista.");
            }
 
        } while (PreguntarContinuar());
 
        return totalCompra;
    }
 
    /// Calcula el total final aplicando descuento y domicilio.
    /// Solo aplica domicilio si hay productos (total > 0).
    /// "totalParcial">Total acumulado antes de ajustes.
    /// "descuento">Salida: valor del descuento aplicado.
    /// "domicilio">Salida: costo del domicilio.
    /// Total final a pagar.
    static double CalcularTotalFinal(double totalParcial, out double descuento, out double domicilio)
    {
        descuento = CalcularDescuento(totalParcial);
        double totalConDescuento = totalParcial - descuento;
        domicilio = totalParcial > 0 ? CalcularDomicilio(totalConDescuento) : 0;
        return totalConDescuento + domicilio;
    }
 
    // ─────────────────────────────────────────
    //  main coordina
    // ─────────────────────────────────────────
 
    static void Main(string[] args)
    {
        List<Producto> productos = InicializarProductos();
 
        MostrarEncabezado();
 
        double totalParcial = EjecutarCicloCompra(productos);
 
        // Si no se agregó ningún producto, cancelar
        if (totalParcial == 0)
        {
            Console.WriteLine("\nNo se agregaron productos. Pedido cancelado.");
            Console.WriteLine("\nGracias por visitar TIENDA VALLE VERDE.");
            Console.ReadKey();
            return;
        }
 
        double totalFinal = CalcularTotalFinal(totalParcial, out double descuento, out double domicilio);
 
        MostrarResumenFinal(totalParcial, descuento, domicilio, totalFinal);
 
        // Selección de medio de pago
        string medioPago = null;
        while (medioPago == null)
        {
            medioPago = SeleccionarMedioPago();
            if (medioPago == null)
                Console.WriteLine("Opcion invalida. Intente de nuevo.");
        }
 
        MostrarCierrePedido(true, medioPago);
 
        Console.ReadKey();
    }
}
