using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Modelo
{
    public class ConsultasModelo
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

        public static void GuardarNuevoUsuario(string nombreUsuario, string claveHash, string email, string rol)
        {
            string sql = "INSERT INTO usuarios (nombre_usuario, clave, email, rol) VALUES (@nombre_usuario, @clave, @email, @rol)";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@nombre_usuario", nombreUsuario);
                command.Parameters.AddWithValue("@clave", claveHash);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@rol", rol);

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
        public static bool VerificarProveedorExistente(string nombre, string apellido, string email)
        {
            string sql = "SELECT COUNT(*) FROM proveedores WHERE nombre_prov = @nombre AND apellido_prov = @apellido AND email_prov = @email";
            int count;

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@apellido", apellido);
                command.Parameters.AddWithValue("@email", email);

                count = (int)command.ExecuteScalar();
                ConexionModelo.CerrarConexion();
            }
            return count > 0;
        }

        public static void InsertarProveedor(string nombre, string apellido, string email, string telefono)
        {
            string sql = "INSERT INTO proveedores (nombre_prov, apellido_prov, email_prov, telefono_prov) VALUES (@Nombre, @Apellido, @Email, @Telefono)";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Apellido", apellido);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Telefono", telefono);

                command.ExecuteNonQuery();
                ConexionModelo.CerrarConexion();
            }
        }
        public static void ActualizarProveedor(int idProveedorSeleccionado, string nombre, string apellido, string email, string telefono)
        {
            string sql = "UPDATE proveedores SET nombre_prov = @nombre, apellido_prov = @apellido, email_prov = @email, telefono_prov = @telefono WHERE id = @id";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@apellido", apellido);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@telefono", telefono);
                command.Parameters.AddWithValue("@id", idProveedorSeleccionado);

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
        public static bool VerificarProductoExistente(string nombre, int tipoProductoID, int tipoEspecificoID)
        {
            string sql = "SELECT COUNT(*) FROM productos WHERE nombre = @nombre AND tipo_producto_id = @tipoProductoID AND tipo_especifico_id = @tipoEspecificoID";
            int count;

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@tipoProductoID", tipoProductoID);
                command.Parameters.AddWithValue("@tipoEspecificoID", tipoEspecificoID);

                count = (int)command.ExecuteScalar();
                ConexionModelo.CerrarConexion();
            }
            return count > 0;
        }
        public static void InsertarProducto(string nombre, int tipoProductoID, int tipoEspecificoID)
        {
            string sql = "INSERT INTO productos (nombre, tipo_producto_id, tipo_especifico_id, stock) " +
                         "VALUES (@Nombre, @TipoProductoID, @TipoEspecificoID, 0)";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@TipoProductoID", tipoProductoID);
                command.Parameters.AddWithValue("@TipoEspecificoID", tipoEspecificoID);

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

        public static int GuardarCompra(string nroFactura, string nroRemito, DateTime fechaCompra, string proveedorEmail, int usuarioId)
        {
            int compraId = 0;

            string sql = "INSERT INTO compras (nro_factura, nro_remito, fecha, proveedor_id, usuario_id) " +
                         "VALUES (@NroFactura, @NroRemito, @FechaCompra, (SELECT id FROM proveedores WHERE email_prov = @ProveedorEmail), @UsuarioId);" +
                         "SELECT SCOPE_IDENTITY();";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@NroFactura", nroFactura);
                command.Parameters.AddWithValue("@NroRemito", nroRemito);
                command.Parameters.AddWithValue("@FechaCompra", fechaCompra);
                command.Parameters.AddWithValue("@ProveedorEmail", proveedorEmail);
                command.Parameters.AddWithValue("@UsuarioId", usuarioId);

                compraId = Convert.ToInt32(command.ExecuteScalar());
                ConexionModelo.CerrarConexion();
            }

            return compraId;
        }

        public static void GuardarDetalleCompra(int compraId, int productoId, int cantidad)
        {
            string sql = "INSERT INTO detalle_compra (compra_id, producto_id, cantidad) " +
                         "VALUES (@CompraId, @ProductoId, @Cantidad)";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@CompraId", compraId);
                command.Parameters.AddWithValue("@ProductoId", productoId);
                command.Parameters.AddWithValue("@Cantidad", cantidad);

                command.ExecuteNonQuery();
                ConexionModelo.CerrarConexion();
            }
        }

        public static int GuardarDonacion(string donante, DateTime fechaDonacion, int usuarioId)
        {
            int donacionId = 0;

            string sql = "INSERT INTO donaciones (entidad_donante, fecha, usuario_id) " +
                         "VALUES (@EntidadDonante, @FechaDonacion, @UsuarioId);" +
                         "SELECT SCOPE_IDENTITY();";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@EntidadDoante", donante);
                command.Parameters.AddWithValue("@FechaDonacion", fechaDonacion);
                command.Parameters.AddWithValue("@UsuarioId", usuarioId);

                donacionId = Convert.ToInt32(command.ExecuteScalar());
                ConexionModelo.CerrarConexion();
            }

            return donacionId;
        }
        public static void GuardarDetalleDonacion(int donacionId, int productoId, int cantidad)
        {
            string sql = "INSERT INTO detalle_donacion (donacion_id, producto_id, cantidad) " +
                         "VALUES (@DonacionId, @ProductoId, @Cantidad)";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@DonacionId", donacionId);
                command.Parameters.AddWithValue("@ProductoId", productoId);
                command.Parameters.AddWithValue("@Cantidad", cantidad);

                command.ExecuteNonQuery();
                ConexionModelo.CerrarConexion();
            }
        }
        public static int GuardarRecoleccion(string lugar, DateTime fechaRecoleccion, int usuarioId)
        {
            int recoleccionId = 0;

            string sql = "INSERT INTO recolecciones (lugar, fecha, usuario_id) " +
                         "VALUES (@Lugar, @FechaRecoleccion, @UsuarioId);" +
                         "SELECT SCOPE_IDENTITY();";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@Lugar", lugar);
                command.Parameters.AddWithValue("@FechaRecolecccion", fechaRecoleccion);
                command.Parameters.AddWithValue("@UsuarioId", usuarioId);

                recoleccionId = Convert.ToInt32(command.ExecuteScalar());
                ConexionModelo.CerrarConexion();
            }

            return recoleccionId;
        }
        public static void GuardarDetalleRecoleccion(int recoleccionId, int productoId, int cantidad)
        {
            string sql = "INSERT INTO detalle_recoleccion (recoleccion_id, producto_id, cantidad) " +
                         "VALUES (@RecoleccionId, @ProductoId, @Cantidad)";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@RecoleccionId", recoleccionId);
                command.Parameters.AddWithValue("@ProductoId", productoId);
                command.Parameters.AddWithValue("@Cantidad", cantidad);

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

    }
}
