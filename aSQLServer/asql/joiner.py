import itertools, operator
from parser_helper import Vector as vec

class JoinerIterator(object):
	def __init__(self, x):
		super(JoinerIterator, self).__init__()
		self.x = x
		
	def next(self):
		return reduce(operator.add, Joiner.unreduce(self.x.next()))

class Joiner(object):
	def __init__(self, o, a, b):
		super(Joiner, self).__init__()
		self.a = a
		self.b = b
		self.o = o

	def __iter__(self):
		return JoinerIterator(self.gen())

	def gen(self):
		return self.o(self.a, self.b)

	@staticmethod
	def unreduce(iterable):
		a, b = iterable
		if isinstance(a, tuple):
			for i in Joiner.unreduce(a): yield i
		else: yield a
		yield b

t1=vec(
	vec(1,0,0),
	vec(2,0,0)
)

t2=vec(
	vec(1,1),
	vec(1,None),
	vec(3,1),
)

t3=vec(
	vec(3,1,0,0),
	vec(4,None,0,0),
	vec(4,0,0,0)
)

# print list(Joiner.unreduce(reduce(lambda a,b:(a,b),xrange(10))))
# p=itertools.product
# for R in p(p(t1,t2),t3):
# 	print list(Joiner.unreduce(R))

product = itertools.product

def _equ(a, b):
	return a == b and a != None

def innerjoin(ia, ib):
	def _join(a, b):
		for ai, bi in product(a, b):
			if _equ(ai[ia], bi[ib]):
				yield ai, bi
	return _join

def leftjoin(ia, ib, nb):
	def _join(a, b):
		for ai in a:
			ct = 0
			for bi in b:
				if _equ(ai[ia], bi[ib]):
					yield ai, bi
					ct += 1
			if ct == 0:
				yield ai, vec(None)*nb
	return _join

def rightjoin(ia, ib, na):
	def _join(a, b):
		for bi in b:
			ct = 0
			for ai in a:
				if _equ(ai[ia], bi[ib]):
					yield ai, bi
					ct += 1
			if ct == 0:
				yield vec(None)*na, bi
	return _join

def fulljoin(ia, ib, na, nb):
	def _join(a, b):
		for ai in a:
			ct = 0
			for bi in b:
				if _equ(ai[ia], bi[ib]):
					yield ai, bi
					ct += 1
			if ct == 0:
				yield ai, vec(None)*nb
		for bi in b:
			ct = 0
			for ai in a:
				if _equ(ai[ia], bi[ib]):
					ct += 1
			if ct == 0:
				yield vec(None)*na, bi
	return _join

jbiops=lambda o, x: jbiops(o[1:], [Joiner(o[0], x[0], x[1])] + x[2:]) if o else x[0]

if __name__ == '__main__':
	print "product"
	for i in Joiner(product, Joiner(product, t1, t2), t3):
		print i

	print
	print "inner join"
	for i in Joiner(innerjoin(0, 0), t1, t2):
		print i

	print
	print "left join"
	for i in Joiner(leftjoin(0, 0, 2), t1, t2):
		print i

	print
	print "right join"
	for i in Joiner(rightjoin(0, 0, 3), t1, t2):
		print i

	print
	print "full join"
	for i in Joiner(fulljoin(0, 0, 3, 2), t1, t2):
		print i

	print
	print "some complicated joins"
	for i in Joiner(innerjoin(3, 1), Joiner(leftjoin(0, 0, 2), t1, t2), t3):
		print i

	print
	print "using jbiops"
	for i in jbiops([leftjoin(0, 0, 2), innerjoin(3, 1)], [t1, t2, t3]):
		print i