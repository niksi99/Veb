using Microsoft.EntityFrameworkCore;
using Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VideoKlubContext>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("VideoKlubCS"));
});



builder.Services.AddCors(options => {
                options.AddPolicy("CORS", builder => {
                    builder.WithOrigins(new string[]
                        {
                            "http://localhost:8080",
                            "https://localhost:8080",
                            "http://127.0.0.1:8080",
                            "https://127.0.0.1:8080",
                            "http://localhost:5500",
                            "https://localhost:5500",
                            "http://127.0.0.1:5500",
                            "https://127.0.0.1:5500",
                            "http://localhost:7254",
                            "https://localhost:7254",
                            "http://127.0.0.1:7254",
                            "https://127.0.0.1:7254"
                        })
                        .AllowAnyHeader()
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

app.UseCors("CORS");

app.UseAuthorization();

app.MapControllers();

app.Run();
