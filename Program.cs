using ProyectoDiseñoSoft.Fabrica;
using ProyectoDiseñoSoft.Modelos;
using ProyectoDiseñoSoft.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("ProyectoDiseñoSoftDatabase"));

builder.Services.AddSingleton<IPersonaService<Cliente>, ClienteService>();
builder.Services.AddSingleton<IPersonaService<Compras>, ComprasService>();
builder.Services.AddSingleton<IPersonaService<Producto>, ProductoService>();
builder.Services.AddSingleton<IPersonaService<OrdenCompra>, OrdenCompraService>();
builder.Services.AddSingleton<IPersonaService<Facturacion>, FacturacionService>();
builder.Services.AddSingleton<IPersonaService<Empleados>, EmpleadoService>();

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
