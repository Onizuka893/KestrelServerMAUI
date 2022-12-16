using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;

namespace KestrelServerMAUI
{
	public static class NetworkHelper
	{
		public static IPAddress GetIpAddress()
		{
			// Up, Ethernet and IP4.
			var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces()
				.Where(network => network.OperationalStatus == OperationalStatus.Up &&
					(network.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
						network.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) &&
					network.GetIPProperties().UnicastAddresses.Any(ai => ai.Address.AddressFamily == AddressFamily.InterNetwork))
				.ToArray();
			if (!networkInterfaces.Any())
				return null;

			var addressInfos = networkInterfaces[1].GetIPProperties().UnicastAddresses
				.Where(ai => ai.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork &&
					!ai.Address.ToString().StartsWith("169"))
				.ToArray();
			return !addressInfos.Any() ? null : addressInfos[0].Address;
		}
	}
}
