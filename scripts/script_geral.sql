-- -----------
-- Geração de Modelo físico
-- Sql ANSI 2003 - brModelo.
use pbd;


CREATE TABLE pessoa (
id INT AUTO_INCREMENT PRIMARY KEY,
cpf_cnpj VARCHAR(14) NOT NULL UNIQUE,
nome VARCHAR(50) NOT NULL,
fisico_juridico CHAR(1) NOT NULL,
tipo_pessoa CHAR(1),
ramo VARCHAR(50),
tipo_prestador_serv CHAR(1),
tipo_colaborador CHAR(1),
setor VARCHAR(50),
pro_labore DECIMAL(12,2),
data_contratacao Date,
agencia VARCHAR(10),
conta VARCHAR(15),
banco VARCHAR(30),
remuneracao DECIMAL(12,2),
UNIQUE INDEX pessoa_index(cpf_cnpj));



CREATE TABLE endereco (
id INT AUTO_INCREMENT PRIMARY KEY,
pessoa_id INT  NOT NULL,
uf CHAR(2) NOT NULL,
cidade VARCHAR(30) NOT NULL,
bairro VARCHAR(30) NOT NULL,
rua VARCHAR(50) NOT NULL,
numero VARCHAR(10) NOT NULL,
complemento VARCHAR(50),
descricao VARCHAR(50),
FOREIGN KEY(pessoa_id) REFERENCES pessoa (id),
UNIQUE INDEX endereco_index(pessoa_id, uf, cidade, bairro, rua, numero));

CREATE TABLE hierarquia (
pessoa_supervisor_id INT ,
pessoa_supervisionado_id INT ,
PRIMARY KEY(pessoa_supervisor_id,pessoa_supervisionado_id),
FOREIGN KEY(pessoa_supervisor_id) REFERENCES pessoa (id),
FOREIGN KEY(pessoa_supervisionado_id) REFERENCES pessoa (id)
);

CREATE TABLE solicitacao_orcamento (
id INT AUTO_INCREMENT PRIMARY KEY,
pessoa_id INT  NOT NULL,
endereco_id INT  NOT NULL,
data_hora DATETIME NOT NULL,
FOREIGN KEY(pessoa_id) REFERENCES pessoa (id),
FOREIGN KEY(endereco_id) REFERENCES endereco (id),
UNIQUE INDEX solicitacao_orcamento_index(pessoa_id, endereco_id, data_hora));

CREATE TABLE cotacao (
pessoa_id INT  NOT NULL,
tipo_material_id INT  NOT NULL,
marca VARCHAR(50),
data Date,
preco DECIMAL(12,2),
PRIMARY KEY(pessoa_id,tipo_material_id,marca,data),
FOREIGN KEY(pessoa_id) REFERENCES pessoa (id),
UNIQUE INDEX cotacao_index(pessoa_id, tipo_material_id, marca, data));

CREATE TABLE documento_orcamento (
orcamento_id INT ,
documento_id INT ,
PRIMARY KEY(orcamento_id,documento_id)
);

CREATE TABLE orcamento (
id INT  PRIMARY KEY,
solicitacao_orcamento_id INT  NOT NULL,
data_hora_emissao DATETIME NOT NULL,
valor_total DECIMAL(12,2) NOT NULL,
tempo_estimando VARCHAR(30) NOT NULL,
garantia CHAR(1) NOT NULL,
status CHAR(1) NOT NULL,
forma_pagamento VARCHAR(255) NOT NULL,
observacao VARCHAR(255),
FOREIGN KEY(solicitacao_orcamento_id) REFERENCES solicitacao_orcamento (id),
UNIQUE INDEX orcamento_index(solicitacao_orcamento_id, data_hora_emissao));

CREATE TABLE documento (
id INT AUTO_INCREMENT PRIMARY KEY,
endereco_id INT  NOT NULL,
data DATETIME NOT NULL,
descricao VARCHAR(50) NOT NULL,
tipo_documento CHAR(1),
detalhe VARCHAR(255),
imagem LONGBLOB,
FOREIGN KEY(endereco_id) REFERENCES endereco (id),
UNIQUE INDEX documento_index(endereco_id, data, descricao));

CREATE TABLE tipo_material (
id INT AUTO_INCREMENT PRIMARY KEY,
descricao VARCHAR(50) NOT NULL,
UNIQUE INDEX tipo_material_index(descricao));

CREATE TABLE servico_material (
tipo_material_id INT ,
servico_id INT ,
responsabilidade_cliente CHAR(1) NOT NULL,
PRIMARY KEY(tipo_material_id,servico_id),
FOREIGN KEY(tipo_material_id) REFERENCES tipo_material (id)
);

CREATE TABLE servico (
id INT AUTO_INCREMENT PRIMARY KEY,
orcamento_id INT  NOT NULL,
descricao VARCHAR(100) NOT NULL,
FOREIGN KEY(orcamento_id) REFERENCES orcamento (id),
UNIQUE INDEX servico_index(orcamento_id, descricao));

CREATE TABLE prestacao_servico (
pessoa_id INT ,
servico_id INT ,
custo DECIMAL(12,2) NOT NULL,
PRIMARY KEY(pessoa_id,servico_id),
FOREIGN KEY(pessoa_id) REFERENCES pessoa (id),
FOREIGN KEY(servico_id) REFERENCES servico (id)
);

CREATE TABLE Contato (
id INT AUTO_INCREMENT PRIMARY KEY,
pessoa_id INT  NOT NULL,
valor VARCHAR(50) NOT NULL,
tipo CHAR(1) NOT NULL,
FOREIGN KEY(pessoa_id) REFERENCES pessoa (id),
UNIQUE INDEX Contato_index(pessoa_id, valor));

ALTER TABLE cotacao ADD FOREIGN KEY(tipo_material_id) REFERENCES tipo_material (id);
ALTER TABLE documento_orcamento ADD FOREIGN KEY(orcamento_id) REFERENCES orcamento (id);
ALTER TABLE documento_orcamento ADD FOREIGN KEY(documento_id) REFERENCES documento (id);
ALTER TABLE servico_material ADD FOREIGN KEY(servico_id) REFERENCES servico (id);
