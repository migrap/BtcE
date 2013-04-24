using System;
using System.Net.Http.Formatting;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;

namespace Btce {
	public class BtceMediaTypeFormatter : JsonMediaTypeFormatter {
		public BtceMediaTypeFormatter() {
		}

		public override bool CanReadType(Type type) {
			return true;
		}

		public override bool CanWriteType(Type type) {
			return true;
		}

		public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger) {
			return base.ReadFromStreamAsync(type, readStream, content, formatterLogger);
		}

		public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext) {
			return base.WriteToStreamAsync(type, value, writeStream, content, transportContext);
		}
	}
}

