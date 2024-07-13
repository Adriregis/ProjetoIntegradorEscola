CREATE DATABASE escolaNeonGenesis;
USE escolaNeonGenesis;

CREATE TABLE aluno (
    id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL,
    data_nascimento DATE 
);


CREATE TABLE professor (
    id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100)  
);


CREATE TABLE materia (
    id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL,
    id_aluno INT NOT NULL,
    id_professor INT NOT NULL,
    FOREIGN KEY (id_aluno) REFERENCES aluno(id),
    FOREIGN KEY (id_professor) REFERENCES professor(id)
);


CREATE TABLE avaliacao (
    id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    id_materia INT NOT NULL,
    nota INT NOT NULL,
    peso INT NOT NULL,
    FOREIGN KEY (id_materia) REFERENCES materia(id)
);

INSERT INTO aluno (nome, data_nascimento) VALUES ("ISABELLA PACHECO", '2005-03-15');
INSERT INTO aluno (nome, data_nascimento) VALUES ("MONIQUE OHANA", '2004-07-22');
INSERT INTO aluno (nome, data_nascimento) VALUES ("JOAO MIGUEL VAZ", '2006-01-10');
INSERT INTO aluno (nome, data_nascimento) VALUES ("ADRIANA PEREIRA", '2005-11-30');

INSERT INTO professor (nome, email) VALUES ("JOAO VITOR VENTURA", 'joao.ventura@example.com');
INSERT INTO professor (nome, email) VALUES ("FERNANDO LOPES", 'fernando.lopes@example.com');
INSERT INTO professor (nome, email) VALUES ("DENISE SILVA", 'denise.silva@example.com');

INSERT INTO materia (nome, id_aluno, id_professor) VALUES ("PORTUGUES", 1, 1);
INSERT INTO materia (nome, id_aluno, id_professor) VALUES ("MATEMATICA", 2, 2);
INSERT INTO materia (nome, id_aluno, id_professor) VALUES ("HISTORIA", 3, 3);

INSERT INTO avaliacao (id_materia, nota, peso) VALUES (1, 8, 2);
INSERT INTO avaliacao (id_materia, nota, peso) VALUES (2, 9, 2);
INSERT INTO avaliacao (id_materia, nota, peso) VALUES (3, 7, 2);