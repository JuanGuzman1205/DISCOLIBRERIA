using Front_Disco.Components;
using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Implementaciones;
using Presentaciones_Discoteca.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRazorPages();

// Configuracion de sesión
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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
builder.Services.AddScoped<IUsuariosPresentacion, UsuariosPresentacion>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseSession();

app.UseAntiforgery();
app.MapStaticAssets();

app.MapRazorPages();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();