using Microsoft.AspNetCore.Http.HttpResults;
using promptus_api.HttpClients;
using promptus_api.Records.v1;

namespace promptus_api.Endpoints.v1;

public static class PromptEndpoint
{
    public static async Task<Ok<PromptSuggestionsResponse>> GetPromptSuggestions(string rawUserPrompt,
        IConfiguration configuration, PromptFlowHttpClient flowClient)
    {
        var result = await flowClient.GetPrompt(rawUserPrompt);
        return TypedResults.Ok(new PromptSuggestionsResponse(result.outPrompt));
    }
}