using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Configuration;
using System.IO;

namespace aWorkbench
{
	class JSON
	{
		//ref: http://www.cnblogs.com/coderzh/archive/2008/11/25/1340862.html
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

		public static T fromJson<T>(string jsonString) {
			var serializer = new DataContractJsonSerializer(typeof(T));
			var mStream = new MemoryStream(Encoding.Default.GetBytes(jsonString));
			return (T)serializer.ReadObject(mStream);
			
		}
	}
}
