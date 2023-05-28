using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace LogisticsApp.Util
{
    public class TokenService
    {
        private readonly HttpClient _httpClient;
        private readonly TokenClient _tokenClient;

        public TokenService()
        {
            _httpClient = new HttpClient();
            _tokenClient = new TokenClient(_httpClient, new TokenClientOptions
            {
                Address = "https://localhost:7078/connect/token", // URL del servidor de autenticación
                ClientId = "client",
                ClientSecret = "secret"
            });
        }

        public async Task<string> GetAccessToken()
        {
            var tokenResponse = await _tokenClient.RequestClientCredentialsTokenAsync("api");
            if (tokenResponse.IsError)
            {
                throw new Exception($"Error al obtener el token de acceso: {tokenResponse.Error}");
            }

            return tokenResponse.AccessToken;
        }
    }
}
