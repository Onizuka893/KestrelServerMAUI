
using System.Net;
using KestrelServerMAUI.KestrelWebHost;
using Microsoft.AspNetCore.Hosting;

namespace KestrelServerMAUI;

public partial class App : Application
{
	public static IWebHost Host { get; set; }
	public static WebHostParameters WebHostParameters { get; set; } = new WebHostParameters();

	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
		//string ipAddress = "10.100.2.69";
		//IPAddress address = IPAddress.Parse(ipAddress);
		//Byte[] bytes = address.GetAddressBytes();
		WebHostParameters.ServerIpEndpoint = new IPEndPoint(NetworkHelper.GetIpAddress(), 10800);

		MainPage = new MainPage();

		new Thread(async () =>
		{
			try
			{
				await KestrelMauiBlazor.KestrelWebHost.Program.Main(WebHostParameters);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine($"######## EXCEPTION: {ex.Message}");
			}
		}).Start();
	}
}
