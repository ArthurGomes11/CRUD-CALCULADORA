create database itens;
use itens;

CREATE TABLE intem(
	iditens INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(50),
    preco DOUBLE,
    quantidade INT,
    pagamento VARCHAR(25),
    imposto DOUBLE
) default charset utf8mb4;