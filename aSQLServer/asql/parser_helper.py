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
		return {
			'+': lambda a,b: calc(a)+calc(b),
			'-': lambda a,b: calc(a)-calc(b),
			'*': lambda a,b: calc(a)*calc(b),
			'/': lambda a,b: calc(a)/calc(b),
			'%': lambda a,b: calc(a)%calc(b)
		}[t[0]](t[1],t[2]) if not isinstance(t[0],int) else t[0]
	else: return t

V=Vector
UNESCAPE_CHAR={'b':'\b', 'f':'\f', 'n':'\n', 'r':'\r', 't':'\t'}
biops=lambda o, x: biops(V(*o[1:]), V(V(o[0], x[0], x[1]), *x[2:])) if o else x[0]
sbind=lambda f: lambda *ts: (f, ts)
more_lambdas=dict(
	unescape=lambda c: UNESCAPE_CHAR[c] if c in UNESCAPE_CHAR else c,
	biop = lambda a,o,b: V(o, a, b),
	biops = lambda *ts: biops(ts[1::2], ts[::2]),
	debug = lambda t: "<debug %s>"%t,
	quote = lambda t:'"%s"'%t,
	vec = Vector,
	int = int,
	calc = calc,
)