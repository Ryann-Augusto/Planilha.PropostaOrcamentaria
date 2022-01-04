
CREATE DATABASE planilhas_db CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

USE planilhas_db;

CREATE TABLE tbl_Categoria(
		pl_codigo int primary key not null auto_increment,
        pl_categoria varchar(30)
)charset = utf8mb4;

CREATE TABLE tbl_Janeiro(
	pl_codigo INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    pl_ano INT(4) NOT NULL,
    pl_proposta DECIMAL(10,2) NULL,
    pl_realizado DECIMAL(10,2) NULL,
    cod_categoria INT NOT NULL,
    FOREIGN KEY (cod_categoria) REFERENCES tbl_Categoria(pl_codigo)
)charset = utf8mb4; 

CREATE TABLE tbl_Fevereiro(
	pl_codigo int primary key not null auto_increment,
    pl_ano int(4) not null,
    pl_proposta decimal(10,2) null,
    pl_realizado decimal(10,2) null,
    cod_categoria int not null,
    foreign key (cod_categoria) references tbl_Categoria(pl_codigo)
)charset = utf8mb4;

CREATE TABLE tbl_Marco(
	pl_codigo int primary key not null auto_increment,
    pl_ano int(4) not null,
    pl_proposta decimal(10,2) null,
    pl_realizado decimal(10,2) null,
    cod_categoria int not null,
    foreign key (cod_categoria) references tbl_Categoria(pl_codigo)
)charset = utf8mb4;

CREATE TABLE tbl_Abril(
	pl_codigo int primary key not null auto_increment,
    pl_ano int(4) not null,
    pl_proposta decimal(10,2) null,
    pl_realizado decimal(10,2) null,
    cod_categoria int not null,
    foreign key (cod_categoria) references tbl_Categoria(pl_codigo)
)charset = utf8mb4;

CREATE TABLE tbl_Maio(
	pl_codigo int primary key not null auto_increment,
    pl_ano int(4) not null,
    pl_proposta decimal(10,2) null,
    pl_realizado decimal(10,2) null,
    cod_categoria int not null,
    foreign key (cod_categoria) references tbl_Categoria(pl_codigo)
)charset = utf8mb4;

CREATE TABLE tbl_Junho(
	pl_codigo int primary key not null auto_increment,
    pl_ano int(4) not null,
    pl_proposta decimal(10,2) null,
    pl_realizado decimal(10,2) null,
    cod_categoria int not null,
    foreign key (cod_categoria) references tbl_Categoria(pl_codigo)
)charset = utf8mb4;

CREATE TABLE tbl_Julho(
	pl_codigo int primary key not null auto_increment,
    pl_ano int(4) not null,
    pl_proposta decimal(10,2) null,
    pl_realizado decimal(10,2) null,
    cod_categoria int not null,
    foreign key (cod_categoria) references tbl_Categoria(pl_codigo)
)charset = utf8mb4;

CREATE TABLE tbl_Agosto(
	pl_codigo int primary key not null auto_increment,
    pl_ano int(4) not null,
    pl_proposta decimal(10,2) null,
    pl_realizado decimal(10,2) null,
    cod_categoria int not null,
    foreign key (cod_categoria) references tbl_Categoria(pl_codigo)
)charset = utf8mb4;

CREATE TABLE tbl_Setembro(
	pl_codigo int primary key not null auto_increment,
    pl_ano int(4) not null,
    pl_proposta decimal(10,2) null,
    pl_realizado decimal(10,2) null,
    cod_categoria int not null,
    foreign key (cod_categoria) references tbl_Categoria(pl_codigo)
)charset = utf8mb4;

CREATE TABLE tbl_Outubro(
	pl_codigo int primary key not null auto_increment,
    pl_ano int(4) not null,
    pl_proposta decimal(10,2) null,
    pl_realizado decimal(10,2) null,
    cod_categoria int not null,
    foreign key (cod_categoria) references tbl_Categoria(pl_codigo)
)charset = utf8mb4;

CREATE TABLE tbl_Novembro(
	pl_codigo int primary key not null auto_increment,
    pl_ano int(4) not null,
    pl_proposta decimal(10,2) null,
    pl_realizado decimal(10,2) null,
    cod_categoria int not null,
    foreign key (cod_categoria) references tbl_Categoria(pl_codigo)
)charset = utf8mb4;

CREATE TABLE tbl_Dezembro(
	pl_codigo int primary key not null auto_increment,
    pl_ano int(4) not null,
    pl_proposta decimal(10,2) null,
    pl_realizado decimal(10,2) null,
    cod_categoria int not null,
    foreign key (cod_categoria) references tbl_Categoria(pl_codigo)
)charset = utf8mb4;

CREATE TABLE tbl_Resultado(
		pl_codigo int primary key not null auto_increment,
		pl_propResultado decimal(10,2) null,
		pl_realiResultado decimal(10,2) null,
        pl_sobreFaturamento decimal(10,2) null,
        pl_contrib_Despesas decimal(10,2) null,
        pl_ano int(4) null,
        cod_categoria int not null,
        foreign key (cod_categoria) references tbl_Categoria(pl_codigo)    
)charset = utf8mb4;

CREATE TABLE tbl_total(
		pl_codigo int primary key auto_increment,
        pl_totalProposta decimal(10,2) null,
        pl_totalRealizado decimal(10,2) null,
        pl_propostaTabResultado decimal(10,2) null,
        pl_realizadoTabResultado decimal(10,2) null,
        pl_ano int(4)not null
)charset = utf8mb4;

		CREATE TABLE 2tbl_totalMeses(
			pl_codigo int primary key auto_increment,
            pl_totalPropostaMes decimal(10,2) null,
            pl_totalRealizadoMes decimal(10,2) null,
            pl_tabelaMes varchar(30) null,
            pl_ano int(4) not null
        )charset = utf8mb4;
        
CREATE TABLE tbl_Usuario(
			pl_codigo int primary key auto_increment not null,
            pl_usuario varchar(50) not null,
            pl_senha varchar(10) not null,
            pl_nivel int not null
)charset = utf8mb4;



