USE Permissoes;

INSERT INTO TiposUsuario(tituloTiposUsuario)
VALUES	('ADM'),
		('Root'),
		('Comum');
GO

INSERT INTO [Status]
VALUES	('Ativo'),
		('Inativo');

INSERT INTO Usuario(idTiposUsuario, idStatus, email, senha, nome)
VALUES	(1,1, 'jose@gmail.com', 'jose1980', 'Jose Nascimento Garcia'),
		(2,1, 'root@gmail.com', 'root9669', 'Arnaldo de oliveira guimarães'),
		(3,2, 'guilherme@gmail.com','guilhermeM3030', 'Guilherme Santos de Andrade');
GO