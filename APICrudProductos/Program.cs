// Program.cs
using Microsoft.EntityFrameworkCore;

// Program.cs

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar la conexión a la base de datos SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin() // Reemplaza con el origen(es) de tu página web
                   .AllowAnyHeader()
                   .AllowAnyMethod();
            // .AllowCredentials(); // Descomenta si necesitas enviar credenciales (cookies, auth headers)
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

app.UseRouting(); // Importante: UseRouting debe ir antes de UseCors

app.UseCors("AllowAll"); // Aplica la política CORS

app.UseAuthorization();

app.MapControllers();

app.Run();