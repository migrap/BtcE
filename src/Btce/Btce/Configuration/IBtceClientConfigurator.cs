using System;
using System.Net.Http;

namespace Btce.Configuration
{
	public interface IBtceClientConfigurator {
		void Scheme(string value);
		void Host(string value);
		void Port(int value);
		void Path(string value);
		void Key(string value);
		void Secret(string value);
	}
}

