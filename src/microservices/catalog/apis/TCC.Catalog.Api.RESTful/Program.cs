using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TCC.Catalog.Api.RESTful;
using TCC.Catalog.Persistence.Postgres.EntityFrameworkCore;

const string appName = "Catalog.API";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPostgresCatalogDbContext(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

try {
    // Log.Information("Configuring web host ({ApplicationContext})...", Program.AppName);
    app.Logger.LogInformation("Configuring web host ({ApplicationContext})...", appName);
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<PostgresCatalogDbContext>();
    var env = app.Services.GetService<IWebHostEnvironment>();
    // var settings = app.Services.GetService<IOptions<CatalogSettings>>();
    // var logger = app.Services.GetService<ILogger<CatalogDbContextSeed>>();
    await context.Database.MigrateAsync();
    //
    // await new CatalogDbContextSeed().SeedAsync(context, env, settings, logger);
    app.Logger.LogInformation("Starting web host ({ApplicationName})...", appName);
    await app.RunAsync();
    return 0;
}
catch (Exception ex) {
    // Log.Fatal(ex, "Program terminated unexpectedly ({ApplicationContext})!", Program.AppName);
    return 1;
}
finally {
    // Log.CloseAndFlush();
}