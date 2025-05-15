using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Clases_para_Proyecto
{
    public partial class frmGestionar : Form
    {
        private cPasajero pasajero;
        private List<cReserva> reservas;
        private cReserva reservaSeleccionada;

        public frmGestionar(cPasajero pPasajero, List<cReserva> pReservas)
        {
            InitializeComponent();
            pasajero = pPasajero;
            reservas = pReservas;

            CargarReservas();
        }

        private void CargarReservas()
        {
            dgvReservas.Rows.Clear();
            foreach (var reserva in pasajero.Reservas)
            {
                dgvReservas.Rows.Add(
                    reserva.Vuelo.CodigoVuelo,
                    reserva.Vuelo.Origen,
                    reserva.Vuelo.Destino,
                    reserva.Vuelo.FechaVuelo.ToShortDateString(),
                    reserva.NroAsiento,
                    reserva.Confirmada ? "Confirmada" : "Pendiente");
            }

            btnEliminar.Enabled = false;
        }

        

        private void dgvReservas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count > 0)
            {
                string codigoVuelo = dgvReservas.SelectedRows[0].Cells[0].Value.ToString();
                int nroAsiento = int.Parse(dgvReservas.SelectedRows[0].Cells[4].Value.ToString());
                reservaSeleccionada = pasajero.Reservas.Find(r => r.Vuelo.CodigoVuelo == codigoVuelo && r.NroAsiento == nroAsiento);
                btnEliminar.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (reservaSeleccionada != null)
            {
                var confirmacion = MessageBox.Show("¿Está seguro que desea eliminar esta reserva?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    reservaSeleccionada.Cancelar();
                    pasajero.EliminarReserva(reservaSeleccionada);
                    reservas.Remove(reservaSeleccionada);

                    // Guardar cambios
                    cReserva.GuardarEnArchivo("reservas.txt", reservas);

                    MessageBox.Show("Reserva eliminada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarReservas();
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}