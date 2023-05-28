using System.Net.Http.Headers;
using System.Text;
using LogisticsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using LogisticsApp.Util;

namespace LogisticsApp.Controllers
{
    public class BodegasController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly TokenService _tokenService;

        public BodegasController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7271");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _tokenService = new TokenService();
        }

        // GET: Bodegas
        public async Task<IActionResult> Index()
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            HttpResponseMessage response = await _httpClient.GetAsync("api/Bodegas");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var bodegas = JsonConvert.DeserializeObject<List<Bodega>>(responseBody);
                return View(bodegas);
            }
            else
            {
                return View("Error");
            }
        }

        // GET: Bodegas/Details/5
        public async Task<IActionResult> Details(int id)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Bodegas/{id}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var bodega = JsonConvert.DeserializeObject<Bodega>(responseBody);
                return View(bodega);
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

        // GET: Bodegas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bodegas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bodega bodega)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            var bodegaJson = JsonConvert.SerializeObject(bodega);
            var httpContent = new StringContent(bodegaJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("api/Bodegas", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var createdBodega = JsonConvert.DeserializeObject<Bodega>(responseBody);
                return RedirectToAction(nameof(Details), new { id = createdBodega.Id });
            }
            else
            {
                return View("Error");
            }
        }

        // GET: Bodegas/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Bodegas/{id}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var bodega = JsonConvert.DeserializeObject<Bodega>(responseBody);
                return View(bodega);
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

        // POST: Bodegas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Bodega bodega)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            var bodegaJson = JsonConvert.SerializeObject(bodega);
            var httpContent = new StringContent(bodegaJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync($"api/Bodegas/{id}", httpContent);
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

        // GET: Bodegas/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Bodegas/{id}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var bodega = JsonConvert.DeserializeObject<Bodega>(responseBody);
                return View(bodega);
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

        // POST: Bodegas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/Bodegas/{id}");
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
