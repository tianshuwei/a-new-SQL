# -*- coding: utf8 -*-
import struct,collections,traceback,string
import os,sys

i_def=struct.calcsize("20si")
i_col=struct.calcsize("20s8si???")


def create_table(tablespec, dbname):
	try:
		tables=list_tables(dbname)
		if tables["ok"]==1:
			for a_table in tables["result"][1:]:
				if tablespec.tname==a_table[0]:
					return {"ok":0,"result":["The table already exists!",]}
		bwfile=open('%s.dbf'%dbname,'ab')
		content1 = struct.pack("20si",tablespec.tname,len(tablespec.columns))
		bwfile.write(content1)
		# typedef struct {
		#   char sFieldName[20];  //字段名
		#   char sType[8];  //字段类型
		#   int iSize;  //字长
		#   bool bKey;  //该字段是否为KEY键
		#   bool bNullFlag;  //该字段是否允许为空
		#   bool bValidFlag;  //该字段是否有效，可用于以后对表中该字段的删除
		#   } TableMode,*PTableMode;
		for line in tablespec.columns:
			content2 = struct.pack("20s8si???",*line)
			bwfile.write(content2)
		bwfile.flush()
		bwfile.close()
		return {"ok":1,"result":[["success in creating table!",],]}
	except Exception,e:
		print traceback.print_exc()


def list_columns(tname, dbname):
	try:
		ret_list=[["FieldName","Type","Size","Key","Null"],]
		brfile=open('%s.dbf'%dbname,'rb')
		while True:
			content1=brfile.read(i_def)
			#print "hh:"+content1
			if content1=='\n'or content1=='': 
				brfile.close()
				return {"ok":0,"result":["There is no such table!\n",]}
			c1=struct.unpack("20si",content1)
			#print c1
			flag = tname==(c1[0].strip('\0'))
			#print c1[1]
			for i in range(1,c1[1]+1):
				content2=brfile.read(i_col)
				#print i
				if flag:
					c2=struct.unpack("20s8si???",content2)
					li=[]
					ii=0
					for cc in c2:
						if ii<2:
							li.append(cc.strip('\0'))
						elif ii>2:
							li.append(int(cc))
						else:
							li.append(cc)
						ii=ii+1
					if li.pop():
						ret_list.append(li)
			if flag: break
		brfile.close()
		return {"ok":1,"result":ret_list}
	except EOFError:
		brfile.close()
		return {"ok":0,"result":["There is no such table!",]}
	except IOError:
		return {"ok":0,"result":["There is no such database!",]}
	except Exception,e:
		print traceback.print_exc()

def list_tables(dbname):
	try:
		ret_list=[["TableName",],]
		brfile=open('%s.dbf'%dbname,'rb')
		content1=brfile.read(i_def)
		#if content1=='' : return {"ok":0,"result":["There is no table in this database!",]}
		while content1 != '':
			c1=struct.unpack("20si",content1)
			tname=c1[0].strip('\0')
			if tname != "~~~DeletedTable~~~":
				ret_list.append([tname,])
			for i in range(1,c1[1]+1):
				content2=brfile.read(i_col)
			content1=brfile.read(i_def)
		brfile.close()
		return {"ok":1,"result":ret_list}
	except EOFError:
		brfile.close()
	except IOError:
		return {"ok":0,"result":["There is no such database!",]}
	except Exception,e:
		print traceback.print_exc()

def creat_dir(file_name):
	try:
		os.mkdir(file_name)
	except OSError:
		pass
	except Exception,e:
		print traceback.print_exc()

def format_string(arrs):
	s=''
	# for arr in arrs:
	# 	s=s+'?'
	for arr in arrs:
		if arr[1]=='int':
			s=s+'i'
		else:
			s=s+str(arr[2])+'s'
	return s

def endWith(s,*endstring):
		array = map(s.endswith,endstring)
		if True in array:
				return True
		else:
				return False

def list_databases():
	try:
		list_file = os.listdir(os.path.dirname(os.path.abspath(__file__)))
		s = os.listdir(os.path.dirname(os.path.abspath(__file__)))
		f_file = [["DatabaseName",],]
		for i in list_file:
				if endWith(i,'.dbf'):
						f_file.append([i[:-4],])
		return {"ok":1,"result":f_file}

	except Exception,e:
		print traceback.print_exc()


def table_exist(tname,dbname):
	tables=list_tables(dbname)
	if tables["ok"]==1:
		for a_table in tables["result"][1:]:
			if tname==a_table[0]:
				return True
	return False


def rename_table(tname, tname_new, dbname):
	try:
		brwfile=open('%s.dbf'%dbname,'rb+')
		if tname_new != "~~~DeletedTable~~~":
			if table_exist(tname_new,dbname):
				brwfile.close()
				return {"ok":0,"result":["The new name already exists!",]}
			# if table_exist(tname,dbname)==False:
			# 	brwfile.close()
			# 	return {"ok":0,"result":["The table does not exist!",]}
		count1 = 0
		count2 = 0
		while True:
			content1=brwfile.read(i_def)
			#print "hh:"+content1
			if content1=='\n'or content1=='': 
				brfile.close()
				return {"ok":0,"result":["There is no such table!\n",]}
			c1=struct.unpack("20si",content1)
			if c1[0].strip('\0')==tname:
				brwfile.seek(count1*i_def+count2*i_col)
				content2=struct.pack("20s",tname_new)
				brwfile.write(content2)
				brwfile.flush()
				brwfile.close()
				if tname_new == "~~~DeletedTable~~~":
					os.remove("%s.dat"%os.path.join(dbname,tname))
				else:
					os.rename("%s.dat"%os.path.join(dbname,tname),"%s.dat"%os.path.join(dbname,tname_new))
				return {"ok":1,"result":[["success in renaming!",],]}
			count1=count1+1
			count2=count2+c1[1]
			for col in range(1,c1[1]+1):
				brwfile.read(i_col)
	except IOError:
		return {"ok":0,"result":["There is no such database!",]}
	except OSError:
		return {"ok":1,"result":[["success in renaming!",],]}
	except Exception,e:
		print traceback.print_exc()

def edit_table(tname, cname, columnspec, dbname):
	pass

def drop_table(tname, dbname):
	rt = rename_table(tname,"~~~DeletedTable~~~",dbname)
	# print "return:"
	# print rt
	if rt["ok"]==1:
		return {"ok":1,"result":[["success in droping table!",],]}
	else:
		return rt


def insert(tname, values, dbname):
	try:
		creat_dir(dbname)
		cols = list_columns(tname,dbname)
		if cols["ok"]==0 : return cols
		format_str=format_string(cols["result"][1:])
		bwfile=open('%s.dat'%os.path.join(dbname,tname),'ab')
		for line in values:
			li=list(line)
			null_list=[]
			format_null=''
			i=0
			for e in li:
				if e == None:
					null_list.append(True)
					if cols["result"][i+1][1]=="int": 
						li[i]=0
					else:
						li[i]='None'
				else:
					null_list.append(False)
				i=i+1
				format_null=format_null+'?'
			#print null_list
			#print li
			content2 = struct.pack('?'+format_null,True,*null_list)
			bwfile.write(content2)
			content2 = struct.pack(format_str,*li)
			bwfile.write(content2)
		bwfile.flush()
		bwfile.close()
		return {"ok":1,"result":[["succeed in insert!",],]}
	except IOError:
		return {"ok":0,"result":["There is no such database!",]}
	except Exception,e:
		print traceback.print_exc()
	"""values: e.g.((1, "jason", None),
					(2, "bradley", None),
					(3, "duffy", "warwick avenue")) """


def delete(tname, where, dbname):
	from parser import mk_test
	test = mk_test(where)

	"""test: e.g.
	# for each record:
		# you need some function equivalent to this:
		def relation(field_name):
			mapping={
				"col1": 100,
				"col2": "haha",
			}
			return mapping[field_name]

		# then you use `test` like:
		if test(relation):
			delete this record
	"""


def update(tname, assignments, where, dbname):
	pass

def select(projection, join_expr, where, dbname):
	pass

def simple_select(tname, dbname):
	try:
		cols = list_columns(tname,dbname)
		if cols["ok"]==0 : return cols
		format_str=format_string(cols["result"][1:])
		brfile=open('%s.dat'%os.path.join(dbname,tname),'rb')
		rt0=[]
		rt_lists=[]
		fo_st=''
		count=0
		for col in cols["result"][1:]:
			rt0.append(col[0])
			count=count+1
			fo_st=fo_st+'?'
		rt_lists.append(rt0)
		c1 = brfile.read(struct.calcsize('?'))
		while c1 !='':
			if struct.unpack("?",c1):
				rt_list=[]
				ii=0
				content1=brfile.read(struct.calcsize('?')*count)
				un_co1=struct.unpack(fo_st,content1)
				content2=brfile.read(struct.calcsize(format_str))
				print format_str
				un_co2=struct.unpack(format_str,content2)
				for f in un_co1:
					if f:
						rt_list.append(None)
					else:
						if cols["result"][ii+1][1]=='string':
							rt_list.append(un_co2[ii].strip('\0'))
						else:
							rt_list.append(un_co2[ii])
					ii=ii+1
				rt_lists.append(rt_list)
			c1 = brfile.read(struct.calcsize('?'))
		return {"ok":1,"result":rt_lists}
		# for line in values:
		# 	li=list(line)
		# 	null_list=[]
		# 	format_null=''
		# 	i=0
		# 	for e in li:
		# 		if e == None:
		# 			null_list.append(True)
		# 			if cols["result"][i+1][1]=="int": 
		# 				li[i]=0
		# 			else:
		# 				li[i]='None'
		# 		else:
		# 			null_list.append(False)
		# 		i=i+1
		# 		format_null=format_null+'?'
		# 	content2 = struct.pack('?'+format_null,True,*null_list)
		# 	bwfile.write(content2)
		# 	content2 = struct.pack(format_str,*li)
		# 	bwfile.write(content2)
		# bwfile.flush()
		# bwfile.close()
		return {"ok":1,"result":[["succeed in insert!",],]}
	except IOError:
		return {"ok":0,"result":["There is no such database!",]}
	except Exception,e:
		print traceback.print_exc()

def test():
	c1=("id","int",4,True,False,True)
	c2=("name","string",20,False,True,True)
	columns=[c1,c2]
	tablespec=collections.namedtuple('tablespec','tname columns')
	t=tablespec(tname="tab111",columns=columns)
	print create_table(t,"test1")

def test2():
	a=((1, "jason"),
					(2, None),
					(3, "warwick avenue"))
	insert("tab11",a,"test1")

if __name__ == '__main__':
	print simple_select("tab1","test1")
