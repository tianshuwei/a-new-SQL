import struct

def create_table(name, num, tablespec):   #表名char[20]，字段数，字段队列
	try:
		bwfile=open("mydb.dbf",'ab')
		content1 = struct.pack("c20si",'~',name,num)
		bwfile.writeline(content1)
		# typedef struct {
		#   char sFieldName[20];  //字段名
		#   char sType[8];  //字段类型
		#   int iSize;  //字长
		#   bool bKey;  //该字段是否为KEY键
		#   bool bNullFlag;  //该字段是否允许为空
		#   bool bValidFlag;  //该字段是否有效，可用于以后对表中该字段的删除
		#   } TableMode,*PTableMode;
		for line in tablespec:
			content2 = struct.pack("20s8si???",line[0],line[1],line[2],line[3],line[4],line[5])
			bwfile.writeline(content2)
		bwfile.flush()
		bwfile.close()
	except Exception,e:
		print e

def list_table(name):
	#..


def test():
	#..

if __name__ == '__main__':
	test()