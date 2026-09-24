CREATE DATABASE SistemaGestion;
GO;
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



CREATE TABLE MetodosPagos (
    IdMetodoPago INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT NULL,
    TipoMetodoPago NVARCHAR(50) NOT NULL,
    NumeroCuenta NVARCHAR(50) NULL,
    CONSTRAINT FK_MetodosPagos_Clientes FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente) ON DELETE SET NULL
);

CREATE TABLE Cajas (
    IdCaja INT IDENTITY(1,1) PRIMARY KEY,
    IdEmpleadoCaja INT NOT NULL,
    DineroInicial DECIMAL(12, 2) NOT NULL DEFAULT 0.00,
    DineroFinal DECIMAL(12, 2) NOT NULL DEFAULT 0.00,
    Ganancias DECIMAL(12, 2) NOT NULL DEFAULT 0.00,
    CONSTRAINT FK_Cajas_Empleados FOREIGN KEY (IdEmpleadoCaja) REFERENCES Empleados(IdEmpleado)
);

CREATE TABLE Eventos (
    IdEvento INT IDENTITY(1,1) PRIMARY KEY,
    IdEncargado INT NOT NULL,
    DetalleEvento NVARCHAR(MAX) NULL,
    FechaEvento DATE NOT NULL,
    HoraInicio DATETIME NOT NULL,
    HoraFin DATETIME NOT NULL,
    CONSTRAINT FK_Eventos_Empleados FOREIGN KEY (IdEncargado) REFERENCES Empleados(IdEmpleado)
);

CREATE TABLE OtrosGastos (
    IdGasto INT IDENTITY(1,1) PRIMARY KEY,
    IdEmpleado INT NOT NULL,
    Descripcion NVARCHAR(255) NULL,
    Monto DECIMAL(12, 2) NOT NULL,
    FechaGasto DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_OtrosGastos_Empleados FOREIGN KEY (IdEmpleado) REFERENCES Empleados(IdEmpleado)
);

CREATE TABLE Compras (
    IdCompra INT IDENTITY(1,1) PRIMARY KEY,
    IdEmpleado INT NOT NULL,
    Total DECIMAL(12, 2) NOT NULL DEFAULT 0.00,
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Compras_Empleados FOREIGN KEY (IdEmpleado) REFERENCES Empleados(IdEmpleado)
);

CREATE TABLE Reservas (
    IdReserva INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT NOT NULL,
    FechaReserva DATETIME NOT NULL,
    Total DECIMAL(12, 2) NOT NULL DEFAULT 0.00,
    CONSTRAINT FK_Reservas_Clientes FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente)
);

CREATE TABLE Reparaciones (
    IdReparacion INT IDENTITY(1,1) PRIMARY KEY,
    IdSolicitante INT NOT NULL,
    IdEncargado INT NOT NULL,
    FechaReparacion DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Reparaciones_Solicitante FOREIGN KEY (IdSolicitante) REFERENCES Empleados(IdEmpleado),
    CONSTRAINT FK_Reparaciones_Encargado FOREIGN KEY (IdEncargado) REFERENCES Empleados(IdEmpleado)
);


CREATE TABLE Inventarios (
    IdInventario INT IDENTITY(1,1) PRIMARY KEY,
    IdProducto INT NULL,
    IdElementoInterno INT NULL,
    Stock INT NOT NULL DEFAULT 0
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
    CONSTRAINT FK_Productos_Categorias FOREIGN KEY (IdCategoria) REFERENCES CategoriaProductos(IdCategoria),
    CONSTRAINT FK_Productos_Proveedores FOREIGN KEY (IdProveedor) REFERENCES Proveedores(IdProveedor),
    CONSTRAINT FK_Productos_Inventarios FOREIGN KEY (IdInventario) REFERENCES Inventarios(IdInventario)
);

ALTER TABLE Inventarios
ADD CONSTRAINT FK_Inventarios_Productos FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto);

CREATE TABLE ElementosInternos (
    IdElementoInterno INT IDENTITY(1,1) PRIMARY KEY,
    IdInventario INT NOT NULL,
    NombreElementoInterno NVARCHAR(100) NOT NULL,
    CantidadElementoInterno INT NOT NULL DEFAULT 0,
    PrecioElementoInterno DECIMAL(12, 2) NOT NULL DEFAULT 0.00,
    CONSTRAINT FK_ElementosInternos_Inventarios FOREIGN KEY (IdInventario) REFERENCES Inventarios(IdInventario)
);

ALTER TABLE Inventarios
ADD CONSTRAINT FK_Inventarios_ElementosInternos FOREIGN KEY (IdElementoInterno) REFERENCES ElementosInternos(IdElementoInterno);

CREATE TABLE MovimientoInventarios (
    IdMovimiento INT IDENTITY(1,1) PRIMARY KEY,
    IdInventario INT NOT NULL,
    TipoMovimiento NVARCHAR(20) NOT NULL, -- Entrada / Salida
    Cantidad INT NOT NULL,
    FechaMovimiento DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_MovimientoInventarios_Inventarios FOREIGN KEY (IdInventario) REFERENCES Inventarios(IdInventario)
);



CREATE TABLE Ventas (
    IdVenta INT IDENTITY(1,1) PRIMARY KEY,
    IdEmpleado INT NOT NULL,
    IdFactura INT NULL, -- Se actualiza cuando se emite la factura
    Total DECIMAL(12, 2) NOT NULL DEFAULT 0.00,
    Estado BIT NOT NULL DEFAULT 1, -- 1: Mesa abierta, 0: Mesa cerrada
    CONSTRAINT FK_Ventas_Empleados FOREIGN KEY (IdEmpleado) REFERENCES Empleados(IdEmpleado)
);

CREATE TABLE Facturas (
    IdFactura INT IDENTITY(1,1) PRIMARY KEY,
    IdVenta INT NOT NULL,
    IdMesero INT NOT NULL,
    IdBarra INT NOT NULL,
    IdCaja INT NOT NULL,
    IdMetodoPago INT NOT NULL,
    FechaFacturacion DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Facturas_Ventas FOREIGN KEY (IdVenta) REFERENCES Ventas(IdVenta),
    CONSTRAINT FK_Facturas_Mesero FOREIGN KEY (IdMesero) REFERENCES Empleados(IdEmpleado),
    CONSTRAINT FK_Facturas_Barra FOREIGN KEY (IdBarra) REFERENCES Empleados(IdEmpleado),
    CONSTRAINT FK_Facturas_Cajas FOREIGN KEY (IdCaja) REFERENCES Cajas(IdCaja),
    CONSTRAINT FK_Facturas_MetodosPagos FOREIGN KEY (IdMetodoPago) REFERENCES MetodosPagos(IdMetodoPago)
);

-- Asignación de la FK circular de Ventas hacia Facturas
ALTER TABLE Ventas
ADD CONSTRAINT FK_Ventas_Facturas FOREIGN KEY (IdFactura) REFERENCES Facturas(IdFactura);



CREATE TABLE DetalleVentas (
    IdDetalleVenta INT IDENTITY(1,1) PRIMARY KEY,
    IdVenta INT NOT NULL,
    IdProducto INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(12, 2) NOT NULL,
    CONSTRAINT FK_DetalleVentas_Ventas FOREIGN KEY (IdVenta) REFERENCES Ventas(IdVenta) ON DELETE CASCADE,
    CONSTRAINT FK_DetalleVentas_Productos FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto)
);

CREATE TABLE DetalleCompras (
    IdDetalleCompra INT IDENTITY(1,1) PRIMARY KEY,
    IdCompra INT NOT NULL,
    IdProducto INT NOT NULL,
    Cantidad INT NOT NULL,
    Total DECIMAL(12, 2) NOT NULL,
    CONSTRAINT FK_DetalleCompras_Compras FOREIGN KEY (IdCompra) REFERENCES Compras(IdCompra) ON DELETE CASCADE,
    CONSTRAINT FK_DetalleCompras_Productos FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto)
);

CREATE TABLE DetalleReservas (
    IdDetalleReserva INT IDENTITY(1,1) PRIMARY KEY,
    IdReserva INT NOT NULL,
    IdMesa INT NOT NULL,
    CONSTRAINT FK_DetalleReservas_Reservas FOREIGN KEY (IdReserva) REFERENCES Reservas(IdReserva) ON DELETE CASCADE,
    CONSTRAINT FK_DetalleReservas_Mesas FOREIGN KEY (IdMesa) REFERENCES Mesas(IdMesa)
);

CREATE TABLE DetalleReparaciones (
    IdDetalleReparacion INT IDENTITY(1,1) PRIMARY KEY,
    IdReparacion INT NOT NULL,
    IdElementoInterno INT NOT NULL,
    DescripcionReparacion NVARCHAR(255) NULL,
    CostoReparacion DECIMAL(12, 2) NOT NULL DEFAULT 0.00,
    CONSTRAINT FK_DetalleReparaciones_Reparaciones FOREIGN KEY (IdReparacion) REFERENCES Reparaciones(IdReparacion) ON DELETE CASCADE,
    CONSTRAINT FK_DetalleReparaciones_ElementosInternos FOREIGN KEY (IdElementoInterno) REFERENCES ElementosInternos(IdElementoInterno)
);