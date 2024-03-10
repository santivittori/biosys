using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidad;
using System.Net.Http.Headers;
using System.Collections;
using System.Runtime.Remoting.Messaging;

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

        public static List<string> ObtenerRolesDisponibles()
        {
            string sql = "SELECT nombre_rol FROM roles";

            List<string> rolesDisponibles = new List<string>();

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    rolesDisponibles.Add(reader["nombre_rol"].ToString());
                }
                reader.Close();
            }
            return rolesDisponibles;
        }

        public static List<string> ObtenerPermisosPorRol(string rol)
        {
            List<string> permisos = new List<string>();

            string sql = @"
                SELECT p.nombre_permiso 
                FROM permisos p 
                JOIN roles_permisos rp ON p.id = rp.id_permiso 
                JOIN roles r ON rp.id_rol = r.id 
                WHERE r.nombre_rol = @rol";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@rol", rol);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        permisos.Add(reader["nombre_permiso"].ToString());
                    }
                }
            }
            return permisos;
        }

        public static List<string> ObtenerPermisos()
        {
            List<string> permisos = new List<string>();

            string sql = "SELECT nombre_permiso FROM permisos";

            using (SqlConnection connection = ConexionModelo.AbrirConexion())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            permisos.Add(reader["nombre_permiso"].ToString());
                        }
                    }
                }
            }

            return permisos;
        }
        public static DataTable ObtenerPermisosPaginados(int indiceInicio, int tamañoPagina)
        {
            string sql = @"SELECT nombre_permiso AS NombrePermiso
               FROM (SELECT ROW_NUMBER() OVER (ORDER BY id) - 1 AS RowNum, * FROM permisos) AS permisosConNumeros
               WHERE RowNum >= @IndiceInicio AND RowNum < @IndiceFin";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@IndiceInicio", indiceInicio);
                command.Parameters.AddWithValue("@IndiceFin", indiceInicio + tamañoPagina);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public static bool ActualizarPermiso(string nombrePermisoSeleccionado, string nuevoNombrePermiso)
        {
            string sql = "UPDATE permisos SET nombre_permiso = @NuevoNombre WHERE nombre_permiso = @NombrePermiso";

            using (SqlConnection connection = ConexionModelo.AbrirConexion())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@NuevoNombre", nuevoNombrePermiso);
                    command.Parameters.AddWithValue("@NombrePermiso", nombrePermisoSeleccionado);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        public static int ObtenerCantidadTotalPermisos()
        {
            int totalPermisos = 0;

            string sql = "SELECT COUNT(*) FROM permisos";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                totalPermisos = (int)command.ExecuteScalar();
            }

            return totalPermisos;
        }


        public static void CrearNuevoRol(string nombreRol, List<string> permisos)
        {
            using (SqlConnection connection = ConexionModelo.AbrirConexion())
            {
                // Insertar el nuevo rol en la tabla roles
                string sqlInsertRol = "INSERT INTO roles (nombre_rol) VALUES (@nombreRol)";
                using (SqlCommand commandInsertRol = new SqlCommand(sqlInsertRol, connection))
                {
                    commandInsertRol.Parameters.AddWithValue("@nombreRol", nombreRol);
                    commandInsertRol.ExecuteNonQuery();
                }

                // Obtener el ID del rol recién insertado
                string sqlSelectRolId = "SELECT @@IDENTITY";
                int nuevoRolId;
                using (SqlCommand commandSelectRolId = new SqlCommand(sqlSelectRolId, connection))
                {
                    nuevoRolId = Convert.ToInt32(commandSelectRolId.ExecuteScalar());
                }

                // Insertar los permisos del nuevo rol en la tabla roles_permisos
                string sqlInsertRolPermisos = "INSERT INTO roles_permisos (id_rol, id_permiso) VALUES (@idRol, @idPermiso)";
                foreach (string permiso in permisos)
                {
                    string sqlSelectPermisoId = "SELECT id FROM permisos WHERE nombre_permiso = @permiso";
                    int permisoId;
                    using (SqlCommand commandSelectPermisoId = new SqlCommand(sqlSelectPermisoId, connection))
                    {
                        commandSelectPermisoId.Parameters.AddWithValue("@permiso", permiso);
                        permisoId = Convert.ToInt32(commandSelectPermisoId.ExecuteScalar());
                    }

                    using (SqlCommand commandInsertRolPermiso = new SqlCommand(sqlInsertRolPermisos, connection))
                    {
                        commandInsertRolPermiso.Parameters.AddWithValue("@idRol", nuevoRolId);
                        commandInsertRolPermiso.Parameters.AddWithValue("@idPermiso", permisoId);
                        commandInsertRolPermiso.ExecuteNonQuery();
                    }
                }
            }
        }

        public static List<string> ObtenerNombresRoles()
        {
            List<string> nombresRoles = new List<string>();

            using (SqlConnection connection = ConexionModelo.AbrirConexion())
            {
                string sql = "SELECT nombre_rol FROM roles";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            nombresRoles.Add(reader["nombre_rol"].ToString());
                        }
                    }
                }
            }

            return nombresRoles;
        }

        public static bool ActualizarRol(string nombreRolAnterior, string nuevoNombreRol, List<string> nuevosPermisos)
        {
            using (SqlConnection connection = ConexionModelo.AbrirConexion())
            {
                // Actualizar el nombre del rol en la tabla roles
                string sqlActualizarNombreRol = "UPDATE roles SET nombre_rol = @nuevoNombre WHERE nombre_rol = @nombreAnterior";

                using (SqlCommand commandActualizarNombreRol = new SqlCommand(sqlActualizarNombreRol, connection))
                {
                    commandActualizarNombreRol.Parameters.AddWithValue("@nuevoNombre", nuevoNombreRol);
                    commandActualizarNombreRol.Parameters.AddWithValue("@nombreAnterior", nombreRolAnterior);

                    commandActualizarNombreRol.ExecuteNonQuery();
                }

                // Obtener el ID del nuevo rol actualizado
                string sqlObtenerIdRol = "SELECT id FROM roles WHERE nombre_rol = @nombreRol";

                int idRol;
                using (SqlCommand commandObtenerIdRol = new SqlCommand(sqlObtenerIdRol, connection))
                {
                    commandObtenerIdRol.Parameters.AddWithValue("@nombreRol", nuevoNombreRol);
                    idRol = (int)commandObtenerIdRol.ExecuteScalar();
                }

                // Eliminar todos los permisos asociados al rol anterior
                string sqlEliminarPermisos = "DELETE FROM roles_permisos WHERE id_rol = @idRolAnterior";

                using (SqlCommand commandEliminarPermisos = new SqlCommand(sqlEliminarPermisos, connection))
                {
                    commandEliminarPermisos.Parameters.AddWithValue("@idRolAnterior", idRol);
                    commandEliminarPermisos.ExecuteNonQuery();
                }

                // Insertar los nuevos permisos asociados al rol actualizado
                string sqlInsertarPermisos = "INSERT INTO roles_permisos (id_rol, id_permiso) VALUES (@idRol, @idPermiso)";

                foreach (var permiso in nuevosPermisos)
                {
                    int idPermiso;
                    // Obtener el ID del permiso
                    string sqlObtenerIdPermiso = "SELECT id FROM permisos WHERE nombre_permiso = @nombrePermiso";

                    using (SqlCommand commandObtenerIdPermiso = new SqlCommand(sqlObtenerIdPermiso, connection))
                    {
                        commandObtenerIdPermiso.Parameters.AddWithValue("@nombrePermiso", permiso);
                        idPermiso = (int)commandObtenerIdPermiso.ExecuteScalar();
                    }

                    // Insertar el nuevo permiso asociado al rol actualizado
                    using (SqlCommand commandInsertarPermiso = new SqlCommand(sqlInsertarPermisos, connection))
                    {
                        commandInsertarPermiso.Parameters.AddWithValue("@idRol", idRol);
                        commandInsertarPermiso.Parameters.AddWithValue("@idPermiso", idPermiso);
                        commandInsertarPermiso.ExecuteNonQuery();
                    }
                }

                // Actualizar el rol de los usuarios que tenían el rol anterior
                string sqlActualizarUsuarios = @"UPDATE usuarios SET rol = @nuevoNombreRol WHERE rol = @nombreRolAnterior";

                using (SqlCommand commandActualizarUsuarios = new SqlCommand(sqlActualizarUsuarios, connection))
                {
                    commandActualizarUsuarios.Parameters.AddWithValue("@nuevoNombreRol", nuevoNombreRol);
                    commandActualizarUsuarios.Parameters.AddWithValue("@nombreRolAnterior", nombreRolAnterior);
                    commandActualizarUsuarios.ExecuteNonQuery();
                }
            }

            return true;
        }

        public static bool EliminarRol(string nombreRol)
        {
            using (SqlConnection connection = ConexionModelo.AbrirConexion())
            {
                // Obtener el ID del rol a eliminar
                string sqlObtenerIdRol = "SELECT id FROM roles WHERE nombre_rol = @nombreRol";

                int idRol;
                using (SqlCommand commandObtenerIdRol = new SqlCommand(sqlObtenerIdRol, connection))
                {
                    commandObtenerIdRol.Parameters.AddWithValue("@nombreRol", nombreRol);
                    idRol = (int)commandObtenerIdRol.ExecuteScalar();
                }

                // Eliminar los permisos asociados al rol
                string sqlEliminarPermisos = "DELETE FROM roles_permisos WHERE id_rol = @idRol";

                using (SqlCommand commandEliminarPermisos = new SqlCommand(sqlEliminarPermisos, connection))
                {
                    commandEliminarPermisos.Parameters.AddWithValue("@idRol", idRol);
                    commandEliminarPermisos.ExecuteNonQuery();
                }

                // Eliminar el rol
                string sqlEliminarRol = "DELETE FROM roles WHERE nombre_rol = @nombreRol";

                using (SqlCommand commandEliminarRol = new SqlCommand(sqlEliminarRol, connection))
                {
                    commandEliminarRol.Parameters.AddWithValue("@nombreRol", nombreRol);
                    commandEliminarRol.ExecuteNonQuery();
                }

                // Eliminar los usuarios que tenían el rol
                string sqlEliminarUsuarios = "DELETE FROM usuarios WHERE rol = @nombreRol";

                using (SqlCommand commandEliminarUsuarios = new SqlCommand(sqlEliminarUsuarios, connection))
                {
                    commandEliminarUsuarios.Parameters.AddWithValue("@nombreRol", nombreRol);
                    commandEliminarUsuarios.ExecuteNonQuery();
                }

                return true;
            }
        }
        public static bool DeshabilitarRol(string nombreRol)
        {
            string sql = "UPDATE roles SET habilitado = 0 WHERE nombre_rol = @NombreRol";

            using (SqlConnection connection = ConexionModelo.AbrirConexion())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@NombreRol", nombreRol);
                    int filasActualizadas = command.ExecuteNonQuery();

                    return filasActualizadas > 0;
                }
            }
        }
        public static bool VerificarRolHabilitado(string rol)
        {
            string sql = "SELECT COUNT(*) FROM roles WHERE nombre_rol = @NombreRol AND Habilitado = 1";

            using (SqlConnection connection = ConexionModelo.AbrirConexion())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@NombreRol", rol);

                    int count = (int)command.ExecuteScalar();

                    // Si count es mayor que 0, significa que el rol está habilitado
                    return count > 0;
                }
            }
        }
        public static bool ActualizarEstadoRol(string nombreRol, bool nuevoEstado)
        {
            string sql = "UPDATE roles SET habilitado = @NuevoEstado WHERE nombre_rol = @NombreRol";

            using (SqlConnection connection = ConexionModelo.AbrirConexion())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@NuevoEstado", nuevoEstado);
                    command.Parameters.AddWithValue("@NombreRol", nombreRol);

                    int filasActualizadas = command.ExecuteNonQuery();

                    // Si se actualizó al menos una fila, se considera una actualización exitosa
                    return filasActualizadas > 0;
                }
            }
        }
        public static bool ExisteRol(string nombreRol)
        {
            using (SqlConnection connection = ConexionModelo.AbrirConexion())
            {
                string sql = "SELECT COUNT(*) FROM roles WHERE nombre_rol = @nombreRol";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@nombreRol", nombreRol);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        public static int ObtenerCantidadTotalRoles()
        {
            int totalRoles = 0;

            string sql = "SELECT COUNT(*) FROM roles";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                totalRoles = (int)command.ExecuteScalar();
            }

            return totalRoles;
        }

        public static DataTable ObtenerRolesPaginados(int indiceInicio, int tamañoPagina)
        {
            string sql = @"SELECT id AS ID, nombre_rol AS NombreRol
               FROM (SELECT ROW_NUMBER() OVER (ORDER BY id) - 1 AS RowNum, * FROM roles) AS rolesConNumeros
               WHERE RowNum >= @IndiceInicio AND RowNum < @IndiceFin";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@IndiceInicio", indiceInicio);
                command.Parameters.AddWithValue("@IndiceFin", indiceInicio + tamañoPagina);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public static DataTable ObtenerTodosLosPermisos()
        {
            DataTable dataTablePermisos = new DataTable();

            string sql = "SELECT nombre_permiso FROM permisos";

            using (SqlConnection connection = ConexionModelo.AbrirConexion())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTablePermisos);
                }
            }

            return dataTablePermisos;
        }

        public static void CrearNuevoPermiso(string nombrePermiso)
        {
            string sql = "INSERT INTO permisos (nombre_permiso) VALUES (@NombrePermiso)";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@NombrePermiso", nombrePermiso);
                command.ExecuteNonQuery();
            }
        }

        public static bool ExistePermiso(string nombrePermiso)
        {
            string sql = "SELECT COUNT(*) FROM permisos WHERE nombre_permiso = @NombrePermiso";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@NombrePermiso", nombrePermiso);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
        public static bool PermisoAsociadoARol(string nombrePermisoSeleccionado)
        {
            // Consultar si el permiso está asociado a algún rol en la base de datos
            string sql = "SELECT COUNT(*) FROM roles_permisos WHERE id_permiso = (SELECT id FROM permisos WHERE nombre_permiso = @NombrePermiso)";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@NombrePermiso", nombrePermisoSeleccionado);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
        public static bool EliminarPermiso(string nombrePermisoSeleccionado)
        {
            // Eliminar el permiso de la base de datos
            string sqlEliminarPermiso = "DELETE FROM permisos WHERE nombre_permiso = @NombrePermiso";

            using (SqlConnection connection = ConexionModelo.AbrirConexion())
            {
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Eliminar el permiso de la tabla permisos
                        using (SqlCommand commandEliminarPermiso = new SqlCommand(sqlEliminarPermiso, connection, transaction))
                        {
                            commandEliminarPermiso.Parameters.AddWithValue("@NombrePermiso", nombrePermisoSeleccionado);
                            commandEliminarPermiso.ExecuteNonQuery();
                        }

                        // Eliminar el registro del permiso de la tabla roles_permisos si existiera
                        string sqlEliminarRolPermiso = "DELETE FROM roles_permisos WHERE id_permiso = (SELECT id FROM permisos WHERE nombre_permiso = @NombrePermiso)";
                        using (SqlCommand commandEliminarRolPermiso = new SqlCommand(sqlEliminarRolPermiso, connection, transaction))
                        {
                            commandEliminarRolPermiso.Parameters.AddWithValue("@NombrePermiso", nombrePermisoSeleccionado);
                            commandEliminarRolPermiso.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public static bool VerificarExistenciaUsuario(string nombreUsuario)
        {
            string sql = "SELECT COUNT(*) FROM usuarios WHERE nombre_usuario = @nombre_usuario";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@nombre_usuario", nombreUsuario);
                int count = (int)command.ExecuteScalar();
                
                return count != 0;
            }
        }

        public static string ObtenerCorreoUsuarioPorID(int idUsuario)
        {
            string correoUsuario = null;

            string sql = "SELECT email FROM usuarios WHERE id = @IdUsuario";

            using (SqlConnection connection = ConexionModelo.AbrirConexion())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    // Ejecutar el comando y obtener el resultado
                    SqlDataReader reader = command.ExecuteReader();

                    // Verificar si se encontraron resultados
                    if (reader.Read())
                    {
                        correoUsuario = reader["email"].ToString();
                    }

                    // Cerrar el lector
                    reader.Close();
                }
            }

            return correoUsuario;
        }
        public static bool VerificarUsuarioHabilitadoPorID(int idUsuario)
        {
            bool usuarioHabilitado = false;

            string sql = "SELECT COUNT(*) FROM usuarios WHERE id = @IdUsuario AND habilitado = 1";

            using (SqlConnection connection = ConexionModelo.AbrirConexion())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    int count = (int)command.ExecuteScalar();

                    // Si count es mayor que 0, significa que el usuario está habilitado
                    usuarioHabilitado = count > 0;
                }
            }

            return usuarioHabilitado;
        }
        public static bool VerificarUsuarioHabilitado(string nombreUsuario)
        {
            string sql = "SELECT COUNT(*) FROM usuarios WHERE nombre_usuario = @NombreUsuario AND habilitado = 1";

            using (SqlConnection connection = ConexionModelo.AbrirConexion())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                    int count = (int)command.ExecuteScalar();

                    // Si count es mayor que 0, significa que el usuario está habilitado
                    return count > 0;
                }
            }
        }
        public static bool ActualizarEstadoUsuarioPorID(int idUsuario, bool nuevoEstadoUsuario)
        {
            string sql = "UPDATE usuarios SET Habilitado = @NuevoEstadoUsuario WHERE id = @IdUsuario";

            using (SqlConnection connection = ConexionModelo.AbrirConexion())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@NuevoEstadoUsuario", nuevoEstadoUsuario);
                    command.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    int filasActualizadas = command.ExecuteNonQuery();

                    // Si se actualizó al menos una fila, se considera una actualización exitosa
                    return filasActualizadas > 0;
                }
            }
        }

        public static bool VerificarExistenciaEmail(string email)
        {
            string sql = "SELECT COUNT(*) FROM usuarios WHERE email = @Email;";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@Email", email);
                int count = Convert.ToInt32(command.ExecuteScalar());
                
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
                        return usuario;
                    }
                    else
                    {
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
            }
        }

        public static List<Proveedor> ObtenerDatosProveedores()
        {
            List<Proveedor> proveedores = new List<Proveedor>();

            using (SqlConnection connection = ConexionModelo.AbrirConexion())
            {
                string sql = "SELECT nombre_prov, apellido_prov, email_prov FROM proveedores";

                using (SqlCommand command = new SqlCommand(sql, connection))
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
                    }
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

                return dataTable;
            }
        }

        public static DataTable ObtenerProveedoresPaginados(int indiceInicio, int tamañoPagina)
        {
            string sql = @"SELECT id AS ID, nombre_prov AS Nombre, apellido_prov AS Apellido, email_prov AS Email, telefono_prov AS Telefono 
                       FROM proveedores
                       ORDER BY id
                       OFFSET @IndiceInicio ROWS
                       FETCH NEXT @TamañoPagina ROWS ONLY";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                // Agregar parámetros para la paginación
                command.Parameters.AddWithValue("@IndiceInicio", indiceInicio);
                command.Parameters.AddWithValue("@TamañoPagina", tamañoPagina);

                // Crear un adaptador de datos y llenar el DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public static int ObtenerCantidadTotalProveedores()
        {
            int totalProveedores = 0;

            string sql = "SELECT COUNT(*) FROM proveedores";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                totalProveedores = (int)command.ExecuteScalar();
            }

            // Retornar el número total de proveedores
            return totalProveedores;
        }

        public static DataTable ObtenerUsuarios()
        {
            string sql = "SELECT id AS ID, nombre_usuario AS Nombre, email AS Email, rol AS Rol FROM usuarios";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public static DataTable ObtenerUsuariosPaginados(int indiceInicio, int tamañoPagina)
        {
            string sql = @"SELECT id AS ID, nombre_usuario AS Nombre, email AS Email, rol AS Rol 
                   FROM (SELECT ROW_NUMBER() OVER (ORDER BY id) - 1 AS RowNum, * FROM usuarios) AS usuariosConNumeros 
                   WHERE RowNum >= @IndiceInicio AND RowNum < @IndiceFin";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@IndiceInicio", indiceInicio);
                command.Parameters.AddWithValue("@IndiceFin", indiceInicio + tamañoPagina);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public static int ObtenerCantidadTotalUsuarios()
        {
            int totalUsuarios = 0;

            string sql = "SELECT COUNT(*) FROM usuarios";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                totalUsuarios = (int)command.ExecuteScalar();
            }

            return totalUsuarios;
        }

        public static DataTable ExecuteQuery(string sql)
        {
            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);

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

        public static DataTable ObtenerProductosPaginados(int indiceInicio, int tamañoPagina)
        {
            string sql = @"SELECT p.id AS ID, p.nombre AS Nombre, tp.nombre AS TipoProducto, te.nombre AS TipoEspecifico 
                   FROM productos p 
                   JOIN tipos_producto tp ON p.tipo_producto_id = tp.id 
                   JOIN tipos_especifico te ON p.tipo_especifico_id = te.id
                   ORDER BY p.id
                   OFFSET @IndiceInicio ROWS
                   FETCH NEXT @TamañoPagina ROWS ONLY";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                // Agregar parámetros para la paginación
                command.Parameters.AddWithValue("@IndiceInicio", indiceInicio);
                command.Parameters.AddWithValue("@TamañoPagina", tamañoPagina);

                // Crear un adaptador de datos y llenar el DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public static int ObtenerCantidadTotalProductos()
        {
            int totalProductos = 0;

            string sql = "SELECT COUNT(*) FROM productos";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                totalProductos = (int)command.ExecuteScalar();
            }

            // Retornar el número total de productos
            return totalProductos;
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
                    
                    return 0;
                }
                else
                {
                    // Si el resultado no es nulo, convertir y devolver el valor
                    int totalCompras = Convert.ToInt32(result);
                    
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
                    return 0;
                }
                else
                {
                    // Si el resultado no es nulo, convertir y devolver el valor
                    int totalDonaciones = Convert.ToInt32(result);
                    
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
                    
                    return 0;
                }
                else
                {
                    // Si el resultado no es nulo, convertir y devolver el valor
                    int totalRecolecciones = Convert.ToInt32(result);
                    
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
            }
        }
        public static bool VerificarProductoEnCompras(int idProducto)
        {
            string sql = "SELECT COUNT(*) FROM detalle_compra WHERE producto_id = @idProducto";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@idProducto", idProducto);

                int count = Convert.ToInt32(command.ExecuteScalar());

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
            }
        }
        public static bool VerificarProveedorEnCompras(int idProveedor)
        {
            string sql = "SELECT COUNT(*) FROM compras WHERE proveedor_id = @idProveedor";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@idProveedor", idProveedor);

                int count = Convert.ToInt32(command.ExecuteScalar());
                
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
                
                return count > 0;
            }
        }
        public static bool UsuarioUtilizadoEnVentas(int idUsuario)
        {
            string sql = "SELECT COUNT(*) FROM ventas WHERE usuario_id = @idUsuario";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@idUsuario", idUsuario);

                int count = Convert.ToInt32(command.ExecuteScalar());

                return count > 0;
            }
        }

        public static bool VerificarClienteExistente(ClienteInfo clienteInfo)
        {
            string sql = "SELECT COUNT(*) FROM clientes WHERE nombre_cliente = @nombre AND apellido_cliente = @apellido AND email_cliente = @email";
            int count;

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@nombre", clienteInfo.Nombre);
                command.Parameters.AddWithValue("@apellido", clienteInfo.Apellido);
                command.Parameters.AddWithValue("@email", clienteInfo.Email);

                count = (int)command.ExecuteScalar();
                
            }
            return count > 0;
        }

        public static void ActualizarCliente(ClienteInfo clienteInfo)
        {
            string sql = "UPDATE clientes SET nombre_cliente = @nombre, apellido_cliente = @apellido, email_cliente = @email, telefono_cliente = @telefono WHERE id = @id";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@nombre", clienteInfo.Nombre);
                command.Parameters.AddWithValue("@apellido", clienteInfo.Apellido);
                command.Parameters.AddWithValue("@email", clienteInfo.Email);
                command.Parameters.AddWithValue("@telefono", clienteInfo.Telefono);
                command.Parameters.AddWithValue("@id", clienteInfo.Id);

                command.ExecuteNonQuery();
            }
        }
        public static void InsertarCliente(ClienteInfo clienteInfo)
        {
            string sql = "INSERT INTO clientes (nombre_cliente, apellido_cliente, email_cliente, telefono_cliente) VALUES (@Nombre, @Apellido, @Email, @Telefono)";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@Nombre", clienteInfo.Nombre);
                command.Parameters.AddWithValue("@Apellido", clienteInfo.Apellido);
                command.Parameters.AddWithValue("@Email", clienteInfo.Email);
                command.Parameters.AddWithValue("@Telefono", clienteInfo.Telefono);

                command.ExecuteNonQuery();
            }
        }
        public static DataTable ObtenerClientes()
        {
            string sql = "SELECT id AS ID, nombre_cliente AS Nombre, apellido_cliente AS Apellido, email_cliente AS Email, telefono_cliente AS Telefono FROM clientes";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public static DataTable ObtenerClientesPaginados(int indiceInicio, int tamañoPagina)
        {
            string sql = @"SELECT id AS ID, nombre_cliente AS Nombre, apellido_cliente AS Apellido, email_cliente AS Email, telefono_cliente AS Telefono 
                   FROM clientes
                   ORDER BY id
                   OFFSET @IndiceInicio ROWS
                   FETCH NEXT @TamañoPagina ROWS ONLY";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                // Agregar parámetros para la paginación
                command.Parameters.AddWithValue("@IndiceInicio", indiceInicio);
                command.Parameters.AddWithValue("@TamañoPagina", tamañoPagina);

                // Crear un adaptador de datos y llenar el DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public static int ObtenerCantidadTotalClientes()
        {
            int totalClientes = 0;

            string sql = "SELECT COUNT(*) FROM clientes";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                totalClientes = (int)command.ExecuteScalar();
            }

            // Retornar el número total de clientes
            return totalClientes;
        }

        public static void EliminarCliente(int idCliente)
        {
            string sql = "DELETE FROM clientes WHERE id = @id";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@id", idCliente);

                // Ejecutar el comando
                command.ExecuteNonQuery();
            }
        }

        public static bool VerificarClienteEnVentas(int idCliente)
        {
            string sql = "SELECT COUNT(*) FROM ventas WHERE cliente_id = @idCliente";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@idCliente", idCliente);

                int count = Convert.ToInt32(command.ExecuteScalar());
                
                return count > 0;
            }
        }

        public static List<Cliente> ObtenerDatosClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            string sql = "SELECT nombre_cliente, apellido_cliente, email_cliente FROM clientes";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nombre = reader.GetString(0);
                        string apellido = reader.GetString(1);
                        string email = reader.GetString(2);

                        Cliente cliente = new Cliente
                        {
                            Nombre = nombre,
                            Apellido = apellido,
                            Email = email
                        };

                        clientes.Add(cliente);
                    }
                }
            }
            return clientes;
        }

        public static List<ProductoInfo> ObtenerProductosStockComboBox()
        {
            string sql = "SELECT p.id, p.nombre, tp.nombre AS tipo_producto, te.nombre AS tipo_especifico, p.stock " +
                         "FROM productos p " +
                         "JOIN tipos_producto tp ON p.tipo_producto_id = tp.id " +
                         "JOIN tipos_especifico te ON p.tipo_especifico_id = te.id " +
                         "WHERE p.stock > 0";  // Agregar esta condición para filtrar productos con stock > 0

            List<ProductoInfo> productos = new List<ProductoInfo>();

            DataTable dataTable = ExecuteQuery(sql);

            foreach (DataRow row in dataTable.Rows)
            {
                ProductoInfo producto = new ProductoInfo
                {
                    Id = Convert.ToInt32(row["id"]),
                    Nombre = row["nombre"].ToString(),
                    TipoProducto = row["tipo_producto"].ToString(),
                    TipoEspecifico = row["tipo_especifico"].ToString(),
                    Stock = Convert.ToInt32(row["stock"])
                };

                productos.Add(producto);
            }
            return productos;
        }

        public static int GuardarVenta(VentaInfo ventaInfo)
        {
            int ventaId = 0;

            string sql = "INSERT INTO ventas (fecha, cliente_id, usuario_id, precio_total) " +
                         "VALUES (@FechaVenta, (SELECT id FROM clientes WHERE email_cliente = @ClienteEmail), @UsuarioId, @PrecioTotalVenta);" +
                         "SELECT SCOPE_IDENTITY();";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@FechaVenta", ventaInfo.FechaVenta);
                command.Parameters.AddWithValue("@ClienteEmail", ventaInfo.ClienteEmail);
                command.Parameters.AddWithValue("@UsuarioId", ventaInfo.UsuarioId);
                command.Parameters.AddWithValue("@PrecioTotalVenta", ventaInfo.PrecioTotalVenta);

                ventaId = Convert.ToInt32(command.ExecuteScalar());
            }

            return ventaId;
        }

        public static void GuardarDetalleVenta(DetalleVentaInfo detalleVentaInfo)
        {
            string sql = "INSERT INTO detalle_venta (venta_id, producto_id, cantidad, precio_unitario, precio_total) " +
                         "VALUES (@VentaId, @ProductoId, @Cantidad, @PrecioUnitario, @PrecioTotalDetalle)";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@VentaId", detalleVentaInfo.VentaId);
                command.Parameters.AddWithValue("@ProductoId", detalleVentaInfo.ProductoId);
                command.Parameters.AddWithValue("@Cantidad", detalleVentaInfo.Cantidad);
                command.Parameters.AddWithValue("@PrecioUnitario", detalleVentaInfo.PrecioUnitario);
                command.Parameters.AddWithValue("@PrecioTotalDetalle", detalleVentaInfo.PrecioTotalDetalle);

                command.ExecuteNonQuery();
            }
        }

        public static DataTable ObtenerMontosVentasPorTipo()
        {
            string sql = "SELECT tp.nombre AS TipoProducto, SUM(dv.precio_total) AS MontoTotal " +
                         "FROM detalle_venta dv " +
                         "JOIN productos p ON dv.producto_id = p.id " +
                         "JOIN tipos_producto tp ON p.tipo_producto_id = tp.id " +
                         "GROUP BY tp.nombre";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public static DataTable ObtenerTresArbolesMasVendidos()
        {
            string sql = "SELECT TOP 3 p.nombre AS Producto, SUM(dv.cantidad) AS CantidadVendida, SUM(dv.precio_total) AS MontoTotal " +
                         "FROM detalle_venta dv " +
                         "JOIN productos p ON dv.producto_id = p.id " +
                         "WHERE p.tipo_producto_id = 1 " + // 1 representa el ID de Árbol en tu tabla de tipos de producto
                         "GROUP BY p.nombre " +
                         "ORDER BY CantidadVendida DESC";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                
                return dataTable;
            }
        }

        public static DataTable ObtenerTresSemillasMasCompradas()
        {
            string sql = "SELECT TOP 3 p.nombre AS Producto, SUM(dc.cantidad) AS CantidadComprada, SUM(dc.precio_total) AS MontoTotal " +
                         "FROM detalle_compra dc " +
                         "JOIN productos p ON dc.producto_id = p.id " +
                         "WHERE p.tipo_producto_id = 2 " + // 2 representa el ID de Semilla en tu tabla de tipos de producto
                         "GROUP BY p.nombre " +
                         "ORDER BY CantidadComprada DESC";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public static int ObtenerStockProducto(string productName, string tipoProducto)
        {
            string sql = "SELECT stock FROM productos WHERE nombre = @Nombre AND tipo_producto_id = (SELECT id FROM tipos_producto WHERE nombre = @Tipo)";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@Nombre", productName);
                command.Parameters.AddWithValue("@Tipo", tipoProducto);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    return -1; // Otra manera de manejar este caso especial
                }
            }
        }

        public static void DisminuirStockProducto(string productName, int cantidad, string tipoProducto)
        {
            string sql = @"UPDATE productos 
                   SET stock = stock - @Cantidad 
                   WHERE nombre = @Nombre 
                   AND tipo_producto_id = (SELECT id FROM tipos_producto WHERE nombre = @TipoProducto)";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@Cantidad", cantidad);
                command.Parameters.AddWithValue("@Nombre", productName);
                command.Parameters.AddWithValue("@TipoProducto", tipoProducto);

                command.ExecuteNonQuery();
            }
        }

        public static void ActualizarStockArbol(int productoId, int cantidad)
        {
            string sql = "UPDATE productos " +
                         "SET stock = stock + @Cantidad " +
                         "WHERE id = @ProductoId";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                command.Parameters.AddWithValue("@Cantidad", cantidad);
                command.Parameters.AddWithValue("@ProductoId", productoId);

                command.ExecuteNonQuery();
            }
        }

        public static void RegistrarBajaProducto(string productName, int cantidadBaja, string motivo)
        {
            DateTime fechaBaja = DateTime.Now;

            // Verificar si ya existe una entrada para el producto y la fecha de baja actual
            string sqlCheckExistence = "SELECT COUNT(*) FROM bajas_productos WHERE producto_id = (SELECT TOP 1 id FROM productos WHERE nombre = @productName) AND fecha_baja = @fechaBaja";

            using (SqlCommand commandCheckExistence = new SqlCommand(sqlCheckExistence, ConexionModelo.AbrirConexion()))
            {
                commandCheckExistence.Parameters.AddWithValue("@fechaBaja", fechaBaja);
                commandCheckExistence.Parameters.AddWithValue("@productName", productName);

                int existingCount = (int)commandCheckExistence.ExecuteScalar();

                if (existingCount > 0)
                {
                    // Si ya existe una entrada para el producto y la fecha de baja actual, actualizar la cantidad en lugar de insertar una nueva fila
                    string sqlUpdate = "UPDATE bajas_productos SET cantidad += @cantidadBaja WHERE producto_id = (SELECT id FROM productos WHERE nombre = @productName) AND fecha_baja = @fechaBaja";

                    using (SqlCommand commandUpdate = new SqlCommand(sqlUpdate, ConexionModelo.AbrirConexion()))
                    {
                        commandUpdate.Parameters.AddWithValue("@cantidadBaja", cantidadBaja);
                        commandUpdate.Parameters.AddWithValue("@fechaBaja", fechaBaja);
                        commandUpdate.Parameters.AddWithValue("@productName", productName);

                        commandUpdate.ExecuteNonQuery();
                    }
                }
                else
                {
                    // Si no existe una entrada para el producto y la fecha de baja actual, insertar una nueva fila
                    string sqlInsert = "INSERT INTO bajas_productos (producto_id, cantidad, motivo, fecha_baja) " +
                                       "SELECT p.id, @cantidadBaja, @motivo, @fechaBaja " +
                                       "FROM productos p " +
                                       "WHERE p.nombre = @productName";

                    using (SqlCommand commandInsert = new SqlCommand(sqlInsert, ConexionModelo.AbrirConexion()))
                    {
                        commandInsert.Parameters.AddWithValue("@cantidadBaja", cantidadBaja);
                        commandInsert.Parameters.AddWithValue("@motivo", motivo);
                        commandInsert.Parameters.AddWithValue("@fechaBaja", fechaBaja);
                        commandInsert.Parameters.AddWithValue("@productName", productName);

                        commandInsert.ExecuteNonQuery();
                    }
                }
            }
        }

        public static DataTable ObtenerDatosBajasProductos()
        {
            string sql = @"SELECT motivo, SUM(cantidad) AS Total
                   FROM (SELECT DISTINCT motivo, cantidad FROM bajas_productos) AS UniqueBajas
                   GROUP BY motivo";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public static DataTable ObtenerDatosBajasTotales()
        {
            string sql = @"SELECT 'Total' AS motivo, SUM(Total) AS Total
                   FROM (
                       SELECT SUM(cantidad) AS Total
                       FROM (
                           SELECT DISTINCT motivo, cantidad 
                           FROM bajas_productos
                       ) AS UniqueBajas
                       GROUP BY motivo
                   ) AS TotalPorMotivo";

            using (SqlCommand command = new SqlCommand(sql, ConexionModelo.AbrirConexion()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public static DataTable ObtenerHistorialComprasConNombres()
        {
            DataTable dtHistorialCompras = new DataTable();

            string sql = @"SELECT c.id AS ID, 
                            c.nro_factura AS 'Nro. Factura', 
                            c.nro_remito AS 'Nro. Remito', 
                            c.fecha AS 'Fecha', 
                            p.nombre_prov AS 'Proveedor', 
                            CASE 
                                WHEN u.nombre_usuario = 'admin' THEN 'Usuario Privilegiado'
                                ELSE u.nombre_usuario 
                            END AS 'Usuario', 
                            dp.cantidad AS 'Cantidad',
                            pr.nombre AS 'Producto'
                     FROM compras c
                     INNER JOIN proveedores p ON c.proveedor_id = p.id
                     INNER JOIN usuarios u ON c.usuario_id = u.id
                     INNER JOIN detalle_compra dp ON c.id = dp.compra_id
                     INNER JOIN productos pr ON dp.producto_id = pr.id";

            using (SqlConnection connection = ConexionModelo.AbrirConexion())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dtHistorialCompras);
                }
            }

            return dtHistorialCompras;
        }
        public static int ObtenerCantidadTotalCompras()
        {
            int totalCompras = 0;

            string sql = "SELECT COUNT(*) FROM compras";

            using (SqlConnection connection = ConexionModelo.AbrirConexion())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // Ejecutar el comando y obtener el resultado
                    totalCompras = (int)command.ExecuteScalar();
                }
            }

            return totalCompras;
        }
        public static DataTable ObtenerHistorialDonacionesConNombres()
        {
            DataTable dtHistorialDonaciones = new DataTable();

            string sql = @"SELECT d.id AS ID,
                            d.entidad_donante AS 'Entidad Donante',
                            d.fecha AS 'Fecha',
                            CASE 
                                WHEN u.nombre_usuario = 'admin' THEN 'Usuario Privilegiado'
                                ELSE u.nombre_usuario 
                            END AS 'Usuario',
                            p.nombre AS 'Producto',
                            dr.cantidad AS 'Cantidad'
                     FROM donaciones d
                     INNER JOIN usuarios u ON d.usuario_id = u.id
                     INNER JOIN detalle_donacion dr ON d.id = dr.donacion_id
                     INNER JOIN productos p ON dr.producto_id = p.id";

            using (SqlConnection connection = ConexionModelo.AbrirConexion())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dtHistorialDonaciones);
                }
            }

            return dtHistorialDonaciones;
        }

        public static int ObtenerCantidadTotalDonaciones()
        {
            int totalDonaciones = 0;

            string sql = "SELECT COUNT(*) FROM donaciones";

            using (SqlConnection connection = ConexionModelo.AbrirConexion())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // Ejecutar el comando y obtener el resultado
                    totalDonaciones = (int)command.ExecuteScalar();
                }
            }

            return totalDonaciones;
        }
        public static DataTable ObtenerHistorialRecoleccionesConNombres()
        {
            DataTable dtHistorialRecolecciones = new DataTable();

            string sql = @"SELECT r.id AS ID,
                            r.lugar AS 'Lugar',
                            r.fecha AS 'Fecha',
                            CASE 
                                WHEN u.nombre_usuario = 'admin' THEN 'Usuario Privilegiado'
                                ELSE u.nombre_usuario 
                            END AS 'Usuario',
                            p.nombre AS 'Producto',
                            dr.cantidad AS 'Cantidad'
                     FROM recolecciones r
                     INNER JOIN usuarios u ON r.usuario_id = u.id
                     INNER JOIN detalle_recoleccion dr ON r.id = dr.recoleccion_id
                     INNER JOIN productos p ON dr.producto_id = p.id";

            using (SqlConnection connection = ConexionModelo.AbrirConexion())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dtHistorialRecolecciones);
                }
            }

            return dtHistorialRecolecciones;
        }

        public static int ObtenerCantidadTotalRecolecciones()
        {
            int totalRecolecciones = 0;

            string sql = "SELECT COUNT(*) FROM recolecciones";

            using (SqlConnection connection = ConexionModelo.AbrirConexion())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // Ejecutar el comando y obtener el resultado
                    totalRecolecciones = (int)command.ExecuteScalar();
                }
            }

            return totalRecolecciones;
        }
        public static DataTable ObtenerHistorialReproduccionesConNombres()
        {
            DataTable dtHistorialReproducciones = new DataTable();

            string sql = @"SELECT s.id AS ID,
                            s.fecha AS 'Fecha',
                            CASE 
                                WHEN u.nombre_usuario = 'admin' THEN 'Usuario Privilegiado'
                                ELSE u.nombre_usuario 
                            END AS 'Usuario',
                            p.nombre AS 'Producto',
                            ds.cantidad AS 'Cantidad'
                     FROM siembra s
                     INNER JOIN usuarios u ON s.usuario_id = u.id
                     INNER JOIN detalle_siembra ds ON s.id = ds.siembra_id
                     INNER JOIN productos p ON ds.producto_id = p.id";

            using (SqlConnection connection = ConexionModelo.AbrirConexion())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dtHistorialReproducciones);
                }
            }

            return dtHistorialReproducciones;
        }

        public static int ObtenerCantidadTotalReproducciones()
        {
            int totalReproducciones = 0;

            string sql = "SELECT COUNT(*) FROM siembra";

            using (SqlConnection connection = ConexionModelo.AbrirConexion())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // Ejecutar el comando y obtener el resultado
                    totalReproducciones = (int)command.ExecuteScalar();
                }
            }

            return totalReproducciones;
        }
    }
}
