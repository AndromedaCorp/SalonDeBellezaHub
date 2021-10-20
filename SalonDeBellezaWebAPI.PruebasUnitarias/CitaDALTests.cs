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
            
            int result = await CitaDAL.CrearAsync(cita);
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
        public async Task ObtenerTodosAsyncTest()
        {
            List<Cita> citas = await CitaDAL.ObtenerTodosAsync();
            Assert.IsFalse(citas.Count == 0);
        }

        [TestMethod()]
        public void BuscarAsyncTest()
        {
            Assert.Fail();
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