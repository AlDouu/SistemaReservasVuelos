using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Clases_para_Proyecto
{
    public partial class frmInicio : Form
    {
        private List<cPasajero> pasajeros;
        private List<cVuelo> vuelos;
        private List<cReserva> reservas;

        public frmInicio()
        {
            InitializeComponent();
            CargarDatosIniciales();
        }

        private void CargarDatosIniciales()
        {
            // Cargar datos desde archivos
            pasajeros = cPasajero.CargarDesdeArchivo("pasajeros.txt");
            vuelos = cVuelo.CargarDesdeArchivo("vuelos.txt");
            reservas = cReserva.CargarDesdeArchivo("reservas.txt", pasajeros, vuelos);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                var pasajero = new cPasajero(
                    txtNombre.Text,
                    txtApellido.Text,
                    txtDNI.Text,
                    dtpFechaNac.Value,
                    txtTelefono.Text,
                    txtCorreo.Text);

                // Verificar si el pasajero ya existe
                var existe = pasajeros.Any(p => p.DNI == pasajero.DNI);

                if (!existe)
                {
                    pasajeros.Add(pasajero);
                    cPasajero.GuardarEnArchivo("pasajeros.txt", pasajeros);
                }

                // Mostrar el formulario de opciones
                var frmMostrar = new frmMostrar(pasajero, vuelos, reservas);
                this.Hide();
                frmMostrar.ShowDialog();
                this.Show();
            }
        }

        private bool ValidarDatos()
        {
            // Validar que todos los campos estén completos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDNI.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar formato de DNI (ejemplo simple)
            if (txtDNI.Text.Length < 8)
            {
                MessageBox.Show("El DNI debe tener al menos 8 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}