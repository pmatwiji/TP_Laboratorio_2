using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;

namespace TestUnitario
{
    [TestClass]
    public class TestValidacionNumerica
    {
        [TestMethod]
        public void ValidarDniException()
        {
            try
            {
                Alumno alumno = new Alumno(1, "Pablo", "Matwijiszyn", "dni", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Alumno alumno2 = new Alumno(2, "Sarasa", "Sarasa", "9999999999999", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            }
            catch (Exception e)
            {

                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }



    }
}