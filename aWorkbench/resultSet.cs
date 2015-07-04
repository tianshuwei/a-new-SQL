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
		public resultSet(string jsonString,string tablename) {
            tableName = tablename;
            //get key array
            keys = new List<string>();
            //foreach() key-type into keys
            values = new List<List<Elem>>();
            // foreach  values.Add(new List<string>(???))

            jsonString = "{\"ok\":1, \"result\":[[\"id\",\"username\"],[1,\"john\"]]}";
            JObject jr = JSON.fromJson(jsonString);
            string ok = jr["ok"].ToString();
            string result = jr["result"].ToString();

            JArray jares = (JArray)JsonConvert.DeserializeObject(result);
            string jacol = jares[0].ToString();
            JArray colarray = (JArray)JsonConvert.DeserializeObject(jacol);
            //for循环塞keys
            for (int i = 0; i < colarray.Count; i++)
            {
                string s = colarray[i].ToString();
                keys.Add(s);
            }
            //for循环塞values
            for (int i = 1; i < jares.Count; i++)
            {
                List<Elem> list = new List<Elem>();
                string xx = jares[i].ToString();
                JArray jaxx = (JArray)JsonConvert.DeserializeObject(xx);
                for (int j = 0; j < jaxx.Count; j++)
                {
                    string xxx = jaxx[j].ToString();
                    Elem elem = new Elem(xxx);
                    list.Add(elem);
                }
                values.Add(list);
            }
		}
	}
}
