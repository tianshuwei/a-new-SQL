using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace aWorkbench
{
	class aSQLConnector
	{
		public enum STATUS{ OPEN,SUSPEND,CLOSE};
		private IPAddress ip;
		private int port;
		private TcpClient client;
		private STATUS status;
		internal STATUS Status
		{
			get
			{
				return status;
			}

		}

		public aSQLConnector(string ipString, int port)  {
			this.ip = IPAddress.Parse(ipString);
			this.port = port;
			status = STATUS.CLOSE;
		}

		private bool openConnection() {
			switch (Status) {
				case STATUS.OPEN:
					return false;
				case STATUS.SUSPEND:
					return false;
				case STATUS.CLOSE:
					client = new TcpClient();
					try
					{
						client.Connect(ip, port);
						status = STATUS.OPEN;
					}
					catch (Exception e)
					{
						//do catch
						return false;
					}
					return true;
			}
			return false;//should never run to here!
		}

		public bool send(string txt,bool keepOpen=false) {
			if (status != STATUS.OPEN)
				if (!openConnection()) return false;
			NetworkStream stream = client.GetStream();
			byte[] sd = Encoding.Default.GetBytes(txt);
			stream.Write(sd, 0, sd.Length);
			stream.Close();
			if (!keepOpen) client.Close();
			return true;
		}
	}
}
