# Copyright 2015 Alex Yang <aleozlx@126.com>
import peglet, os, collections, re
import parser_helper
from parser_helper import Vector as V, G, sbind
from backend import *
sizeof={ 'int': 4 }
tablespec=collections.namedtuple('tablespec','tname columns')
columnspec=collections.namedtuple('columnspec','cname type size key null valid')

class CellRef(object):
	rule = re.compile(r'((.+)\.)?(.+)')
	def __init__(self, field_name):
		super(CellRef, self).__init__()
		m = CellRef.rule.match(field_name)
		self.tname = m.group(2)
		self.cname = m.group(3)

	def __call__(self, relation):
		return relation(self.cname)

	def __repr__(self):
		return "CellRef(%s)"%repr(self.cname)

class TypeCast(object):
	def __init__(self, (var, type_name)):
		super(TypeCast, self).__init__()
		typecasts = {
			'int': lambda a: int(a) if a!=None else None,
			'varchar': lambda a: int(a) if a!=None else None,
		}
		self.typecast = typecasts[type_name[0]]
		self.type_name = type_name
		self.var = var

	def __repr__(self):
		return "TypeCast(%s,%s)"%(repr(self.type_name),repr(self.var))

def _eval(value_expr, R):
	e = value_expr
	v = lambda e: _eval(e, R)
	if isinstance(e, V):
		o = e[0]
		if o == '+': return v(e[1])+v(e[2])
		elif o == '-': return v(e[1])-v(e[2])
		elif o == '*': return v(e[1])*v(e[2])
		elif o == '/': return v(e[1])/v(e[2])
		elif o == '%': return v(e[1])%v(e[2])
		elif o == 'U-': return -v(e[1])
	elif isinstance(e, int): return e
	elif isinstance(e, str): return e
	elif isinstance(e, CellRef): return e(R)
	elif isinstance(e, TypeCast):
		return e.typecast(v(e.var))
	else: return e

LIKE_contains = re.compile(r'^\%(.+)\%$')
LIKE_endswith = re.compile(r'^%(.+)$')
LIKE_startswith = re.compile(r'^(.+)%$')

def mk_test(_boolean_expr):
	e = _boolean_expr
	if not isinstance(e, V): return
	def test(R):
		o = e[0]
		t = lambda e: mk_test(e)(R)
		v = lambda e: _eval(e, R)
		if o == 'or': return t(e[1]) or t(e[2])
		elif o == 'and': return t(e[1]) and t(e[2])
		elif o == '!': return not t(e[1])
		elif o in ['=','==','is']: return v(e[1]) == v(e[2])
		elif o in ['<>','!=','isnot']: return v(e[1]) != v(e[2])
		elif o == 'like':
			m=LIKE_contains.match(e[2])
			if m: return m.group(1) in v(e[1])
			m=LIKE_startswith.match(e[2])
			if m: return v(e[1]).startswith(m.group(1))
			m=LIKE_endswith.match(e[2])
			if m: return v(e[1]).endswith(m.group(1))
			return v(e[1]) == e[2]
		elif o == '<': return v(e[1]) < v(e[2])
		elif o == '>=': return v(e[1]) >= v(e[2])
		elif o == '>': return v(e[1]) > v(e[2])
		elif o == '<=': return v(e[1]) <= v(e[2])
		elif o == '><':
			a, b = v(e[2]), v(e[3])
			return min(a,b) <= v(e[1]) <= max(a,b)
		elif o == '!><':
			a, b = v(e[2]), v(e[3])
			return not (min(a,b) <= v(e[1]) <= max(a,b))
		elif o == 'in': return v(e[1]) in e[2]
		elif o == '!in': return v(e[1]) not in e[2]
		elif o == '?': return v(e[1]) == None
		elif o == '!?': return v(e[1]) != None
	return test

parse = peglet.Parser(G('asql.re')+G('asql.lex.re'),
	hug = peglet.hug, join = peglet.join,
	mk_columnI=lambda *ts:columnspec(cname=ts[0],type=ts[1][0],size=ts[1][1],key=ts[2][0],null=ts[2][1],valid=True),
	mk_columnII=lambda *ts:columnspec(cname=ts[0],type=ts[1][0],size=ts[1][1],key=False,null=True,valid=ts[2]),
	mk_columnIII=lambda *ts:columnspec(cname=ts[0],type=ts[1][0],size=ts[1][1],key=False,null=True,valid=True),
	mk_columnIV=lambda *ts:columnspec(cname=ts[0],type=ts[1][0],size=ts[1][1],key=ts[2][0],null=ts[2][1],valid=ts[3]),
	mk_typeI=lambda *ts: (ts[0], sizeof[ts[0].lower()]) if ts[0].lower() in sizeof else (ts[0], 0),
	mk_constraintI=lambda *ts: (False, ts[0]), # key=False null=ts[0]
	const_null=lambda *ts: None, mk_key=lambda *ts: bool(ts[0]),
	mk_null=lambda *ts: bool(ts[0].upper()!="NOT"), mk_valid=lambda *ts: bool(ts[0].upper()!="NOT"),
	mk_create_table=lambda *ts: (create_table,(tablespec(tname=ts[0], columns=ts[1]),ts[2])),
	mk_list_columns=sbind(list_columns), mk_list_tables=sbind(list_tables),
	mk_list_databases=sbind(list_databases), mk_rename_table=sbind(rename_table),
	mk_alter_table=lambda *ts: (edit_table, (ts[0], ts[1][0], ts[1], ts[2])),
	mk_drop_table=sbind(drop_table), mk_insert=sbind(insert),
	mk_op_not=lambda *ts: V('!', ts[1]),
	mk_op_null=lambda *ts: V('!?' if ts[1].upper()=="NOT" else '?', ts[0]),
	mk_op_between=lambda *ts: V("!><", ts[0], ts[3], ts[4]) if ts[1].upper()=="NOT" else V("><", ts[0], ts[2], ts[3]),
	mk_ref=lambda *ts: CellRef(ts[0]),
	mk_op_in=lambda *ts: V('!in', ts[0], ts[2]) if isinstance(ts[1],str) and ts[1].upper()=="NOT" else V('in', ts[0], ts[1]),
	mk_typecast=lambda *ts: TypeCast(ts),
	mk_delete=sbind(delete), mk_update=sbind(update),
	mk_op_join=lambda *ts: V(parser_helper.operator(ts[0]), (ts[2], ts[3]), ts[1]),
	mk_select=sbind(select), mk_simple_select=sbind(simple_select),
	**parser_helper.more_lambdas)

def execute(sql):
	from server import error
	ret=None
	try:
		for r in parse(sql):
			if len(r)==2: ret=r[0](*r[1])
			else:
				print r
				return error("parser error") 
		else:
			if ret: return ret
			else: return error("backend error")
	except peglet.Unparsable:
		return error("syntax error")

if __name__ == '__main__':
	import sys
	if len(sys.argv)>=2:
		for fname in sys.argv[1:]:
			for stmt in parse(G(fname)):
				print stmt
