using Alfa;
using Temporalio.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton(async _ =>
{
    var client = await TemporalClient.ConnectAsync(new("temporal:7233"));
    return client;
});

builder.Services.AddControllers();
builder.Services.AddScoped<Activities>();
builder.Services.AddHostedService<TemporalWorkerService>();
var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();