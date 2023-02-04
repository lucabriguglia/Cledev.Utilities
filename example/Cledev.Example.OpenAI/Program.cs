using Cledev.OpenAI.Extensions;
using Cledev.OpenAI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Cledev OpenAI Example");

var builder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>();

IConfiguration configuration = builder.Build();
var serviceCollection = new ServiceCollection();
serviceCollection.AddScoped(_ => configuration);

serviceCollection.AddCledevOpenAI();

var serviceProvider = serviceCollection.BuildServiceProvider();
var service = serviceProvider.GetRequiredService<IOpenAIService>();

var response = await service.CreateCompletion("Say this is a test");

Console.ReadKey();
