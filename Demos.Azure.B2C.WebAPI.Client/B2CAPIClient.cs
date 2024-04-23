using Demos.Azure.B2C.Models;
using System.Text.Json;

namespace Demos.Azure.B2C.WebAPI.Client
{
    public class B2CAPIClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public B2CAPIClient(string apiBaseUrl)
        {
            _apiBaseUrl = apiBaseUrl;
            _httpClient = new HttpClient();
        }

        public async Task<User?> GetUserDetailsAsync(string userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_apiBaseUrl}/api/users/{userId}");

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
