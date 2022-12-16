using Microsoft.AspNetCore.Http;
using System.Net.WebSockets;
using System.Text;

namespace KestrelServerMAUI.KestrelWebHost
{
	public class WebApp
	{
		private static readonly byte[] _helloWorldBytes = Encoding.UTF8.GetBytes(
			"Hello Xamarin, greetings from Kestrel");

		public async static Task<HttpResponse> OnHttpRequest(HttpContext httpContext)
		{
			var response = httpContext.Response;
			var responseBodyStream = new MemoryStream();
			response.Body = responseBodyStream;
			response.StatusCode = 200;
			response.ContentType = "text/plain";
			var helloWorld = _helloWorldBytes;
			response.ContentLength = helloWorld.Length;
			await response.Body.WriteAsync(helloWorld, 0, helloWorld.Length);
			return response;
			//var bodyData = await new StreamReader(response.Body, Encoding.Default).ReadToEndAsync();
			//Stream stream = new MemoryStream(_helloWorldBytes);
			//return response.WriteAsync(bodyData);
			//return response.Body;
		}
	}
}