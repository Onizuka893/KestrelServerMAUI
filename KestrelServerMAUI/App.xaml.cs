
using System.Net;
using EmbedIO;
using EmbedIO.Actions;
using EmbedIO.Files;
using EmbedIO.WebApi;
using KestrelServerMAUI.KestrelWebHost;
using Microsoft.AspNetCore.Hosting;
using Swan.Logging;

namespace KestrelServerMAUI;

public partial class App : Application
{
	public static IWebHost Host { get; set; }
	public static WebHostParameters WebHostParameters { get; set; } = new WebHostParameters();

	private static WebServer CreateWebServer(string url)
	{
		var server = new WebServer(o => o
				.WithUrlPrefix(url)
				.WithMode(HttpListenerMode.EmbedIO))
			// First, we will configure our web server by adding Modules.
			.WithLocalSessionManager()
			.WithWebApi("/api", m => m
				.WithController<TestController>())
			.WithModule(new ActionModule("/", HttpVerbs.Any, ctx => ctx.SendDataAsync(new { Message = "Error" })));

		// Listen for state changes.
		server.StateChanged += (s, e) => $"WebServer New State - {e.NewState}".Info();

		return server;
	}
	public App()
	{
		InitializeComponent();
		var url = "http://10.100.2.152:10800/";
		MainPage = new AppShell();
		WebHostParameters.ServerIpEndpoint = new IPEndPoint(NetworkHelper.GetIpAddress(), 10800);

		MainPage = new MainPage();

		using (var server = CreateWebServer(url))
		{
			// Once we've registered our modules and configured them, we call the RunAsync() method.
			server.RunAsync();

			var browser = new System.Diagnostics.Process()
			{
				StartInfo = new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true }
			};
			browser.Start();
		}
	}
}
