using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalonBelleza.EntidadesDeNegocio;
using SalonBelleza.AccesoADatos;

namespace SalonBelleza.LogicaDeNegocio
{
    //Soy un cliente.
    //Soy el segundo cliente
    public class ClienteBL
    {
        public async Task<int> CrearAsync(Cliente pCliente) 
        {
            return await ClienteDAL.CrearAsync(pCliente);
        }

        public async Task<int> ModificarAsync(Cliente pCliente) 
        {
            return await ClienteDAL.ModificarAsync(pCliente);
        }
        public async Task<int> EliminarAsync(Cliente pCliente) 
        {
            return await ClienteDAL.EliminarAsync(pCliente);
        }
        public async Task<Cliente> ObtenerPorIdAsync(Cliente pCliente) 
        {
            return await ClienteDAL.ObtenerPorIdAsync(pCliente);
        }
        public async Task<List<Cliente>> ObtenerTodosAsync() 
        {
            return await ClienteDAL.ObtenerTodosAsync();
        }
        public async Task<List<Cliente>> BuscarAsync(Cliente pCliente1) 
        {
            return await ClienteDAL.BuscarAsync(pCliente1);
        }
    }
}
