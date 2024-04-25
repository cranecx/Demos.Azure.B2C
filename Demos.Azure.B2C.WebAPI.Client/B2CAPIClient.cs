using Demos.Azure.B2C.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Demos.Azure.B2C.WebAPI.Client
{
    public class B2CAPIClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;
        private readonly string _accessToken;

        public B2CAPIClient(string apiBaseUrl, string accessToken)
        {
            _apiBaseUrl = apiBaseUrl;
            _httpClient = new HttpClient();
            _accessToken = accessToken;
        }

        public async Task<User?> GetUserDetailsAsync()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{_apiBaseUrl}/api/users/me");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var user = JsonSerializer.Deserialize<User>(json, options);
                    return user;
                }
                else
                {
                    // Manejo de errores en caso de una respuesta no exitosa del API
                    // ...
                    return null;
                }
            }
            catch 
            {
                // Manejo de excepciones en caso de errores de comunicación con el API
                // ...
                return null;
            }
        }
    }
}
