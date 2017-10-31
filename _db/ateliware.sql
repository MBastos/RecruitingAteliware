-- Scripts for create database
CREATE DATABASE `ateliware`;

-- Table for insert top 5 repositories
CREATE TABLE `ateliware`.`repositorio`(
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_repositorio` int(11) NOT NULL,
  `ordem` varchar(45) DEFAULT NULL,
  `linguagem` varchar(10) NOT NULL,
  `nome` varchar(45) NOT NULL,
  `descricao` text NOT NULL,
  `proprietario` varchar(100) NOT NULL,
  `data_criacao` timestamp NOT NULL,
  `data_atualizacao` timestamp NOT NULL,
  `data_cadastro` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4;


