using server.Services;
using server.Services.Interfaces;
using SQLDBAAssistant.Context;
using Serilog;
using Serilog.Hosting;

var builder = WebApplication.CreateBuilder(args);


//Setting up and adding a log provider
var logConfig = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    //.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIROMENT") ?? "Production"}.json", true)
    .Build();

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(logConfig));

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IConnectedSQLServerService, ConnectedSQLServerService>();
builder.Services.AddDbContext<MasterContext>();
builder.Services.AddScoped(typeof(IStoreRepository), typeof(StoreRepository));
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(
           options => options.WithOrigins("http://localhost:3000").AllowAnyMethod()
       );

InitializerData.SeedData(app);
app.Run();
