using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;
using System.Net;

namespace Btce
{
	public class ApiException : Exception {
		public HttpStatusCode Status { get; protected set; }
		public HttpResponseMessage ResponseMessage { get; protected set; }

		public ApiException(HttpResponseMessage responseMessage, string message, Exception innerException = null)
			: base(message, innerException) {
			ResponseMessage = responseMessage;
			Status = responseMessage.StatusCode;
		}
	}
}

