using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP_03_LabII_.Archivos;
using TP_03_LabII_.ClasesAbstractas;
using TP_03_LabII_.ClasesInstanciables;
using TP_03_LabII_.Excepciones;

namespace TP_03_LabII_.UnitTest
{
    [TestClass]
    public class UnitTestExcepciones
    {
        [TestMethod]
        public void TestDNIInvalidoException()
        {
            try
            {
                Alumno alumnoTest = new Alumno(10, "Nombre", "Apellido", "91000000",
                    Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Assert.Fail();
            }
            catch(Exception) { }       
        }

        [TestMethod]
        public void TestAlumnoRepetidoException()
        {
            try
            {
                Alumno alumnoTest = new Alumno(10, "Nombre", "Apellido", "91000000",
                    Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Universidad universidadTest = new Universidad();
                universidadTest += alumnoTest;
                universidadTest += alumnoTest;
                Assert.Fail();
            }
            catch (Exception) { }
        }
    }
}
