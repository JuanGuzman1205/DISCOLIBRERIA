using Biblioteca_Discoteca.Implementaciones;
using Biblioteca_Discoteca.Interfaces;
using Biblioteca_Discoteca.Nucleo;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(o =>
{
    // No enviar propiedades null en las respuestas
    o.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddScoped<IConexion>(sp =>
    new Conexion { StringConexion = DatosGenerales.ObtenerStringConexion() });

builder.Services.AddScoped<ICajasAplicacion, CajasAplicacion>();
builder.Services.AddScoped<IProductosAplicacion, ProductosAplicacion>();
builder.Services.AddScoped<IVentasAplicacion, VentasAplicacion>();
builder.Services.AddScoped<IDetalleVentasAplicacion, DetalleVentasAplicacion>();
builder.Services.AddScoped<IFacturasAplicacion, FacturasAplicacion>();
builder.Services.AddScoped<IMetodosPagoAplicacion, MetodosPagosAplicacion>();
builder.Services.AddScoped<IReservasAplicacion, ReservasAplicacion>();
builder.Services.AddScoped<IDetalleReservasAplicacion, DetalleReservasAplicacion>();
builder.Services.AddScoped<IDetalleComprasAplicacion, DetalleComprasAplicacion>();
builder.Services.AddScoped<IDetalleReparacionesAplicacion, DetalleReparacionesAplicacion>();
builder.Services.AddScoped<IEventosAplicacion, EventosAplicacion>();
builder.Services.AddScoped<IOtrosGastosAplicacion, OtrosGastosAplicacion>();
builder.Services.AddScoped<IInventariosAplicacion, InventariosAplicacion>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
