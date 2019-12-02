using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitario
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void VerificarInstaciaListaPaquetesCorreo()
        {
            Correo c = new Correo();

            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void VerificarCargaDosPaquetesMimosTrackingId()
        {
            Paquete p1 = new Paquete("Brasil", "111");
            Paquete p2 = new Paquete("Bolivia", "111");
            Correo c = new Correo();
            try
            {
                c += p1;
                c += p2;
                Assert.Fail("Los paquetes tienen el m tracking ID");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
            }

        }
    }
}

