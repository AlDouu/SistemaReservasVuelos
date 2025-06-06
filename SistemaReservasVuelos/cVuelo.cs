using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Clases_para_Proyecto
{
    public class cVuelo
    {
        private string aCodigoVuelo;
        private DateTime aFechaVuelo;
        private string aHoraVuelo;
        private string aOrigen;
        private string aDestino;
        private double aPrecio;
        private int aCapacidadTotal;
        private List<int> aAsientosOcupados;

        public cVuelo(string pCodigoVuelo, DateTime pFechaVuelo, string pHoraVuelo,
                     string pOrigen, string pDestino, int pCapacidadTotal, double pPrecio)
        {
            aCodigoVuelo = pCodigoVuelo;
            aFechaVuelo = pFechaVuelo;
            aHoraVuelo = pHoraVuelo;
            aOrigen = pOrigen;
            aDestino = pDestino;
            aCapacidadTotal = pCapacidadTotal;
            aPrecio = pPrecio;
            aAsientosOcupados = new List<int>();
        }

        public bool VerificarDisponibilidad()
        {
            return AsientosDisponibles > 0;
        }

        public bool ReservarAsiento(int pNroAsiento)
        {
            if (pNroAsiento < 1 || pNroAsiento > aCapacidadTotal)
                return false;

            lock (aAsientosOcupados) // Thread-safe para operaciones concurrentes
            {
                if (!aAsientosOcupados.Contains(pNroAsiento))
                {
                    aAsientosOcupados.Add(pNroAsiento);
                    return true;
                }
            }
            return false;
        }

        public bool LiberarAsiento(int pNroAsiento)
        {
            lock (aAsientosOcupados) // Thread-safe para operaciones concurrentes
            {
                return aAsientosOcupados.Remove(pNroAsiento);
            }
        }

        public int ObtenerProximoAsientoDisponible()
        {
            for (int i = 1; i <= aCapacidadTotal; i++)
            {
                if (!aAsientosOcupados.Contains(i))
                    return i;
            }
            return -1; // No hay asientos disponibles
        }

        public void MostrarDetalles()
        {
            Console.WriteLine($"Vuelo: {aCodigoVuelo} | Fecha: {aFechaVuelo:yyyy-MM-dd} | Hora: {aHoraVuelo} | " +
                              $"Origen: {aOrigen} | Destino: {aDestino} | Asientos: {AsientosDisponibles}/{aCapacidadTotal} | " +
                              $"Precio: ${aPrecio}");
        }

        public static List<cVuelo> CargarDesdeArchivo(string rutaArchivo)
        {
            var vuelos = new List<cVuelo>();
            if (File.Exists(rutaArchivo))
            {
                foreach (string linea in File.ReadAllLines(rutaArchivo))
                {
                    var partes = linea.Split('|');
                    if (partes.Length >= 7)
                    {
                        try
                        {
                            var vuelo = new cVuelo(
                                partes[0],
                                DateTime.Parse(partes[1]),
                                partes[2],
                                partes[3],
                                partes[4],
                                int.Parse(partes[5]),
                                double.Parse(partes[6]));
                            vuelos.Add(vuelo);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error al cargar vuelo: {ex.Message}");
                        }
                    }
                }
            }
            return vuelos;
        }

        public static void GuardarEnArchivo(string rutaArchivo, List<cVuelo> vuelos)
        {
            var lineas = vuelos.Select(v =>
                $"{v.CodigoVuelo}|{v.FechaVuelo:yyyy-MM-dd}|{v.HoraVuelo}|{v.Origen}|{v.Destino}|{v.CapacidadTotal}|{v.Precio}");
            File.WriteAllLines(rutaArchivo, lineas);
        }

        // Propiedades
        public string CodigoVuelo { get => aCodigoVuelo; set => aCodigoVuelo = value; }
        public DateTime FechaVuelo { get => aFechaVuelo; set => aFechaVuelo = value; }
        public string HoraVuelo { get => aHoraVuelo; set => aHoraVuelo = value; }
        public string Origen { get => aOrigen; set => aOrigen = value; }
        public string Destino { get => aDestino; set => aDestino = value; }
        public double Precio { get => aPrecio; set => aPrecio = value; }
        public int CapacidadTotal { get => aCapacidadTotal; set => aCapacidadTotal = value; }
        public List<int> AsientosOcupados => new List<int>(aAsientosOcupados); // Copia para seguridad
        public int AsientosDisponibles => aCapacidadTotal - aAsientosOcupados.Count;

        public override string ToString()
        {
            return $"{CodigoVuelo} {FechaVuelo:yyyy-MM-dd} {HoraVuelo} {Origen}-{Destino} " +
                   $"[{AsientosDisponibles}/{CapacidadTotal}] ${Precio}";
        }
    }
}