using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryNetStandart
{
	public class Startup
	{
		private static readonly byte[] _helloWorldBytes = Encoding.UTF8.GetBytes("HelloWord");

		public void Configure(IApplicationBuilder app)
		{
			app.Run((httpContext) =>
			{
				var response = httpContext.Response;
				response.StatusCode = 200;
				response.ContentType = "text/plain";

				var helloworld = _helloWorldBytes;
				response.ContentLength = helloworld.Length;
				return response.Body.WriteAsync(helloworld, 0, helloworld.Length);
			});
		}

		public static Task Main(string[] args)
		{
			var host = new WebHostBuilder()
				.UseKestrel(options =>
				{
					options.Listen(IPAddress.Loopback, 5001);
				})
				.UseContentRoot(Directory.GetCurrentDirectory())
				.UseStartup<Startup>()
				.Build();

			return host.RunAsync();
		}
	}
}
