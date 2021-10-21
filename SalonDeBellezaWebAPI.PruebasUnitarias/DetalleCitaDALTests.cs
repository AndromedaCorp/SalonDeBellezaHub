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
            detalle.Id = 22;
            detalle.IdCita = 27;
            detalle.IdServicio = 4;
            detalle.Precio = 2;
            detalle.Duracion = 4.5;

            int result = await DetalleCitaDAL.ModificarAsync(detalle);
            Assert.IsFalse(result == 0);
        }

        [TestMethod()]
        public async Task EliminarAsyncTest()
        {
            DetalleCita detalle = new DetalleCita();
            detalle.Id = 24;

            int result = await DetalleCitaDAL.EliminarAsync(detalle);
            Assert.IsFalse(result == 0);
        }

        [TestMethod()]
        public async Task ObtenerPorIdAsyncTest()
        {
            DetalleCita detalle = new DetalleCita();
            detalle.Id = 22;

            DetalleCita result;
            result = await DetalleCitaDAL.ObtenerPorIdAsync(detalle);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public async Task ObtenerTodosAsyncTest()
        {
            List<DetalleCita> detalles = await DetalleCitaDAL.ObtenerTodosAsync();
            Assert.IsFalse(detalles.Count == 0);
        }

        [TestMethod()]
        public void BuscarAsyncTest()
        {
            Assert.Fail();
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