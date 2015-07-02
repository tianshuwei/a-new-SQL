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
		}
	}
}
