using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Clases_para_Proyecto
{
    public partial class frmMostrar : Form
    {
        private cPasajero pasajero;
        private List<cVuelo> vuelos;
        private List<cReserva> reservas;

        public frmMostrar(cPasajero pPasajero, List<cVuelo> pVuelos, List<cReserva> pReservas)
        {
            InitializeComponent();
            pasajero = pPasajero;
            vuelos = pVuelos;
            reservas = pReservas;

            lblBienvenida.Text = $"Bienvenido, {pasajero.Nombre} {pasajero.Apellido}";
        }

        private void btnRealizarReserva_Click(object sender, EventArgs e)
        {
            var frmReservar = new frmReservar(pasajero, vuelos, reservas);
            this.Hide();
            frmReservar.ShowDialog();
            this.Show();
        }

        private void btnGestionarReservas_Click(object sender, EventArgs e)
        {
            var frmGestionar = new frmGestionar(pasajero, reservas);
            this.Hide();
            frmGestionar.ShowDialog();
            this.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}