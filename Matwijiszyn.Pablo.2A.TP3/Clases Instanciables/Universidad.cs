using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Archivos;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        #region Atributos

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #endregion

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        #region Constructores

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }

        #endregion

        #region Propiedades


        public List<Alumno> Alumnos
        {
            get => this.alumnos;
            set => this.alumnos = value; 
        }

        public List<Profesor> Instructores
        {
            get => this.profesores; 
            set => this.profesores = value; 
        }

        public List<Jornada> Jornadas
        {
            get => this.jornada; 
            set => this.jornada = value; 
        }

        public Jornada this[int i]
        {
            get => this.jornada[i]; 
            set => this.jornada[i] = value; 
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Guarda los datos de la universidad en un archivo .xml
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            return xml.Guardar(path + @"Universidad.xml", uni);
        }

        /// <summary>
        /// Lee los datos de la uiversidad desde un archivo .xml
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {

            Universidad uni = new Universidad();

            Xml<Universidad> xml = new Xml<Universidad>();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            xml.Leer(path + @"Universidad.xml", out uni);

            return uni;
        }

        /// <summary>
        /// Muestra los datos de la Universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");

            foreach (Jornada item in uni.Jornadas)
            {
                sb.AppendLine(item.ToString());
                sb.AppendLine("<----------------------------------------------------->");
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno item in g.Alumnos)
            {
                if (item == a)
                {
                    retorno = true;
                    break;
                }

            }

            return retorno;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            foreach (Profesor item in g.profesores)
            {
                if (item == i)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor retorno = null;
            bool aux = false;

            foreach (Profesor item in u.profesores)
            {
                if (item == clase)
                {
                    aux = true;
                    retorno = item;
                    break;
                }
            }
            if (aux == false)
            {
                throw new SinProfesorException();
            }

            return retorno;
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor retorno = null;
            bool aux = false;

            foreach (Profesor item in u.profesores)
            {
                if (item != clase)
                {
                    aux = true;
                    retorno = item;
                    break;
                }
            }
            if (aux == false)
            {
                throw new SinProfesorException();
            }

            return retorno;
        }

        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }

            return u;
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return u;
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profesor = (g == clase);
            Jornada jornada = new Jornada(clase, profesor);

            foreach (Alumno item in g.alumnos)
            {
                if (item == clase)
                {
                    jornada += item;
                }

            }

            g.Jornadas.Add(jornada);
            return g;
        }

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        #endregion
    }
}
