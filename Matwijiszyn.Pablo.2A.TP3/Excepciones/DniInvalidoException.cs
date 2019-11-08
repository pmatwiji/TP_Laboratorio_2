using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private string mensaje;

        public DniInvalidoException() : base("DNI invalido")
        {

        }

        public DniInvalidoException(Exception e) : base(e.Message)
        {

        }

        public DniInvalidoException(string message) : base(message)
        {
            this.mensaje = message;
        }



        public DniInvalidoException(string message, Exception e) : base(message, e.InnerException)
        {
            this.mensaje = message;
        }

    }
}