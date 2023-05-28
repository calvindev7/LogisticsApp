using System.Net.Http.Headers;
using System.Text;
using LogisticsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using LogisticsApp.Util;
using System.Collections.Generic;

namespace LogisticsApp.Controllers
{
    public class EnviosTerrestresController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly TokenService _tokenService;

        public EnviosTerrestresController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7271");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _tokenService = new TokenService();
        }

        //GET: EnviosTerrestres
        public async Task<IActionResult> Index()
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            HttpResponseMessage response = await _httpClient.GetAsync("api/EnviosTerrestres");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var envioterrestres = JsonConvert.DeserializeObject<List<EnvioTerrestre>>(responseBody);
                for (int i = 0; i < envioterrestres.Count(); i++)
                {
                    HttpResponseMessage responseproduct = await _httpClient.GetAsync($"api/Productos/{envioterrestres[i].ProductoId}");
                    if (responseproduct.IsSuccessStatusCode)
                    {
                        string responsetext = await responseproduct.Content.ReadAsStringAsync();
                        envioterrestres[i].Producto = JsonConvert.DeserializeObject<Producto>(responsetext);
                    }
                    else
                        break;

                    HttpResponseMessage responseclient = await _httpClient.GetAsync($"api/Clientes/{envioterrestres[i].ClienteId}");
                    if (responseclient.IsSuccessStatusCode)
                    {
                        string responsetext = await responseclient.Content.ReadAsStringAsync();
                        envioterrestres[i].Cliente = JsonConvert.DeserializeObject<Cliente>(responsetext);
                    }
                    else
                        break;

                    HttpResponseMessage responsebodega = await _httpClient.GetAsync($"api/Bodegas/{envioterrestres[i].BodegaId}");
                    if (responsebodega.IsSuccessStatusCode)
                    {
                        string responsetext = await responsebodega.Content.ReadAsStringAsync();
                        envioterrestres[i].Bodega = JsonConvert.DeserializeObject<Bodega>(responsetext);
                    }
                    else
                        break;
                }

                return View(envioterrestres);
            }
            else
            {
                return View("Error");
            }
        }

        //GET: EnviosTerrestres/Details/5
        public async Task<IActionResult> Details(int id)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/EnviosTerrestres{id}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var envioterrestre = JsonConvert.DeserializeObject<EnvioTerrestre>(responseBody);
                return View(envioterrestre);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                return View("Error");
            }
        }

        //GET: EnviosTerrestres/Create
        public async Task<IActionResult> Create()
        {
            List<Producto> productos = new List<Producto>();
            List<Cliente> clientes = new List<Cliente>();
            List<Bodega> bodegas = new List<Bodega>();
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            HttpResponseMessage response = await _httpClient.GetAsync("api/Bodegas");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                bodegas = JsonConvert.DeserializeObject<List<Bodega>>(responseBody);
            }
            else
            {
                return View("Error");
            }

            HttpResponseMessage responseproducts = await _httpClient.GetAsync("api/Productos");
            if (responseproducts.IsSuccessStatusCode)
            {
                string responseBody = await responseproducts.Content.ReadAsStringAsync();
                productos = JsonConvert.DeserializeObject<List<Producto>>(responseBody);
            }
            else
            {
                return View("Error");
            }

            HttpResponseMessage responseclients = await _httpClient.GetAsync("api/Clientes");
            if (responseclients.IsSuccessStatusCode)
            {
                string responseBody = await responseclients.Content.ReadAsStringAsync();
                clientes = JsonConvert.DeserializeObject<List<Cliente>>(responseBody);
            }
            else
            {
                return View("Error");
            }

            EnvioTerresteViewModel envioterrestre = new EnvioTerresteViewModel {
                Bodegas = bodegas,
                Productos = productos,
                Clientes = clientes,
                EnvioTerrestre = new EnvioTerrestre()
            };

            return View(envioterrestre);
        }

        // POST: EnviosTerrestres/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EnvioTerresteViewModel envioTerresteViewModel)
        {
            envioTerresteViewModel.EnvioTerrestre.FechaRegistro = DateTime.Now;

            decimal descuento = 0.0M;
            if (envioTerresteViewModel.EnvioTerrestre.CantidadProducto > 10)
                descuento = 0.05M; // Descuento del 5% para logística terrestre
            else if (envioTerresteViewModel.EnvioTerrestre.CantidadProducto > 5)
                descuento = 0.03M; // Descuento del 3% para logística marítima

            decimal precioEnvio = ((envioTerresteViewModel.EnvioTerrestre.CantidadProducto * envioTerresteViewModel.Productos.ToList()[envioTerresteViewModel.EnvioTerrestre.ProductoId + 1].PrecioUnidad) * (1 - descuento));
            decimal descuentoOtorgado = envioTerresteViewModel.EnvioTerrestre.PrecioEnvio - precioEnvio;

            envioTerresteViewModel.EnvioTerrestre.PrecioEnvio = precioEnvio;

            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            var envioterrestreJson = JsonConvert.SerializeObject(envioTerresteViewModel.EnvioTerrestre);
            var httpContent = new StringContent(envioterrestreJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("api/EnviosTerrestres", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var createdEnvioTerrestre = JsonConvert.DeserializeObject<EnvioTerrestre>(responseBody);
                return RedirectToAction(nameof(Details), new { id = createdEnvioTerrestre.Id });
            }
            else
            {
                return View("Error");
            }
        }

        //GET: EnviosTerrestres/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/EnviosTerrestres{id}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var envioterrestre = JsonConvert.DeserializeObject<EnvioTerrestre>(responseBody);
                return View(envioterrestre);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                return View("Error");
            }
        }

        // POST: EnvioTerrestres/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EnvioTerrestre envioterrestre)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            var envioterrestreJson = JsonConvert.SerializeObject(envioterrestre);
            var httpContent = new StringContent(envioterrestreJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync($"api/EnviosTerrestres{id}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Details), new { id });
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                return View("Error");
            }
        }

        //GET: EnviosTerrestres/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/EnviosTerrestres{id}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var envioterrestre = JsonConvert.DeserializeObject<EnvioTerrestre>(responseBody);
                return View(envioterrestre);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                return View("Error");
            }
        }

        // POST: EnvioTerrestres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/EnviosTerrestres{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                return View("Error");
            }
        }
    }
}
