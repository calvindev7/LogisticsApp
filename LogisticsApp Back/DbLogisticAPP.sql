-- Crea la base de datos
CREATE DATABASE LogisticsApp;

-- Utiliza la base de datos
USE LogisticsApp;

-- Crea la tabla de Clientes
CREATE TABLE Clientes (
    Id INT PRIMARY KEY IDENTITY,
    Nombre VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL
);

-- Crea la tabla de Productos
CREATE TABLE Productos (
    Id INT PRIMARY KEY IDENTITY,
    Nombre VARCHAR(100) NOT NULL,
    Tipo VARCHAR(50) NOT NULL,
	PrecioUnidad DECIMAL(10, 2) NOT NULL
);

-- Crea la tabla de Bodegas
CREATE TABLE Bodegas (
    Id INT PRIMARY KEY IDENTITY,
    Nombre VARCHAR(100) NOT NULL,
    Ubicacion VARCHAR(100) NOT NULL
);

-- Crea la tabla de Bodegas
CREATE TABLE Puertos (
    Id INT PRIMARY KEY IDENTITY,
    Nombre VARCHAR(100) NOT NULL,
    Ubicacion VARCHAR(100) NOT NULL
);

-- Crea la tabla de Envíos Terrestres
CREATE TABLE EnviosTerrestres (
    Id INT PRIMARY KEY IDENTITY,
    TipoProducto VARCHAR(50) NOT NULL,
    CantidadProducto INT NOT NULL,
    FechaRegistro DATE NOT NULL,
    FechaEntrega DATE NOT NULL,
    BodegaId INT NOT NULL,
    PrecioEnvio DECIMAL(10, 2) NOT NULL,
    PlacaVehiculo CHAR(6) NOT NULL,
    NumeroGuia VARCHAR(10) NOT NULL,
    ClienteId INT NOT NULL,
    ProductoId INT NOT NULL,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id),
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id),
	FOREIGN KEY (BodegaId) REFERENCES Bodegas(Id)
);

-- Crea la tabla de Envíos Marítimos
CREATE TABLE EnviosMaritimos (
    Id INT PRIMARY KEY IDENTITY,
    TipoProducto VARCHAR(50) NOT NULL,
    CantidadProducto INT NOT NULL,
    FechaRegistro DATE NOT NULL,
    FechaEntrega DATE NOT NULL,
    PuertoId INT NOT NULL,
    PrecioEnvio DECIMAL(10, 2) NOT NULL,
    NumeroFlota CHAR(8) NOT NULL,
    NumeroGuia VARCHAR(10) NOT NULL,
    ClienteId INT NOT NULL,
    ProductoId INT NOT NULL,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id),
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id),
	FOREIGN KEY (PuertoId) REFERENCES Puertos(Id)
);

-- Insertar tipos de productos
INSERT INTO Productos (Nombre, Tipo, PrecioUnidad) VALUES
    ('Camiseta', 'Terrestre', 15.00),
    ('Zapatos', 'Terrestre', 50.00),
    ('Bolso', 'Terrestre', 30.00),
    ('Teléfono móvil', 'Terrestre', 70.00),
    ('Portátil', 'Terrestre', 80.00),
    ('Libro', 'Marítimo', 10.00),
    ('Película', 'Marítimo', 10.00),
    ('Joyas', 'Marítimo', 68.00),
    ('Cámara', 'Marítimo', 45.00),
    ('Gafas de sol', 'Marítimo', 25.00);


-- Insertar clientes
INSERT INTO Clientes (Nombre, Email) VALUES
    ('Juan Pérez', 'juan.perez@example.com'),
    ('María García', 'maria.garcia@example.com'),
    ('Carlos López', 'carlos.lopez@example.com'),
    ('Ana Martínez', 'ana.martinez@example.com'),
    ('Luis Rodríguez', 'luis.rodriguez@example.com');

-- Inserta registros en la tabla Bodegas
INSERT INTO Bodegas (Nombre, Ubicacion) VALUES
    ('Bodega A', 'Calle 123, Ciudad X'),
    ('Bodega B', 'Avenida Principal, Ciudad Y'),
    ('Bodega C', 'Plaza Central, Ciudad Z'),
    ('Bodega D', 'Calle Principal, Ciudad W'),
    ('Bodega E', 'Avenida 456, Ciudad V'),
    ('Bodega F', 'Paseo del Sol, Ciudad U'),
    ('Bodega G', 'Callejón 789, Ciudad T'),
    ('Bodega H', 'Avenida Central, Ciudad S'),
    ('Bodega I', 'Plaza Mayor, Ciudad R'),
    ('Bodega J', 'Calle de la Luna, Ciudad Q');

	-- Inserta registros en la tabla Puertos
INSERT INTO Puertos (Nombre, Ubicacion) VALUES
    ('Puerto A', 'Calle 123, Ciudad X'),
    ('Puerto B', 'Avenida Principal, Ciudad Y'),
    ('Puerto C', 'Plaza Central, Ciudad Z'),
    ('Puerto D', 'Calle Principal, Ciudad W'),
    ('Puerto E', 'Avenida 456, Ciudad V'),
    ('Puerto F', 'Paseo del Sol, Ciudad U'),
    ('Puerto G', 'Callejón 789, Ciudad T'),
    ('Puerto H', 'Avenida Central, Ciudad S'),
    ('Puerto I', 'Plaza Mayor, Ciudad R'),
    ('Puerto J', 'Calle de la Luna, Ciudad Q');

-- Insertar envíos terrestres
INSERT INTO EnviosTerrestres (TipoProducto, CantidadProducto, FechaRegistro, FechaEntrega, BodegaId, PrecioEnvio, PlacaVehiculo, NumeroGuia, ClienteId, ProductoId) VALUES
    ('Camiseta', 5, '2023-05-27', '2023-06-03', 1, 10.00, 'ABC123', '1234567890', 1, 1),
    ('Zapatos', 2, '2023-05-28', '2023-06-05', 2, 15.50, 'DEF456', '0987654321', 2, 2),
    ('Bolso', 1, '2023-05-29', '2023-06-06', 3, 8.75, 'GHI789', '2468135790', 3, 3),
    ('Teléfono móvil', 1, '2023-05-30', '2023-06-07', 4, 20.00, 'JKL012', '1357924680', 4, 4),
    ('Portátil', 1, '2023-06-01', '2023-06-09', 5, 25.00, 'MNO345', '8024679135', 5, 5);

-- Insertar envíos marítimos
INSERT INTO EnviosMaritimos (TipoProducto, CantidadProducto, FechaRegistro, FechaEntrega, PuertoId, PrecioEnvio, NumeroFlota, NumeroGuia, ClienteId, ProductoId) VALUES
    ('Libro', 3, '2023-05-27', '2023-06-06', 1, 12.00, 'ABC1234A', '1234567890', 1, 6),
    ('Película', 2, '2023-05-28', '2023-06-07', 2, 10.50, 'DEF4567B', '0987654321', 2, 7),
    ('Joyas', 1, '2023-05-29', '2023-06-08', 3, 15.75, 'GHI7890C', '2468135790', 3, 8),
    ('Cámara', 1, '2023-05-30', '2023-06-09', 4, 18.00, 'JKL0123D', '1357924680', 4, 9),
    ('Gafas de sol', 1, '2023-06-01', '2023-06-10', 5, 22.50, 'MNO3456E', '8024679135', 5, 10);




