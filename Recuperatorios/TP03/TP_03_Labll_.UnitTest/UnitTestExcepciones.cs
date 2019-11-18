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
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestNacionalidadInvalidaException()
        {
            Alumno alumnoTest = new Alumno(10, "Nombre", "Apellido", "90000000",
                Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniInvalidoException()
        {
            Alumno alumnoTest = new Alumno(20, "Nombre", "Apellido", "String invalida",
                Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestAlumnoRepetidoException()
        {
            Alumno alumnoTest = new Alumno(10, "Nombre", "Apellido", "45000000",
                Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Universidad universidadTest = new Universidad();
            universidadTest += alumnoTest;
            universidadTest += alumnoTest;
            Assert.Fail();
        }
    }
}
