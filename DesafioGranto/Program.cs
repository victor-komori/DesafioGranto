using DesafioGranto.Data;
using DesafioGranto.Repositories;
using DesafioGranto.Repositories.Interface;
using DesafioGranto.Services;
using DesafioGranto.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Services

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IOportunidadeService, OportunidadeService>();
builder.Services.AddScoped<IPublicaService, PublicaService>();

//Repositories

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IOportunidadeRepository, OportunidadeRepository>();

builder.Services.AddDbContext<DesafioContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("sqlServerConnectionString"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Desafio Granto API",
        Description = "Swagger de uma desafio apresentado pela Granto Seguros."
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DefaultModelsExpandDepth(-1);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
