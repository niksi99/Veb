using Microsoft.EntityFrameworkCore;
using Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProdavnicaCS"));
});

builder.Services.AddCors(options => {
    options.AddPolicy("CORS", builder => {
        builder.WithOrigins(new string[] { 
            "https://localhost:8080",
            "http://localhost:8080",
            "https://127.0.0.1:8080",
            "http://127:0:01:8080",
            "https://localhost:7291",
            "http://localhost:7291",
            "https://127.0.0.1:7291",
            "http://127:0:01:7291"
        }).AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();     
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CORS");

app.UseAuthorization();

app.MapControllers();

app.Run();
