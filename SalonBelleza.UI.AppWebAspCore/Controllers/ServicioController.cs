using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/********************************/
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
    public class ServicioController : Controller
    {
        // Codigo agregar para consumir la Web API
        private readonly HttpClient httpClient;
        public ServicioController(HttpClient client)
        {
            httpClient = client;
        }
        private async Task<Servicio> ObtenerServicioPorIdAsync(Servicio pServicio)
        {
            Servicio servicio = new Servicio();
            var response = await httpClient.GetAsync("Servicio/" + pServicio.Id);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                servicio = JsonSerializer.Deserialize<Servicio>(responseBody,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            return servicio;
        }
        //***************************************
        // GET: ServicioController
        public async Task<IActionResult> Index(Servicio pServicio = null)
        {
            if (pServicio == null)
                pServicio = new Servicio();
            if (pServicio.Top_Aux == 0)
                pServicio.Top_Aux = 10;
            else if (pServicio.Top_Aux == -1)
                pServicio.Top_Aux = 0;
            // Codigo agregar para consumir la Web API
            var servicios = new List<Servicio>();
            var response = await httpClient.PostAsJsonAsync("Servicio/Buscar", pServicio);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                servicios = JsonSerializer.Deserialize<List<Servicio>>(responseBody,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            //******************************************
            ViewBag.Top = pServicio.Top_Aux;
            return View(servicios);
        }

        // GET: ServicioController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            // Codigo agregar para consumir la Web API
            Servicio servicio = await ObtenerServicioPorIdAsync(new Servicio { Id = id });
            //*******************************************************
            return View(servicio);
        }

        // GET: ServicioController/Create
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: ServicioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Servicio pServicio)
        {
            try
            {
                // Codigo agregar para consumir la Web API
                var response = await httpClient.PostAsJsonAsync("Servicio", pServicio);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Sucedio un error al consumir la WEP API";
                    return View(pServicio);
                }
                // ********************************************
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pServicio);
            }
        }

        // GET: ServicioController/Edit/5
        public async Task<IActionResult> Edit(Servicio pServicio)
        {
            // Codigo agregar para consumir la Web API
            Servicio servicio = await ObtenerServicioPorIdAsync(pServicio);
            // ***********************************************
            ViewBag.Error = "";
            return View(servicio);
        }

        // POST: RolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Servicio pServicio)
        {
            try
            {
                // Codigo agregar para consumir la Web API
                var response = await httpClient.PutAsJsonAsync("Servicio/" + id, pServicio);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Sucedio un error al consumir la WEP API";
                    return View(pServicio);
                }
                // ************************************************
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pServicio);
            }
        }

        // GET: RolController/Delete/5
        public async Task<IActionResult> Delete(Servicio pServicio)
        {
            ViewBag.Error = "";
            // Codigo agregar para consumir la Web API
            Servicio servicio = await ObtenerServicioPorIdAsync(pServicio);
            // ************************************************
            return View(servicio);
        }

        // POST: RolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Servicio pServicio)
        {
            try
            {
                // Codigo agregar para consumir la Web API
                var response = await httpClient.DeleteAsync("Servicio/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Sucedio un error al consumir la WEP API";
                    return View(pServicio);
                }
                // **********************************************
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pServicio);
            }
        }
    }
}
