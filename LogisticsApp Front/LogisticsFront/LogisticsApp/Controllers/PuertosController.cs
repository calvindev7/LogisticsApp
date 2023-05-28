using System.Net.Http.Headers;
using System.Text;
using LogisticsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using LogisticsApp.Util;

namespace LogisticsApp.Controllers
{
    public class PuertosController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly TokenService _tokenService;

        public PuertosController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7271");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _tokenService = new TokenService();
        }

        // GET: Puertos
        public async Task<IActionResult> Index()
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            HttpResponseMessage response = await _httpClient.GetAsync("api/Puertos");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var puertos = JsonConvert.DeserializeObject<List<Puerto>>(responseBody);
                return View(puertos);
            }
            else
            {
                return View("Error");
            }
        }

        // GET: Puertos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Puertos/{id}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var puerto = JsonConvert.DeserializeObject<Puerto>(responseBody);
                return View(puerto);
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

        // GET: Puertos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Puertos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Puerto puerto)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            var puertoJson = JsonConvert.SerializeObject(puerto);
            var httpContent = new StringContent(puertoJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("api/Puertos", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var createdPuerto = JsonConvert.DeserializeObject<Puerto>(responseBody);
                return RedirectToAction(nameof(Details), new { id = createdPuerto.Id });
            }
            else
            {
                return View("Error");
            }
        }

        // GET: Puertos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Puertos/{id}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var puerto = JsonConvert.DeserializeObject<Puerto>(responseBody);
                return View(puerto);
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

        // POST: Puertos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Puerto puerto)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            var puertoJson = JsonConvert.SerializeObject(puerto);
            var httpContent = new StringContent(puertoJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync($"api/Puertos/{id}", httpContent);
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

        // GET: Puertos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Puertos/{id}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var puerto = JsonConvert.DeserializeObject<Puerto>(responseBody);
                return View(puerto);
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

        // POST: Puertos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string accestoken = await _tokenService.GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accestoken);
            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/Puertos/{id}");
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
