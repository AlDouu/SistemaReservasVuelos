using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_para_Proyecto
{
    public class cPersona
    {
        protected string aNombre;
        protected string aApellido;
        protected string aDNI;
        protected DateTime aFechaNac;
        public cPersona(string pNombre, string pApellido, string pDNI, DateTime pFechaNac)
        {
            aNombre = pNombre;
            aApellido = pApellido;
            aDNI = pDNI;
            aFechaNac = pFechaNac;
        }
        public cPersona()
        {
            aNombre = "";
            aApellido = "";
            aDNI = "";
            aFechaNac = DateTime.MinValue;
        }
        public int CalcularEdad()
        {
            return DateTime.Today.AddTicks(-aFechaNac.Ticks).Year - 1;
        }
        public string Nombre
        {
            get { return aNombre; }
            set { aNombre = value; }
        }
        public string Apellido
        {
            get { return aApellido; }
            set { aApellido = value; }
        }
        public string DNI
        {
            get { return aDNI; }
            set { aDNI = value; }
        }
        public DateTime FechaNac
        {
            get { return aFechaNac; }
            set { aFechaNac = value; }
        }
        public string NombreCompleto()
        {
            return aNombre + ", " + aApellido;
        }
    }
}
