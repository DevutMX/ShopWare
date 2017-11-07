CREATE TABLE Banco
(
	Tarjeta NUMERIC(16) PRIMARY KEY,
	Saldo DECIMAL(10,2) NOT NULL
);

CREATE TABLE TiposPago
(
	Tipo INTEGER IDENTITY(1,1) PRIMARY KEY,
	Descripcion varchar(40) not null,
	RequiereTarjeta bit not null
);

CREATE TABLE Empresa
(
	Id INTEGER IDENTITY(1,1) PRIMARY KEY,
	RazonSocial VARCHAR(100) NOT NULL,
	Direccion VARCHAR(100) NOT NULL,
	RFC VARCHAR(20) NOT NULL,
	Telefono VARCHAR(20) NOT NULL,
	Correo VARCHAR(40) NOT NULL,
    Tarjeta numeric(16) REFERENCES Banco(Tarjeta)
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
	Detalle VARCHAR(MAX) NOT NULL,
	Precio DECIMAL(10,2) NOT NULL,
	Existencias INTEGER NOT NULL,
	Categoria integer REFERENCES Categoria(Id)
);

create table usuarios
(
	Id integer identity(1,1) primary key,
	Usuario varchar(40) not null,
	Contrasena varchar(512) not null,
	Correo varchar(40) not null,
	Privilegio varchar(40) not null
);

CREATE TABLE DatosClientes
(
	Id INTEGER IDENTITY(1,1) PRIMARY KEY,
	Usuario integer references Usuarios(Id),
	Nombre VARCHAR(50) NOT NULL,
	Apellidos VARCHAR(50) NOT NULL,
	Telefono VARCHAR(20) NOT NULL,
	Domicilio varchar(256) not null,
	Foto varbinary(max),
	Tarjeta NUMERIC(16) REFERENCES Banco(Tarjeta),
	Mes numeric(2) NOT null,
	Ano numeric(4) NOT null,
	CVV numeric(3) NOT null
);

CREATE TABLE Carrito
(
	id INTEGER IDENTITY(1,1) PRIMARY KEY,
	IdProducto INTEGER REFERENCES Productos(Id),
	Precio DECIMAL(10,2) NOT NULL,
	Pagado bit not null,
	Ticket VARCHAR(20) NOT NULL,
	Usuario INTEGER REFERENCES Usuarios(id)
);

CREATE TABLE Venta
(
	Ticket varchar(20) PRIMARY KEY,
	Total DECIMAL(10,2) NOT NULL,
	TipoPago integer references TiposPago(Tipo),
	Cliente INTEGER REFERENCES DatosClientes(id)
);

insert into categoria(Descripcion) values
('Juegos'),
('Software');

insert into Banco values
(1, 0),
(4152312377392144, 0);


insert into Empresa (RazonSocial, Direccion, RFC, Telefono, Correo, Tarjeta) values
('WebShop', 'Orquideas 14 PPG, Iguala. Gro.', 'WBSP171022I93', '7331047641', 'support@devutmx.com', 4152312377392144);

insert into Productos(Descripcion, Detalle, Precio, Existencias, Categoria) values
('DOOM', 'DOOM, desarrollado por id Software, estudio pionero en el género de los shooters en primera persona y creador de las partidas multijugador en formato Deathmatch, regresa una vez más como un moderno shooter repleto de diversión y desafíos. Despiadados demonios, armas de destrucción inimaginables y un movimiento ágil y fluido constituyen la base de un intenso combate en primera persona, tanto si estás cargándote a las hordas demoníacas del infierno en la campaña para un jugador como si compites contra amigos en los diversos modos multijugador. Amplía tu experiencia de juego con DOOM SnapMap, el editor de juego que permite crear, jugar y compartir contenidos con el resto del mundo.', 699, 100, 1),
('Star Wars Battlefront II', 'La beta multijugador de Star Wars Battlefront II ya ha terminado. Los jugadores han luchado en distintos escenarios de Asalto galáctico, se han enfrentado a oleadas de enemigos controlados por la IA en Arcade, se han unido a escuadrones de amigos en Asalto de cazas estelares y han subido al máximo sus habilidades de soldado en las misiones de Ataque ocho contra ocho.', 1399, 50, 1),
('Battlefield 1', 'Únete a la comunidad de Battlefield y descubre la guerra total. Descubre las historias no contadas de la Primera Guerra Mundial con la intensidad incomparable que incluye el Premium Pass y la experiencia siempre en aumento de Battlefield. Battlefield 1 Revolution te permite participar en la Gran Guerra a través de enormes batallas multijugador por equipos. Con roles de combate únicos por tierra, mar y aire, ninguna batalla es igual. O descubre un mundo en guerra a través de la campaña para un solo jugador con las Historias de guerra.', 800, 85, 1),
('Yooka & Laylee', '¡Yooka-Laylee es un nuevo juego de plataformas de mundo abierto de los veteranos del género Playtonic! Explora mundos vastos y preciosos, conoce (y vence) a un reparto inolvidable de personajes y acumula un montón de brillantes coleccionables mientras la pareja de Yooka (el verde) y Laylee (la murciélago ocurrente de nariz grande) se embarcan en una aventura épica para acabar con el malvado empresario Capital B y su retorcidos planes para absorber todos los libros del mundo... ¡Y convertirlos en beneficio puro!', 459, 135, 1),
('Wolfenstein II The new colossus', 'Wolfenstein® II, una emocionante aventura hecha realidad gracias al motor id Tech® 6, líder en el sector, enviará a los jugadores a unos Estados Unidos que se encuentran bajo el control nazi, en una misión para reclutar a los líderes más audaces de la resistencia que queden con vida. Combate a los nazis en lugares emblemáticos tales como la pequeña ciudad de Roswell, Nuevo México, las inundadas calles de Nueva Orleans y un Manhattan posnuclear. Equípate con un arsenal de armas brutales y desata nuevas habilidades para abrirte paso a través de legiones de avanzados soldados, cíborgs y über-soldados en este shooter en primera persona definitivo.', 1099, 20, 1);

insert into Productos(Descripcion, Detalle, Precio, Existencias, Categoria) values
('Microsoft Windows 10', 'Windows 10 es el último sistema operativo desarrollado por Microsoft como parte de la familia de sistemas operativos Windows NT.​ Fue dado a conocer oficialmente en septiembre de 2014, seguido por una breve presentación de demostración en la conferencia Build 2014. Entró en fase beta de prueba en octubre de 2014 y fue lanzado al público en general el 29 de julio de 2015.​ Para animar su adopción, Microsoft anunció su disponibilidad gratuita por un año desde su fecha de lanzamiento, para los usuarios que cuenten con copias genuinas de Windows 7 Service Pack 1 o Windows 8.1 Update. En junio de 2015, se habilitó una herramienta que permitía reservar esta actualización, dicha herramienta notificaba a cada usuario el momento en el que estaría lista la descarga de la actualización para su dispositivo para así instalar la compilación 10240, la primera versión estable liberada. Los participantes del programa Windows Insider pueden recibir una licencia de Windows 10, pero con ciertas condiciones, entre ellas que su sistema operativo instalado (7, 8 u 8.1) fuese legítimo.', 2919, 42, 2),
('Microsoft Visual Studio 2017 Enterprise', 'Microsoft Visual Studio es un entorno de desarrollo integrado (IDE, por sus siglas en inglés) para sistemas operativos Windows. Soporta múltiples lenguajes de programación, tales como C++, C#, Visual Basic .NET, F#, Java, Python, Ruby y PHP, al igual que entornos de desarrollo web, como ASP.NET MVC, Django, etc., a lo cual hay que sumarle las nuevas capacidades online bajo Windows Azure en forma del editor Monaco.', 127000, 8, 2),
('Microsoft Office 2016 Professional', 'Microsoft Office 2016 (nombre clave Office 16) es una versión de la suite de oficina Microsoft Office, sucesora de Office 2013 y de Office para Mac 2011. Fue lanzado en MacOS el 9 de julio de 2015 y en Microsoft Windows el 22 de septiembre de 2015 para suscriptores de Office 365.​ El soporte principal finaliza el 13 de octubre de 2020 y el soporte extendido el 14 de octubre de 2025, al mismo tiempo que Windows 10. La versión con licencia perpetua en MacOS y Windows se publicó el 22 de septiembre de 2015.​', 3500, 45, 2),
('Microsoft SQL Server 2016', 'Microsoft SQL Server es un sistema de manejo de bases de datos del modelo relacional, desarrollado por la empresa Microsoft. El lenguaje de desarrollo utilizado (por línea de comandos o mediante la interfaz gráfica de Management Studio) es Transact-SQL (TSQL), una implementación del estándar ANSI del lenguaje SQL, utilizado para manipular y recuperar datos (DML), crear tablas y definir relaciones entre ellas (DDL).', 67000, 15, 2),
('Adobe Creative Cloud 1 año', 'Adobe Creative Cloud, es un servicio de Adobe Systems que da a los usuarios acceso a los softwares de diseño gráfico, edición de video, diseño web y servicios en la nube. Adobe CC, trabaja a partir de un modelo de software como servicio, donde los consumidores no poseen el software, pero lo adquieren por una suscripción. Cuando la suscripción termina y no se renueva, el usuario pierde el acceso a las aplicaciones así como al trabajo guardado en formatos propietarios que no puede ser usado en aplicaciones de la competencia.', 32000, 18, 2);

insert into DatosClientes(Usuario, Contrasena, Correo, Nombre, Apellidos, Telefono, Foto, Tarjeta, Mes, Ano, CVV) values
('DevutMX', '1zD/Xbme5NbokeuDTJ2uBwyGZAuWkUGjIXsgRKEdDGR8n6h0HrdVX+/HrvQ09SroWXFPmIz7/FG52aAQBVYELw==', 'support@devutmx.com', 'Victor Manuel', 'Castrejon Martinez', '7331047641', null, 4152312377392144, 01, 2017, 111);