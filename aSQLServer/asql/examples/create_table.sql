create table t1(id int) into parser_test;

create table t2(
	id int primary key not null
) into parser_test;

create table t3(
	id varchar(10) primary key not null
) into parser_test;

create table t4(
	id int primary key not null,
	name varchar(20) not null,
	address varchar(80)
) into parser_test;

create table t5(
	id int primary key not null,
	name varchar(20) not null,
	address varchar(80) not null valid
) into parser_test;

create table t6(
	id int primary key not null,
	name varchar(20) not null,
	address varchar(80) not valid
) into parser_test;
