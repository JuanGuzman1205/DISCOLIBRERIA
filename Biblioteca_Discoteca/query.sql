CREATE DATABASE SistemaGestion;
GO
USE SistemaGestion;
GO


CREATE TABLE Proveedores (
    IdProveedor INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Telefono NVARCHAR(20) NULL,
    Email NVARCHAR(100) NULL
);

CREATE TABLE CategoriaProductos (
    IdCategoria INT IDENTITY(1,1) PRIMARY KEY,
    NomCategoria NVARCHAR(100) NOT NULL
);

CREATE TABLE Clientes (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    Apellido NVARCHAR(50) NOT NULL
);

CREATE TABLE Empleados (
    IdEmpleado INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Telefono NVARCHAR(20) NULL,
    Cargo NVARCHAR(50) NOT NULL,
    Nomina DECIMAL(12, 2) NOT NULL DEFAULT 0.00
);

CREATE TABLE Mesas (
    IdMesa INT IDENTITY(1,1) PRIMARY KEY,
    ConsumoMinimo INT NOT NULL DEFAULT 0,
    Ubicacion NVARCHAR(100) NULL,
    Capacidad INT NOT NULL
);

CREATE TABLE Inventarios (
    IdInventario INT IDENTITY(1,1) PRIMARY KEY
);


CREATE TABLE MetodosPagos (
    IdMetodoPago INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT NULL,
    TipoMetodoPago NVARCHAR(50) NOT NULL,
    NumeroCuenta NVARCHAR(50) NULL,
    CONSTRAINT FK_MetodosPagos_Clientes FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente) ON DELETE CASCADE
);

CREATE TABLE Cajas (
    IdCaja INT IDENTITY(1,1) PRIMARY KEY,
    IdEmpleadoCaja INT NOT NULL,
    DineroInicial DECIMAL(12, 2) NOT NULL DEFAULT 0.00,
    DineroFinal DECIMAL(12, 2) NOT NULL DEFAULT 0.00,
    Ganancias DECIMAL(12, 2) NOT NULL DEFAULT 0.00,
    CONSTRAINT FK_Cajas_Empleados FOREIGN KEY (IdEmpleadoCaja) REFERENCES Empleados(IdEmpleado) ON DELETE CASCADE
);

CREATE TABLE Eventos (
    IdEvento INT IDENTITY(1,1) PRIMARY KEY,
    IdEncargado INT NOT NULL,
    DetalleEvento NVARCHAR(MAX) NULL,
    FechaEvento DATE NOT NULL,
    HoraInicio DATETIME NOT NULL,
    HoraFin DATETIME NOT NULL,
    CONSTRAINT FK_Eventos_Empleados FOREIGN KEY (IdEncargado) REFERENCES Empleados(IdEmpleado) ON DELETE CASCADE
);

CREATE TABLE OtrosGastos (
    IdGasto INT IDENTITY(1,1) PRIMARY KEY,
    IdEmpleado INT NOT NULL,
    Descripcion NVARCHAR(255) NULL,
    Monto DECIMAL(12, 2) NOT NULL,
    FechaGasto DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_OtrosGastos_Empleados FOREIGN KEY (IdEmpleado) REFERENCES Empleados(IdEmpleado) ON DELETE CASCADE
);

CREATE TABLE Compras (
    IdCompra INT IDENTITY(1,1) PRIMARY KEY,
    IdEmpleado INT NOT NULL,
    Total DECIMAL(12, 2) NOT NULL DEFAULT 0.00,
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Compras_Empleados FOREIGN KEY (IdEmpleado) REFERENCES Empleados(IdEmpleado) ON DELETE CASCADE
);

CREATE TABLE Reservas (
    IdReserva INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT NOT NULL,
    FechaReserva DATETIME NOT NULL,
    Total DECIMAL(12, 2) NOT NULL DEFAULT 0.00,
    CONSTRAINT FK_Reservas_Clientes FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente) ON DELETE CASCADE
);

CREATE TABLE Reparaciones (
    IdReparacion INT IDENTITY(1,1) PRIMARY KEY,
    IdSolicitante INT NOT NULL,
    IdEncargado INT NOT NULL,
    FechaReparacion DATETIME NOT NULL DEFAULT GETDATE(),
    -- Solo el Solicitante tiene CASCADE, el Encargado queda NO ACTION para evitar rutas múltiples
    CONSTRAINT FK_Reparaciones_Solicitante FOREIGN KEY (IdSolicitante) REFERENCES Empleados(IdEmpleado) ON DELETE CASCADE,
    CONSTRAINT FK_Reparaciones_Encargado FOREIGN KEY (IdEncargado) REFERENCES Empleados(IdEmpleado) ON DELETE NO ACTION
);

CREATE TABLE Productos (
    IdProducto INT IDENTITY(1,1) PRIMARY KEY,
    IdCategoria INT NOT NULL,
    IdProveedor INT NOT NULL,
    IdInventario INT NOT NULL,
    NomProducto NVARCHAR(100) NOT NULL,
    Presentacion NVARCHAR(50) NULL,
    PrecioCompra DECIMAL(12, 2) NOT NULL DEFAULT 0.00,
    PrecioVenta DECIMAL(12, 2) NOT NULL DEFAULT 0.00,
    Stock INT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Productos_Categorias FOREIGN KEY (IdCategoria) REFERENCES CategoriaProductos(IdCategoria) ON DELETE CASCADE,
    CONSTRAINT FK_Productos_Proveedores FOREIGN KEY (IdProveedor) REFERENCES Proveedores(IdProveedor) ON DELETE CASCADE,
    CONSTRAINT FK_Productos_Inventarios FOREIGN KEY (IdInventario) REFERENCES Inventarios(IdInventario) ON DELETE CASCADE
);

CREATE TABLE ElementosInternos (
    IdElementoInterno INT IDENTITY(1,1) PRIMARY KEY,
    IdInventario INT NOT NULL,
    NombreElementoInterno NVARCHAR(100) NOT NULL,
    CantidadElementoInterno INT NOT NULL DEFAULT 0,
    PrecioElementoInterno DECIMAL(12, 2) NOT NULL DEFAULT 0.00,
    CONSTRAINT FK_ElementosInternos_Inventarios FOREIGN KEY (IdInventario) REFERENCES Inventarios(IdInventario) ON DELETE CASCADE
);

CREATE TABLE MovimientoInventarios (
    IdMovimiento INT IDENTITY(1,1) PRIMARY KEY,
    IdInventario INT NOT NULL,
    TipoMovimiento NVARCHAR(20) NOT NULL, -- Entrada / Salida
    Cantidad INT NOT NULL,
    FechaMovimiento DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_MovimientoInventarios_Inventarios FOREIGN KEY (IdInventario) REFERENCES Inventarios(IdInventario) ON DELETE CASCADE
);

CREATE TABLE Ventas (
    IdVenta INT IDENTITY(1,1) PRIMARY KEY,
    IdEmpleado INT NOT NULL,
    IdFactura INT NULL, -- Se actualiza cuando se emite la factura (FK se asigna al final del script)
    Total DECIMAL(12, 2) NOT NULL DEFAULT 0.00,
    Estado BIT NOT NULL DEFAULT 1, -- 1: Mesa abierta, 0: Mesa cerrada
    CONSTRAINT FK_Ventas_Empleados FOREIGN KEY (IdEmpleado) REFERENCES Empleados(IdEmpleado) ON DELETE CASCADE
);

CREATE TABLE Facturas (
    IdFactura INT IDENTITY(1,1) PRIMARY KEY,
    IdVenta INT NOT NULL,
    IdMesero INT NOT NULL,
    IdBarra INT NOT NULL,
    IdCaja INT NOT NULL,
    IdMetodoPago INT NOT NULL,
    FechaFacturacion DATETIME NOT NULL DEFAULT GETDATE(),
    -- Solo IdVenta tiene CASCADE. El resto es NO ACTION para evitar error 1750 (rutas múltiples de cascada)
    CONSTRAINT FK_Facturas_Ventas FOREIGN KEY (IdVenta) REFERENCES Ventas(IdVenta) ON DELETE CASCADE,
    CONSTRAINT FK_Facturas_Mesero FOREIGN KEY (IdMesero) REFERENCES Empleados(IdEmpleado) ON DELETE NO ACTION,
    CONSTRAINT FK_Facturas_Barra FOREIGN KEY (IdBarra) REFERENCES Empleados(IdEmpleado) ON DELETE NO ACTION,
    CONSTRAINT FK_Facturas_Cajas FOREIGN KEY (IdCaja) REFERENCES Cajas(IdCaja) ON DELETE NO ACTION,
    CONSTRAINT FK_Facturas_MetodosPagos FOREIGN KEY (IdMetodoPago) REFERENCES MetodosPagos(IdMetodoPago) ON DELETE NO ACTION
);

CREATE TABLE DetalleVentas (
    IdDetalleVenta INT IDENTITY(1,1) PRIMARY KEY,
    IdVenta INT NOT NULL,
    IdProducto INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(12, 2) NOT NULL,
    CONSTRAINT FK_DetalleVentas_Ventas FOREIGN KEY (IdVenta) REFERENCES Ventas(IdVenta) ON DELETE CASCADE,
    CONSTRAINT FK_DetalleVentas_Productos FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto) ON DELETE CASCADE
);

CREATE TABLE DetalleCompras (
    IdDetalleCompra INT IDENTITY(1,1) PRIMARY KEY,
    IdCompra INT NOT NULL,
    IdProducto INT NOT NULL,
    Cantidad INT NOT NULL,
    Total DECIMAL(12, 2) NOT NULL,
    CONSTRAINT FK_DetalleCompras_Compras FOREIGN KEY (IdCompra) REFERENCES Compras(IdCompra) ON DELETE CASCADE,
    CONSTRAINT FK_DetalleCompras_Productos FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto) ON DELETE CASCADE
);

CREATE TABLE DetalleReservas (
    IdDetalleReserva INT IDENTITY(1,1) PRIMARY KEY,
    IdReserva INT NOT NULL,
    IdMesa INT NOT NULL,
    CONSTRAINT FK_DetalleReservas_Reservas FOREIGN KEY (IdReserva) REFERENCES Reservas(IdReserva) ON DELETE CASCADE,
    CONSTRAINT FK_DetalleReservas_Mesas FOREIGN KEY (IdMesa) REFERENCES Mesas(IdMesa) ON DELETE CASCADE
);

CREATE TABLE DetalleReparaciones (
    IdDetalleReparacion INT IDENTITY(1,1) PRIMARY KEY,
    IdReparacion INT NOT NULL,
    IdElementoInterno INT NOT NULL,
    DescripcionReparacion NVARCHAR(255) NULL,
    CostoReparacion DECIMAL(12, 2) NOT NULL DEFAULT 0.00,
    CONSTRAINT FK_DetalleReparaciones_Reparaciones FOREIGN KEY (IdReparacion) REFERENCES Reparaciones(IdReparacion) ON DELETE CASCADE,
    CONSTRAINT FK_DetalleReparaciones_ElementosInternos FOREIGN KEY (IdElementoInterno) REFERENCES ElementosInternos(IdElementoInterno) ON DELETE CASCADE
);


-- Asignación de la FK de Ventas hacia Facturas (NO ACTION para evitar conflictos de rutas con la FK de Facturas a Ventas)
ALTER TABLE Ventas
ADD CONSTRAINT FK_Ventas_Facturas FOREIGN KEY (IdFactura) REFERENCES Facturas(IdFactura) ON DELETE NO ACTION;

ALTER TABLE Ventas 
ALTER COLUMN IdFactura INT NULL;