create table t1(id int, address varchar(80)) into test_table1;
list databases;
list tables in test_table1;
list columns from t1 in test_table1;
edit table t1(address varchar(120)) in test_table1;
rename table t1 t2 in test_table1;
list tables in test_table1;
drop table t2 in test_table1;

create table z1(id int, address varchar(80)) into test_table1;
create table z2(id int, name varchar(80)) into test_table1;
insert into z1 values
	(1, "5th street"),
	(2, "6th street")
in test_table1;
insert into z2 values
	(1, "ashley"),
	(2, "jake")
in test_table1;
select * from z1 in test_table1;
select * from z2 in test_table1;
update z2 set name="john" where id=2 in test_table1;
select z1.id, z2.name from z1, z1, z2 where 1=1 in test_table1;
select * from z1 left join z2 on z1.id=z2.id where 1=1 in test_table1;
delete from z2 where id=1 in test_table1;
select * from z2 in test_table1;
drop table z1;
drop table z2;
