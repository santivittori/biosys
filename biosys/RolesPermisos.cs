﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace biosys
{
    public partial class RolesPermisos : Form
    {
        public Dashboard DashboardInstance { get; set; }

        // Paginado de roles
        private int paginaActual = 1; 
        private int tamañoPagina = 8;
        // Paginado de permisos
        private int paginaActualPermiso = 1;
        private int tamañoPaginaPermiso = 8;


        public RolesPermisos()
        {
            InitializeComponent();

            // Cargar los permisos disponibles al iniciar el formulario
            CargarPermisos();

            dataGridViewRoles.SelectionChanged += dataGridViewRoles_SelectionChanged;
            dataGridViewPermisos.SelectionChanged += dataGridViewPermisos_SelectionChanged;
        }

        private void CargarPermisos()
        {
            // Limpiar los elementos existentes en el CheckedListBox
            checkedListBoxPermisos.Items.Clear();

            // Obtener los permisos disponibles desde la base de datos
            List<string> permisos = Controladora.Controladora.ObtenerPermisos();

            // Agregar los permisos al checkedListBoxPermisos
            foreach (string permiso in permisos)
            {
                checkedListBoxPermisos.Items.Add(permiso);
            }
        }

        public void msgError(string msg)
        {
            lblErrorRol.Text = "      " + msg;
            lblErrorRol.Visible = true;
        }

        private void LimpiarCampos()
        {
            // Limpiar el TextBox
            txtNombreRol.Clear();

            // Deseleccionar todos los elementos en el CheckedListBox
            for (int i = 0; i < checkedListBoxPermisos.Items.Count; i++)
            {
                checkedListBoxPermisos.SetItemChecked(i, false);
            }

            lblErrorRol.Visible = false;
            dataGridViewRoles.ClearSelection();
        }

        private void CrearNuevoRol(string nombreRol, List<string> permisos)
        {
            Controladora.Controladora.CrearNuevoRol(nombreRol, permisos);
        }

        private void CargarRolesEnDataGridView()
        {
            int indiceInicio = (paginaActual - 1) * tamañoPagina;
            DataTable dataTable = Controladora.Controladora.ObtenerRolesPaginados(indiceInicio, tamañoPagina);

            // Limpiar las columnas existentes en el DataGridView antes de agregar nuevas
            dataGridViewRoles.Columns.Clear();

            // Configurar DataGridView para no generar automáticamente las columnas
            dataGridViewRoles.AutoGenerateColumns = false;

            // Agregar la columna para NombreRol
            DataGridViewTextBoxColumn columnaNombreRol = new DataGridViewTextBoxColumn();
            columnaNombreRol.HeaderText = "Roles"; // Encabezado de la columna
            columnaNombreRol.DataPropertyName = "NombreRol"; // Nombre de la propiedad en el objeto de datos
            columnaNombreRol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // La columna se ajusta para llenar el espacio disponible
            columnaNombreRol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centrar el contenido de las celdas

            // Agregar la columna de NombreRol al DataGridView
            dataGridViewRoles.Columns.Add(columnaNombreRol);

            // Establecer el origen de datos después de configurar las columnas
            dataGridViewRoles.DataSource = dataTable;

            // Suscribirse al evento CellFormatting para cambiar el color de fondo de las filas según el estado del rol
            dataGridViewRoles.CellFormatting += dataGridViewRoles_CellFormatting;

            MostrarInformacionPaginacionRoles();
        }
        private void dataGridViewRoles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verificar si la celda actual es de la columna "NombreRol" y si hay datos en la fila
            if (e.ColumnIndex == dataGridViewRoles.Columns[0].Index && e.RowIndex >= 0)
            {
                // Obtener el nombre del rol de la celda actual
                string nombreRol = dataGridViewRoles.Rows[e.RowIndex].Cells[0].Value.ToString();

                // Verificar si el rol está deshabilitado
                if (!Controladora.Controladora.VerificarRolHabilitado(nombreRol))
                {
                    // Cambiar el color de fondo de la fila a amarillo para indicar que el rol está deshabilitado
                    dataGridViewRoles.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;

                    // Agregar un tooltip que explique por qué el rol está inhabilitado
                    dataGridViewRoles.Rows[e.RowIndex].Cells[0].ToolTipText = "Este rol está inhabilitado actualmente.";
                }
                else
                {
                    // Limpiar el tooltip si el rol está habilitado
                    dataGridViewRoles.Rows[e.RowIndex].Cells[0].ToolTipText = "";
                }
            }
        }

        private void dataGridViewRoles_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewRoles.SelectedRows.Count > 0)
            {
                // Obtener el nombre del rol seleccionado
                string nombreRol = dataGridViewRoles.SelectedRows[0].Cells[0].Value.ToString();

                // Habilitar o deshabilitar el TextBox dependiendo del nombre del rol seleccionado
                txtNombreRol.Enabled = !nombreRol.Equals("Empleado", StringComparison.OrdinalIgnoreCase);

                // Obtener los permisos asociados a ese rol
                List<string> permisos = Controladora.Controladora.ObtenerPermisosPorRol(nombreRol);

                // Llenar el TextBox con el nombre del rol
                txtNombreRol.Text = nombreRol;

                // Seleccionar los permisos correspondientes en el CheckedListBox
                SeleccionarPermisos(permisos);
            }
        }

        private void MostrarInformacionPaginacionRoles()
        {
            int totalRoles = Controladora.Controladora.ObtenerCantidadTotalRoles();
            int totalPaginas = (int)Math.Ceiling((double)totalRoles / tamañoPagina);
            labelRol.Text = $"Página {paginaActual} de {totalPaginas}. Total de roles: {totalRoles}";
        }

        private void btnPagAntRol_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                CargarRolesEnDataGridView();
            }
        }

        private void btnPagSigRol_Click(object sender, EventArgs e)
        {
            int totalRoles = Controladora.Controladora.ObtenerCantidadTotalRoles();
            int totalPaginas = (int)Math.Ceiling((double)totalRoles / tamañoPagina);
            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                CargarRolesEnDataGridView();
            }
        }

        private void SeleccionarPermisos(List<string> permisos)
        {
            // Deseleccionar todos los elementos en el CheckedListBox
            for (int i = 0; i < checkedListBoxPermisos.Items.Count; i++)
            {
                checkedListBoxPermisos.SetItemChecked(i, false);
            }

            // Seleccionar los permisos correspondientes en el CheckedListBox
            foreach (string permiso in permisos)
            {
                int index = checkedListBoxPermisos.Items.IndexOf(permiso);
                if (index != -1)
                {
                    checkedListBoxPermisos.SetItemChecked(index, true);
                }
            }
        }

        private bool HuboCambiosEnPermisos()
        {
            // Obtener los permisos asociados al rol seleccionado
            string nombreRolSeleccionado = dataGridViewRoles.SelectedRows[0].Cells[0].Value.ToString();
            List<string> permisosActuales = Controladora.Controladora.ObtenerPermisosPorRol(nombreRolSeleccionado);

            // Obtener los permisos seleccionados en el CheckedListBox
            List<string> permisosSeleccionados = new List<string>();
            foreach (var item in checkedListBoxPermisos.CheckedItems)
            {
                permisosSeleccionados.Add(item.ToString());
            }

            // Verificar si hay diferencias entre los permisos actuales y los seleccionados
            return !permisosActuales.SequenceEqual(permisosSeleccionados);
        }

        private void pictureBack_Click(object sender, EventArgs e)
        {
            GestionarUsuario gestionarUsuarioForm = new GestionarUsuario();
            gestionarUsuarioForm.DashboardInstance = DashboardInstance;
            DashboardInstance.AbrirFormHijo(gestionarUsuarioForm);
        }

        private void RolesPermisos_Load(object sender, EventArgs e)
        {
            CargarRolesEnDataGridView();
            CargarPermisosEnDataGridView();

            // Calcular la posición x para centrar el Label horizontalmente
            int labelPosX = (this.ClientSize.Width - labelTitulo.Width) / 2;

            // Establecer la posición del Label
            labelTitulo.Location = new Point(labelPosX, 50);
        }

        private void CargarPermisosEnDataGridView()
        {
            int indiceInicio = (paginaActualPermiso - 1) * tamañoPaginaPermiso;
            DataTable dataTablePermisos = Controladora.Controladora.ObtenerPermisosPaginados(indiceInicio, tamañoPaginaPermiso);

            // Limpiar las columnas existentes en el DataGridView antes de agregar nuevas
            dataGridViewPermisos.Columns.Clear();

            // Agregar la columna para Permisos
            DataGridViewTextBoxColumn columnaNombrePermiso = new DataGridViewTextBoxColumn();
            columnaNombrePermiso.HeaderText = "Permisos"; // Encabezado de la columna
            columnaNombrePermiso.DataPropertyName = "NombrePermiso"; // Nombre de la propiedad en el objeto de datos
            columnaNombrePermiso.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // La columna se ajusta para llenar el espacio disponible
            columnaNombrePermiso.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centrar el contenido de las celdas

            // Agregar la columna de Permisos al DataGridView
            dataGridViewPermisos.Columns.Add(columnaNombrePermiso);

            // Asignar los datos al DataSource del DataGridView
            dataGridViewPermisos.DataSource = dataTablePermisos;

            // Mostrar información de paginación
            MostrarInformacionPaginacionPermisos();
        }
        private void btnAntPermiso_Click(object sender, EventArgs e)
        {
            if (paginaActualPermiso > 1)
            {
                paginaActualPermiso--;
                CargarPermisosEnDataGridView();
            }
        }

        private void btnSigPermiso_Click(object sender, EventArgs e)
        {
            int totalPermisos = Controladora.Controladora.ObtenerCantidadTotalPermisos();
            int totalPaginas = (int)Math.Ceiling((double)totalPermisos / tamañoPaginaPermiso);
            if (paginaActualPermiso < totalPaginas)
            {
                paginaActualPermiso++;
                CargarPermisosEnDataGridView();
            }
        }

        private void MostrarInformacionPaginacionPermisos()
        {
            int totalPermisos = Controladora.Controladora.ObtenerCantidadTotalPermisos();
            int totalPaginas = (int)Math.Ceiling((double)totalPermisos / tamañoPaginaPermiso);
            labelPermiso.Text = $"Página {paginaActualPermiso} de {totalPaginas}. Total de permisos: {totalPermisos}";
        }

        public void msgErrorPermiso(string msg)
        {
            lblErrorPermiso.Text = "      " + msg;
            lblErrorPermiso.Visible = true;
        }

        private void LimpiarCamposPermiso()
        {
            txtNombrePermiso.Clear();
            lblErrorPermiso.Visible = false;
            dataGridViewPermisos.ClearSelection();
            txtNombrePermiso.Enabled = true;
        }

        private void dataGridViewPermisos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewPermisos.SelectedRows.Count > 0)
            {
                string nombrePermiso = dataGridViewPermisos.SelectedRows[0].Cells[0].Value.ToString();

                // Verificar si el nombre del permiso está en la lista de permisos deshabilitados
                List<string> permisosDeshabilitados = new List<string> {
                    "Alta de Productos",
                    "Ventas",
                    "Informes",
                    "Baja de Productos",
                    "Reproduccion",
                    "Gestionar Usuarios",
                    "ABMs"
                };

                // Deshabilitar el TextBox de permisos si el nombre del permiso está en la lista de permisos deshabilitados
                txtNombrePermiso.Enabled = !permisosDeshabilitados.Contains(nombrePermiso);

                // Asignar el nombre del permiso al TextBox de permisos
                txtNombrePermiso.Text = nombrePermiso;
            }
        }
        private bool ConfirmarCambioEstadoRol(string nombreRol, bool nuevoEstado)
        {
            string mensaje = nuevoEstado ? $"¿Desea habilitar el rol '{nombreRol}'?" : $"¿Desea deshabilitar el rol '{nombreRol}'? Esto impedirá que los usuarios con este rol inicien sesión.";
            DialogResult result = MessageBox.Show(mensaje, "Confirmar cambio de estado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        private void dataGridViewRoles_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewRoles.ClearSelection();
        }

        private void dataGridViewPermisos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewPermisos.ClearSelection();
        }

        private void btnCrearPermiso_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridViewPermisos.SelectedRows.Count > 0)
            {
                msgErrorPermiso("  Limpie los campos antes de crear un nuevo permiso.");
                return;
            }

            // Verificar si el nombre del permiso está ingresado
            if (string.IsNullOrWhiteSpace(txtNombrePermiso.Text))
            {
                msgErrorPermiso("  Ingrese un nombre para el permiso.");
                return;
            }

            // Verificar si ya existe un permiso con el mismo nombre
            string nombrePermiso = txtNombrePermiso.Text.Trim();
            if (Controladora.Controladora.ExistePermiso(nombrePermiso))
            {
                msgErrorPermiso("  Ya existe un permiso con este nombre.");
                return;
            }

            // Crear el nuevo permiso
            Controladora.Controladora.CrearNuevoPermiso(nombrePermiso);

            // Actualizar el DataGridView de permisos
            CargarPermisosEnDataGridView();

            // Actualizar el CheckedListBox de permisos
            CargarPermisos();

            LimpiarCamposPermiso();
            MessageBox.Show("¡El nuevo permiso se creó correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCrearRol_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridViewRoles.SelectedRows.Count > 0)
            {
                msgError("  Limpie los campos antes de crear un nuevo rol.");
                return;
            }

            // Verificar si el nombre del rol está ingresado
            if (string.IsNullOrWhiteSpace(txtNombreRol.Text))
            {
                msgError("  Debe ingresar un nombre para el rol.");
                return;
            }

            // Verificar si ya existe un rol con el mismo nombre
            string nombreRol = txtNombreRol.Text.Trim();
            if (Controladora.Controladora.ExisteRol(nombreRol))
            {
                msgError("  Ya existe un rol con este nombre.");
                return;
            }

            // Verificar si al menos un permiso está seleccionado
            if (checkedListBoxPermisos.CheckedItems.Count == 0)
            {
                msgError("  Debe seleccionar al menos un permiso para el rol.");
                return;
            }

            // Crear el nuevo rol con los permisos seleccionados
            CrearNuevoRol(nombreRol, checkedListBoxPermisos.CheckedItems.Cast<string>().ToList());

            LimpiarCampos();
            // Actualizar el DataGridView
            CargarRolesEnDataGridView();

            MessageBox.Show("¡El nuevo rol se creó correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuardarRol_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dataGridViewRoles.SelectedRows.Count == 0)
            {
                msgError("  Seleccione una fila de la casilla para editar.");
                return;
            }

            // Obtener el nombre del rol seleccionado en el DataGridView
            string nombreRolSeleccionado = dataGridViewRoles.SelectedRows[0].Cells[0].Value.ToString();

            // Verificar si el rol está deshabilitado
            if (!Controladora.Controladora.VerificarRolHabilitado(nombreRolSeleccionado))
            {
                msgError("  El rol ha sido deshabilitado y no puede ser editado.");
                return;
            }

            // Verificar si el rol seleccionado es "Administrador"
            if (nombreRolSeleccionado.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("No se puede modificar el rol de Administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
                return;
            }

            // Verificar si se realizaron cambios en el nombre del rol
            string nuevoNombreRol = txtNombreRol.Text.Trim();
            if (nuevoNombreRol == nombreRolSeleccionado && !HuboCambiosEnPermisos())
            {
                msgError("  No se realizaron cambios en el rol.");
                return;
            }

            // Obtener los permisos seleccionados
            List<string> permisosSeleccionados = new List<string>();
            foreach (var item in checkedListBoxPermisos.CheckedItems)
            {
                permisosSeleccionados.Add(item.ToString());
            }

            // Realizar la actualización del rol
            bool actualizacionExitosa = Controladora.Controladora.ActualizarRol(nombreRolSeleccionado, nuevoNombreRol, permisosSeleccionados);

            if (actualizacionExitosa)
            {
                MessageBox.Show("Se realizó la modificación del rol con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar los campos y actualizar el DataGridView
                LimpiarCampos();
                CargarRolesEnDataGridView();
            }
            else
            {
                MessageBox.Show("Error al intentar actualizar el rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarRol_Click(object sender, EventArgs e)
        {
            // Limpiar el TextBox
            txtNombreRol.Clear();

            // Deseleccionar todos los elementos en el CheckedListBox
            for (int i = 0; i < checkedListBoxPermisos.Items.Count; i++)
            {
                checkedListBoxPermisos.SetItemChecked(i, false);
            }

            lblErrorRol.Visible = false;
            dataGridViewRoles.ClearSelection();
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            // Verificar si se seleccionó una fila
            if (dataGridViewRoles.SelectedRows.Count == 0)
            {
                msgError("  Seleccione un rol antes de habilitarlo o deshabilitarlo.");
                return;
            }

            string nombreRol = dataGridViewRoles.SelectedRows[0].Cells[0].Value.ToString();

            // Verificar si el rol es "Administrador"
            if (nombreRol.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("El rol de Administrador no se puede deshabilitar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
                return;
            }

            // Obtener el estado actual del rol
            bool rolHabilitado = Controladora.Controladora.VerificarRolHabilitado(nombreRol);

            // Invertir el estado del rol
            bool nuevoEstadoRol = !rolHabilitado;

            // Confirmar con el usuario si desea cambiar el estado del rol
            DialogResult result = MessageBox.Show($"¿Desea {(nuevoEstadoRol ? "habilitar" : "deshabilitar")} el rol '{nombreRol}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Actualizar el estado del rol en la base de datos
                bool actualizacionExitosa = Controladora.Controladora.ActualizarEstadoRol(nombreRol, nuevoEstadoRol);

                if (actualizacionExitosa)
                {
                    if (nuevoEstadoRol)
                    {
                        MessageBox.Show($"El rol '{nombreRol}' se habilitó con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"El rol '{nombreRol}' se deshabilitó con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Actualizar el DataGridView
                    CargarRolesEnDataGridView();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show($"No se pudo cambiar el estado del rol '{nombreRol}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminarRol_Click(object sender, EventArgs e)
        {
            // Verificar si se seleccionó una fila
            if (dataGridViewRoles.SelectedRows.Count == 0)
            {
                msgError("  Seleccione un rol antes de eliminarlo.");
                return;
            }

            string nombreRol = dataGridViewRoles.SelectedRows[0].Cells[0].Value.ToString();

            // Verificar si el rol es "Administrador"
            if (nombreRol.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("El rol de Administrador no se puede eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarCampos();
                return;
            }

            // Verificar si el rol tiene al menos uno de los permisos que requieren protección
            List<string> permisosProtegidos = new List<string> { "Alta de Productos", "Ventas", "Reproduccion" };
            List<string> permisosRol = Controladora.Controladora.ObtenerPermisosPorRol(nombreRol);

            if (permisosRol.Intersect(permisosProtegidos).Any())
            {
                MessageBox.Show($"El rol '{nombreRol}' no se puede eliminar porque tiene permisos que requieren protección.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Preguntar al usuario si está seguro de eliminar el rol
            DialogResult result = MessageBox.Show($"¿Desea eliminar el rol '{nombreRol}'? Esto eliminará también los usuarios asociados.", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool eliminacionExitosa = Controladora.Controladora.EliminarRol(nombreRol);

                if (eliminacionExitosa)
                {
                    MessageBox.Show($"El rol '{nombreRol}' se eliminó con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Actualizar el DataGridView
                    CargarRolesEnDataGridView();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show($"No se pudo eliminar el rol '{nombreRol}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGuardarPermiso_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dataGridViewPermisos.SelectedRows.Count == 0)
            {
                msgErrorPermiso("  Seleccione una fila de la casilla para editar.");
                return;
            }

            // Obtener el nombre del permiso seleccionado en el DataGridView
            string nombrePermisoSeleccionado = dataGridViewPermisos.SelectedRows[0].Cells[0].Value.ToString();

            // Verificar si se realizaron cambios en el nombre del permiso
            string nuevoNombrePermiso = txtNombrePermiso.Text.Trim();
            if (nuevoNombrePermiso == nombrePermisoSeleccionado)
            {
                msgErrorPermiso("  No se realizaron cambios en el permiso.");
                return;
            }

            // Realizar la actualización del permiso
            bool actualizacionExitosa = Controladora.Controladora.ActualizarPermiso(nombrePermisoSeleccionado, nuevoNombrePermiso);

            if (actualizacionExitosa)
            {
                MessageBox.Show("Se realizó la modificación del permiso con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar los campos y actualizar el DataGridView de empleados y el CheckedListBox de permisos
                LimpiarCamposPermiso();
                CargarPermisosEnDataGridView();
                CargarPermisos();
            }
            else
            {
                MessageBox.Show("Error al intentar actualizar el permiso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLimpiarPermisos_Click(object sender, EventArgs e)
        {
            // Limpiar el TextBox
            txtNombrePermiso.Clear();

            lblErrorPermiso.Visible = false;
            dataGridViewPermisos.ClearSelection();
            txtNombrePermiso.Enabled = true;
        }
        private void btnEliminarPermiso_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dataGridViewPermisos.SelectedRows.Count == 0)
            {
                msgErrorPermiso("  Seleccione una fila de la casilla para eliminar.");
                return;
            }

            // Obtener el nombre del permiso seleccionado en el DataGridView
            string nombrePermisoSeleccionado = dataGridViewPermisos.SelectedRows[0].Cells[0].Value.ToString();

            // Verificar si el permiso está asociado a algún rol
            if (Controladora.Controladora.PermisoAsociadoARol(nombrePermisoSeleccionado))
            {
                MessageBox.Show("El permiso está asociado a un rol y no se puede eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Preguntar al usuario si está seguro de eliminar el permiso
            DialogResult result = MessageBox.Show($"¿Desea eliminar el permiso '{nombrePermisoSeleccionado}'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Eliminar el permiso
                bool eliminacionExitosa = Controladora.Controladora.EliminarPermiso(nombrePermisoSeleccionado);

                if (eliminacionExitosa)
                {
                    MessageBox.Show($"El permiso '{nombrePermisoSeleccionado}' se eliminó con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Actualizar el DataGridView de permisos
                    CargarPermisosEnDataGridView();

                    // Actualizar el CheckedListBox de permisos
                    CargarPermisos();

                    LimpiarCamposPermiso();
                }
                else
                {
                    MessageBox.Show($"Error al intentar eliminar el permiso '{nombrePermisoSeleccionado}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCrearRol_MouseEnter(object sender, EventArgs e)
        {
            btnCrearRol.BackColor = Color.FromArgb(0, 192, 0);
        }

        private void btnCrearRol_MouseLeave(object sender, EventArgs e)
        {
            btnCrearRol.BackColor = Color.White;
        }

        private void btnCrearPermiso_MouseEnter(object sender, EventArgs e)
        {
            btnCrearPermiso.BackColor = Color.FromArgb(0, 192, 0);
        }

        private void btnCrearPermiso_MouseLeave(object sender, EventArgs e)
        {
            btnCrearPermiso.BackColor = Color.White;
        }

        private void btnHabilitar_MouseEnter(object sender, EventArgs e)
        {
            btnHabilitar.BackColor = Color.Yellow;
        }

        private void btnHabilitar_MouseLeave(object sender, EventArgs e)
        {
            btnHabilitar.BackColor = Color.White;
        }

        private void btnEliminarRol_MouseEnter(object sender, EventArgs e)
        {
            btnEliminarRol.BackColor = Color.Red;
        }

        private void btnEliminarRol_MouseLeave(object sender, EventArgs e)
        {
            btnEliminarRol.BackColor = Color.White;
        }

        private void btnEliminarPermiso_MouseEnter(object sender, EventArgs e)
        {
            btnEliminarPermiso.BackColor = Color.Red;
        }

        private void btnEliminarPermiso_MouseLeave(object sender, EventArgs e)
        {
            btnEliminarPermiso.BackColor = Color.White;
        }

        private void btnGuardarPermiso_MouseEnter(object sender, EventArgs e)
        {
            btnGuardarPermiso.BackColor = Color.FromArgb(0, 192, 0);
        }

        private void btnGuardarPermiso_MouseLeave(object sender, EventArgs e)
        {
            btnGuardarPermiso.BackColor = Color.White;
        }

        private void btnGuardarRol_MouseEnter(object sender, EventArgs e)
        {
            btnGuardarRol.BackColor = Color.FromArgb(0, 192, 0);
        }

        private void btnGuardarRol_MouseLeave(object sender, EventArgs e)
        {
            btnGuardarRol.BackColor = Color.White;
        }
    }
}
