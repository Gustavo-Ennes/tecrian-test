using Serilog;
using Tecrian.Api.ConfigExtensions;
using Tecrian.Infra.Database;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServices(builder.Configuration);

var app = builder.Build();

// Ensure the database is created and synchronized with the models
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TecrianDbContext>();
    dbContext.Database.EnsureCreated();
}

app.UseSerilogRequestLogging();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.UseHttpsRedirection();
app.UseCors("AllowLocalhost4200");

Log.Information("Application started: 5000.");
app.Run();


public partial class Program { }