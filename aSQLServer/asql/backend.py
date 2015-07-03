# -*- coding: utf8 -*-
import struct

def create_table(tablespec, dbname):
	try:
		bwfile=open('%s.dbf'%dbname,'ab')
		content1 = struct.pack("c20si",'~',tablespec.tname,len(tablespec.columns))
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
	except Exception,e:
		print e

def list_columns(tname, dbname):
	pass

def list_tables(dbname):
	pass

def list_databases():
	pass

def rename_table(tname, tname_new, dbname):
	pass

def edit_table(tname, cname, columnspec, dbname):
	pass

def drop_table(tname, dbname):
	pass
