CREATE TABLE Banco
(
	Cuenta NUMERIC(12) PRIMARY KEY,
	Saldo DECIMAL(10,2) NOT NULL
);

CREATE TABLE Empresa
(
	Id INTEGER IDENTITY(1,1) PRIMARY KEY,
	RazonSocial VARCHAR(100) NOT NULL,
	Direccion VARCHAR(100) NOT NULL,
	RFC VARCHAR(20) NOT NULL,
	Telefono VARCHAR(20) NOT NULL,
	Correo VARCHAR(40) NOT NULL,
    Cuenta numeric(12) REFERENCES Banco(Cuenta)
);

create table Categoria
(
	Id integer IDENTITY(1,1) primary key,
	Descripcion varchar(80) not null
);

CREATE TABLE Productos
(
	Id INTEGER IDENTITY(1,1) PRIMARY KEY,
	Descripcion VARCHAR(40) NOT NULL,
	Detalle VARCHAR(120) NOT NULL,
	Precio DECIMAL(10,2) NOT NULL,
	Existencias INTEGER NOT NULL,
	Categoria integer REFERENCES Categoria(Id)
);

CREATE TABLE Carrito
(
	id INTEGER IDENTITY(1,1) PRIMARY KEY,
	IdProducto INTEGER REFERENCES dbo.Productos(Id),
	Precio DECIMAL(10,2) NOT NULL,
	Ticket VARCHAR(20) NOT NULL,
	Cliente INTEGER REFERENCES dbo.DatosClientes(id)
);

CREATE TABLE Venta
(
	Ticket varchar(20) PRIMARY KEY,
	Total DECIMAL(10,2) NOT NULL,
	Cliente INTEGER REFERENCES dbo.DatosClientes(id)
);

CREATE TABLE Usuario
(
	Id INTEGER IDENTITY(1,1) PRIMARY KEY,
	Usuario VARCHAR(40) NOT NULL,
	Contrasena VARCHAR(512) NOT NULL,
	Pregunta VARCHAR(120) NOT NULL,
	Respuesta VARCHAR(120) NOT NULL,
	Correo VARCHAR(40) NOT NULL
);

CREATE TABLE DatosClientes
(
	Id INTEGER IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL,
	Apellidos VARCHAR(50) NOT NULL,
	Correo VARCHAR(50) NOT NULL,
	Telefono VARCHAR(20) NOT NULL,
	Tarjeta NUMERIC(16) NOT null,
	Mes INT(2) NOT null,
	Ano int(4) NOT null,
	CVV INT(3) NOT null,
	Cuenta NUMERIC(12) REFERENCES dbo.BancoCliente(Cuenta),
	Usuario INTEGER REFERENCES dbo.Usuario(Id)
);