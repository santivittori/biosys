using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Modelo;
using Entidad;
using System.Runtime.Remoting;

namespace Controladora
{
    public class Controladora
    {
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
        public static void GuardarNuevoUsuario(Usuario usuario)
        {
            ConsultasModelo.GuardarNuevoUsuario(usuario);
        }
        public static int ObtenerIdUsuario(string nombreUsuario)
        {
            return ConsultasModelo.ObtenerIdUsuario(nombreUsuario);
        }
        public static Usuario ObtenerUsuarioPorId(int idUsuario)
        {
            return ConsultasModelo.ObtenerUsuarioPorId(idUsuario);
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
        public static bool VerificarProveedorExistente(ProveedorInfo proveedorInfo)
        {
            return ConsultasModelo.VerificarProveedorExistente(proveedorInfo);
        }
        public static void InsertarProveedor(ProveedorInfo proveedorInfo)
        {
            ConsultasModelo.InsertarProveedor(proveedorInfo);
        }
        public static void ActualizarProveedor(ProveedorInfo proveedorInfo)
        {
            ConsultasModelo.ActualizarProveedor(proveedorInfo);
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
        public static DataTable ObtenerUsuarios()
        {
            return ConsultasModelo.ObtenerUsuarios();
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
        public static bool VerificarProductoExistente(Producto producto)
        {
            return ConsultasModelo.VerificarProductoExistente(producto);
        }
        public static void InsertarProducto(Producto producto)
        {
            ConsultasModelo.InsertarProducto(producto);
        }
        public static int GuardarCompra(CompraInfo compraInfo)
        {
            return ConsultasModelo.GuardarCompra(compraInfo);
        }
        public static void GuardarDetalleCompra(DetalleCompraInfo detalleCompraInfo)
        {
            ConsultasModelo.GuardarDetalleCompra(detalleCompraInfo);
        }
        public static int GuardarDonacion(DonacionInfo donacionInfo)
        {
            return ConsultasModelo.GuardarDonacion(donacionInfo);
        }
        public static void GuardarDetalleDonacion(DetalleDonacionInfo detalleDonacionInfo)
        {
            ConsultasModelo.GuardarDetalleDonacion(detalleDonacionInfo);
        }
        public static int GuardarRecoleccion(RecoleccionInfo recoleccionInfo)
        {
            return ConsultasModelo.GuardarRecoleccion(recoleccionInfo);
        }
        public static void GuardarDetalleRecoleccion(DetalleRecoleccionInfo detalleRecoleccionInfo)
        {
            ConsultasModelo.GuardarDetalleRecoleccion(detalleRecoleccionInfo);
        }
        public static void ActualizarStock(int productoId, int cantidad)
        {
            ConsultasModelo.ActualizarStock(productoId, cantidad);
        }
        public static void DisminuirStock(int productoId, int cantidad)
        {
            ConsultasModelo.DisminuirStock(productoId, cantidad);
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
        public static bool VerificarProductoEnDetalleSiembra(int idProducto)
        {
            return ConsultasModelo.VerificarProductoEnDetalleSiembra(idProducto);
        }
        public static void EliminarProveedor(int idProveedor)
        {
            ConsultasModelo.EliminarProveedor(idProveedor);
        }
        public static void EliminarUsuario(int idUsuario)
        {
            ConsultasModelo.EliminarUsuario(idUsuario);
        }
        public static bool VerificarProveedorEnCompras(int idProveedor)
        {
            return ConsultasModelo.VerificarProveedorEnCompras(idProveedor);
        }
        public static DataTable ObtenerMontosComprasPorTipo()
        {
            return ConsultasModelo.ObtenerMontosComprasPorTipo();
        }
        public static List<Producto> ObtenerSemillasConStockMayorCero()
        {
            return ConsultasModelo.ObtenerSemillasConStockMayorCero();
        }
        public static int GuardarSiembra(SiembraInfo siembraInfo)
        {
            return ConsultasModelo.GuardarSiembra(siembraInfo);
        }
        public static void GuardarDetalleSiembra(DetalleSiembraInfo detalleSiembraInfo)
        {
            ConsultasModelo.GuardarDetalleSiembra(detalleSiembraInfo);
        }
        public static Producto ObtenerProductoArbolPorNombre(string nombre)
        {
            return ConsultasModelo.ObtenerProductoArbolPorNombre(nombre);
        }
        public static Producto ObtenerProductoPorId(int productoId)
        {
            return ConsultasModelo.ObtenerProductoPorId(productoId);
        }
        public static int InsertarProductoSiembra(Producto producto, int stockInicial)
        {
            return ConsultasModelo.InsertarProductoSiembra(producto, stockInicial);
        }
        public static void ActualizarUsuario(Usuario usuario)
        {
            ConsultasModelo.ActualizarUsuario(usuario);
        }
        public static string ObtenerCorreoUsuario(string nombreUsuario)
        {
            return ConsultasModelo.ObtenerCorreoUsuario(nombreUsuario);
        }
        public static string ObtenerCorreoUsuarioAEliminar(int idUsuario)
        {
            return ConsultasModelo.ObtenerCorreoUsuarioAEliminar(idUsuario);
        }
        public static bool UsuarioUtilizadoEnCompras(int idUsuario)
        {
            return ConsultasModelo.UsuarioUtilizadoEnCompras(idUsuario);
        }
        public static bool VerificarClienteExistente(ClienteInfo clienteInfo)
        {
            return ConsultasModelo.VerificarClienteExistente(clienteInfo);
        }
        public static void ActualizarCliente(ClienteInfo clienteInfo)
        {
            ConsultasModelo.ActualizarCliente(clienteInfo);
        }
        public static void InsertarCliente(ClienteInfo clienteInfo)
        {
            ConsultasModelo.InsertarCliente(clienteInfo);
        }
        public static DataTable ObtenerClientes()
        {
            return ConsultasModelo.ObtenerClientes();
        }
        public static void EliminarCliente(int idCliente)
        {
            ConsultasModelo.EliminarCliente(idCliente);
        }
        public static bool VerificarClienteEnVentas(int idCliente)
        {
            return ConsultasModelo.VerificarClienteEnVentas(idCliente);
        }
        public static List<Cliente> ObtenerDatosClientes()
        {
            return ConsultasModelo.ObtenerDatosClientes()
                .Select(cliente => new Cliente
                {
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Email = cliente.Email
                })
                .ToList();
        }
        public static List<ProductoInfo> ObtenerProductosStockComboBox()
        {
            return ConsultasModelo.ObtenerProductosStockComboBox();
        }
        public static int GuardarVenta(VentaInfo ventaInfo)
        {
            return ConsultasModelo.GuardarVenta(ventaInfo);
        }
        public static void GuardarDetalleVenta(DetalleVentaInfo detalleVentaInfo)
        {
            ConsultasModelo.GuardarDetalleVenta(detalleVentaInfo);
        }
        public static DataTable ObtenerMontosVentasPorTipo()
        {
            return ConsultasModelo.ObtenerMontosVentasPorTipo();
        }
        public static DataTable ObtenerTresArbolesMasVendidos()
        {
            return ConsultasModelo.ObtenerTresArbolesMasVendidos();
        }
        public static DataTable ObtenerTresSemillasMasCompradas()
        {
            return ConsultasModelo.ObtenerTresSemillasMasCompradas();
        }
        public static int ObtenerStockProducto(string productName)
        {
            return ConsultasModelo.ObtenerStockProducto(productName);
        }
        public static void DisminuirStockProducto(string productName, int cantidad)
        {
            ConsultasModelo.DisminuirStockProducto(productName, cantidad);
        }
        public static void ActualizarStockArbol(int productoId, int cantidad)
        {
            ConsultasModelo.ActualizarStockArbol(productoId, cantidad);
        }
        public static void RegistrarBajaProducto(string productName, int cantidadBaja, string motivo)
        {
            ConsultasModelo.RegistrarBajaProducto(productName, cantidadBaja, motivo);
        }
        public static DataTable ObtenerDatosBajasProductos()
        {
            return ConsultasModelo.ObtenerDatosBajasProductos();
        }
        public static DataTable ObtenerDatosBajasTotales()
        {
            return ConsultasModelo.ObtenerDatosBajasTotales();
        }
    }
}
