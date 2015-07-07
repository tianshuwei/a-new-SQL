import os
from socket import *
package=lambda *ts:''.join(['\x1B^','\x1B,'.join(ts),'\x1B$'])

def send(lines):
    sock=socket(AF_INET, SOCK_STREAM)
    sock.connect(('120.24.174.100',2222))
    sock.send(package('','\x20'.join(lines),''))
    while 1:
    	data=sock.recv(2048)
    	if data: print data
    	else: break
    sock.close()

try:
    while 1:
        lines=[]
        try:
        	while 1:
        	    lines.append(raw_input())
        	    if lines[-1].endswith(';'):
        	        send(lines)
        	        break
        except EOFError: pass
except KeyboardInterrupt: pass
