using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesInstanciables;
using EntidadesAbstractas;

namespace TestUnitario
{
    [TestClass]
    public class TestUnitariosValoresNulos
    {
        [TestMethod]
        public void ValidarVNull()
        {
            Universidad universidad = new Universidad();
            Assert.IsNotNull(universidad.Alumnos);
            Assert.IsNotNull(universidad.Instructores);
            Assert.IsNotNull(universidad.Jornadas);
        }
    }
}