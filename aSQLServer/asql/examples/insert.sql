insert into t1 values (0) in parser_test;

insert into t1 values
	(1+2+3),
	(1+2*3),
	((1+2)*3),
	(NULL)
in parser_test;

insert into t4 values
	(1, "jason", NULL),
	(2, "bradley", NULL),
	(3, "duffy", "warwick avenue")
in parser_test;

