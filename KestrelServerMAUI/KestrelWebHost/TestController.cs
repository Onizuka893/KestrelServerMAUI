using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using Microsoft.AspNetCore.Http;


namespace KestrelServerMAUI.KestrelWebHost;

public class TestController : WebApiController
{
    [Route(HttpVerbs.Get, "/api/people")]
    public Task<IEnumerable<string>> test()
    {
        return null;
    }
}