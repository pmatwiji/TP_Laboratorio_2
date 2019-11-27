using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos

        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        #endregion

        #region Propiedades

        public List<Paquete> Paquetes { get => this.paquetes; set => this.paquetes = value; }

        #endregion

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        #region Metodos

        /// <summary>
        /// Guarda en una cadena todos los paquetes de un correo
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>string con datos de los paquetes de correo</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Paquete item in ((Correo)elemento).paquetes)
            {
                sb.AppendFormat("{0} para {1} ({2}) \n", item.TrackingID, item.DireccionEntrega, item.Estado.ToString());

            }

            return sb.ToString();
        }

        /// <summary>
        /// Cierra todos los hilos activos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                item.Abort();
            }
        }

        public static Correo operator +(Correo c, Paquete p)
        {

            foreach (Paquete item in c.paquetes)
            {
                if (item == p)
                {
                    throw new TrackingIdRepetidoException("El Tracking ID " + item.TrackingID + " ya se encunetra en la lista.");
                }
            }

            c.paquetes.Add(p);

            Thread nuevoThread = new Thread(p.MockCicloDeVida);

            c.mockPaquetes.Add(nuevoThread);

            nuevoThread.Start();

            return c;
        }

        #endregion
    }
}
