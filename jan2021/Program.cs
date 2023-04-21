using Microsoft.EntityFrameworkCore;
using Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GradContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("GradCS"));
});

builder.Services.AddCors(options=>{options.AddPolicy("Cors", builder=>{
                builder.WithOrigins(new string[]{
                "http://localhost:8080",
                "https://localohost:8080",
                "http://127.0.0.1:8080",
                "https://127.0.0.1:8080",
                "https://localhost:7257",
                "https://127.0.0.1:7257",
                "http://localhost:7257",
                "http://127.0.0.1:7257"
                
                }).AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
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

app.UseCors("Cors");

app.UseAuthorization();

app.MapControllers();

app.Run();
