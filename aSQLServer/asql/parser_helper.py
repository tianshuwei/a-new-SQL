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
	theme = lambda self: underline
	def __init__(self, *ts):
		super(Vector, self).__init__(ts)

	def __str__(self):
		return vec(sjoin(bmap(ifilter(str),self.theme(),str)(self)))

	@staticmethod
	def to_string(x):
		return str(Vector(*x))