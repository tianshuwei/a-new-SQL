create table t1(id int) into mydb;

create table t1(
	id int primary key not null
) into mydb;

create table t1(
	id char(10) primary key not null
) into mydb;

create table t1(
	id int primary key not null,
	name varchar(20) not null,
	address varchar(80)
) into mydb;

create table t1(
	id int primary key not null,
	name varchar(20) not null,
	address varchar(80) not null valid
) into mydb;

create table t1(
	id int primary key not null,
	name varchar(20) not null,
	address varchar(80) not valid
) into mydb;
