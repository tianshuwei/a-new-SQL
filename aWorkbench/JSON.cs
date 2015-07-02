using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace aWorkbench
{
	class JSON
	{
		//ref: http://www.cnblogs.com/txw1958/archive/2012/08/01/csharp-json.html
		public static string toJson<T>(T obj)
		{
			var serializer = new DataContractJsonSerializer(obj.GetType());
			var stream = new MemoryStream();
			serializer.WriteObject(stream, obj);

			byte[] dataBytes = new byte[stream.Length];

			stream.Position = 0;

			stream.Read(dataBytes, 0, (int)stream.Length);

			return Encoding.UTF8.GetString(dataBytes);
		}

		public static JObject fromJson(string jsonString) {
			return (JObject)JsonConvert.DeserializeObject(jsonString);

	}
	}
}
