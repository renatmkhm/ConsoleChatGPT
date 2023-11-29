using Azure;
using Azure.AI.OpenAI;
using ConsoleChatGPT;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

IHostBuilder hostBuilder = Host.CreateDefaultBuilder(args);

hostBuilder.ConfigureAppConfiguration((builder) => builder
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true, true)
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>());

hostBuilder.ConfigureServices((context, services) =>
{
    services.Configure<Settings>(context.Configuration.GetSection("settings"));

    services.AddSingleton(provider =>
    {
        Settings settings = provider.GetRequiredService<IOptions<Settings>>().Value;

        OpenAIClient client = new OpenAIClient(new Uri(settings.Endpoint!), new AzureKeyCredential(settings.Key));

        return client;
    });

    services.AddHostedService<ConsoleGPTService>();
});

await hostBuilder.Build().RunAsync();