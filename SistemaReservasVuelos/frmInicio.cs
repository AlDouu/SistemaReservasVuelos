using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
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
            // Cargar datos desde archivos, retorna listas. En este caso asigna listas a los atributos
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

                cPasajero Pasajero_Form = new cPasajero();

                if (!existe)  // Pasajero nuevo, añadir a base de datos
                {
                    pasajeros.Add(pasajero); // Se añade a la lista de esta clase
                    cPasajero.GuardarEnArchivo("pasajeros.txt", pasajeros); // Se usa la lista para guardar todo con los cambios
                    Pasajero_Form = pasajero;
                }
                else
                {
                    
                    //RECUPERAR INFORMACION DE PASAJERO
                    Pasajero_Form = BuscarPasajero(pasajeros, txtDNI.Text); // Si existe solo se recuperan los datos y se usa como parámetro cambiando sus atributos
                    //MessageBox.Show($"PASAJERO EXISTE {Pasajero_Form.ToString}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                // Mostrar el formulario de opciones
                var frmMostrar = new frmMostrar(Pasajero_Form, vuelos, reservas); //Carga todos los vuelos y reservas. Falta filtrar por pasajero
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



        public cPasajero BuscarPasajero(List<cPasajero> L, string pDNI) // Módulo para buscar pasajero en lista precargada
        {
            cPasajero Res = new cPasajero();
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i].DNI == pDNI) { Res = L[i]; }
            }
            MessageBox.Show("Pasajero existente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //Res.Reservas.Add();
            return Res;
        }


        public string Mostrar_Vuelos(List<cVuelo> pLista)
        {
            string R = "";
            for (int i = 0; i < pLista.Count; i++)
            {
                R += pLista[i].ToString() + "\n";
            }
            return R;
        }
        public string Mostrar_Reservas(List<cReserva> pListaReservas)
        {
            string R = "";
            for (int k = 0; k < pListaReservas.Count; k++)
            {
                R += pListaReservas[k].ToString();
            }
            return R;
        }
    }
}