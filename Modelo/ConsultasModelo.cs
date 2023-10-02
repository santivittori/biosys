using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidad;
using System.Net.Http.Headers;

namespace Modelo
{
    public class ConsultasModelo
    {
        public static bool VerificarAutenticacion(string nombreUsuario, string claveCifrada)
        {
            string sql = "SELECT COUNT(*) FROM usuarios WHERE nombre_usuario = @nombre_usuario AND clave = @clave";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@nombre_usuario", nombreUsuario);
                command.Parameters.AddWithValue("@clave", claveCifrada);

                int count = (int)command.ExecuteScalar();
                ConexionModelo.CerrarConexion();
                return count != 0;
            }
        }
        public static bool VerificarEmailExistente(string email)
        {
            string sql = "SELECT COUNT(*) FROM usuarios WHERE email = @email";
            int count;

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@email", email);

                count = (int)command.ExecuteScalar();
                ConexionModelo.CerrarConexion();
            }

            return count > 0;
        }

        public static string GenerarCodigoVerificacion()
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();

            // Generar un código de 6 caracteres
            string codigo = new string(Enumerable.Repeat(caracteres, 6).Select(s => s[random.Next(s.Length)]).ToArray());

            return codigo;
        }

        public static void ActualizarContraseñaUsuario(string email, string nuevaContraseña)
        {
            string sql = "UPDATE usuarios SET clave = @nuevaContraseña WHERE email = @email";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@nuevaContraseña", nuevaContraseña);
                command.Parameters.AddWithValue("@email", email);
                command.ExecuteNonQuery();
            }
        }

        public static string ObtenerRolUsuario(string nombreUsuario)
        {
            string sql = "SELECT rol FROM usuarios WHERE nombre_usuario = @nombre_usuario";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@nombre_usuario", nombreUsuario);
                
                return (string)command.ExecuteScalar();
            }
        }

        public static bool VerificarExistenciaUsuario(string nombreUsuario)
        {
            string sql = "SELECT COUNT(*) FROM usuarios WHERE nombre_usuario = @nombre_usuario";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@nombre_usuario", nombreUsuario);
                int count = (int)command.ExecuteScalar();
                ConexionModelo.CerrarConexion();
                return count != 0;
            }
        }

        public static bool VerificarExistenciaEmail(string email)
        {
            string sql = "SELECT COUNT(*) FROM usuarios WHERE email = @Email;";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@Email", email);
                int count = Convert.ToInt32(command.ExecuteScalar());
                ConexionModelo.CerrarConexion();
                return count > 0;
            }
        }
        public static void GuardarNuevoUsuario(Usuario usuario)
        {
            string sql = "INSERT INTO usuarios (nombre_usuario, clave, email, rol) VALUES (@nombre_usuario, @clave, @email, @rol)";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@nombre_usuario", usuario.NombreUsuario);
                command.Parameters.AddWithValue("@clave", usuario.Clave);
                command.Parameters.AddWithValue("@email", usuario.Email);
                command.Parameters.AddWithValue("@rol", usuario.Rol);

                command.ExecuteNonQuery();
                ConexionModelo.CerrarConexion();
            }
        }
        public static int ObtenerIdUsuario(string nombreUsuario)
        {
            string sql = "SELECT id FROM usuarios WHERE nombre_usuario = @nombre_usuario";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@nombre_usuario", nombreUsuario);
                
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        // Método para obtener usuario por id
        public static Usuario ObtenerUsuarioPorId(int idUsuario)
        {
            string sql = "SELECT nombre_usuario, clave, email, rol FROM usuarios WHERE id = @idUsuario";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@idUsuario", idUsuario);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string nombreUsuario = reader.GetString(0);
                        string clave = reader.GetString(1);
                        string email = reader.GetString(2);
                        string rol = reader.GetString(3);

                        Usuario usuario = new Usuario
                        {
                            NombreUsuario = nombreUsuario,
                            Clave = clave,
                            Email = email,
                            Rol = rol
                        };

                        ConexionModelo.CerrarConexion();
                        return usuario;
                    }
                    else
                    {
                        ConexionModelo.CerrarConexion();
                        return null;
                    }
                }
            }
        }
        public static bool VerificarProveedorExistente(ProveedorInfo proveedorInfo)
        {
            string sql = "SELECT COUNT(*) FROM proveedores WHERE nombre_prov = @nombre AND apellido_prov = @apellido AND email_prov = @email";
            int count;

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@nombre", proveedorInfo.Nombre);
                command.Parameters.AddWithValue("@apellido", proveedorInfo.Apellido);
                command.Parameters.AddWithValue("@email", proveedorInfo.Email);

                count = (int)command.ExecuteScalar();
                ConexionModelo.CerrarConexion();
            }
            return count > 0;
        }

        public static void InsertarProveedor(ProveedorInfo proveedorInfo)
        {
            string sql = "INSERT INTO proveedores (nombre_prov, apellido_prov, email_prov, telefono_prov) VALUES (@Nombre, @Apellido, @Email, @Telefono)";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@Nombre", proveedorInfo.Nombre);
                command.Parameters.AddWithValue("@Apellido", proveedorInfo.Apellido);
                command.Parameters.AddWithValue("@Email", proveedorInfo.Email);
                command.Parameters.AddWithValue("@Telefono", proveedorInfo.Telefono);

                command.ExecuteNonQuery();
                ConexionModelo.CerrarConexion();
            }
        }
        public static void ActualizarProveedor(ProveedorInfo proveedorInfo)
        {
            string sql = "UPDATE proveedores SET nombre_prov = @nombre, apellido_prov = @apellido, email_prov = @email, telefono_prov = @telefono WHERE id = @id";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@nombre", proveedorInfo.Nombre);
                command.Parameters.AddWithValue("@apellido", proveedorInfo.Apellido);
                command.Parameters.AddWithValue("@email", proveedorInfo.Email);
                command.Parameters.AddWithValue("@telefono", proveedorInfo.Telefono);
                command.Parameters.AddWithValue("@id", proveedorInfo.Id);

                command.ExecuteNonQuery();
                ConexionModelo.CerrarConexion();
            }
        }

        public static List<Proveedor> ObtenerDatosProveedores()
        {
            List<Proveedor> proveedores = new List<Proveedor>();

            string sql = "SELECT nombre_prov, apellido_prov, email_prov FROM proveedores";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nombre = reader.GetString(0);
                        string apellido = reader.GetString(1);
                        string email = reader.GetString(2);

                        Proveedor proveedor = new Proveedor
                        {
                            Nombre = nombre,
                            Apellido = apellido,
                            Email = email
                        };

                        proveedores.Add(proveedor);
                    }
                    ConexionModelo.CerrarConexion();
                }
            }
            return proveedores;
        }

        public static DataTable ObtenerProveedores()
        {
            string sql = "SELECT id AS ID, nombre_prov AS Nombre, apellido_prov AS Apellido, email_prov AS Email, telefono_prov AS Telefono FROM proveedores";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                ConexionModelo.CerrarConexion();

                return dataTable;
            }
        }
        public static DataTable ObtenerUsuarios()
        {
            string sql = "SELECT id AS ID, nombre_usuario AS Nombre, clave AS Constraseña, email AS Email, rol AS Rol FROM usuarios";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                ConexionModelo.CerrarConexion();

                return dataTable;
            }
        }

        public static DataTable ExecuteQuery(string sql)
        {
            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);

                ConexionModelo.CerrarConexion();

                return dataTable;
            }
        }

        public static DataTable ObtenerProductosCompleto()
        {
            string sql = "SELECT p.id AS ID, p.nombre AS Nombre, tp.nombre AS TipoProducto, te.nombre AS TipoEspecifico " +
                         "FROM productos p " +
                         "JOIN tipos_producto tp ON p.tipo_producto_id = tp.id " +
                         "JOIN tipos_especifico te ON p.tipo_especifico_id = te.id";

            return ExecuteQuery(sql);
        }
        public static List<string> ObtenerProductosComboBox()
        {
            string sql = "SELECT p.nombre + ' - ' + tp.nombre + ' - ' + te.nombre AS ProductoCompleto " +
                         "FROM productos p " +
                         "JOIN tipos_producto tp ON p.tipo_producto_id = tp.id " +
                         "JOIN tipos_especifico te ON p.tipo_especifico_id = te.id";

            List<string> productos = new List<string>();

            DataTable dataTable = ExecuteQuery(sql);

            foreach (DataRow row in dataTable.Rows)
            {
                string productoCompleto = row["ProductoCompleto"].ToString();
                productos.Add(productoCompleto);
            }

            return productos;
        }
        public static bool VerificarProductoExistente(Producto producto)
        {
            string sql = "SELECT COUNT(*) FROM productos WHERE nombre = @nombre AND tipo_producto_id = @tipoProductoID AND tipo_especifico_id = @tipoEspecificoID";
            int count;

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@TipoProductoID", producto.TipoProductoId);
                command.Parameters.AddWithValue("@TipoEspecificoID", producto.TipoEspecificoId);

                count = (int)command.ExecuteScalar();
                ConexionModelo.CerrarConexion();
            }
            return count > 0;
        }
        public static void InsertarProducto(Producto producto)
        {
            string sql = "INSERT INTO productos (nombre, tipo_producto_id, tipo_especifico_id, stock) " +
                         "VALUES (@Nombre, @TipoProductoID, @TipoEspecificoID, 0)";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@TipoProductoID", producto.TipoProductoId);
                command.Parameters.AddWithValue("@TipoEspecificoID", producto.TipoEspecificoId);

                command.ExecuteNonQuery();
                ConexionModelo.CerrarConexion();
            }
        }
        public static void ActualizarProducto(int idProductoSeleccionado, string nuevoNombre)
        {
            string sql = "UPDATE productos SET nombre = @nuevoNombre WHERE id = @idProducto";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@nuevoNombre", nuevoNombre);
                command.Parameters.AddWithValue("@idProducto", idProductoSeleccionado);

                command.ExecuteNonQuery();
                ConexionModelo.CerrarConexion();
            }
        }

        public static int GuardarCompra(CompraInfo compraInfo)
        {
            int compraId = 0;

            string sql = "INSERT INTO compras (nro_factura, nro_remito, fecha, proveedor_id, usuario_id, precio_total) " +
                         "VALUES (@NroFactura, @NroRemito, @FechaCompra, (SELECT id FROM proveedores WHERE email_prov = @ProveedorEmail), @UsuarioId, @PrecioTotalCompra);" +
                         "SELECT SCOPE_IDENTITY();";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@NroFactura", compraInfo.NroFactura);
                command.Parameters.AddWithValue("@NroRemito", compraInfo.NroRemito);
                command.Parameters.AddWithValue("@FechaCompra", compraInfo.FechaCompra);
                command.Parameters.AddWithValue("@ProveedorEmail", compraInfo.ProveedorEmail);
                command.Parameters.AddWithValue("@UsuarioId", compraInfo.UsuarioId); 
                command.Parameters.AddWithValue("@PrecioTotalCompra", compraInfo.PrecioTotalCompra);

                compraId = Convert.ToInt32(command.ExecuteScalar());
                ConexionModelo.CerrarConexion();
            }

            return compraId;
        }

        public static void GuardarDetalleCompra(DetalleCompraInfo detalleCompraInfo)
        {
            string sql = "INSERT INTO detalle_compra (compra_id, producto_id, cantidad, precio_unitario, precio_total) " +
                         "VALUES (@CompraId, @ProductoId, @Cantidad, @PrecioUnitario, @PrecioTotalDetalle)";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@CompraId", detalleCompraInfo.CompraId);
                command.Parameters.AddWithValue("@ProductoId", detalleCompraInfo.ProductoId);
                command.Parameters.AddWithValue("@Cantidad", detalleCompraInfo.Cantidad);
                command.Parameters.AddWithValue("@PrecioUnitario", detalleCompraInfo.PrecioUnitario);
                command.Parameters.AddWithValue("@PrecioTotalDetalle", detalleCompraInfo.PrecioTotalDetalle); 

                command.ExecuteNonQuery();
                ConexionModelo.CerrarConexion();
            }
        }
        public static int GuardarDonacion(DonacionInfo donacionInfo)
        {
            int donacionId = 0;

            string sql = "INSERT INTO donaciones (entidad_donante, fecha, usuario_id) " +
                         "VALUES (@EntidadDonante, @FechaDonacion, @UsuarioId);" +
                         "SELECT SCOPE_IDENTITY();";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@EntidadDonante", donacionInfo.Donante);
                command.Parameters.AddWithValue("@FechaDonacion", donacionInfo.FechaDonacion);
                command.Parameters.AddWithValue("@UsuarioId", donacionInfo.UsuarioId);

                donacionId = Convert.ToInt32(command.ExecuteScalar());
                ConexionModelo.CerrarConexion();
            }

            return donacionId;
        }
        public static void GuardarDetalleDonacion(DetalleDonacionInfo detalleDonacionInfo)
        {
            string sql = "INSERT INTO detalle_donacion (donacion_id, producto_id, cantidad) " +
                         "VALUES (@DonacionId, @ProductoId, @Cantidad)";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@DonacionId", detalleDonacionInfo.DonacionId);
                command.Parameters.AddWithValue("@ProductoId", detalleDonacionInfo.ProductoId);
                command.Parameters.AddWithValue("@Cantidad", detalleDonacionInfo.Cantidad);

                command.ExecuteNonQuery();
                ConexionModelo.CerrarConexion();
            }
        }
        public static int GuardarRecoleccion(RecoleccionInfo recoleccionInfo)
        {
            int recoleccionId = 0;

            string sql = "INSERT INTO recolecciones (lugar, fecha, usuario_id) " +
                         "VALUES (@Lugar, @FechaRecoleccion, @UsuarioId);" +
                         "SELECT SCOPE_IDENTITY();";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@Lugar", recoleccionInfo.Lugar);
                command.Parameters.AddWithValue("@FechaRecoleccion", recoleccionInfo.FechaRecoleccion);
                command.Parameters.AddWithValue("@UsuarioId", recoleccionInfo.UsuarioId);

                recoleccionId = Convert.ToInt32(command.ExecuteScalar());
                ConexionModelo.CerrarConexion();
            }

            return recoleccionId;
        }
        public static void GuardarDetalleRecoleccion(DetalleRecoleccionInfo detalleRecoleccionInfo)
        {
            string sql = "INSERT INTO detalle_recoleccion (recoleccion_id, producto_id, cantidad) " +
                         "VALUES (@RecoleccionId, @ProductoId, @Cantidad)";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@RecoleccionId", detalleRecoleccionInfo.RecoleccionId);
                command.Parameters.AddWithValue("@ProductoId", detalleRecoleccionInfo.ProductoId);
                command.Parameters.AddWithValue("@Cantidad", detalleRecoleccionInfo.Cantidad);

                command.ExecuteNonQuery();
                ConexionModelo.CerrarConexion();
            }
        }
        public static void ActualizarStock(int productoId, int cantidad)
        {
            string sql = "UPDATE productos SET stock = stock + @Cantidad WHERE id = @ProductoId";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@Cantidad", cantidad);
                command.Parameters.AddWithValue("@ProductoId", productoId);

                command.ExecuteNonQuery();
                ConexionModelo.CerrarConexion();
            }
        }

        public static void DisminuirStock(int productoId, int cantidad)
        {
            string sql = "UPDATE productos SET stock = stock - @Cantidad WHERE id = @ProductoId";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@Cantidad", cantidad);
                command.Parameters.AddWithValue("@ProductoId", productoId);

                command.ExecuteNonQuery();
                ConexionModelo.CerrarConexion();
            }
        }

        public static int ObtenerIdProducto(string nombre, int tipoProducto, int tipoEspecifico)
        {
            string sql = "SELECT id FROM productos " +
                         "WHERE nombre = @Nombre AND tipo_producto_id = @TipoProducto AND tipo_especifico_id = @TipoEspecifico";

            int productoId = 0;

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@TipoProducto", tipoProducto);
                command.Parameters.AddWithValue("@TipoEspecifico", tipoEspecifico);

                var result = command.ExecuteScalar();
                if (result != null)
                {
                    productoId = Convert.ToInt32(result);
                }
                ConexionModelo.CerrarConexion();
            }
            return productoId;
        }

        public static DataTable ObtenerDatosGraficoProductos()
        {
            string sql = "SELECT p.tipo_producto_id AS TipoProductoId, SUM(p.stock) AS Stock " +
                         "FROM productos p " +
                         "GROUP BY p.tipo_producto_id";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                ConexionModelo.CerrarConexion();
                return dataTable;
            }
        }

        public static DataTable ObtenerDatosGraficoArboles()
        {
            string sql = "SELECT p.nombre AS Nombre, p.stock " +
                         "FROM productos p " +
                         "JOIN tipos_producto tp ON p.tipo_producto_id = tp.id " +
                         "WHERE p.tipo_producto_id = 1";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                ConexionModelo.CerrarConexion();
                return dataTable;
            }
        }

        public static DataTable ObtenerDatosGraficoSemillas()
        {
            string sql = "SELECT p.nombre AS Nombre, p.stock " +
                         "FROM productos p " +
                         "JOIN tipos_producto tp ON p.tipo_producto_id = tp.id " +
                         "WHERE p.tipo_producto_id = 2";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                ConexionModelo.CerrarConexion();
                return dataTable;
            }
        }
        public static int ObtenerTotalCompras()
        {
            string sql = "SELECT SUM(cantidad) FROM detalle_compra;";
            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                object result = command.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                {
                    // Si el resultado es nulo, devolver cero
                    ConexionModelo.CerrarConexion();
                    return 0;
                }
                else
                {
                    // Si el resultado no es nulo, convertir y devolver el valor
                    int totalCompras = Convert.ToInt32(result);
                    ConexionModelo.CerrarConexion();
                    return totalCompras;
                }
            }
        }
        public static int ObtenerTotalDonaciones()
        {
            string sql = "SELECT SUM(cantidad) FROM detalle_donacion;";
            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                object result = command.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                {
                    // Si el resultado es nulo, devolver cero
                    ConexionModelo.CerrarConexion();
                    return 0;
                }
                else
                {
                    // Si el resultado no es nulo, convertir y devolver el valor
                    int totalDonaciones = Convert.ToInt32(result);
                    ConexionModelo.CerrarConexion();
                    return totalDonaciones;
                }
            }
        }
        public static int ObtenerTotalRecoleccion()
        {
            string sql = "SELECT SUM(cantidad) FROM detalle_recoleccion;";
            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                object result = command.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                {
                    // Si el resultado es nulo, devolver cero
                    ConexionModelo.CerrarConexion();
                    return 0;
                }
                else
                {
                    // Si el resultado no es nulo, convertir y devolver el valor
                    int totalRecolecciones = Convert.ToInt32(result);
                    ConexionModelo.CerrarConexion();
                    return totalRecolecciones;
                }
            }
        }

        public static void EliminarProducto(int idProducto)
        {
            string sql = "DELETE FROM productos WHERE id = @id";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@id", idProducto);

                // Ejecutar el comando
                command.ExecuteNonQuery();
                ConexionModelo.CerrarConexion();
            }
        }
        public static bool VerificarProductoEnCompras(int idProducto)
        {
            string sql = "SELECT COUNT(*) FROM detalle_compra WHERE producto_id = @idProducto";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@idProducto", idProducto);

                int count = Convert.ToInt32(command.ExecuteScalar());
                ConexionModelo.CerrarConexion();

                return count > 0;
            }
        }
        public static bool VerificarProductoEnDetalleSiembra(int idProducto)
        {
            string sql = "SELECT COUNT(*) FROM detalle_siembra WHERE producto_id = @idProducto";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@idProducto", idProducto);

                int count = Convert.ToInt32(command.ExecuteScalar());
                ConexionModelo.CerrarConexion();

                return count > 0;
            }
        }

        public static void EliminarUsuario(int idUsuario)
        {
            string sql = "DELETE FROM usuarios WHERE id = @id";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@id", idUsuario);

                // Ejecutar el comando
                command.ExecuteNonQuery();
                ConexionModelo.CerrarConexion();
            }
        }

        public static void EliminarProveedor(int idProveedor)
        {
            string sql = "DELETE FROM proveedores WHERE id = @id";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@id", idProveedor);

                // Ejecutar el comando
                command.ExecuteNonQuery();
                ConexionModelo.CerrarConexion();
            }
        }
        public static bool VerificarProveedorEnCompras(int idProveedor)
        {
            string sql = "SELECT COUNT(*) FROM compras WHERE proveedor_id = @idProveedor";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@idProveedor", idProveedor);

                int count = Convert.ToInt32(command.ExecuteScalar());
                ConexionModelo.CerrarConexion();

                return count > 0;
            }
        }

        public static DataTable ObtenerMontosComprasPorTipo()
        {
            string sql = "SELECT tp.nombre AS TipoProducto, SUM(dc.precio_total) AS MontoTotal " +
                         "FROM detalle_compra dc " +
                         "JOIN productos p ON dc.producto_id = p.id " +
                         "JOIN tipos_producto tp ON p.tipo_producto_id = tp.id " +
                         "GROUP BY tp.nombre";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                ConexionModelo.CerrarConexion();
                return dataTable;
            }
        }

        public static List<Producto> ObtenerSemillasConStockMayorCero()
        {
            string sql = "SELECT p.id, p.nombre, p.tipo_producto_id, p.tipo_especifico_id, p.stock " +
                         "FROM productos p " +
                         "JOIN tipos_producto tp ON p.tipo_producto_id = tp.id " +
                         "JOIN tipos_especifico te ON p.tipo_especifico_id = te.id " +
                         "WHERE tp.nombre = 'Semilla' AND p.stock > 0";

            List<Producto> semillasConStock = new List<Producto>();

            DataTable dataTable = ExecuteQuery(sql);

            foreach (DataRow row in dataTable.Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                string nombre = row["nombre"].ToString();
                int tipoProductoId = Convert.ToInt32(row["tipo_producto_id"]);
                int tipoEspecificoId = Convert.ToInt32(row["tipo_especifico_id"]);
                int stock = Convert.ToInt32(row["stock"]);

                // Crear el objeto Producto con la información recuperada
                Producto semilla = new Producto
                {
                    Id = id,
                    Nombre = nombre,
                    TipoProductoId = tipoProductoId,
                    TipoEspecificoId = tipoEspecificoId,
                    Stock = stock
                    // Puedes agregar más atributos de Producto si es necesario
                };

                semillasConStock.Add(semilla);
            }

            return semillasConStock;
        }

        public static int GuardarSiembra(SiembraInfo siembraInfo)
        {
            int siembraId = 0;

            string sql = "INSERT INTO siembra (fecha, usuario_id) VALUES (@FechaSiembra, @UsuarioId); SELECT SCOPE_IDENTITY();";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@FechaSiembra", siembraInfo.FechaSiembra);
                command.Parameters.AddWithValue("@UsuarioId", siembraInfo.UsuarioId);

                siembraId = Convert.ToInt32(command.ExecuteScalar());
                ConexionModelo.CerrarConexion();
            }
            return siembraId;
        }

        public static void GuardarDetalleSiembra(DetalleSiembraInfo detalleSiembraInfo)
        {
            string sql = "INSERT INTO detalle_siembra (siembra_id, producto_id, cantidad) VALUES (@SiembraId, @ProductoId, @Cantidad);";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@SiembraId", detalleSiembraInfo.SiembraId);
                command.Parameters.AddWithValue("@ProductoId", detalleSiembraInfo.ProductoId);
                command.Parameters.AddWithValue("@Cantidad", detalleSiembraInfo.Cantidad);

                command.ExecuteNonQuery();
                ConexionModelo.CerrarConexion();
            }
        }

        public static void ActualizarStockSiembra(int productoId, int cantidad, List<ProductoConversion> productoConversionList)
        {
            Producto producto = ObtenerProductoPorId(productoId);

            if (producto != null)
            {
                if (producto.TipoProductoId == 2) // Representa a las semillas
                {
                    // Buscar la conversión de producto correspondiente en la lista
                    ProductoConversion conversion = productoConversionList.FirstOrDefault(p => p.ProductoSemillaId == productoId);

                    if (conversion != null)
                    {
                        // Restar la cantidad de semillas utilizadas en la siembra del stock actual de semillas
                        int nuevoStockSemillas = producto.Stock - cantidad;

                        // Actualizar el stock de semillas
                        ActualizarStock(productoId, nuevoStockSemillas);

                        // Sumar la misma cantidad al stock de árboles del producto de árbol relacionado
                        int nuevoStockArboles = ObtenerStockPorId(conversion.ProductoArbolId) + cantidad;

                        // Actualizar el stock de árboles
                        ActualizarStock(conversion.ProductoArbolId, nuevoStockArboles);
                    }
                }
            }
        }


        public static Producto ObtenerProductoPorId(int productoId)
        {
            string sql = "SELECT id, nombre, tipo_producto_id, tipo_especifico_id, stock FROM productos WHERE id = @ProductoId";

            Producto producto = null;

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@ProductoId", productoId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        producto = new Producto
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nombre = reader["nombre"].ToString(),
                            TipoProductoId = Convert.ToInt32(reader["tipo_producto_id"]),
                            TipoEspecificoId = Convert.ToInt32(reader["tipo_especifico_id"]),
                            Stock = Convert.ToInt32(reader["stock"])
                        };
                    }
                }
                ConexionModelo.CerrarConexion();
            }

            return producto;
        }
        public static int ObtenerStockPorId(int productoId)
        {
            string sql = "SELECT stock FROM productos WHERE id = @ProductoId";

            int stock = 0;

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@ProductoId", productoId);

                var result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int stockValue))
                {
                    stock = stockValue;
                }
                ConexionModelo.CerrarConexion();
            }
            return stock;
        }
        public static Producto ObtenerProductoArbolPorNombre(string nombre)
        {
            string sql = "SELECT TOP 1 * FROM productos WHERE nombre = @Nombre AND tipo_producto_id = 1";

            Producto producto = null;

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@Nombre", nombre);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        producto = new Producto
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nombre = reader["nombre"].ToString(),
                            TipoProductoId = Convert.ToInt32(reader["tipo_producto_id"]),
                            TipoEspecificoId = Convert.ToInt32(reader["tipo_especifico_id"]),
                            Stock = Convert.ToInt32(reader["stock"])
                        };
                    }
                }
            }

            return producto;
        }
        public static int InsertarProductoSiembra(Producto producto, int stockInicial)
        {
            string sql = "INSERT INTO productos (nombre, tipo_producto_id, tipo_especifico_id, stock) " +
                         "VALUES (@Nombre, @TipoProductoID, @TipoEspecificoID, @Stock); SELECT SCOPE_IDENTITY();";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@TipoProductoID", producto.TipoProductoId);
                command.Parameters.AddWithValue("@TipoEspecificoID", producto.TipoEspecificoId);
                command.Parameters.AddWithValue("@Stock", stockInicial);

                int productoId = Convert.ToInt32(command.ExecuteScalar());
                ConexionModelo.CerrarConexion();

                return productoId;
            }
        }

        public static void ActualizarUsuario(Usuario usuario)
        {
            string sql = "UPDATE usuarios SET nombre_usuario = @nombre_usuario, email = @email, rol = @rol";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@nombre_usuario", usuario.NombreUsuario);
                command.Parameters.AddWithValue("@email", usuario.Email);
                command.Parameters.AddWithValue("@rol", usuario.Rol);


                command.ExecuteNonQuery();
                ConexionModelo.CerrarConexion();
            }
        }

        public static string ObtenerCorreoUsuario(string nombreUsuario)
        {
            try
            {
                string sql = "SELECT email FROM usuarios WHERE nombre_usuario = @nombre_usuario";

                using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
                {
                    command.Parameters.AddWithValue("@nombre_usuario", nombreUsuario);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["email"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el correo electrónico del usuario: " + ex.Message);
            }

            return null; // Devuelve null en caso de error o si el usuario no se encuentra.
        }
        public static string ObtenerCorreoUsuarioAEliminar(int idUsuario)
        {
            try
            {
                string sql = "SELECT email FROM usuarios WHERE id = @idUsuario";

                using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
                {
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["email"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el correo electrónico del usuario a eliminar: " + ex.Message);
            }

            return null; // Devuelve null en caso de error o si el usuario no se encuentra.
        }
        public static bool UsuarioUtilizadoEnCompras(int idUsuario)
        {
            string sql = "SELECT COUNT(*) FROM compras WHERE usuario_id = @idUsuario";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@idUsuario", idUsuario);

                int count = Convert.ToInt32(command.ExecuteScalar());
                ConexionModelo.CerrarConexion();

                return count > 0;
            }
        }

    }
}
