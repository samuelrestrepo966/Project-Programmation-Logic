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
