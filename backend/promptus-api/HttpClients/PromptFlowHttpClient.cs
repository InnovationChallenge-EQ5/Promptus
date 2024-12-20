using promptus_api.Models;

namespace promptus_api.HttpClients;

public class PromptFlowHttpClient
{
    private readonly HttpClient _httpClient;

    public PromptFlowHttpClient(HttpClient httpClient, IConfiguration configuration)
    {
        httpClient.BaseAddress = new Uri(configuration["Azure:PromptFlowEndpoint"] ??
                                         throw new InvalidOperationException("Azure:PromptFlowEndpoint"));
        httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + configuration["PromptusFlow"] ??
                                                               throw new InvalidOperationException("PromptusFlow"));
        httpClient.Timeout = TimeSpan.FromMinutes(5);
        _httpClient = httpClient;
    }

    public async Task<PromptFlowOutput> GetPrompt(string rawUserPrompt)
    {
        var response = await _httpClient.PostAsJsonAsync((string?)null, new
        {
            inPrompt = rawUserPrompt
        });

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<PromptFlowOutput>()
                     ?? throw new InvalidOperationException("PromptFlow response was null");

        return result;
    }
}