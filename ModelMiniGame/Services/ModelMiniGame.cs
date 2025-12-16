using System.Net.Http.Json;
using ModelMiniGame.DTOs;

namespace ModelMiniGame.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    public ApiService(string apiBaseUrl)
    {
        _httpClient = new HttpClient();
        _apiBaseUrl = apiBaseUrl.TrimEnd('/');
    }

    public async Task<ModelOutputDTO> PredictAsync(string statement)
    {
        var input = new ModelInputDTO
        {
            Statement = statement,
            Assessment = 0
        };

        try
        {
            var response = await _httpClient.PostAsJsonAsync($"{_apiBaseUrl}/predict", input);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ModelOutputDTO>();
            return result;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"\n❌ API Error: {ex.Message}");
            throw;
        }
    }
}
