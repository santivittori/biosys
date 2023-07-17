using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Modelo;

namespace Controladora
{
    public class Controladora
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

        public static bool VerificarAutenticacion(string nombreUsuario, string claveCifrada)
        {
            return ConsultasModelo.VerificarAutenticacion(nombreUsuario, claveCifrada);
        }
        public static string ObtenerRolUsuario(string nombreUsuario)
        {
            return ConsultasModelo.ObtenerRolUsuario(nombreUsuario);
        }
        public static bool VerificarExistenciaUsuario(string nombreUsuario)
        {
            return ConsultasModelo.VerificarExistenciaUsuario(nombreUsuario);
        }
        public static bool VerificarExistenciaEmail(string email)
        {
            return ConsultasModelo.VerificarExistenciaEmail(email);
        }
        public static void GuardarNuevoUsuario(string nombreUsuario, string claveHash, string email, string rol)
        {
            ConsultasModelo.GuardarNuevoUsuario(nombreUsuario, claveHash, email, rol);
        }
        public static int ObtenerIdUsuario(string nombreUsuario)
        {
            return ConsultasModelo.ObtenerIdUsuario(nombreUsuario);
        }
        public static bool VerificarEmailExistente(string email)
        {
            return ConsultasModelo.VerificarEmailExistente(email);
        }
        public static string GenerarCodigoVerificacion()
        {
            return ConsultasModelo.GenerarCodigoVerificacion();
        }
        public static void ActualizarContraseñaUsuario(string email, string nuevaContraseña)
        {
            ConsultasModelo.ActualizarContraseñaUsuario(email, nuevaContraseña);
        }
        public static bool VerificarProveedorExistente(string nombre, string apellido, string email)
        {
            return ConsultasModelo.VerificarProveedorExistente(nombre, apellido, email);
        }
        public static void InsertarProveedor(string nombre, string apellido, string email, string telefono)
        {
            ConsultasModelo.InsertarProveedor(nombre, apellido, email, telefono);
        }
        public static void ActualizarProveedor(int idProveedorSeleccionado, string nombre, string apellido, string email, string telefono)
        {
            ConsultasModelo.ActualizarProveedor(idProveedorSeleccionado, nombre, apellido, email, telefono);
        }
        public static void ActualizarProducto(int idProductoSeleccionado, string nuevoNombre)
        {
            ConsultasModelo.ActualizarProducto(idProductoSeleccionado, nuevoNombre);
        }
        public static List<Proveedor> ObtenerDatosProveedores()
        {
            return ConsultasModelo.ObtenerDatosProveedores()
                .Select(proveedor => new Proveedor
                {
                    Nombre = proveedor.Nombre,
                    Apellido = proveedor.Apellido,
                    Email = proveedor.Email
                })
                .ToList();
        }
        public static DataTable ObtenerProveedores()
        {
            return ConsultasModelo.ObtenerProveedores();
        }
        public static DataTable ExecuteQuery(string sql)
        {
            return ConsultasModelo.ExecuteQuery(sql);
        }
        public static DataTable ObtenerProductosCompleto()
        {
            return ConsultasModelo.ObtenerProductosCompleto();
        }
        public static List<string> ObtenerProductosComboBox()
        {
            return ConsultasModelo.ObtenerProductosComboBox();
        }
        public static bool VerificarProductoExistente(string nombre, int tipoProductoID, int tipoEspecificoID)
        {
            return ConsultasModelo.VerificarProductoExistente(nombre, tipoProductoID, tipoEspecificoID);
        }
        public static void InsertarProducto(string nombre, int tipoProductoID, int tipoEspecificoID)
        {
            ConsultasModelo.InsertarProducto(nombre, tipoProductoID, tipoEspecificoID);
        }
        public static int GuardarCompra(string nroFactura, string nroRemito, DateTime fechaCompra, string proveedorEmail, int usuarioId, decimal precioTotalCompra)
        {
            return ConsultasModelo.GuardarCompra(nroFactura, nroRemito, fechaCompra, proveedorEmail, usuarioId, precioTotalCompra);
        }
        public static void GuardarDetalleCompra(int compraId, int productoId, int cantidad, decimal precioUnitario, decimal precioTotalDetalle)
        {
            ConsultasModelo.GuardarDetalleCompra(compraId, productoId, cantidad, precioUnitario, precioTotalDetalle);
        }
        public static int GuardarDonacion(string donante, DateTime fechaDonacion, int usuarioId)
        {
            return ConsultasModelo.GuardarDonacion(donante, fechaDonacion, usuarioId);
        }
        public static void GuardarDetalleDonacion(int donacionId, int productoId, int cantidad)
        {
            ConsultasModelo.GuardarDetalleDonacion(donacionId, productoId, cantidad);
        }
        public static int GuardarRecoleccion(string lugar, DateTime fechaRecoleccion, int usuarioId)
        {
            return ConsultasModelo.GuardarRecoleccion(lugar, fechaRecoleccion, usuarioId);
        }
        public static void GuardarDetalleRecoleccion(int recoleccionId, int productoId, int cantidad)
        {
            ConsultasModelo.GuardarDetalleRecoleccion(recoleccionId, productoId, cantidad);
        }
        public static void ActualizarStock(int productoId, int cantidad)
        {
            ConsultasModelo.ActualizarStock(productoId, cantidad);
        }
        public static int ObtenerIdProducto(string nombre, int tipoProducto, int tipoEspecifico)
        {
            return ConsultasModelo.ObtenerIdProducto(nombre, tipoProducto, tipoEspecifico);
        }
        public static DataTable ObtenerDatosGraficoProductos()
        {
            return ConsultasModelo.ObtenerDatosGraficoProductos();
        }
        public static DataTable ObtenerDatosGraficoArboles()
        {
            return ConsultasModelo.ObtenerDatosGraficoArboles();
        }
        public static DataTable ObtenerDatosGraficoSemillas()
        {
            return ConsultasModelo.ObtenerDatosGraficoSemillas();
        }
        public static int ObtenerTotalCompras()
        {
            return ConsultasModelo.ObtenerTotalCompras();
        }
        public static int ObtenerTotalDonaciones()
        {
            return ConsultasModelo.ObtenerTotalDonaciones();
        }
        public static int ObtenerTotalRecoleccion()
        {
            return ConsultasModelo.ObtenerTotalRecoleccion();
        }
        public static void EliminarProducto(int idProducto)
        {
            ConsultasModelo.EliminarProducto(idProducto);
        }
        public static bool VerificarProductoEnCompra(int idProducto)
        {
            return ConsultasModelo.VerificarProductoEnCompras(idProducto);
        }
        public static void EliminarProveedor(int idProveedor)
        {
            ConsultasModelo.EliminarProveedor(idProveedor);
        }
        public static bool VerificarProveedorEnCompras(int idProveedor)
        {
            return ConsultasModelo.VerificarProveedorEnCompras(idProveedor);
        }
    }
}
