using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalonBelleza.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ***************************************************
using SalonBelleza.EntidadesDeNegocio;

namespace SalonBelleza.AccesoADatos.Tests
{
    [TestClass()]
    public class DetalleCitaDALTests
    {
        [TestMethod()]
        public async Task CrearAsyncTest()
        {
            DetalleCita detalle = new DetalleCita();
            detalle.IdCita = 27;
            detalle.IdServicio = 10;
            detalle.Precio = 2;
            detalle.Duracion = 4.5;

            //int result = await DetalleCitaDAL.CrearAsync(detalle);
            //Assert.IsFalse(result == 0);
        }

        [TestMethod()]
        public async Task ModificarAsyncTest()
        {
            DetalleCita detalle = new DetalleCita();
            //Agregamos el Id mas los parametros a modificar, no puede ir ninguno vacio. 
            detalle.Id = 22;
            detalle.IdCita = 27;
            detalle.IdServicio = 4;
            detalle.Precio = 2;
            detalle.Duracion = 4.5;

            int result = await DetalleCitaDAL.ModificarAsync(detalle);
            Assert.IsFalse(result == 0); //Si es falso el resultado, marcara un error.
        }

        [TestMethod()]
        public async Task EliminarAsyncTest()
        {
            DetalleCita detalle = new DetalleCita();
            detalle.Id = 24; //Obtenemos el Id del Detalle a borrar.

            int result = await DetalleCitaDAL.EliminarAsync(detalle);
            Assert.IsFalse(result == 0);
        }

        [TestMethod()]
        public async Task ObtenerPorIdAsyncTest()
        {
            DetalleCita detalle = new DetalleCita();
            detalle.Id = 22; //Declaramos el Id del Detalle a buscar 

            DetalleCita result;
            result = await DetalleCitaDAL.ObtenerPorIdAsync(detalle); //Agregamos el Id al metodo Obtener, el resultado se lo agregamos a result.
            Assert.IsNotNull(result); //Si el objeto es Null marcara una excepcion.
        }

        [TestMethod()]
        public async Task ObtenerTodosAsyncTest()
        {
            List<DetalleCita> detalles = await DetalleCitaDAL.ObtenerTodosAsync(); //Se declara un List ya que se espera una lista de Detalles.
            Assert.IsFalse(detalles.Count == 0);
        }

        [TestMethod()]
        public async Task BuscarAsyncTest()
        {
            DetalleCita detalle = new DetalleCita(); 
            //Se agregan los parametros que se desean buscar.
            detalle.Precio = 2;
            detalle.Duracion = 4.5;

            //Agregamos los parametros al metodo buscar, luego este llenara la Lista de Detalles con los resultados.
            List<DetalleCita> detalles = await DetalleCitaDAL.BuscarAsync(detalle);
            Assert.IsFalse(detalles.Count == 0);
        }

        [TestMethod()]
        public void BuscarIncluirServicioAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CrearDetallesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ActualizarDetallesTest()
        {
            Assert.Fail();
        }
    }
}