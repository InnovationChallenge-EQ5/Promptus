using Microsoft.AspNetCore.Http.HttpResults;
using promptus_api.Records.v1;

namespace promptus_api.Endpoints.v1;

public static class PromptEndpoint
{
    public static Ok<PromptSuggestionsResponse> GetPromptSuggestions(string rawUserPrompt)
    {
        return TypedResults.Ok(new PromptSuggestionsResponse("Este es el prompt sugerido al usuario"));
    }
}