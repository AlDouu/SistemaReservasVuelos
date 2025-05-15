using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Clases_para_Proyecto
{
    public partial class frmReservar : Form
    {
        private cPasajero pasajero;
        private List<cVuelo> vuelos;
        private List<cReserva> reservas;
        private cVuelo? vueloSeleccionado;

        public frmReservar(cPasajero pPasajero, List<cVuelo> pVuelos, List<cReserva> pReservas)
        {
            InitializeComponent();
            pasajero = pPasajero;
            vuelos = pVuelos;
            reservas = pReservas;
            CargarVuelos();
        }

        private void CargarVuelos()
        {
            dgvVuelos.Rows.Clear();
            foreach (var vuelo in vuelos)
            {
                if (vuelo.AsientosDisponibles > 0)
                {
                    dgvVuelos.Rows.Add(
                        vuelo.CodigoVuelo,
                        vuelo.Origen,
                        vuelo.Destino,
                        vuelo.FechaVuelo.ToShortDateString(),
                        vuelo.HoraVuelo,
                        $"{vuelo.AsientosDisponibles}/{vuelo.CapacidadTotal}",
                        $"${vuelo.Precio}");
                }
            }
        }

        private void dgvVuelos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVuelos.SelectedRows.Count > 0 && dgvVuelos.SelectedRows[0].Cells[0].Value != null)
            {
                string? codigoVuelo = dgvVuelos.SelectedRows[0].Cells[0].Value.ToString();
                if (!string.IsNullOrEmpty(codigoVuelo))
                {
                    vueloSeleccionado = vuelos.Find(v => v.CodigoVuelo == codigoVuelo);
                    btnConfirmar.Enabled = (vueloSeleccionado != null && vueloSeleccionado.AsientosDisponibles > 0);
                    return;
                }
            }
            btnConfirmar.Enabled = false;
            vueloSeleccionado = null;
        }

        private void btnConfirmar_Click_1(object sender, EventArgs e)
        {
            // Verificación más robusta de la selección
            if (dgvVuelos.SelectedRows.Count == 0 ||
                dgvVuelos.SelectedRows[0].Index < 0 ||
                vueloSeleccionado == null)
            {
                MessageBox.Show("Seleccione un vuelo válido primero", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Obtener datos del vuelo seleccionado
                DataGridViewRow fila = dgvVuelos.SelectedRows[0];
                string codigoVuelo = fila.Cells[0].Value?.ToString() ?? "";
                string origen = fila.Cells[1].Value?.ToString() ?? "";
                string destino = fila.Cells[2].Value?.ToString() ?? "";
                string fecha = fila.Cells[3].Value?.ToString() ?? "";
                string hora = fila.Cells[4].Value?.ToString() ?? "";
                string disponibilidad = fila.Cells[5].Value?.ToString() ?? "";
                string precio = fila.Cells[6].Value?.ToString() ?? "";

                // Confirmación con el usuario
                string mensaje = $"¿Desea confirmar la reserva para el siguiente vuelo?\n\n" +
                               $"Origen: {origen}\nDestino: {destino}\nFecha: {fecha}\n" +
                               $"Hora: {hora}\nDisponibilidad: {disponibilidad}\nPrecio: {precio}";

                DialogResult resultado = MessageBox.Show(mensaje, "Confirmar reserva",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Asignar asiento automáticamente
                    int nroAsiento = vueloSeleccionado.ObtenerProximoAsientoDisponible();
                    if (nroAsiento == -1)
                    {
                        MessageBox.Show("No hay asientos disponibles", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Crear reserva
                    var reserva = new cReserva(pasajero, vueloSeleccionado, nroAsiento);
                    if (reserva.Confirmar() == false)
                    {
                        MessageBox.Show("No se pudo confirmar la reserva", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Actualizar listas
                    reservas.Add(reserva);
                    pasajero.AgregarReserva(reserva);

                    // Guardar en archivo
                    cReserva.GuardarEnArchivo("reservas.txt", reservas);

                    MessageBox.Show($"Reserva confirmada. Asiento: {nroAsiento}", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Actualizar vista
                    CargarVuelos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al confirmar reserva: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}