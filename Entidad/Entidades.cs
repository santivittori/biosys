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
        public decimal PrecioTotal { get; set; }
        public string TipoProducto { get; set; } // Agregar esta propiedad
        public string UnidadMedida { get; set; } // Agregar esta propiedad

        // Constructor que acepta todos los parámetros, incluyendo el precio total
        public Compra(int productoId, string producto, int cantidad, decimal precioUnitario, decimal precioTotal, string tipoProducto, string unidadMedida)
        {
            ProductoId = productoId;
            Producto = producto;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            PrecioTotal = precioTotal;
            TipoProducto = tipoProducto;
            UnidadMedida = unidadMedida;
        }
    }

    public class Donacion
    {
        public int ProductoId { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public string TipoProducto { get; set; }
        public string UnidadMedida { get; set; }
    }
    public class Recoleccion
    {
        public int ProductoId { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
    }
    public class Usuario
    {
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
    }
    public class CompraInfo
    {
        public string NroFactura { get; set; }
        public string NroRemito { get; set; }
        public DateTime FechaCompra { get; set; }
        public string ProveedorEmail { get; set; }
        public int UsuarioId { get; set; }
        public decimal PrecioTotalCompra { get; set; }
    }
    public class DetalleCompraInfo
    {
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioTotalDetalle { get; set; }
    }
    public class ProveedorInfo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
    public class ClienteInfo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }

    public class DonacionInfo
    {
        public string Donante { get; set; }
        public DateTime FechaDonacion { get; set; }
        public int UsuarioId { get; set; }
    }
    public class DetalleDonacionInfo
    {
        public int DonacionId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }
    public class RecoleccionInfo
    {
        public string Lugar { get; set; }
        public DateTime FechaRecoleccion { get; set; }
        public int UsuarioId { get; set; }
    }
    public class DetalleRecoleccionInfo
    {
        public int RecoleccionId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }
    public class Siembra
    {
        public int ProductoId { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
    }
    public class SiembraInfo
    {
        public DateTime FechaSiembra { get; set; }
        public int UsuarioId { get; set; }
    }
    public class DetalleSiembraInfo
    {
        public int SiembraId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int TipoProductoId { get; set; }
        public int TipoEspecificoId { get; set; }
        public int? TamSemillaId { get; set; }
        public int Stock { get; set; }
        public int StockDisponible { get; set; }
    }
    public class ProductoConversion
    {
        public int ProductoSemillaId { get; set; }
        public int ProductoArbolId { get; set; }
    }
    public class StockProducto
    {
        public int ProductoId { get; set; }
        public int StockInicial { get; set; }
        public int StockDisponible { get; set; }
    }
    public class UsuarioActual
    {
        public static Usuario UsuarioLogueado { get; set; }
    }
    public class Venta
    {
        public int ProductoId { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioTotal => Cantidad * PrecioUnitario;

        // Propiedad para el stock original
        public int StockOriginal { get; set; }
    }
    public class DetalleVentaInfo
    {
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioTotalDetalle { get; set; }
    }
    public class VentaInfo
    {
        public DateTime FechaVenta { get; set; }
        public string ClienteEmail { get; set; }
        public int UsuarioId { get; set; }
        public decimal PrecioTotalVenta { get; set; }
        public string MedioPago { get; set; }
        public string CodigoFactura { get; set; }
    }

    public class Cliente
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
    public class ProductoInfo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string TipoProducto { get; set; } // Tipo de producto (Árbol, Semilla, etc.)
        public string TipoEspecifico { get; set; } // Tipo específico del producto (Exótica, Nativa, etc.)
        public int Stock { get; set; }
    }

}
