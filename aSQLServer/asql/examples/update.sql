update t4
	set address = "221B Baker Street"
	where name like "Sherlock %" or name like "% Watson"
	in parser_test;

update t4
	set
		name = "Sherlock Holmes",
		address = "221B Baker Street"
	where id = 1
	in parser_test;

update t8
	set z = z + 1
	where z > 20
	in parser_test;
