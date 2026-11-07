using Front_Disco.Components;
using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Implementaciones;
using Presentaciones_Discoteca.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Configuración de Blazor y Razor Pages en .NET 10
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRazorPages(); // <-- 1. REGISTRAR SERVICIO DE RAZOR PAGES

// Inyección de dependencias
builder.Services.AddScoped<IComunicaciones, Comunicaciones>();
builder.Services.AddScoped<ICajasPresentacion, CajasPresentacion>();
builder.Services.AddScoped<IClientesPresentacion, ClientesPresentacion>();
builder.Services.AddScoped<IEmpleadosPresentacion, EmpleadosPresentacion>();
builder.Services.AddScoped<ICategoriaProductosPresentacion, CategoriaProductosPresentacion>();
builder.Services.AddScoped<IElementosInternosPresentacion, ElementosInternosPresentacion>();
builder.Services.AddScoped<IInventariosPresentacion, InventariosPresentacion>();
builder.Services.AddScoped<IProductosPresentacion, ProductosPresentacion>();
builder.Services.AddScoped<IProveedoresPresentacion, ProveedoresPresentacion>();
builder.Services.AddScoped<IMovimientoInventariosPresentacion, MovimientoInventariosPresentacion>();
builder.Services.AddScoped<IFacturasPresentacion, FacturasPresentacion>();
builder.Services.AddScoped<IMesasPresentacion, MesasPresentacion>();
builder.Services.AddScoped<IMetodosPagosPresentacion, MetodosPagosPresentacion>();
builder.Services.AddScoped<IVentasPresentacion, VentasPresentacion>();
builder.Services.AddScoped<IDetalleVentasPresentacion, DetalleVentasPresentacion>();
builder.Services.AddScoped<IComprasPresentacion, ComprasPresentacion>();
builder.Services.AddScoped<IDetalleComprasPresentacion, DetalleComprasPresentacion>();
builder.Services.AddScoped<IOtrosGastosPresentacion, OtrosGastosPresentacion>();
builder.Services.AddScoped<IEventosPresentacion, EventosPresentacion>();
builder.Services.AddScoped<IReparacionesPresentacion, ReparacionesPresentacion>();
builder.Services.AddScoped<IDetalleReparacionesPresentacion, DetalleReparacionesPresentacion>();
builder.Services.AddScoped<IReservasPresentacion, ReservasPresentacion>();
builder.Services.AddScoped<IDetalleReservasPresentacion, DetalleReservasPresentacion>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();

app.MapRazorPages(); // <-- 2. MAPEAR RUTAS DE RAZOR PAGES

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();