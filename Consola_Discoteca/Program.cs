using Biblioteca_Discoteca.Implementaciones;
using Biblioteca_Discoteca.Interfaces;

try
{
    IConexion conexion = new Conexion();
    conexion.StringConexion = "server=localhost;database=SistemaGestion;Integrated Security=True;TrustServerCertificate=true;";
    var lista_empleados = conexion.Empleados!.ToList();
    Console.WriteLine("--- VERIFICACIÓN DE ENTIDADES ---");

    Console.WriteLine($"Cajas: {conexion.Cajas!.ToList().Count}");
    Console.WriteLine($"Categorías: {conexion.CategoriaProductos!.ToList().Count}");
    Console.WriteLine($"Clientes: {conexion.Clientes!.ToList().Count}");
    Console.WriteLine($"Compras: {conexion.Compras!.ToList().Count}");
    Console.WriteLine($"Detalle Compras: {conexion.DetalleCompras!.ToList().Count}");
    Console.WriteLine($"Detalle Reparaciones: {conexion.DetalleReparaciones!.ToList().Count}");
    Console.WriteLine($"Detalle Reservas: {conexion.DetalleReservas!.ToList().Count}");
    Console.WriteLine($"Detalle Ventas: {conexion.DetalleVentas!.ToList().Count}");
    Console.WriteLine($"Elementos Internos: {conexion.ElementosInternos!.ToList().Count}");
    Console.WriteLine($"Empleados: {conexion.Empleados!.ToList().Count}");
    Console.WriteLine($"Eventos: {conexion.Eventos!.ToList().Count}");
    Console.WriteLine($"Facturas: {conexion.Facturas!.ToList().Count}");
    Console.WriteLine($"Inventarios: {conexion.Inventarios!.ToList().Count}");
    Console.WriteLine($"Mesas: {conexion.Mesas!.ToList().Count}");
    Console.WriteLine($"Métodos de Pagos: {conexion.MetodosPagos!.ToList().Count}");
    Console.WriteLine($"Movimientos: {conexion.MovimientoInventarios!.ToList().Count}");
    Console.WriteLine($"Otros Gastos: {conexion.OtrosGastos!.ToList().Count}");
    Console.WriteLine($"Productos: {conexion.Productos!.ToList().Count}");
    Console.WriteLine($"Proveedores: {conexion.Proveedores!.ToList().Count}");
    Console.WriteLine($"Reparaciones: {conexion.Reparaciones!.ToList().Count}");
    Console.WriteLine($"Reservas: {conexion.Reservas!.ToList().Count}");
    Console.WriteLine($"Ventas: {conexion.Ventas!.ToList().Count}");

    Console.WriteLine("---------------------------------");
    Console.WriteLine("¡Conexión y mapeo de todas las entidades exitosos!");

}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

Console.WriteLine("presentacion_consola");