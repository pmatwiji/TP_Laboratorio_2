using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;

namespace TestUnitario
{
    [TestClass]
    public class TestExcepciones
    {
        [TestMethod]
        public void ValidarNacionalidadException()
        {
            try
            {
                Alumno alumno = new Alumno(1, "Pablo", "Matwijiszyn", "35630715", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            }
            catch (Exception e)
            {

                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        [TestMethod]
        public void ValidarAlumnoException()
        {
            try
            {
                Universidad universidad = new Universidad();
                Alumno alumno1 = new Alumno(1, "Pablo", "Matwijiszyn", "35630715", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
                Alumno alumno2 = new Alumno(1, "Pablo", "Matwijiszyn", "35630715", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);

                universidad = universidad + alumno1;
                universidad = universidad + alumno2;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }



    }
}
