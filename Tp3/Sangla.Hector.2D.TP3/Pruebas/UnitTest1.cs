using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using ClasesInstanciables;
using Exepciones;

namespace Pruebas
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                Alumno alumno = new Alumno(1, "Juan", "DelosPalotes", "-5586", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Becado);
            }
            catch (DniInvalidoException e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            try
            {
                Alumno alumnoUno = new Alumno(1, "Juan", "DelosPalotes", "5586", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Becado);
                Alumno alumnoDos = new Alumno(1, "Juan", "DelosPalotes", "5586", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Becado);
                Universidad universidad = new Universidad();
                universidad = universidad + alumnoUno;
                universidad = universidad + alumnoDos;
            }catch(AlumnoRepetidoException e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }
        [TestMethod]
        public void TestMethod3()
        {
            try
            {
                Alumno alumnoUno = new Alumno(1, "Juan", "DelosPalotes", "fds", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Becado);
                Alumno alumnoDos = new Alumno(1, "Juan", "DelosPalotes", "cedwsa", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Becado);
                
            }
            catch (DniInvalidoException e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }
        [TestMethod]
        public void TestMethod4()
        {
            Alumno alumno = new Alumno();
            Assert.IsNotNull(alumno.DNI);
        }
    }
}
