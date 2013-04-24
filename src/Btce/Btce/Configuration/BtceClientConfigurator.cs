using System;
using System.Net.Http;

namespace Btce.Configuration
{
	public class BtceClientConfigurator:IBtceClientConfigurator{
		private string _scheme = "https";
		private string _host = "";
		private int _port = 443;
		private string _path = "";
		private string _key;
		private string _secret;

		public void Scheme(string value) {
			_scheme = value;
		}

		public void Host(string value) {
			_host = value;
		}

		public void Port(int value) {
			_port = value;
		}

		public void Path(string value) {
			_path = value;
		}

		public void Key(string value) {
			_key = value;
		}

		public void Secret(string value) {
			_secret = value;
		}

		public BtceClient Build() {
			return new BtceClient(_scheme, _host, _port, _path, _key, _secret);
		}
	}
}

