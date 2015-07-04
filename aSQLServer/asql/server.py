import traceback, json
from socket import *
SYMBOL_START='\x1B^'
SYMBOL_SEPARATOR='\x1B,'
SYMBOL_END='\x1B$'
success = lambda result: {"ok":1,"result":result}
error = lambda errmsg: {"ok":0,"result":[errmsg]}
onSQL = lambda sql: error("no parser bound")

def run():
	try:
		sock=socket(AF_INET, SOCK_STREAM)
		sock.bind(('0.0.0.0', 1234))
		sock.listen(5)
		while 1:
			s, raddr=sock.accept()
			print 'accepted', raddr
			try: data=s.recv(2048)
			except: traceback.print_exc()
			else:
				if SYMBOL_START in data and SYMBOL_END in data:
					iS, iE=data.find(SYMBOL_START),data.find(SYMBOL_END)
					s.send(json.dumps(
						onDataReceived(data[iS+len(SYMBOL_START):iE].split(SYMBOL_SEPARATOR))
					))
				else: s.send(json.dumps(error("request truncated")))
			finally: s.close()
	except KeyboardInterrupt: pass
	finally: sock.close()

def onDataReceived(x):
	if not x[0]:
		print x[1]
		return onSQL(x[1])
	else:
		print x[0]
		return error("malformed request")

if __name__ == '__main__':
	run()
