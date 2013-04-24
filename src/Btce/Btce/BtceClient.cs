using System;
using System.Net.Http;
using System.Security;
using Btce.Configuration;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace Btce {
	public partial class BtceClient {
		private BtceMediaTypeFormatter _formatter = new BtceMediaTypeFormatter();
		private HttpClient _http;
		private SecureString _key;
		private SecureString _secret;

		public static BtceClient New(Action<IBtceClientConfigurator> configure) {
			var configurator = new BtceClientConfigurator();
			configure(configurator);
			return configurator.Build();
		}

		public BtceClient(string scheme = "https", string host = "data.mtgox.com", int port = 443, string path = "api", string key = "", string secret = "") {
			var builder = new UriBuilder { Scheme = scheme, Host = host, Port = port, Path = path };


			_http = new HttpClient(new HttpClientHandler());
			_http.BaseAddress = builder.Uri;
			_http.DefaultRequestHeaders.Add("User-Agent", "{0} {1}".FormatWith(typeof(BtceClient).Assembly.GetName().Name, typeof(BtceClient).Assembly.GetName().Version.ToString(4)));
			_http.DefaultRequestHeaders.Add("Rest-Key", key);
			_http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			_key = key.GetSecureString();
			_secret = key.GetSecureString();
		}

		private async Task<HttpResponseMessage> SendAsync(HttpMethod method, Action<IHttpRequestMessageConfigurator> configure) {
			var configurator = new HttpRequestMessageConfigurator();

			configurator.Method(method);
			configurator.BaseAddress(_http.BaseAddress);
			configure(configurator);

			var request = configurator.Build();

			var response = await _http.SendAsync(request).ConfigureAwait(false);
			await response.EnsureSuccessStatusCode(true).ConfigureAwait(false);
			return response;
		}

		private async Task<HttpResponseMessage> GetAsync(string path, object values = null) {
			return await SendAsync(HttpMethod.Get, x => {
				x.Path(path);
				x.Values(values);
			});
		}

		private async Task<HttpResponseMessage> PostAsync(string path) {
			return await SendAsync(HttpMethod.Post, x => {
				x.Path(path);
			});
		}
	}
}

