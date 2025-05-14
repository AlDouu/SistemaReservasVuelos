using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Clases_para_Proyecto
{
    public class cPasajero : cPersona
    {
        private string aTelefono;
        private string aCorreo;
        private List<cReserva> aReservas;

        public cPasajero(string pNombre, string pApellido, string pDNI, DateTime pFechaNac, string pTelefono, string pCorreo) : base(pNombre, pApellido, pDNI, pFechaNac)
        {
            aTelefono = pTelefono;
            aCorreo = pCorreo;
            aReservas = new List<cReserva>();
        }

        public cPasajero() : base()
        {
            aTelefono = "";
            aCorreo = "";
            aReservas = new List<cReserva>();
        }

        public string Telefono { get => aTelefono; set => aTelefono = value; }
        public string Correo { get => aCorreo; set => aCorreo = value; }
        public List<cReserva> Reservas { get => aReservas; }

        public void MostrarDatos()
        {
            Console.WriteLine($"Pasajero: {Nombre} {Apellido}");
            Console.WriteLine($"DNI: {DNI} - Email: {Correo} - Teléfono: {Telefono}");
        }

        public void AgregarReserva(cReserva pReserva)
        {
            if (!aReservas.Contains(pReserva))
            {
                aReservas.Add(pReserva);
            }
        }

        public void EliminarReserva(cReserva pReserva)
        {
            if (aReservas.Contains(pReserva))
            {
                aReservas.Remove(pReserva);
            }
        }

        public static List<cPasajero> CargarDesdeArchivo(string rutaArchivo)
        {
            var pasajeros = new List<cPasajero>();
            if (File.Exists(rutaArchivo))
            {
                foreach (string linea in File.ReadAllLines(rutaArchivo))
                {
                    var partes = linea.Split('|');
                    if (partes.Length >= 6)
                    {
                        var pasajero = new cPasajero(
                            partes[0], partes[1], partes[2],
                            DateTime.Parse(partes[3]), partes[4], partes[5]);
                        pasajeros.Add(pasajero);
                    }
                }
            }
            return pasajeros;
        }

        public static void GuardarEnArchivo(string rutaArchivo, List<cPasajero> pasajeros)
        {
            var lineas = pasajeros.Select(p => 
                $"{p.Nombre}|{p.Apellido}|{p.DNI}|{p.FechaNac:yyyy-MM-dd}|{p.Telefono}|{p.Correo}");
            File.WriteAllLines(rutaArchivo, lineas);
        }
    }
}