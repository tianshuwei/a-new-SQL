using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

            jsonString = "'ok':1,result:[['col1','col2'],['11','22'],['33','44']]";
            JObject jr = JSON.fromJson(jsonString);
            string ok = jr["ok"].ToString();
            string result = jr["result"].ToString();
            JArray ja = (JArray)JsonConvert.DeserializeObject(result);
            JObject o = (JObject)ja[1];
            //string[] str = jsonString.Split(new char[2] { '[', ']' });
            //foreach (string s in str)
            //{
            //    keys.Add(s);
            //    string[] str2 = s.Split(new char[1] { ',' });
            //    List<Elem> list = new List<Elem>();
            //    foreach (string ss in str2)
            //    {
            //        Elem elem = new Elem(ss);
            //        list.Add(elem);
            //    }
            //    values.Add(list);
            //}
		}
	}
}
