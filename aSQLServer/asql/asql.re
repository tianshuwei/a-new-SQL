start = _ sql_stmt_list _ !.
sql_stmt_list = _sql_stmt sql_stmt_list
	| _sql_stmt
_sql_stmt = sql_stmt SEMICOLON
sql_stmt = create_table_stmt
	| alter_table_stmt
	| rename_table_stmt
	| drop_table_stmt
	| insert_stmt
	| update_stmt
	| delete_stmt
	| simple_select_stmt
	| select_stmt
	| list_stmt
	| dummy_stmt
create_table_stmt = K_CREATE __ K_TABLE __ table_name _ \( _ _column_defs _ \) _ K_INTO __ database_name mk_create_table
alter_table_stmt = K_ALTER __ K_TABLE __ table_name _ \( _ column_def _ \) _ K_IN __ database_name mk_alter_table
rename_table_stmt = K_RENAME __ K_TABLE __ table_name __ table_name __ K_IN __ database_name mk_rename_table
drop_table_stmt = K_DROP __ K_TABLE __ table_name __ K_IN __ database_name mk_drop_table
insert_stmt = K_INSERT __ K_INTO __ table_name __ K_VALUES _ _const_tuples _ K_IN __ database_name mk_insert
delete_stmt = K_DELETE __ K_FROM __ table_name __ K_WHERE __ _boolean_expr __ K_IN __ database_name mk_delete
update_stmt = K_UPDATE __ table_name __ K_SET __ _assignments __ K_WHERE __ _boolean_expr __ K_IN __ database_name mk_update
simple_select_stmt = K_SELECT __ (?:\*) __ K_FROM __ table_name __ K_IN __ database_name mk_simple_select
select_stmt = select_core __ K_IN __ database_name mk_select
list_stmt = K_LIST __ (?i)(?:columns) __ K_FROM __ table_name __ K_IN __ database_name mk_list_columns
	| K_LIST __ (?i)(?:tables) __ K_IN __ database_name mk_list_tables
	| K_LIST __ (?i)(?:databases) mk_list_databases
dummy_stmt = _
select_core = K_SELECT __ _columns __ K_FROM __ _join_expr __ K_WHERE __ _boolean_expr
_join_expr = join_expr hug
join_expr = table_name __join_expr
__join_expr = COMMA join_expr
	| _join_clause __join_expr
	|
_join_clause = join_clause mk_op_join
join_clause = __ (?i)((?:inner\s+)?join) __join_clause
	| __ (?i)(left\s+(?:outer\s+)?join) __join_clause
	| __ (?i)(right\s+(?:outer\s+)?join) __join_clause
	| __ (?i)(full\s+(?:outer\s+)?join) __join_clause
__join_clause = __ table_name __ (?i)(?:on) __ dynamic EQU dynamic
_column_defs = column_defs hug
column_defs = column_def COMMA column_defs
	| column_def
_assignments = assignments hug
assignments = assignment COMMA assignments
	| assignment
_columns = columns hug
columns = dynamic COMMA columns
	| dynamic
	| (\*)
assignment = column_name EQU value_expr hug
column_def = column_name __ type_name __ column_constraint __ valid_flag mk_columnIV
	| column_name __ type_name __ column_constraint mk_columnI
	| column_name __ type_name __ valid_flag mk_columnII
	| column_name __ type_name mk_columnIII
type_name = any_name _ \( _ NUMERIC_LITERAL _ \) hug
	| any_name mk_typeI
table_name = any_name
database_name = any_name
column_name = any_name
column_constraint = null_flag mk_constraintI
	| key_flag __ null_flag hug
key_flag = (?i)((?:primary\s+)?key) mk_key
null_flag = K_NOT __ K_NULL mk_null
valid_flag = (?i)(valid) mk_valid
	| K_NOT __ (?i)(valid) mk_valid
any_name = IDENTIFIER
	| `([^`]+)`
expr = value_expr
	| _boolean_expr
_const_tuples = const_tuples hug
const_tuples = const_tuple COMMA const_tuples
	| const_tuple
const_tuple = \( _ consts _ \) hug
consts = const_expr COMMA consts
	| const_expr
const_expr = _additive calc
	| string
value_expr = _additive
	| string
_boolean_expr = boolean_expr biops
boolean_expr = _conjuctional __ K_OR __ boolean_expr
	| _conjuctional
_conjuctional = conjuctional biops
conjuctional = _propositional __ K_AND __ conjuctional
	| _propositional
_propositional = K_NOT __ propositional mk_op_not
	| propositional
propositional = value_expr __  K_NOT _ K_NULL mk_op_null
	| value_expr __ K_IS _ K_NULL mk_op_null
	| value_expr __ K_NOT _ K_IN _ const_tuple mk_op_in
	| value_expr __ K_IN _ const_tuple mk_op_in
	| value_expr __ K_NOT _ K_IN _ \( _ select_stmt _ \)
	| value_expr __ K_IN _ \( _ select_stmt _ \)
	| comparitive
	| K_NOT _ K_EXISTS _ \( _ select_stmt _ \)
	| K_EXISTS _ \( _ select_stmt _ \)
comparitive = _additive _ (\=\=|\=|\!\=|<>) _ _additive biop
	| string __ (?i)(is\s*not|is|like) __ string biop
	| _additive _ (<=|<|>=|>) _ _additive biop
	| _additive __ K_BETWEEN __ _additive __ (?i)(?:and) __ _additive mk_op_between
	| _additive __ K_NOT __ K_BETWEEN __ _additive __ (?i)(?:and) __ _additive mk_op_between
_additive = additive biops
additive = _multiplicative _ (\+|-) _ additive
	| _multiplicative
_multiplicative = multiplicative biops
multiplicative = factor _ (\*|/|%) _ multiplicative
	| factor
factor = NUMERIC_LITERAL
	| dynamic
	| \( _ _additive _ \)
	| unary_operator _additive uop
string = STRING_LITERAL
	| dynamic
dynamic = K_NULL const_null
	| K_CAST _ \( _ expr __ K_AS __ type_name _ \) mk_typecast
	| table_name (\.) column_name join mk_ref
	| column_name mk_ref
	| BIND_PARAMETER const_null
unary_operator = (-)
