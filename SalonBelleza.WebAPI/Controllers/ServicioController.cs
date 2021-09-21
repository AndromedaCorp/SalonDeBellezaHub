using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
//referencias.
using SalonBelleza.LogicaDeNegocio;
using SalonBelleza.EntidadesDeNegocio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalonBelleza.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private ServicioBL servicioBL = new ServicioBL();

        // GET: api/<ServicioController>
        [HttpGet]
        public async Task<IEnumerable<Servicio>> Get() //Convertimos el metodo a Async, ya que en la logica de negocio el metodo es Async.
        {
            return await servicioBL.ObtenerTodosAsync(); //De esta forma nos va a retornas una lista de Servicios.
        }

        // GET api/<ServicioController>/5
        [HttpGet("{id}")]
        public async Task<Servicio> Get(int id)
        {
            Servicio servicio = new Servicio();
            servicio.Id = id; //Creamos un objeto de la clase servicio para indicarle que el Id, sera el mismo que el que se envia como parametro.
            return await servicioBL.ObtenerPorIdAsync(servicio);
        }

        // POST api/<ServicioController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Servicio servicio)
        {
            try
            {
                await servicioBL.CrearAsync(servicio);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        // PUT api/<ServicioController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Servicio servicio)
        {
            if (servicio.Id == id)
            {
                await servicioBL.ModificarAsync(servicio);
                return Ok();
            }
            else {
                return BadRequest();
            }


        }

        // DELETE api/<ServicioController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Servicio servicio = new Servicio();
                servicio.Id = id;
                await servicioBL.EliminarAsync(servicio);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost("Buscar")]
        public async Task<List<Servicio>> Buscar([FromBody] object pServicio)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strServicio = JsonSerializer.Serialize(pServicio);
            Servicio servicio = JsonSerializer.Deserialize<Servicio>(strServicio, option);
            return await servicioBL.BuscarAsync(servicio);
        }

        
    }
}
