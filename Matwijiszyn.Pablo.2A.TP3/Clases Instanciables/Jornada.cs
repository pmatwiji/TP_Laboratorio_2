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
    public class Jornada
    {
        #region Atributos

        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #endregion


        #region Propiedades


        public List<Alumno> Alumnos
        {
            get => this.alumnos;
            set => this.alumnos = value;
        }

        public Universidad.EClases Clase
        {
            get => this.clase;
            set => this.clase = value;
        }

        public Profesor Instructor
        {
            get => this.instructor;
            set => this.instructor = value;
        }


        #endregion

        #region Contrusctores

        public Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Guarda los datos de la Jornada en un archivo .txt
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            return texto.Guardar(AppDomain.CurrentDomain.BaseDirectory + @"Jornada.txt", jornada.ToString());

        }

        /// <summary>
        /// Lee los datos de la Jornada de un archivo .txt
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            string cadena = null;

            Texto texto = new Texto();
            texto.Leer(AppDomain.CurrentDomain.BaseDirectory + @"Jornada.txt", out cadena);

            return cadena;
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno item in j.alumnos)
            {
                if (item == a)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return j;
        }

        /// <summary>
        /// Sobrecarga del metodo ToString que muestra los datos de la Jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendFormat("CLASE DE {0} POR {1} ", this.clase, this.instructor.ToString());
            sb.AppendLine();
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno alumno in this.Alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }

            return sb.ToString();
        }

        #endregion
    }
}
