using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*********************************/
using SalonBelleza.EntidadesDeNegocio;
using SalonBelleza.LogicaDeNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Net.Http;
using System.Text.Json;
using System.Net.Http.Json;

namespace SalonBelleza.UI.AppWebAspCore.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class ClienteController : Controller
    {
        // Codigo agregar para consumir la Web API
        private readonly HttpClient httpClient;
        public ClienteController(HttpClient client)
        {
            httpClient = client;
        }
        private async Task<Cliente> ObtenerClientePorIdAsync(Cliente pCliente)
        {
            Cliente cliente = new Cliente();
            var response = await httpClient.GetAsync("Cliente/" + pCliente.Id);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                cliente = JsonSerializer.Deserialize<Cliente>(responseBody,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            return cliente;
        }
       
        // GET: ClienteController
        public async Task<IActionResult> Index(Cliente pCliente = null)
        {
            if (pCliente == null)
                pCliente = new Cliente();
            if (pCliente.Top_Aux == 0)
                pCliente.Top_Aux = 10;
            else if (pCliente.Top_Aux == -1)
                pCliente.Top_Aux = 0;
            // Codigo agregar para consumir la Web API
            var clientes = new List<Cliente>();
            var response = await httpClient.PostAsJsonAsync("Cliente/Buscar", pCliente);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                clientes = JsonSerializer.Deserialize<List<Cliente>>(responseBody,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            //******************************************
            ViewBag.Top = pCliente.Top_Aux;
            return View(clientes);
        }

        // GET: ClienteController/Details/5
        public async Task<IActionResult> Details(int id)
        {

            // Codigo agregar para consumir la Web API
            Cliente cliente = await ObtenerClientePorIdAsync(new Cliente { Id = id });
            //*******************************************************
            return View(cliente);
        }

        // GET: ClienteController/Create
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente pCliente)
        {
            try
            {
                // Codigo agregar para consumir la Web API
                var response = await httpClient.PostAsJsonAsync("Cliente", pCliente);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Sucedio un error al consumir la WEP API";
                    return View(pCliente);
                }
                // ********************************************
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCliente);
            }
        }

        // GET: ClienteController/Edit/5
        public async Task<IActionResult> Edit(Cliente pCliente)
        {
            // Codigo agregar para consumir la Web API
            Cliente cliente = await ObtenerClientePorIdAsync(pCliente);
            // ***********************************************
            ViewBag.Error = "";
            return View(cliente);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cliente pCliente)
        {
            try
            {
                // Codigo agregar para consumir la Web API
                var response = await httpClient.PutAsJsonAsync("Cliente/" + id, pCliente);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Sucedio un error al consumir la WEP API";
                    return View(pCliente);
                }
                // ************************************************
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCliente);
            }
        }

        // GET: ClienteController/Delete/5
        public async Task<IActionResult> Delete(Cliente pCliente)
        {
            ViewBag.Error = "";
            // Codigo agregar para consumir la Web API
            Cliente clientes = await ObtenerClientePorIdAsync(pCliente);
            // ************************************************
            return View(clientes);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Cliente pCliente)
        {
            try
            {
                // Codigo agregar para consumir la Web API
                var response = await httpClient.DeleteAsync("Cliente/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Sucedio un error al consumir la WEP API";
                    return View(pCliente);
                }
                // **********************************************
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCliente);
            }
        }
    }
}
