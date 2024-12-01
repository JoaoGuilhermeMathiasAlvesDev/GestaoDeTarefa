using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GestaoDeTarefa.Aplication.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetTarefasAsync(string token)
        {
            // Adicionar o token JWT no cabeçalho Authorization
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync("https://localhost:7180/Tarefa/Index");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
