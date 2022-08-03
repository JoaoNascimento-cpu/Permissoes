USE Permissoes;

INSERT INTO TiposUsuario(tituloTiposUsuario)
VALUES	('ADM'),
		('Root'),
		('Comum');
GO

INSERT INTO Usuario(idTiposUsuario, email, senha)
VALUES	(1, 'jose@gmail.com', 'jose1980'),
		(2, 'root@gmail.com', 'root9669'),
		(3, 'guilherme@gmail.com','guilhermeM3030');
GO