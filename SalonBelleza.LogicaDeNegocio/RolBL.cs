using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalonBelleza.EntidadesDeNegocio;
using SalonBelleza.AccesoADatos;

namespace SalonBelleza.LogicaDeNegocio
{
    /// <summary>  
    /// Esta clase es de la entidad Rol de la capa Logica de De Negocio
    /// Esta clase contiene Los metodos CRUD de Rol
    /// 
    /// </summary> 
    public class RolBL
    {
        public async Task<int> CrearAsync(Rol pRol) 
        {
            return await RolDAL.CrearAsync(pRol);
        }
        public async Task<int> ModificarAsync(Rol pRol) 
        {
            return await RolDAL.ModificarAsync(pRol);
        }
        public async Task<int> EliminarAsync(Rol pRol) 
        {
            return await RolDAL.EliminarAsync(pRol);
        }
        public async Task<Rol> ObtenerPorIdAsync(Rol pRol) 
        {
            return await RolDAL.ObtenerPorIdAsync(pRol);
        }
        public async Task<List<Rol>> ObtenerTodosAsync() 
        {
            return await RolDAL.ObtenerTodosAsync();
        }
        public async Task<List<Rol>> BuscarAsync(Rol pRol) 
        {
            return await RolDAL.BuscarAsync(pRol);
        }
    }
}
