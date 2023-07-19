﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Modelo;
using Entidad;

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
