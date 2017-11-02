-- Table for insert top 5 repositories
CREATE TABLE repositorio(
  id INT IDENTITY PRIMARY KEY NOT NULL,
  id_repositorio int NOT NULL,
  ordem varchar(45) DEFAULT NULL,
  linguagem varchar(10) NOT NULL,
  nome varchar(45) NOT NULL,
  descricao text NOT NULL,
  proprietario varchar(100) NOT NULL,
  data_criacao DATETIME NOT NULL,
  data_atualizacao DATETIME NOT NULL,
  data_cadastro DATETIME NULL DEFAULT GETDATE()
);