using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Proveedor
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }

        public string NombreCompleto => $"{Nombre} {Apellido}";

        public override string ToString()
        {
            return NombreCompleto;
        }
    }
    public class Compra
    {
        public int ProductoId { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioTotal => Cantidad * PrecioUnitario;
    }
    public class Donacion
    {
        public int ProductoId { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
    }
    public class Recoleccion
    {
        public int ProductoId { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
