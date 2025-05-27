using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using NamestajSanin.Data;
using NamestajSanin.Services;
using System.Text.Json.Serialization;
using NamestajSanin.Middleware;


var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://*:80");

// Registracija baze
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// Enum u string
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); 
    });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<StatusService>();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

// ✅ Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
