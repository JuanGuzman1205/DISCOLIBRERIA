using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Cajas>? Cajas { get; set; }
        public DbSet<CategoriaProductos>? CategoriaProductos { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Compras>? Compras { get; set; }
        public DbSet<DetalleCompras>? DetalleCompras { get; set; }
        public DbSet<DetalleReparaciones>? DetalleReparaciones { get; set; }
        public DbSet<DetalleReservas>? DetalleReservas { get; set; }
        public DbSet<DetalleVentas>? DetalleVentas { get; set; }
        public DbSet<ElementosInternos>? ElementosInternos { get; set; }
        public DbSet<Eventos>? Eventos { get; set; }
        public DbSet<Facturas>? Facturas { get; set; }
        public DbSet<Inventarios>? Inventarios { get; set; }
        public DbSet<Mesas>? Mesas { get; set; }
        public DbSet<MetodosPagos>? MetodosPagos { get; set; }
        public DbSet<MovimientoInventarios>? MovimientoInventarios { get; set; }
        public DbSet<OtrosGastos>? OtrosGastos { get; set; }
        public DbSet<Productos>? Productos { get; set; }
        public DbSet<Proveedores>? Proveedores { get; set; }
        public DbSet<Reparaciones>? Reparaciones { get; set; }
        public DbSet<Reservas>? Reservas { get; set; }
        public DbSet<Ventas>? Ventas { get; set; }
    }
}
