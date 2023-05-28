using System.Net.Http.Headers;
using System.Text;
using LogisticsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using LogisticsApp.Util;

namespace LogisticsApp.Controllers
{
    public class ProductosController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly TokenService _tokenService;

        public ProductosController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7271");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _tokenService = new TokenService();
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            HttpResponseMessage response = await _httpClient.GetAsync("api/Productos");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var productos = JsonConvert.DeserializeObject<List<Producto>>(responseBody);
                return View(productos);
            }
            else
            {
                return View("Error");
            }
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Productos/{id}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var producto = JsonConvert.DeserializeObject<Producto>(responseBody);
                return View(producto);
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

        // GET: Productos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            var productoJson = JsonConvert.SerializeObject(producto);
            var httpContent = new StringContent(productoJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("api/Productos", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var createdProducto = JsonConvert.DeserializeObject<Producto>(responseBody);
                return RedirectToAction(nameof(Details), new { id = createdProducto.Id });
            }
            else
            {
                return View("Error");
            }
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Productos/{id}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var producto = JsonConvert.DeserializeObject<Producto>(responseBody);
                return View(producto);
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

        // POST: Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            var productoJson = JsonConvert.SerializeObject(producto);
            var httpContent = new StringContent(productoJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync($"api/Productos/{id}", httpContent);
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

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Productos/{id}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var producto = JsonConvert.DeserializeObject<Producto>(responseBody);
                return View(producto);
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

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/Productos/{id}");
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
