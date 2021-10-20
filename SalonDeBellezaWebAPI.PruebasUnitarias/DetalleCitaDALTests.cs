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

            int result = await DetalleCitaDAL.CrearAsync(detalle);
            Assert.IsFalse(result == 0);
        }

        [TestMethod()]
        public void ModificarAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ObtenerPorIdAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ObtenerTodosAsyncTest()
        {
            Assert.Fail();
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