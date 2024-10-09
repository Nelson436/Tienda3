using System;
using System.Collections.Generic;
using Tienda_3;

namespace Tienda_3
{
    // Programa principal
    class Program
    {
        static void Main(string[] args)
        {
            // Llenar el catálogo de productos
            Catalogo.LlenarCatalogo();

            // Crear un nuevo carrito de compras
            Carrito carrito = new Carrito();

            Console.WriteLine("Bienvenido a la Tienda\n");
            bool continuar = true;

            // Menú para agregar productos al carrito
            while (continuar)
            {
                // Mostrar el catálogo de productos
                Catalogo.MostrarCatalogo();

                Console.WriteLine("\nIngresa el ID del producto que deseas agregar al carrito:");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    Articulo articuloSeleccionado = Catalogo.BuscarArticuloPorID(id);

                    if (articuloSeleccionado != null)
                    {
                        Console.WriteLine($"Has seleccionado: {articuloSeleccionado.Nombre}");
                        Console.WriteLine("Ingresa la cantidad que deseas agregar:");

                        if (int.TryParse(Console.ReadLine(), out int cantidad) && cantidad > 0)
                        {
                            // Crear una copia del artículo con la cantidad especificada
                            Articulo articuloParaCarrito = new Articulo
                            {
                                ID = articuloSeleccionado.ID,
                                Nombre = articuloSeleccionado.Nombre,
                                Precio = articuloSeleccionado.Precio,
                                Cantidad = cantidad
                            };
                            carrito.AgregarArticulo(articuloParaCarrito);
                            Console.WriteLine("Producto agregado al carrito exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("Cantidad inválida. Inténtalo de nuevo.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("El ID ingresado no existe en el catálogo. Inténtalo de nuevo.");
                    }
                }
                else
                {
                    Console.WriteLine("ID inválido. Inténtalo de nuevo.");
                }

                Console.WriteLine("\n¿Deseas agregar otro producto? (s/n)");
                continuar = Console.ReadLine().ToLower() == "s";
            }

            // Mostrar los artículos en el carrito y el total de la compra
            carrito.MostrarArticulosEnCarrito();
            decimal totalCompra = carrito.CalcularTotal();
            Console.WriteLine($"\nTotal de la compra: {totalCompra:C2}");

            // Solicitar el monto a pagar
            decimal montoPagado = 0;
            bool pagoValido = false;

            while (!pagoValido)
            {
                Console.WriteLine("\nIngresa el monto con el que deseas pagar:");
                if (decimal.TryParse(Console.ReadLine(), out montoPagado))
                {
                    if (montoPagado >= totalCompra)
                    {
                        pagoValido = true;
                        Console.WriteLine("Pago aceptado.");
                    }
                    else
                    {
                        Console.WriteLine("El monto ingresado es insuficiente para cubrir el total de la compra. Inténtalo de nuevo.");
                    }
                }
                else
                {
                    Console.WriteLine("Monto inválido. Ingresa un valor numérico.");
                }
            }

            // Calcular el cambio y generar el ticket
            decimal cambio = montoPagado - totalCompra;

            Ticket ticket = new Ticket
            {
                Lista = carrito.ObtenerArticulos(),
                Total = totalCompra,
                Pagado = montoPagado,
                Cambio = cambio,
                Fecha = DateTime.Now,
                NumCompra = new Random().Next(1000, 9999),
                IVA = totalCompra * 0.16m  // Calcular IVA del 16%
            };
            ticket.MostrarTicket();

            Console.WriteLine("\nGracias por tu compra Tienda el pepe. Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}