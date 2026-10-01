using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Discoteca
{
    public static class GeneradorDatosPrueba
    {
        
        public static Proveedores ObtenerProveedor()
        {
            return new Proveedores()
            {
                Nombre = "Distribuidora Licores Prueba",
                Telefono = "604 123 45 67",
                Email = "contacto@distribuidora.com"
            };
        }

        public static CategoriaProductos ObtenerCategoriaProducto()
        {
            return new CategoriaProductos()
            {
                NomCategoria = "Licores Fuertes"
            };
        }

        public static Clientes ObtenerCliente()
        {
            return new Clientes()
            {
                Nombre = "Juan",
                Apellido = "Pérez"
            };
        }

        public static Empleados ObtenerEmpleado()
        {
            return new Empleados()
            {
                Nombre = "Carlos Empleado Prueba",
                Telefono = "300 987 65 43",
                Cargo = "Mesero",
                Nomina = 1500000.00m
            };
        }

        public static Mesas ObtenerMesa()
        {
            return new Mesas()
            {
                ConsumoMinimo = 50000,
                Ubicacion = "VIP Centro",
                Capacidad = 6
            };
        }

        public static Inventarios ObtenerInventario()
        {
            return new Inventarios(); // La tabla solo tiene Id autoincremental
        }

        public static MetodosPagos ObtenerMetodoPago(int? idCliente = null)
        {
            return new MetodosPagos()
            {
                IdCliente = idCliente,
                TipoMetodoPago = "Tarjeta de Crédito",
                NumeroCuenta = "1234-5678-9012"
            };
        }

        public static Cajas ObtenerCaja(int idEmpleadoCaja)
        {
            return new Cajas()
            {
                IdEmpleadoCaja = idEmpleadoCaja,
                DineroInicial = 200000.00m,
                DineroFinal = 0.00m,
                Ganancias = 0.00m
            };
        }

        public static Eventos ObtenerEvento(int idEncargado)
        {
            return new Eventos()
            {
                IdEncargado = idEncargado,
                DetalleEvento = "Noche de Reggaeton Test",
                FechaEvento = DateTime.Now.Date,
                HoraInicio = DateTime.Now,
                HoraFin = DateTime.Now.AddHours(5)
            };
        }

        public static OtrosGastos ObtenerOtroGasto(int idEmpleado)
        {
            return new OtrosGastos()
            {
                IdEmpleado = idEmpleado,
                Descripcion = "Compra de hielo de emergencia",
                Monto = 15000.00m,
                FechaGasto = DateTime.Now
            };
        }

        public static Compras ObtenerCompra(int idEmpleado)
        {
            return new Compras()
            {
                IdEmpleado = idEmpleado,
                Total = 500000.00m,
                Fecha = DateTime.Now
            };
        }

        public static Reservas ObtenerReserva(int idCliente)
        {
            return new Reservas()
            {
                IdCliente = idCliente,
                FechaReserva = DateTime.Now.AddDays(2),
                Total = 100000.00m
            };
        }

        public static Reparaciones ObtenerReparacion(int idSolicitante, int idEncargado)
        {
            return new Reparaciones()
            {
                IdSolicitante = idSolicitante,
                IdEncargado = idEncargado,
                FechaReparacion = DateTime.Now
            };
        }

        public static Productos ObtenerProducto(int idCategoria, int idProveedor, int idInventario)
        {
            return new Productos()
            {
                IdCategoria = idCategoria,
                IdProveedor = idProveedor,
                IdInventario = idInventario,
                NomProducto = "Aguardiente Prueba 750ml",
                Presentacion = "Botella",
                PrecioCompra = 40000.00m,
                PrecioVenta = 85000.00m,
                stock = 20
            };
        }

        public static ElementosInternos ObtenerElementoInterno(int idInventario)
        {
            return new ElementosInternos()
            {
                IdInventario = idInventario,
                NombreElementoInterno = "Silla Alta Barra",
                CantidadElementoInterno = 10,
                PrecioElementoInterno = 120000.00m
            };
        }

        public static MovimientoInventarios ObtenerMovimientoInventario(int idInventario)
        {
            return new MovimientoInventarios()
            {
                IdInventario = idInventario,
                TipoMovimiento = "Entrada",
                Cantidad = 50,
                FechaMovimiento = DateTime.Now
            };
        }

        public static Ventas ObtenerVenta(int idEmpleado, int? idFactura = null)
        {
            return new Ventas()
            {
                IdEmpleado = idEmpleado,
                IdFactura = idFactura, 
                Total = 150000.00m,
                Estado = true
            };
        }

        public static Facturas ObtenerFactura(int idVenta, int idMesero, int idBarra, int idCaja, int idMetodoPago)
        {
            return new Facturas()
            {
                IdVenta = idVenta,
                IdMesero = idMesero,
                IdBarra = idBarra,
                IdCaja = idCaja,
                IdMetodoPago = idMetodoPago,
                FechaFacturacion = DateTime.Now
            };
        }



        public static DetalleVentas ObtenerDetalleVenta(int idVenta, int idProducto)
        {
            return new DetalleVentas()
            {
                IdVenta = idVenta,
                IdProducto = idProducto,
                Cantidad = 2,
                PrecioUnitario = 85000.00m
            };
        }

        public static DetalleCompras ObtenerDetalleCompra(int idCompra, int idProducto)
        {
            return new DetalleCompras()
            {
                IdCompra = idCompra,
                IdProducto = idProducto,
                Cantidad = 10,
                Total = 400000.00m
            };
        }

        public static DetalleReservas ObtenerDetalleReserva(int idReserva, int idMesa)
        {
            return new DetalleReservas()
            {
                IdReserva = idReserva,
                IdMesa = idMesa
            };
        }

        public static DetalleReparaciones ObtenerDetalleReparacion(int idReparacion, int idElementoInterno)
        {
            return new DetalleReparaciones()
            {
                IdReparacion = idReparacion,
                IdElementoInterno = idElementoInterno,
                DescripcionReparacion = "Cambio de tapizado",
                CostoReparacion = 45000.00m
            };
        }
    }
}
