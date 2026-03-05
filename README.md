# Project-Programmation-Logic
Samuel Restrepo Giraldo

Descripción del problema: 
Un sistema que recibe la información de un pedido realizado en una tienda en línea y determina su categoría de despacho y el costo de envío correspondiente. Para cumplir eso utiliza información como el nombre del cliente, el tipo de cliente, monto del pedido, ciudad destino, cantidad de ítems y el método de envío.

PROYECTO: Sistema de clasificación de pedidos
        Entradas: 
        * nombrecliente
        * tipo cliente
        * monto
        * ciudad
        * cantidadItem
        * metododeenvio.

        Procesos: 
        * validar datos
        * clasificar según tipo de cliente: cliente recurrente/ cliente nuevo
        * determinar beneficios/recargos: envio gratis o estandar
        * saber zona de despacho: si envio es exterior + costo envío
        * ajustar costo según cantidad
        * dar metodo de envío

        Salidas:
        * categoría del pedido
        * costo de envío
        * resumen del pedido

        Variables
        nombreCliente: (string) identifica el cliente
        tipoCliente: (string) clasifica el cliente
        monto: (decimal) valor total del pedido
        ciudad: (string) ciudad donde se enviará el pedido
        cantidadItem: (int) número de items que tiene el pedido
        metodoDeEnvio: (string) tipo de envío gratis o estándar
        categoria: (string) resultado de la clasificación final
        costoEnvio: (decimal) calculo del envio si es necesario
