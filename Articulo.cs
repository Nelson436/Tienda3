using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda_3
{
    internal class Articulo
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; } = 1;  // Cantidad predeterminada es 1

        // Método para calcular el subtotal basado en la cantidad
        public decimal CalcularSubtotal()
        {
            return Precio * Cantidad;
        }
    }
}