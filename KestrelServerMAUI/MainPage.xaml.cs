namespace KestrelServerMAUI;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		Ip.Text = App.WebHostParameters.ServerIpEndpoint.Address.ToString();
		Url.Text = $"http://{Ip.Text}:{App.WebHostParameters.ServerIpEndpoint.Port}";
	}
}

