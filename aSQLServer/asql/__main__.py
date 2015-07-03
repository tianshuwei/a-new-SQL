import server, parser
def onSQL(sql):
	parser.execute(sql)
server.onSQL=onSQL
server.run()
