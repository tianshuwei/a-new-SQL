delete from t1
	where id=1 or id=3 and id!=3 or id!=1 or not 1=1
	in parser_test;

delete from t1
	where id is null or id not null
	in parser_test;

delete from t1
	where id<100
	in parser_test;

delete from t3
	where id like "1%" and id is not "1"
	in parser_test;

delete from t1
	where id between 10 and 100 
		and id not between 20 and 50
	in parser_test;

delete from t1
	where id in (1,3,5,7,9)
		and id not in (3,5)
	in parser_test;

delete from t1
	where NULL is NULL
	in parser_test;

delete from t1
	where @p not NULL
	in parser_test;

delete from t1
	where cast (id as varchar(20)) is "1"
	in parser_test;