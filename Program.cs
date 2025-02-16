using CTeEmissor.Data;
using CTeEmissor.Dominio.Services;
using CTeEmissor.Dominio.Services.Interfaces;
using CTeEmissor.Repositorio;
using CTeEmissor.Routes;
using ViaCep;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<AppDbContext>(); 
builder.Services.AddSingleton<IAliquotaRepositorio>(provider =>
        new AliquotaRepositorio());
builder.Services.AddScoped<ICompraService, CompraService>();
builder.Services.AddScoped<ICalculaFreteService, CalculaFreteService>();
builder.Services.AddScoped<ICalculaIcmsService, CalculaIcmsService>();
builder.Services.AddHttpClient<IViaCepClient, ViaCepClient>(client => { client.BaseAddress = new Uri("https://viacep.com.br/"); });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "CTe Emissor");
    });
}

app.CteRoutes();
app.CompraRoutes();

app.UseHttpsRedirection();

app.Run();