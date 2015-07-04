# Copyright 2015 Alex Yang <aleozlx@126.com>
import peglet, os, collections
from parser_helper import Vector as V, G, more_lambdas, sbind
from backend import *
sizeof={ 'int': 4 }
tablespec=collections.namedtuple('tablespec','tname columns')
columnspec=collections.namedtuple('columnspec','cname type size key null valid')

class CellRef(object):
	def __init__(self, field_name):
		super(CellRef, self).__init__()
		self.field_name = field_name

	def __call__(self, relation):
		return relation(self.field_name)

	def __repr__(self):
		return "CellRef(%s)"%repr(self.field_name)

class TypeCast(object):
	def __init__(self, (var, type_name)):
		super(TypeCast, self).__init__()
		self.type_name = type_name
		self.var = var

	def __repr__(self):
		return "TypeCast(%s,%s)"%(repr(self.type_name),repr(self.var))

def _eval(value_expr, R):
	pass

def mk_test(_boolean_expr):
	e = _boolean_expr
	if not isinstance(e, Vector): return
	def test(R):
		o = e[0]
		t=lambda e: mk_test(e)(R)
		v=lambda e: _eval(e, R)
		if o is 'or': return t(e[1]) or t(e[2])
		elif o is 'and': return t(e[1]) and t(e[2])
		elif o is '!': return not t(e[1])
		elif o in ['=','==','is']: return v(e[1]) == v(e[2])
		elif o in ['<>','!=','isnot']: return v(e[1]) != v(e[2])
		elif o is 'like': return False
		elif o is '<': return v(e[1]) < v(e[2])
		elif o is '>=': return v(e[1]) >= v(e[2])
		elif o is '>': return v(e[1]) > v(e[2])
		elif o is '<=': return v(e[1]) <= v(e[2])
		elif o is '><':
			a, b = v(e[2]), v(e[3])
			return min(a,b) <= v(e[1]) <= max(a,b)
		elif o is '!><':
			a, b = v(e[2]), v(e[3])
			return not (min(a,b) <= v(e[1]) <= max(a,b))
		elif o is 'in':
			return False
		elif o is '!in':
			return False
		elif o is '?':
			return False
		elif o is '!?':
			return False
	return test

parse = peglet.Parser(G('asql.re')+G('asql.lex.re'),
	hug = peglet.hug, join = peglet.join,
	mk_columnI=lambda *ts:columnspec(cname=ts[0],type=ts[1][0],size=ts[1][1],key=ts[2][0],null=ts[2][1],valid=True),
	mk_columnII=lambda *ts:columnspec(cname=ts[0],type=ts[1][0],size=ts[1][1],key=False,null=True,valid=ts[2]),
	mk_columnIII=lambda *ts:columnspec(cname=ts[0],type=ts[1][0],size=ts[1][1],key=False,null=True,valid=True),
	mk_columnIV=lambda *ts:columnspec(cname=ts[0],type=ts[1][0],size=ts[1][1],key=ts[2][0],null=ts[2][1],valid=ts[3]),
	mk_typeI=lambda *ts: (ts[0], sizeof[ts[0].lower()]) if ts[0].lower() in sizeof else (ts[0], 0),
	mk_constraintI=lambda *ts: (0, ts[0]), # key=False null=ts[0]
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
	**more_lambdas)

def execute(sql):
	from server import error
	ret=None
	for r in parse(sql):
		if len(r)==2: ret=r[0](*r[1])
		else:
			print r
			return error("parser error") 
	else:
		if ret: return ret
		else: return error("backend error")

if __name__ == '__main__':
	import sys
	print os.path.abspath(__file__)
	for stmt in parse(G(sys.argv[1])):
		print stmt
