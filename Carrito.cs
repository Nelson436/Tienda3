using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda_3
{
    // Clase para gestionar el carrito de compras
    internal class Carrito
    {
        private List<Articulo> articulosEnCarrito = new List<Articulo>();

        // Método para agregar un artículo al carrito
        public void AgregarArticulo(Articulo articulo)
        {
            // Verificar si el artículo ya existe en el carrito
            var articuloExistente = articulosEnCarrito.Find(a => a.ID == articulo.ID);
            if (articuloExistente != null)
            {
                articuloExistente.Cantidad += articulo.Cantidad;  // Aumentar la cantidad si ya existe
            }
            else
            {
                articulosEnCarrito.Add(articulo);  // Agregar como nuevo artículo
            }
        }

        // Método para obtener la lista de artículos en el carrito
        public List<Articulo> ObtenerArticulos()
        {
            return articulosEnCarrito;
        }

        // Método para mostrar los artículos en el carrito
        public void MostrarArticulosEnCarrito()
        {
            Console.WriteLine("\n--- Artículos en el Carrito ---");
            if (articulosEnCarrito.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
            }
            else
            {
                foreach (var articulo in articulosEnCarrito)
                {
                    Console.WriteLine($"ID: {articulo.ID}, Nombre: {articulo.Nombre}, Cantidad: {articulo.Cantidad}, Precio Unitario: {articulo.Precio:C2}, Subtotal: {articulo.CalcularSubtotal():C2}");
                }
            }
        }

        // Método para calcular el total de la compra
        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var articulo in articulosEnCarrito)
            {
                total += articulo.CalcularSubtotal();  // Calcular total acumulado
            }
            return total;
        }

        // Método para vaciar el carrito
        public void VaciarCarrito()
        {
            articulosEnCarrito.Clear();  // Eliminar todos los artículos
        }
    }
}