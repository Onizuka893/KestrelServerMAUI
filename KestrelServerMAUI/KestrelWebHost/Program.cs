using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarinme;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using KestrelServerMAUI.KestrelWebHost;

namespace KestrelMauiBlazor.KestrelWebHost
{
	public class Program
	{
		public static Task Main(WebHostParameters webHostParameters)
		{
			var webHost = new WebHostBuilder()
				.ConfigureAppConfiguration((config) =>
				{
					config.AddEmbeddedResource(
						new EmbeddedResourceConfigurationOptions
						{
							Assembly = Assembly.GetExecutingAssembly(),
							Prefix = "KestrelServerMAUI"
						});
				})
				.ConfigureServices((hostContext, services) =>
				{
					services.AddSingleton<IHostLifetime, ConsoleLifetimePatch>();
				})
				.UseKestrel(options =>
				{
					options.Listen(webHostParameters.ServerIpEndpoint);
				})
				//.UseUrls("http://localhost:5001")
				.UseContentRoot(Directory.GetCurrentDirectory())
				.UseStartup<Startup>()
				.Build();

			App.Host = webHost;
			return webHost.RunPatchedAsync();
		}
	}
}
