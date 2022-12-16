using Microsoft.AspNetCore.Http;
using System.Net.WebSockets;
using System.Text;
using System;
using EmbedIO;
using EmbedIO.Actions;
using EmbedIO.Files;
using Swan.Logging;

namespace KestrelServerMAUI.KestrelWebHost
{
	public static class WebApp
	{
		public static Task<HttpResponse> OnHttpRequest(HttpContext httpContext)
		{
			var response = httpContext.Response;
			return Task.FromResult(response);
		}
	}
}