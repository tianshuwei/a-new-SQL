K_ALTER = (?i)(?:edit)
K_TABLE = (?i)(?:table)
K_RENAME = (?i)(?:rename)
K_DROP = (?i)(?:drop)
K_CREATE = (?i)(?:create)
K_IN = (?i)(?:in)
K_INTO = (?i)(?:into)
K_INSERT = (?i)(?:insert)
K_VALUES = (?i)(?:values)
K_DELETE = (?i)(delete)
K_FROM = (?i)(?:from)
K_WHERE = (?i)(where)
K_UPDATE = (?i)(update)
K_SET = (?i)(set)
K_NOT = (?i)(not)
K_AND = (?i)(and)
K_OR = (?i)(or)
K_CAST = (?i)(cast)
K_AS = (?i)(as)
K_IS = (?i)(is)
K_EXISTS = (?i)(exists)
K_SELECT = (?i)(select)
K_LIST = (?i)(?:list)
K_NULL = (?i)(null) const_null
SEMICOLON = _ ; _
COMMA = _ , _
EQUAL = _ \= _
DOT = _ \. _
BIND_PARAMETER = @ IDENTIFIER
IDENTIFIER = ([a-zA-Z_][a-zA-Z_0-9]*)
NUMERIC_LITERAL = (\d+) int
STRING_LITERAL = " chars " join
	| ' sqchars ' join
chars = char chars
	|
sqchars = sqchar sqchars
	|
char = ([^\x00-\x1f"\\])
	| esc_char
sqchar = ([^\x00-\x1f'\\])
	| esc_char
esc_char = \\(['"/\\])
	| \\([bfnrt]) unescape
_ = \s*
__ = \s+
