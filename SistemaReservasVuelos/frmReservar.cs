using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Clases_para_Proyecto
{
    public partial class frmReservar : Form
    {
        private cPasajero pasajero;
        private List<cVuelo> vuelos;
        private List<cReserva> reservas;
        private cVuelo vueloSeleccionado;

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
            if (dgvVuelos.SelectedRows.Count > 0)
            {
                string codigoVuelo = dgvVuelos.SelectedRows[0].Cells[0].Value.ToString();
                vueloSeleccionado = vuelos.Find(v => v.CodigoVuelo == codigoVuelo);
                btnConfirmar.Enabled = true;

                // Cargar asientos disponibles
                CargarAsientosDisponibles();
            }
            else
            {
                btnConfirmar.Enabled = false;
            }
        }

        private void CargarAsientosDisponibles()
        {
            cmbAsientos.Items.Clear();
            if (vueloSeleccionado != null)
            {
                for (int i = 1; i <= vueloSeleccionado.CapacidadTotal; i++)
                {
                    if (!vueloSeleccionado.AsientosOcupados.Contains(i))
                    {
                        cmbAsientos.Items.Add(i);
                    }
                }

                if (cmbAsientos.Items.Count > 0)
                {
                    cmbAsientos.SelectedIndex = 0;
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (vueloSeleccionado != null && cmbAsientos.SelectedItem != null)
            {
                int nroAsiento = (int)cmbAsientos.SelectedItem;
                var reserva = new cReserva(pasajero, vueloSeleccionado, nroAsiento);
                reserva.Confirmar();
                reservas.Add(reserva);
                pasajero.AgregarReserva(reserva);

                // Guardar la reserva
                cReserva.GuardarEnArchivo("reservas.txt", reservas);

                MessageBox.Show("Reserva confirmada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarVuelos();
                CargarAsientosDisponibles();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}