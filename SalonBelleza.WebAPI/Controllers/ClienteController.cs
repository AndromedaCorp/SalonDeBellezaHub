using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Agregue las siguientes referencias al controlador 
using SalonBelleza.LogicaDeNegocio;
using SalonBelleza.EntidadesDeNegocio;
using System.Text.Json;//Libreria para seliarizar en el metodo Buscar
//Agregar la siguiente libreria para la seguridad JWT 
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalonBelleza.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        //Creando objeto de tipo privado e instanciandolo
        private ClienteBL clienteBL = new ClienteBL();
        // GET: api/<ClienteController>
        [HttpGet]
        //Haciendo cambios dentro del metodo GET para trabajar con metodo asyncronico
        public async Task<IEnumerable<Cliente>> Get()//Convirtimos el metodo en asincronico,procesamos informacion por medio de task y definimos respuesta de tipo usuario
        {
            return await clienteBL.ObtenerTodosAsync();
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        //Haciendo cambios dentro del metodo GET que espera un parametro Id
        public async Task<Cliente> Get(int id)
        {
            Cliente cliente = new Cliente();
            cliente.Id = id;
            return await clienteBL.ObtenerPorIdAsync(cliente);
        }

        // POST api/<ClienteController>
        [HttpPost]
        //Haciendo cambios dentro del metodo POST para trabajar con metodo asyncronico
        public async Task<ActionResult> Post([FromBody] Cliente cliente)
        {
            try
            {
                await clienteBL.CrearAsync(cliente);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        //Haciendo cambios dentro del metodo PUT que espera un parametro Id
        public async Task<ActionResult> Put(int id, [FromBody] Cliente cliente)
        {
            if (cliente.Id == id)
            {
                await clienteBL.ModificarAsync(cliente);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        //Haciendo cambios dentro del metodo DELETE que espera un parametro Id
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Cliente cliente = new Cliente();
                cliente.Id = id;
                await clienteBL.EliminarAsync(cliente);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
        //Agregando metodo logico que nos permitira Buscar
        [HttpPost("Buscar")]
        public async Task<List<Cliente>> Buscar([FromBody] object pCliente)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strCliente = JsonSerializer.Serialize(pCliente);
            Cliente cliente = JsonSerializer.Deserialize<Cliente>(strCliente, option);
            return await clienteBL.BuscarAsync(cliente);
        }
    }
}
