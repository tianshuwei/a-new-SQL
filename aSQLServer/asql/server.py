import traceback
from socket import *
SYMBOL_START='\x1B^'
SYMBOL_SEPARATOR='\x1B,'
SYMBOL_END='\x1B$'
def run():
	try:
		sock=socket(AF_INET, SOCK_STREAM)
		sock.bind(('0.0.0.0', 1234))
		sock.listen(5)
		while 1:
			s, raddr=sock.accept()
			print 'accepted', raddr
			try:
				data=s.recv(2048)
				if SYMBOL_START in data and SYMBOL_END in data:
					iS, iE=data.find(SYMBOL_START),data.find(SYMBOL_END)
					onDataReceived(data[iS+len(SYMBOL_START):iE].split(SYMBOL_SEPARATOR))
			except:
				traceback.print_exc()
			else:
				s.send("""{"ok":0,result:["not implemented"]}""")
			finally: s.close()
	except KeyboardInterrupt: pass
	finally: sock.close()

def onDataReceived(x):
	if not x[0]:
		onSQL(x[1])

def onSQL(sql):
	pass

if __name__ == '__main__':
	run()
