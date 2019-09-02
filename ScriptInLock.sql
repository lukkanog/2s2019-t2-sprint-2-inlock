--Banco de dados desenvolvida pela dupla Victor I. / Lucas N. para o software da empresa InLock --
--DDL--

Use M_InLock;

Create database M_InLock;

Create table Paises(
	PaisId INT IDENTITY NOT NULL PRIMARY KEY,
	NomePais Varchar (255) NOT NULL UNIQUE
);
Alter table Estudios
Add UsuarioId INT FOREIGN KEY REFERENCES Usuarios(UsuarioId);

Create table Estudios(
	EstudioId INT IDENTITY NOT NULL Primary key,
	NomeEstudio Varchar (255) NOT NULL Unique,
	Origem INT Foreign key references Paises(PaisId),
	DataCriacao Datetime not null
);
Create table TiposUsuarios(
	TipoId INT Primary key not null identity,
	DescricaoTipo Varchar (255) not null unique
);

Create table Usuarios(
	UsuarioId INT PRIMARY KEY NOT NULL IDENTITY,
	TipoUsuario INT FOREIGN KEY REFERENCES TiposUsuarios(TipoId),
	NomeUsuario varchar (255) not null unique,
	Email varchar(255) not null unique,
	Senha varchar(255) not null
);
Create table Jogos(
	JogoId INT PRIMARY KEY NOT NULL IDENTITY,
	NomeJogo Varchar (255) not null unique,
	Descricao text not null,
	DataLancamento datetime not null,
	Valor INT NOT NULL,
	EstudioId INT FOREIGN KEY REFERENCES Estudios(EstudioId),
	UsuarioId INT FOREIGN KEY REFERENCES Usuarios(UsuarioId)
);
--DDL--

--DML--

Insert TiposUsuarios(DescricaoTipo)
	VALUES('ADMINISTRADOR'),('CLIENTE');

Insert Usuarios(TipoUsuario, NomeUsuario,Email,Senha)
	VALUES(1,'admin','admin@admin.com','admin'),(2,'cliente','cliente@cliente.com','cliente');

Insert Paises(NomePais)
	Values('Japão'),('EUA');

Insert Estudios(NomeEstudio,Origem,DataCriacao,UsuarioId)
	Values ('Blizzard',2,'1991-02-08T00:00:00',1),('Rockstar Studios',2,'1998-12-01T00:00:00',1),('Square Enix',1,'2003-04-01T00:00:00',1);

Insert Jogos(NomeJogo,DataLancamento,Descricao,Valor,EstudioId,UsuarioId)
	Values ('Diablo 3','2012-05-15T00:00:00','É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã', 99.00,1,1);

Insert Jogos(NomeJogo,DataLancamento,Descricao,Valor,EstudioId,UsuarioId)
	Values ('Red Dead Redemption 2','2018-10-26T00:00:00','Jogo eletrônico de ação-aventura western', 120,2,1);
--DML--

--DQL--

Select * from Usuarios;

Select Usuarios.UsuarioId,Usuarios.NomeUsuario,Usuarios.Email,Usuarios.Senha,TiposUsuarios.DescricaoTipo
from TiposUsuarios
join Usuarios
On Usuarios.TipoUsuario = TiposUsuarios.TipoId;

Select * from TiposUsuarios;
Select * from Estudios;

Select Estudios.EstudioId,Estudios.NomeEstudio,Estudios.DataCriacao,Paises.NomePais,Usuarios.Email
from Estudios
Join Paises
On Paises.PaisId = Estudios.Origem
join Usuarios
on Estudios.UsuarioId = Usuarios.UsuarioId;

select * from Paises;

select * from Jogos;

select Jogos.JogoId,Jogos.NomeJogo,Jogos.Descricao,Jogos.DataLancamento,Jogos.Valor as 'Valor em reais',Estudios.NomeEstudio,Usuarios.NomeUsuario
from Jogos
Join Estudios
On Jogos.EstudioId = Estudios.EstudioId
join Usuarios
On Usuarios.UsuarioId = Jogos.UsuarioId;

--DQL--