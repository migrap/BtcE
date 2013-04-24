using System;
using System.Net.Http;
using System.Security;
using Btce.Configuration;
using System.Threading.Tasks;

namespace Btce
{
	internal interface IHttpRequestMessageConfigurator {
		void Path(string value);
		void Values(object values);
	}
}

