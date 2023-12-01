using ProyectoDiseñoSoft.Modelos;
using ProyectoDiseñoSoft.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("ProyectoDiseñoSoftDatabase"));

builder.Services.AddSingleton<ClienteService>();
builder.Services.AddSingleton<ComprasService>();
builder.Services.AddSingleton<ProductoService>();
builder.Services.AddSingleton<OrdenCompraService>();
builder.Services.AddSingleton<FacturacionService>();
builder.Services.AddSingleton<EmpleadoService>();

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

app.Run();
