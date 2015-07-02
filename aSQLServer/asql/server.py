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
			print 'foreign addr:', raddr
			try:
				data=s.recv(2048)
				if SYMBOL_START in data and SYMBOL_END in data:
					iS, iE=data.find(SYMBOL_START),data.find(SYMBOL_END)
					onDataReceived(data[iS+len(SYMBOL_START):iE].split(SYMBOL_SEPARATOR))
			except:
				traceback.print_exc()
			else:
				s.send("ok")
			finally: s.close()
	except KeyboardInterrupt: pass
	finally: sock.close()

def onDataReceived(x):
	print x

if __name__ == '__main__':
	run()
