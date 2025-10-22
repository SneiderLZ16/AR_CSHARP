# Proyecto tienda

Ana es una estudiante que vende dulces en el salón. Ella quiere tener un programa en **C#** que le ayude a manejar las ventas de su tienda.  
Tu equipo será el encargado de desarrollar este programa.

---

## 🎯 Objetivo

Crear un sistema en **C# (consola)** que simule el funcionamiento de la tienda de Ana, aplicando todos los temas vistos en clase:

- Condicionales (`if`, `else if`, `else`, anidados, ternarios).
- Ciclos (`for`, `while`, `do while`).
- Arrays.
- Listas.
- Métodos.

---

## Requerimientos del programa

### 1. Productos iniciales

La tienda debe manejar 4 productos, cada uno con:

- Nombre.
- Precio.
- Stock (cantidad disponible).

### 2. Mostrar productos

Al iniciar, el programa debe mostrar todos los productos con su precio y stock disponible.

### 3. Comprar productos

- El usuario debe poder escribir qué producto desea comprar.
- El programa debe validar si existe ese producto.
- Luego debe preguntar cuántas unidades quiere.
- Si la cantidad solicitada está disponible en el stock:
  - Se descuenta del inventario.
  - Se suma al total de la compra.
  - Se guarda un registro de lo comprado en un historial.
- Si no hay suficiente stock, mostrar un mensaje de error.

### 4. Seguir comprando

Después de cada compra, el programa debe preguntar si desea seguir comprando.

- Si la respuesta es **"sí"**, volver a mostrar el menú de productos.
- Si la respuesta es **"no"**, terminar la compra.

### 5. Descuentos

- Si la compra total supera **$10.000**, aplicar un **10% de descuento**.
- Si la compra total supera **$20.000**, aplicar un **20% de descuento**.

### 6. Ticket de compra

Al final, el programa debe mostrar:

- Todos los productos comprados con su cantidad y subtotal.
- El total de la compra (con el descuento aplicado si corresponde).
- Un mensaje de agradecimiento:  
  **"¡Gracias por comprar en la tienda de Ana!"**

---

## Recomendación

Trabajen en equipo (célula). Cada integrante puede encargarse de una parte:

1. Mostrar productos.  
2. Manejo del stock.  
3. Validaciones de compra.  
4. Aplicar descuentos.  
5. Generar el ticket final.  

---

## ✅ Checklist – Proyecto Tienda de Ana

## Productos iniciales

- [x] Crear una estructura para los productos (nombre, precio, stock).  
- [x] Iniciar con al menos 4 productos en un diccionario o lista.  

## Mostrar productos

- [x] Al arrancar el programa, mostrar todos los productos disponibles.  
- [x] Que se vea el nombre, precio y stock.  

## Comprar productos

- [x] Pedir al usuario el nombre del producto que quiere comprar.  
- [x] Validar si el producto existe en la lista.  
- [x] Preguntar la cantidad a comprar.  
- [x] Verificar si hay suficiente stock:  
  - [x] Sí hay → descontar del inventario.  
  - [x] Sí hay → sumar al total de la compra.  
  - [x] Sí hay → guardar registro en un historial/carrito.  
  - [x] No hay → mostrar mensaje de error.  

## Seguir comprando

- [x] Preguntar si quiere seguir comprando después de cada compra.  
- [x] Si dice “sí”, mostrar nuevamente la lista de productos.  
- [x] Si dice “no”, terminar la compra y pasar al ticket.  

## Descuentos

- [x] Aplicar 10% de descuento si el total > $10.000.  
- [x] Aplicar 20% de descuento si el total > $20.000.  

## Ticket final

- [x] Mostrar lista de productos comprados.  
- [ ] Mostrar cantidad y subtotal por producto.  ![Pendiente]
- [x] Mostrar el total de la compra con descuento aplicado.  
- [x] Mostrar mensaje final: **"¡Gracias por comprar en la tienda de Ana!"**  

---
