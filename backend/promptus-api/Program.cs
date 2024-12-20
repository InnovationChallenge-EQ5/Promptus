using Asp.Versioning;
using Azure.Identity;
using promptus_api.Endpoints.v1;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddProblemDetails()
    .AddHealthChecks();

//Azure Key Vault.
if (builder.Environment.IsProduction())
{
    builder.Configuration.AddAzureKeyVault(
        new Uri(builder.Configuration["KeyVaultUrl"] ?? throw new InvalidOperationException()),
        new DefaultAzureCredential(new DefaultAzureCredentialOptions() {ManagedIdentityClientId = builder.Configuration["KeyVaultIdentity"]}));
}

//Versioning.
builder.Services.AddApiVersioning(options =>
    {
        options.ApiVersionReader = new UrlSegmentApiVersionReader();
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.ReportApiVersions = true;
    })
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseExceptionHandler(new ExceptionHandlerOptions
{
    StatusCodeSelector = ex => ex is TimeoutException
        ? StatusCodes.Status503ServiceUnavailable
        : StatusCodes.Status500InternalServerError,
});


app.UseHttpsRedirection();

app.MapHealthChecks("/health")
    .DisableHttpMetrics();

var group = app.NewVersionedApi("api")
    .MapGroup("api/v{version:apiVersion}/prompts");
group.MapGet("suggestions", PromptEndpoint.GetPromptSuggestions)
    .MapToApiVersion(1);

app.Run();