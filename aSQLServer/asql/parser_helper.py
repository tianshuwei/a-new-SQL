# Copyright 2015 Alex Yang <aleozlx@126.com>
ifilter = lambda t: lambda i: isinstance(i,t)
bmap = lambda b,T,F: lambda x: map(lambda i:T(i) if b(i) else F(i),x)
sjoin = lambda x: '\x20'.join(x)
ejoin = lambda x: ''.join(x)
B = lambda l,r: lambda s: ''.join([l,s,r])
S = lambda v: B('\x1B[','m')(v)
C = lambda v: B(S(v),default)
default = S('0'); underline = C('4;37')
vec = B('(',')')

class Vector(list):
	theme = lambda self: lambda s:s
	def __init__(self, *ts):
		super(Vector, self).__init__(ts)

	def __str__(self):
		return vec(sjoin(bmap(ifilter(str),self.theme(),str)(self)))

	@staticmethod
	def to_string(x):
		return str(Vector(*x))

def calc(t):
	if isinstance(t,Vector):
		if t[0] == '+': return calc(t[1])+calc(t[2])
		elif t[0] == '-': return calc(t[1])-calc(t[2])
		elif t[0] == '*': return calc(t[1])*calc(t[2])
		elif t[0] == '/': return calc(t[1])/calc(t[2])
		elif t[0] == '%': return calc(t[1])%calc(t[2])
		elif t[0] == 'U-': return -calc(t[1])
	else: return t

V=Vector
UNESCAPE_CHAR={'b':'\b', 'f':'\f', 'n':'\n', 'r':'\r', 't':'\t'}
operator=lambda s: s.replace('\x20','').lower()
uop=lambda o,a: V('U'+operator(o), a)
biop=lambda a,o,b: V(operator(o), a, b)
biops=lambda o, x: biops(V(*o[1:]), V(biop(x[0], operator(o[0]), x[1]), *x[2:])) if o else x[0]
sbind=lambda f: lambda *ts: (f, ts)
more_lambdas=dict(
	unescape=lambda c: UNESCAPE_CHAR[c] if c in UNESCAPE_CHAR else c,
	uop = uop, biop = biop, biops = lambda *ts: biops(ts[1::2], ts[::2]),
	debug = lambda t: "<debug %s>"%t, quote = lambda t:'"%s"'%t,
	vec = Vector, int = int, calc = calc,
)

def G(fname):
	import os
	with open(os.path.join(os.path.abspath(os.path.dirname(__file__)),fname)) as f:
		return f.read()
