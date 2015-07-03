using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aWorkbench
{
	class resultSet
	{
		string tableName;
		List<string> keys;
		List<List<Elem>> values;
		resultSet(string jsonString,string tablename) {
            tableName = tablename;
            //get key array
            keys = new List<string>();
            //foreach() key-type into keys
            values = new List<List<Elem>>();
            // foreach  values.Add(new List<string>(???))

            string[] str = jsonString.Split(new char[2] { '[', ']' });
            foreach (string s in str)
            {
                keys.Add(s);
                string[] str2 = s.Split(new char[1] { ',' });
                List<Elem> list = new List<Elem>();
                foreach (string ss in str2)
                {
                    Elem elem = new Elem(ss);
                    list.Add(elem);
                }
                values.Add(list);
            }
		}
	}
}
