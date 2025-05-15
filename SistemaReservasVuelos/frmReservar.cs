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
            // Añadirlos en la tabla creada con columnas previamente
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

        /*
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
        }*/

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }






        private void btnConfirmar_Click_1(object sender, EventArgs e)
        {
            // Buscar código de vuelo de tabla y guardarlo en la forma "12345678|AV101|15|true"
            // ->  DNI | Cod Vuelo | NroAsiento | Confirmada (sin espacios)
            //238574521
            if (dgvVuelos.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvVuelos.SelectedRows[0];

                string codigoVuelo = filaSeleccionada.Cells[0].Value?.ToString();
                string origen = filaSeleccionada.Cells[1].Value?.ToString();
                string destino = filaSeleccionada.Cells[2].Value?.ToString();
                string fecha = filaSeleccionada.Cells[3].Value?.ToString();
                string hora = filaSeleccionada.Cells[4].Value?.ToString();
                string disponibilidad = filaSeleccionada.Cells[5].Value?.ToString();
                string precio = filaSeleccionada.Cells[6].Value?.ToString();

                string mensaje = $"¿Desea confirmar la reserva para el siguiente vuelo?\n\n" +
                         $"Origen: {origen}\nDestino: {destino}\nFecha: {fecha}\nHora: {hora}\nDisponibilidad: {disponibilidad}\nPrecio: {precio}";

                DialogResult resultado = MessageBox.Show(mensaje, "Confirmar reserva", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Se puede ir a la ventana de pagos o simplemente guardar en el archivo validando que este pasajero no haya hecho una reserva en este vuelo antes
                    Console.WriteLine();

                }
                else { }

            }
            else
            {
                MessageBox.Show("Seleccione una fila primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }



        // Se puede usar evento de click sobre la tabla para almacenar los valores mostrados
        // Esto servirá solo para selecionar el codigo de vuelo (fecha y hora para validar que sea el mismo) y buscarlo en el atributo de vuelos pasado del anterior form

    }
}