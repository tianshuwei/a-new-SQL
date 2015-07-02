# Copyright 2015 Alex Yang <aleozlx@126.com>
import peglet, os, sys
from parser_helper import Vector

def G(fname):
	with open(os.path.join(os.path.dirname(__file__),fname)) as f:
		return f.read()

UNESCAPE_CHAR={'b':'\b', 'f':'\f', 'n':'\n', 'r':'\r', 't':'\t'}
unescape = lambda c: UNESCAPE_CHAR[c] if c in UNESCAPE_CHAR else c
parse = lambda src: peglet.Parser(G('asql.re')+G('asql.lex.re'),
	hug = peglet.hug, join = peglet.join, debug = lambda t: "<debug %s>"%t, quote = lambda t:'"%s"'%t, 
	vec = Vector, 
	unescape = unescape)(src)

if __name__ == '__main__':
	print parse(G(sys.argv[1]))
