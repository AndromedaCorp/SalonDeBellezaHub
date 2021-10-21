using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalonBelleza.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// *************************************************************
using SalonBelleza.EntidadesDeNegocio;

namespace SalonBelleza.AccesoADatos.Tests
{
    [TestClass()]
    public class CitaDALTests
    {
        [TestMethod()]
        public async Task CrearAsyncTest()
        {
            Cita cita = new Cita(); //Creamos una instancia de Rol en la cual le agregaremos parametros. 
            cita.IdUsuario = 1;
            cita.IdCliente = 1;
            cita.Total = 2;
            cita.Estado = 0;
            cita.FechaCita = DateTime.Now;
            
            //int result = await CitaDAL.CrearAsync(cita);
            //Assert.IsFalse(result == 0);
        }

        [TestMethod()]
        public async Task ModificarAsyncTest()
        {
            Cita cita = new Cita(); //Creamos una instancia de Cita en la cual le agregaremos parametros.
            //Agregamos el Id mas los parametros a modificar, no puede ir ninguno vacio.
            cita.Id = 46;
            cita.IdUsuario = 1;
            cita.IdCliente = 2;
            cita.Total = 2;
            cita.Estado = 0;
            cita.FechaCita = DateTime.Now;

            int result = await CitaDAL.ModificarAsync(cita);
            Assert.IsFalse(result == 0); //Si es falso el resultado, marcara un error.
        }

        [TestMethod()]
        public async Task EliminarAsyncTest()
        {
            Cita cita = new Cita();
            cita.Id = 32; //Obtenemos el Id para eliminar el registro.

            int result = await CitaDAL.EliminarAsync(cita); //Le pasamos el objeto con el ID al metodo Eliminar.
            Assert.IsFalse(result == 0);
        }

        [TestMethod()]
        public async Task ObtenerPorIdAsyncTest()
        {
            //Creamos un objeto de la clase, para luego Indicar el ID que se desea buscar.
            Cita cita = new Cita();
            cita.Id = 46;

            Cita result;
            result = await CitaDAL.ObtenerPorIdAsync(cita); //Agregamos el Id al metodo Obtener, el resultado se lo agregamos a result.
            Assert.IsNotNull(result); //Si el objeto es Null marcara una excepcion.
        }

        [TestMethod()]
        public async Task ObtenerTodosAsyncTest()
        {
            //Se declara un List ya que se espera una lista de Detalles.
            List<Cita> citas = await CitaDAL.ObtenerTodosAsync();
            Assert.IsFalse(citas.Count == 0);
        }

        [TestMethod()]
        public async Task BuscarAsyncTest()
        {
            Cita cita = new Cita();
            //Agregamos los parametro para buscar.
            cita.Estado = 0;

            //Agregamos los parametros al metodo buscar, luego este llenara la Lista de Cita con los resultados.
            List<Cita> citas = await CitaDAL.BuscarAsync(cita);
            Assert.IsFalse(citas.Count == 0);
        }

        [TestMethod()]
        public void BuscarIncluirUsuarioAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarIncluirClienteAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarIncluirUsuarioClienteAsyncTest()
        {
            Assert.Fail();
        }
    }
}