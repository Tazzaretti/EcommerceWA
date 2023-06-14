using Microsoft.EntityFrameworkCore;
using Model.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar el contexto de la base de datos y la cadena de conexión
builder.Services.AddDbContext<ecommerceDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ecommerceDBConnection")));


// Add services to the container.
builder.Services.AddControllers();
//builder.Services.AddScoped<IEnvioService, EnvioService>();
//builder.Services.AddScoped<IUserService, UserService>();


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

app.Run();
