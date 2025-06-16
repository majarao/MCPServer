using MCPServer.Shared.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace MCPServer.Shared.Clients;

public class PessoaClient
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _serializerOptions;

    public PessoaClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _serializerOptions = new JsonSerializerOptions{
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<List<PessoaResultModel>> ObterPessoas(string? nome)
    {
        string url = string.IsNullOrWhiteSpace(nome) ? "pessoas" : $"pessoas?nome={Uri.EscapeDataString(nome)}";
        HttpResponseMessage response = await _httpClient.GetAsync(url);

        if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            return [];

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<PessoaResultModel>>(_serializerOptions) ?? [];
    }

    public async Task CriarPessoaAsync(PessoaInputModel model) => 
        await _httpClient.PostAsJsonAsync("pessoas", model);
}
