# Copyright 2015 Alex Yang <aleozlx@126.com>
import peglet, os, sys, collections
from parser_helper import Vector
from backend import *
sizeof={ 'int': 4 }
UNESCAPE_CHAR={'b':'\b', 'f':'\f', 'n':'\n', 'r':'\r', 't':'\t'}
tablespec=collections.namedtuple('tablespec','tname columns')
columnspec=collections.namedtuple('columnspec','cname type size key null valid')

def G(fname):
	with open(os.path.join(os.path.dirname(__file__),fname)) as f:
		return f.read()

parse = peglet.Parser(G('asql.re')+G('asql.lex.re'),
	hug = peglet.hug, join = peglet.join, debug = lambda t: "<debug %s>"%t, quote = lambda t:'"%s"'%t, vec = Vector, int=int,
	mk_columnI=lambda *ts:columnspec(cname=ts[0],type=ts[1][0],size=ts[1][1],key=ts[2][0],null=ts[2][1],valid=True),
	mk_columnII=lambda *ts:columnspec(cname=ts[0],type=ts[1][0],size=ts[1][1],key=False,null=True,valid=ts[2]),
	mk_columnIII=lambda *ts:columnspec(cname=ts[0],type=ts[1][0],size=ts[1][1],key=False,null=True,valid=True),
	mk_columnIV=lambda *ts:columnspec(cname=ts[0],type=ts[1][0],size=ts[1][1],key=ts[2][0],null=ts[2][1],valid=ts[3]),
	mk_typeI=lambda *ts: (ts[0], sizeof[ts[0].lower()]) if ts[0].lower() in sizeof else (ts[0], 0),
	mk_constraintI=lambda *ts: (0, ts[0]), # key=False null=ts[0]
	mk_key=lambda *ts: bool(ts[0]),
	mk_null=lambda *ts: bool(ts[0].upper()!="NOT"),
	mk_valid=lambda *ts: bool(ts[0].upper()!="NOT"),
	mk_create_table=lambda *ts: (create_table,(tablespec(tname=ts[0], columns=ts[1]),ts[2])),
	mk_list_columns=lambda *ts: (list_columns,(ts[0],ts[1])),
	mk_list_tables=lambda *ts: (list_tables,(ts[0])),
	mk_list_databases=lambda *ts: (list_databases,()),
	mk_rename_table=lambda *ts: (rename_table, (ts[0],ts[1],ts[2])),
	mk_alter_table=lambda *ts: (edit_table, (ts[0], ts[1][0], ts[1], ts[2])),
	unescape=lambda c: UNESCAPE_CHAR[c] if c in UNESCAPE_CHAR else c)

def execute(sql):
	for r in parse(sql):
		if len(r)==2: r[0](*r[1])
		else: print r

if __name__ == '__main__':
	for stmt in parse(G(sys.argv[1])):
		print stmt
