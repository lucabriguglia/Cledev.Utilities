using System.Text.Json;
using Cledev.OpenAI.Extensions;
using Cledev.OpenAI.V1;
using Cledev.OpenAI.V1.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var jsonSerializerOptions = new JsonSerializerOptions
{
    WriteIndented = true
};

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

//var response = await service.RetrieveModels();
//var response = await service.RetrieveModel("text-davinci-003");
var response = await service.CreateCompletion("Say this is a test");
//var response = await service.CreateCompletion("What is MOB programming?", OpenAIModels.TextDavinciV3, maxTokens: 100);

Console.WriteLine($"{JsonSerializer.Serialize(response, jsonSerializerOptions)}");
Console.ReadKey();
