CREATE DATABASE Permissoes;

USE Permissoes;

CREATE TABLE TiposUsuario(
	idTiposUsuario INT PRIMARY KEY IDENTITY,
	tituloTiposUsuario VARCHAR(20) NOT NULL,
);
GO

CREATE TABLE [Status](
	idStatus INT PRIMARY KEY IDENTITY,
	tituloStatus VARCHAR(10)
);
GO

CREATE TABLE Usuario(
	idUsuario INT PRIMARY KEY IDENTITY,
	idTiposUsuario INT FOREIGN KEY REFERENCES TiposUsuario(idTiposUsuario),
	idstatus INT FOREIGN KEY REFERENCES	[Status](idStatus),
	email VARCHAR(100) NOT NULL,
	senha VARCHAR(20)  NOT NULL,
	nome VARCHAR(100)	NOT NULL
);
GO