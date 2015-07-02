from socket import *
package=lambda *ts:''.join(['\x1B^','\x1B,'.join(ts),'\x1B$'])
sock=socket(AF_INET, SOCK_STREAM)
sock.connect(('localhost',1234))
lines=[]
try:
	while 1: lines.append(raw_input())
except EOFError: pass
sock.send(package('','\x20'.join(lines),''))
while 1:
	data=sock.recv(2048)
	if data: print data
	else: break
sock.close()