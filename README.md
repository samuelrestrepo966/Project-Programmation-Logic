# Project-Programmation-Logic
Samuel Restrepo y Deivy Gómez

Descripción del problema

Una tienda llamada Valle Verde necesita un sistema que le permita registrar los productos que un cliente quiere comprar, calcular el total de la compra, aplicar descuentos y cobro de domicilio según ciertas condiciones, y confirmar el pago del pedido.


Entradas

- Nombre del producto
- Precio del producto
- Cantidad del producto
- Respuesta si desea agregar otro producto (si/no)
- Confirmación del método de pago (si/no)
- Opción del menú (1, 2, 3 o 0)


Procesos

- Calcular el subtotal de cada producto (precio × cantidad)
- Acumular el total de la compra sumando todos los subtotales
- Guardar cada producto en una lista para poder consultarlo después
- Calcular el subtotal más alto y el más bajo de todos los productos
- Aplicar un descuento del 5% si el total es mayor o igual a $100.000
- Agregar un costo de domicilio de $1.000 si el total es menor a $10.000
- Confirmar o cancelar el pedido según la respuesta del usuario


Salidas

- Nombre y subtotal de cada producto registrado
- Total parcial de la compra
- Listado de todos los productos con sus subtotales
- Subtotal más alto y más bajo
- Mensaje de descuento aplicado (si aplica)
- Mensaje de domicilio gratis o con costo
- Total final a pagar
- Mensaje de confirmación o cancelación del pedido

Capa UI — Entrada / Salida por consola

Función	Parámetros	Retorno	Responsabilidad
MostrarEncabezado()
—	void	Imprime el banner de bienvenida
MostrarProductos(productos)	List<Producto>	void	Lista numerada con precios
LeerEntradaProducto()	—	string	Lee número o nombre del producto
LeerCantidad()	—	int	Lee la cantidad deseada
MostrarSubtotal(prod, sub)	Producto, double	void	Muestra nombre y subtotal del ítem
PreguntarContinuar()	—	bool	Pregunta si agregar otro producto
MostrarResumenFinal(...)	4× double	void	Imprime el ticket de cierre
ConfirmarPago()	—	bool	Lee confirmación del pago
MostrarCierrePedido(conf)	bool	void	Mensaje final del pedido

Capa de Cálculo — sin Console

Función	Parámetros	Retorno	Responsabilidad

InicializarProductos()

—	List<Producto
>	
Crea el catálogo de productos
BuscarProducto(ent, prods)	string, List<Producto>	Producto?	Busca por número o nombre
CalcularSubtotal(precio, qty)	
double, int	
double	
precio × cantidad
CalcularDescuento(total)	double	double	5% si total  $100.000, si no 0
CalcularDomicilio(total)	double	double	$0 si total  $20.000, si no $5.000

Capa de Orquestación
 
Función	Parámetros	Retorno	Responsabilidad

EjecutarCicloCompra(prods)

List<Producto>	
double	Loop de compra; retorna total parcial
CalcularTotalFinal(tot,
...)	
double, out double, out double	
double	
Aplica descuento + domicilio
Main — solo coordina: llama InicializarProductos  EjecutarCicloCompra  CalcularTotalFinal 
MostrarResumenFinal  ConfirmarPago  MostrarCierrePedido.



Main
■■■ InicializarProductos()
■■■ MostrarEncabezado()
■■■ EjecutarCicloCompra()
■	■■■ [loop]
■	■■■ MostrarProductos()
■	■■■ LeerEntradaProducto()
■	■■■ BuscarProducto()
■	■■■ LeerCantidad()
■	■■■ CalcularSubtotal()
■	■■■ MostrarSubtotal()
■	■■■ PreguntarContinuar()
■■■ CalcularTotalFinal()
■	■■■ CalcularDescuento()
■	■■■ CalcularDomicilio()
■■■ MostrarResumenFinal()
■■■ ConfirmarPago()
■■■ MostrarCierrePedido()


Acción	Entrada	Resultado esperado
1	Seleccionar por número	1  cantidad 2	Subtotal $7.000
2	Seleccionar por nombre	chocoramo  cant 1	Subtotal $3.000
3	Producto inexistente	xyz	"Producto no encontrado."
 

Acción	Entrada	Resultado esperado
4	Total  $100.000	Varias compras grandes	Descuento 5% aplicado
5	Total < $100.000	Compra pequeña	Sin descuento
6	Total  $20.000	Compra normal	Domicilio gratis
7	Total < $20.000	Bom Bom Bum × 1	Domicilio $5.000 sumado
8	Confirmar pago	si	"Pedido confirmado."
9	No confirmar pago	no	"Pedido pendiente de pago."


