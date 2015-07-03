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
	| select_stmt
	| list_stmt
	| dummy_stmt
create_table_stmt = K_CREATE __ K_TABLE __ table_name _ \( _ _column_defs _ \) _ K_INTO __ database_name mk_create_table
alter_table_stmt = K_ALTER __ K_TABLE __ table_name _ \( _ column_def _ \) _ K_IN __ database_name mk_alter_table
rename_table_stmt = K_RENAME __ K_TABLE __ table_name __ table_name __ K_IN __ database_name mk_rename_table
drop_table_stmt = K_DROP __ K_TABLE __ table_name __ K_IN __ database_name mk_drop_table
insert_stmt = K_INSERT __ K_INTO __ table_name __ K_VALUES _ _insert_values _ K_IN __ database_name mk_insert
delete_stmt = K_DELETE __ K_FROM __ table_name __ K_WHERE __ boolean_expr __ K_IN __ database_name
update_stmt = K_UPDATE __ table_name __ K_SET __ assignments __ K_WHERE __ boolean_expr __ K_IN __ database_name
select_stmt = select_core __ K_IN __ database_name
list_stmt = K_LIST __ (?i)(?:columns) __ K_FROM __ table_name __ K_IN __ database_name mk_list_columns
	| K_LIST __ (?i)(?:tables) __ K_IN __ database_name mk_list_tables
	| K_LIST __ (?i)(?:databases) mk_list_databases
dummy_stmt = \s*
select_core = K_SELECT __ columns __ K_FROM __ table_name __ K_WHERE __ boolean_expr
_column_defs = column_defs hug
column_defs = column_def COMMA column_defs
	| column_def
consts = const_expr COMMA consts
	| const_expr
assignments = assignment COMMA assignments
	| assignment
columns = column_name COMMA columns
	| column_name
	| (\*)
assignment = column_name EQUAL value_expr
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
key_flag = (?i)(?:primary) __ (?i)(key) mk_key
null_flag = K_NOT __ K_NULL mk_null
valid_flag = (?i)(valid) mk_valid
	| K_NOT __ (?i)(valid) mk_valid
any_name = IDENTIFIER
	| `([^`]+)`
expr = value_expr
	| boolean_expr
_insert_values = insert_values hug
insert_values = insert_value COMMA insert_values
	| insert_value
insert_value = \( _ consts _ \) hug
const_expr = string
	| _additive calc
value_expr = string
	| _additive
boolean_expr = conjuctional __ K_OR __ conjuctional
	| conjuctional
conjuctional = _propositional __ K_AND __ _propositional
	| _propositional
_propositional = propositional
	| K_NOT __ propositional
propositional = comparitive
	| value_expr __  K_NOT _ K_NULL
	| value_expr __ K_IS _ K_NULL
	| value_expr __ K_NOT _ K_IN _ \( _ consts _ \)
	| value_expr __ K_IN _ \( _ consts _ \)
	| value_expr __ K_NOT _ K_IN _ \( _ select_stmt _ \)
	| value_expr __ K_IN _ \( _ select_stmt _ \)
	| K_NOT _ K_EXISTS _ \( _ select_stmt _ \)
	| K_EXISTS _ \( _ select_stmt _ \)
comparitive = _additive _ (\=\=|\=|\!\=|<>) _ _additive biop
	| string __ (?i)(is *not|is|like) __ string biop
	| _additive _ (<=|<|>=|>) _ _additive biop
	| _additive __ K_BETWEEN __ _additive __ K_AND __ _additive
	| _additive __ K_NOT __ K_BETWEEN __ _additive __ K_AND __ _additive
_additive = additive biops
additive = _multiplicative _ (\+|-) _ additive
	| _multiplicative
_multiplicative = multiplicative biops
multiplicative = factor _ (\*|/|%) _ multiplicative
	| factor
factor = NUMERIC_LITERAL
	| dynamic
	| \( _ _additive _ \)
	| unary_operator _additive
string = STRING_LITERAL
	| dynamic
dynamic = K_NULL
	| K_CAST _ \( _ expr K_AS type_name _ \)
	| table_name DOT column_name
	| column_name
	| BIND_PARAMETER
unary_operator = (-)
