using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KestrelServerMAUI.KestrelWebHost
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
		}

		public void Configure(IApplicationBuilder app)
		{
			app.Use(async (context, next) =>
			{
				context.Request.EnableBuffering();
				await next();
			});
			app.Run(WebApp.OnHttpRequest);
		}
	}
}
