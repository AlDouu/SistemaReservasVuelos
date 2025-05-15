using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Clases_para_Proyecto
{
    public class cReserva
    {
        private cPasajero aPasajero;
        private cVuelo aVuelo;
        private int aNroAsiento;
        private bool aConfirmada;

        public cReserva(cPasajero pPasajero, cVuelo pVuelo, int pNroAsiento)
        {
            aPasajero = pPasajero;
            aVuelo = pVuelo;
            aNroAsiento = pNroAsiento;
            aConfirmada = false;
        }

        public string ObtenerDetalle()
        {
            return $"Vuelo: {aVuelo.CodigoVuelo} | Origen: {aVuelo.Origen} | Destino: {aVuelo.Destino} | " +
                   $"Fecha: {aVuelo.FechaVuelo:yyyy-MM-dd} | Asiento: {aNroAsiento} | " +
                   $"Estado: {(aConfirmada ? "Confirmada" : "Pendiente")}";
        }

        public void Confirmar()
        {
            if (aVuelo.ReservarAsiento(aNroAsiento))
            {
                aConfirmada = true;
            }
        }

        public void Cancelar()
        {
            if (aConfirmada && aVuelo.LiberarAsiento(aNroAsiento))
            {
                aConfirmada = false;
            }
        }

        public static List<cReserva> CargarDesdeArchivo(string rutaArchivo, List<cPasajero> pasajeros, List<cVuelo> vuelos)
        {
            var reservas = new List<cReserva>();
            if (File.Exists(rutaArchivo))
            {
                foreach (string linea in File.ReadAllLines(rutaArchivo))
                {
                    var partes = linea.Split('|');
                    if (partes.Length >= 4)
                    {
                        var dniPasajero = partes[0];
                        var codigoVuelo = partes[1];
                        var nroAsiento = int.Parse(partes[2]);
                        var confirmada = bool.Parse(partes[3]);

                        var pasajero = pasajeros.FirstOrDefault(p => p.DNI == dniPasajero);// Busca elemento
                        var vuelo = vuelos.FirstOrDefault(v => v.CodigoVuelo == codigoVuelo);

                        if (pasajero != null && vuelo != null)
                        {
                            var reserva = new cReserva(pasajero, vuelo, nroAsiento);
                            if (confirmada) reserva.Confirmar();
                            reservas.Add(reserva);
                            pasajero.AgregarReserva(reserva);
                        }
                    }
                }
            }
            return reservas;
        }

        public static void GuardarEnArchivo(string rutaArchivo, List<cReserva> reservas)
        {
            var lineas = reservas.Select(r => 
                $"{r.aPasajero.DNI}|{r.aVuelo.CodigoVuelo}|{r.aNroAsiento}|{r.aConfirmada}");
            File.WriteAllLines(rutaArchivo, lineas);
        }

        // Propiedades
        public cPasajero Pasajero => aPasajero;
        public cVuelo Vuelo => aVuelo;
        public int NroAsiento => aNroAsiento;
        public bool Confirmada => aConfirmada;


        public override string ToString()
        {
            return $"{aPasajero.ToString()} {aNroAsiento} {aConfirmada}";
        }
    }
}