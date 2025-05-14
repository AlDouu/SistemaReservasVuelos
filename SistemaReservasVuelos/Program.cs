using System;
using System.Windows.Forms;

namespace Clases_para_Proyecto
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Crear archivos con datos iniciales si no existen
                if (!File.Exists("pasajeros.txt"))
                {
                    File.WriteAllLines("pasajeros.txt", new string[] {
                "Juan|Pérez|12345678|1985-05-15|5551234567|juan.perez@email.com",
                "María|Gómez|87654321|1990-08-22|5557654321|maria.gomez@email.com"
            });
                }

                if (!File.Exists("vuelos.txt"))
                {
                    File.WriteAllLines("vuelos.txt", new string[] {
                "AV101|2023-12-15|08:00|Lima|Buenos Aires|150|350.50",
                "AV202|2023-12-16|14:30|Buenos Aires|Santiago|120|280.75"
            });
                }

                if (!File.Exists("reservas.txt"))
                {
                    File.WriteAllLines("reservas.txt", new string[] {
                "12345678|AV101|15|true",
                "87654321|AV202|22|false"
            });
                }

                Application.Run(new frmInicio());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar la aplicación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}