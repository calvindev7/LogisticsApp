using System.Net.Http.Headers;
using System.Text;
using LogisticsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using LogisticsApp.Util;

namespace LogisticsApp.Controllers
{
    public class ClientesController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly TokenService _tokenService;

        public ClientesController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7271");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _tokenService = new TokenService();
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            HttpResponseMessage response = await _httpClient.GetAsync("api/Clientes");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var clientes = JsonConvert.DeserializeObject<List<Cliente>>(responseBody);
                return View(clientes);
            }
            else
            {
                return View("Error");
            }
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Clientes/{id}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var cliente = JsonConvert.DeserializeObject<Cliente>(responseBody);
                return View(cliente);
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

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            var clienteJson = JsonConvert.SerializeObject(cliente);
            var httpContent = new StringContent(clienteJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("api/Clientes", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var createdCliente = JsonConvert.DeserializeObject<Cliente>(responseBody);
                return RedirectToAction(nameof(Details), new { id = createdCliente.Id });
            }
            else
            {
                return View("Error");
            }
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Clientes/{id}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var cliente = JsonConvert.DeserializeObject<Cliente>(responseBody);
                return View(cliente);
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

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cliente cliente)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            var clienteJson = JsonConvert.SerializeObject(cliente);
            var httpContent = new StringContent(clienteJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync($"api/Clientes/{id}", httpContent);
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

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Clientes/{id}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var cliente = JsonConvert.DeserializeObject<Cliente>(responseBody);
                return View(cliente);
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

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/Clientes/{id}");
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
