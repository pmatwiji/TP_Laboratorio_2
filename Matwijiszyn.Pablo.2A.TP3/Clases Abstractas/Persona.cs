using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Atributos

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        #endregion

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #region Propiedades

        public string Apellido
        {
            get => this.apellido;
            set => this.apellido = ValidarNombreApellido(value);
        }

        public int DNI
        {
            get => this.dni;
            set => this.dni = this.ValidarDni(this.nacionalidad,value);
        }

        public ENacionalidad Nacionalidad
        {
            get => this.nacionalidad;
            set => this.nacionalidad = value;
        }

        public string Nombre
        {
            get => this.nombre;
            set => this.nombre = ValidarNombreApellido(value);
        }

        public string StringToDNI
        {
            set => this.DNI = this.ValidarDni(this.nacionalidad,value);
        }


        #endregion

        #region Constructores

        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) :this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Sobrecarga del metodo ToString mostrando datos de Persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}", this.Apellido, this.Nombre);
            sb.AppendLine();
            sb.AppendFormat("NACIONALIDAD; {0}", this.Nacionalidad.ToString());
            sb.AppendLine();

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {

            return this.ValidarDni(nacionalidad, dato.ToString());
        }

        /// <summary>
        /// Valida el largo del dni para que sea de 8 caracteres y que coincida con su nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {

            int retorno = -1;
            int dni;

            if (dato.Length >= 1 && dato.Length <= 8)
            {
                foreach (char item in dato)
                {
                    if (!char.IsNumber(item))
                    {
                        throw new DniInvalidoException();
                    }
                }

                dni = Convert.ToInt32(dato);

                switch (nacionalidad)
                {
                    case ENacionalidad.Argentino:
                        if (dni >= 1 && dni <= 89999999)
                        {
                            retorno = dni;

                        }
                        else
                        {
                            throw new NacionalidadInvalidaException();
                        }
                        break;
                    case ENacionalidad.Extranjero:
                        if (dni >= 90000000 && dni <= 99999999)
                        {
                            retorno = dni;
                        }
                        else
                        {
                            throw new NacionalidadInvalidaException();
                        }
                        break;
                }
            }
            else
            {
                throw new DniInvalidoException();
            }

            return retorno;
        }

        /// <summary>
        /// Valida que el nombre y apellido solo contengan letras
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            foreach (char letra in dato)
            {
                if (!char.IsLetter(letra))
                {
                    dato = null;
                }
            }
            return dato;
        }

        #endregion


    }
}
