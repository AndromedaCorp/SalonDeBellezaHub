using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Agregue las siguientes referencias al controlador 
using SalonBelleza.LogicaDeNegocio;
using SalonBelleza.EntidadesDeNegocio;
using System.Text.Json;//Libreria para seliarizar en el metodo Buscar

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalonBelleza.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //Creando objeto de tipo privado e instanciandolo
        private UsuarioBL usuarioBL = new UsuarioBL();
        // GET: api/<UsuarioController>
        [HttpGet]
        //Haciendo cambios dentro del metodo GET para trabajar con metodo asyncronico
        public async Task<IEnumerable<Usuario>> Get()//Convirtimos el metodo en asincronico,procesamos informacion por medio de task y definimos respuesta de tipo usuario
        {
            return await usuarioBL.ObtenerTodosAsync();
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        //Haciendo cambios dentro del metodo GET que espera un parametro Id
        public async Task<Usuario> Get(int id)
        {
            Usuario usuario = new Usuario();
            usuario.Id = id;
            return await usuarioBL.ObtenerPorIdAsync(usuario);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        //Haciendo cambios dentro del metodo POST para trabajar con metodo asyncronico
        public async Task<ActionResult> Post([FromBody] Usuario usuario)
        {
            try
            {
                await usuarioBL.CrearAsync(usuario);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        //Haciendo cambios dentro del metodo PUT que espera un parametro Id
        public async Task<ActionResult> Put(int id, [FromBody] Usuario usuario)
        {
            if (usuario.Id == id)
            {
                await usuarioBL.ModificarAsync(usuario);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        //Haciendo cambios dentro del metodo DELETE que espera un parametro Id
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.Id = id;
                await usuarioBL.EliminarAsync(usuario);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
        //Agregando metodo logico que nos permitira Buscar
        [HttpPost("Buscar")]
        public async Task<List<Usuario>> Buscar([FromBody] object pUsuario)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strUsuario = JsonSerializer.Serialize(pUsuario);
            Usuario usuario = JsonSerializer.Deserialize<Usuario>(strUsuario, option);
            return await usuarioBL.BuscarAsync(usuario);
        }
    }
}
