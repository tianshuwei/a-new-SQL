# Copyright 2015 Alex Yang <aleozlx@126.com>
import peglet, os, sys, collections
from parser_helper import Vector as V, more_lambdas, sbind
from backend import *
sizeof={ 'int': 4 }
tablespec=collections.namedtuple('tablespec','tname columns')
columnspec=collections.namedtuple('columnspec','cname type size key null valid')

def G(fname):
	with open(os.path.join(os.path.dirname(__file__),fname)) as f:
		return f.read()

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
	mk_ref=lambda *ts: "ref<%s>"%ts[0],
	**more_lambdas)

def execute(sql):
	for r in parse(sql):
		if len(r)==2: r[0](*r[1])
		else: print r

if __name__ == '__main__':
	print os.path.abspath(__file__)
	for stmt in parse(G(sys.argv[1])):
		print stmt
