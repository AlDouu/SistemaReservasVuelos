using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Clases_para_Proyecto
{
    public partial class frmMostrar : Form
    {
        private cPasajero pasajero; // Datos de pasajero ya registrado en txt (puede ser nuevo o antiguo)
        private List<cVuelo> vuelos; // Lista total de todos los vuelos disponibles
        private List<cReserva> reservas; // Reservas hechas por el pasajero
        

        public frmMostrar(cPasajero pPasajero, List<cVuelo> pVuelos, List<cReserva> pReservas)// Recibe listas completas de vuelos y reservas [reservas por pesona forma "12345678|AV101|15|true"] 
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

        private void btnGestionarReservas_Click(object sender, EventArgs e) // Boton de gestionar
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