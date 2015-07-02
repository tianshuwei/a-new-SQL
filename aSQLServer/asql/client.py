from socket import *
package=lambda *ts:''.join(['\x1B^','\x1B,'.join(ts),'\x1B$'])
sock=socket(AF_INET, SOCK_STREAM)
sock.connect(('localhost',1234))
sock.send(package('','list databases;',''))
print sock.recv(2048)
sock.close()