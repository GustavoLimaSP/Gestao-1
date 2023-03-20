DELETE FROM PermissaoGrupoUsuario
GO
DELETE FROM Permissao
GO

INSERT INTO Permissao(Id, Descricao)VALUES(1,'Visualizar usuário')
INSERT INTO Permissao(Id, Descricao)VALUES(2,'Cadastrar usuário')
INSERT INTO Permissao(Id, Descricao)VALUES(3,'Alterar usuário')
INSERT INTO Permissao(Id, Descricao)VALUES(4,'Excluir usuário')
INSERT INTO Permissao(Id, Descricao)VALUES(5,'Visualizar grupo de usuário')
INSERT INTO Permissao(Id, Descricao)VALUES(6,'Cadastrar grupo de usuário')
INSERT INTO Permissao(Id, Descricao)VALUES(7,'Alterar grupo de usuário')
INSERT INTO Permissao(Id, Descricao)VALUES(8,'Excluir grupo de usuário')
INSERT INTO Permissao(Id, Descricao)VALUES(9,'Adicionar permissão a um grupo de usuário')
INSERT INTO Permissao(Id, Descricao)VALUES(10,'Adicionar grupo de usuário a um usuário')
