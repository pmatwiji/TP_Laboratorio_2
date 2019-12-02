using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Entidades
{
    public class Paquete :IMostrar<Paquete>
    {
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        public delegate void DelegadoEstado(object sender, EventArgs e);

        #region Atributos

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public event DelegadoEstado InformaEstado;

        #endregion

        #region Propiedades

        public string DireccionEntrega { get => this.direccionEntrega; set => this.direccionEntrega = value; }
        public EEstado Estado { get => this.estado; set => this.estado = value; }
        public string TrackingID { get => this.trackingID; set => this.trackingID = value; }

        #endregion

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }

        #region Metodos

        /// <summary>
        /// Muestra los datos del paquete
        /// </summary>
        /// <param name="elemento">paquete a mostrar datos</param>
        /// <returns>cadena con los datos del paquete</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0} para {1}", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega);

            return sb.ToString();
        }

        public void MockCicloDeVida()
        {
            do
            {

                Thread.Sleep(4000);


                if (this.estado == EEstado.Ingresado)
                {
                    this.estado = EEstado.EnViaje;
                }
                else if (this.estado == EEstado.EnViaje)
                {
                    this.estado = EEstado.Entregado;
                }

                this.InformaEstado(this.estado, EventArgs.Empty);
            } while (this.estado != EEstado.Entregado);

            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception e)
            {
                
                MessageBox.Show(e.Message);
            }
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retorno = false;

            if (p1.trackingID == p2.trackingID)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion

    }
}
