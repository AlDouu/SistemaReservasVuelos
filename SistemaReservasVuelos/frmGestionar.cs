using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Clases_para_Proyecto
{
    public partial class frmGestionar : Form
    {
        private readonly cPasajero pasajero;
        private readonly List<cReserva> reservas;
        private cReserva? reservaSeleccionada;

        public frmGestionar(cPasajero pPasajero, List<cReserva> pReservas)
        {
            InitializeComponent();
            pasajero = pPasajero ?? throw new ArgumentNullException(nameof(pPasajero));
            reservas = pReservas ?? throw new ArgumentNullException(nameof(pReservas));

            // Configuración inicial
            ConfigureDataGridView();
            CargarReservas();
        }

        private void ConfigureDataGridView()
        {
            // Configuración básica del DataGridView
            dgvReservas.AutoGenerateColumns = false;
            dgvReservas.AllowUserToAddRows = false;
            dgvReservas.AllowUserToDeleteRows = false;
            dgvReservas.ReadOnly = true;
            dgvReservas.MultiSelect = false;
            dgvReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservas.RowHeadersVisible = false;

            // Crear columnas
            dgvReservas.Columns.Clear();
            dgvReservas.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CodigoVuelo",
                HeaderText = "Código Vuelo",
                DataPropertyName = "CodigoVuelo",
                Width = 120
            });

            dgvReservas.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Origen",
                HeaderText = "Origen",
                DataPropertyName = "Origen",
                Width = 120
            });

            // Agregar las demás columnas de la misma manera...
            dgvReservas.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Destino",
                HeaderText = "Destino",
                DataPropertyName = "Destino",
                Width = 120
            });

            dgvReservas.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "FechaVuelo",
                HeaderText = "Fecha",
                DataPropertyName = "FechaVuelo",
                Width = 100
            });

            dgvReservas.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NroAsiento",
                HeaderText = "Asiento",
                DataPropertyName = "NroAsiento",
                Width = 80
            });

            dgvReservas.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Estado",
                HeaderText = "Estado",
                DataPropertyName = "Estado",
                Width = 100
            });

            dgvReservas.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "AsientosDisp",
                HeaderText = "Asientos Disp.",
                DataPropertyName = "AsientosDisp",
                Width = 120
            });
        }

        private void CargarReservas()
        {
            try
            {
                dgvReservas.Rows.Clear();

                foreach (var reserva in pasajero.Reservas)
                {
                    if (reserva.Vuelo == null) continue;

                    int rowIndex = dgvReservas.Rows.Add(
                        reserva.Vuelo.CodigoVuelo,
                        reserva.Vuelo.Origen,
                        reserva.Vuelo.Destino,
                        reserva.Vuelo.FechaVuelo.ToShortDateString(),
                        reserva.NroAsiento,
                        reserva.Confirmada ? "Confirmada" : "Pendiente",
                        $"{reserva.Vuelo.AsientosDisponibles}/{reserva.Vuelo.CapacidadTotal}");

                    // Opcional: Establecer estilo de fila basado en el estado
                    if (!reserva.Confirmada)
                    {
                        dgvReservas.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                }

                btnEliminar.Enabled = false;
                reservaSeleccionada = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar reservas: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvReservas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count == 0 || dgvReservas.SelectedRows[0].Index < 0)
            {
                btnEliminar.Enabled = false;
                return;
            }

            var selectedRow = dgvReservas.SelectedRows[0];
            var codigoVuelo = selectedRow.Cells["CodigoVuelo"].Value?.ToString();
            var nroAsientoStr = selectedRow.Cells["NroAsiento"].Value?.ToString();

            if (string.IsNullOrEmpty(codigoVuelo) || string.IsNullOrEmpty(nroAsientoStr) ||
                !int.TryParse(nroAsientoStr, out int nroAsiento))
            {
                btnEliminar.Enabled = false;
                return;
            }

            reservaSeleccionada = pasajero.Reservas.Find(r =>
                r.Vuelo != null &&
                r.Vuelo.CodigoVuelo == codigoVuelo &&
                r.NroAsiento == nroAsiento);

            btnEliminar.Enabled = reservaSeleccionada != null;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (reservaSeleccionada == null) return;

            var confirmacion = MessageBox.Show(
                $"¿Está seguro que desea eliminar la reserva del vuelo {reservaSeleccionada.Vuelo?.CodigoVuelo}?\n\n" +
                $"Asiento: {reservaSeleccionada.NroAsiento}\n" +
                $"Estado: {(reservaSeleccionada.Confirmada ? "Confirmada" : "Pendiente")}",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirmacion != DialogResult.Yes) return;

            try
            {
                // Liberar el asiento
                if (reservaSeleccionada.Cancelar() == false)
                {
                    MessageBox.Show("No se pudo liberar el asiento", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Eliminar de las listas
                pasajero.EliminarReserva(reservaSeleccionada);
                reservas.Remove(reservaSeleccionada);

                // Guardar cambios
                cReserva.GuardarEnArchivo("reservas.txt", reservas);

                // Actualizar vista
                CargarReservas();

                MessageBox.Show("Reserva eliminada exitosamente", "Éxito",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar reserva: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}