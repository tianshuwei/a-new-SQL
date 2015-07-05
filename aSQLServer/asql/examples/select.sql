select * from t1
	where id=1
	in parser_test;

select t1.id, t2.name from t1, t7
	inner join t2 on t1.id=t2.id
	left outer join t3 on t1.id=t3.id
	right join t4 on t1.id=t4.id, t5
	join t6 on t1.id=t6.id
	where t1.id=1
	in parser_test;

select * from t4 in parser_test;