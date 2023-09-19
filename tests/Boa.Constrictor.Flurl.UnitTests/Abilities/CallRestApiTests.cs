using System.Net;
using System.Net.Http.Headers;
using Boa.Constrictor.Flurl.Abilities;
using Boa.Constrictor.Flurl.Interactions;
using Boa.Constrictor.Screenplay;
using Boa.Constrictor.Xunit;
using Xunit.Abstractions;

namespace Boa.Constrictor.Flurl.UnitTests.Abilities;

public class CallRestApiTests
{
    private const string ApiBaseUrl = "https://httpbin.org";
    private readonly ITestOutputHelper _output;
    
    public CallRestApiTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async Task GetRestCallShouldReturnOk()
    {
        var actor = new Actor("Andy", new XunitLogger(_output));
        actor.Can(CallRestApi.Using(ApiBaseUrl));

        var request = HttpBinApiCalls.Get();
        var response = await actor.CallsAsync(Rest.Request(request));
        
        Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
    }

    [Fact]
    public async Task GetRestCallShouldReturnResult()
    {
        var actor = new Actor("Andy", new XunitLogger(_output));
        actor.Can(CallRestApi.Using(ApiBaseUrl));

        var request = HttpBinApiCalls.Get();
        var response = await actor.CallsAsync(Rest.Request<HttpBinApiResult>(request));
        
        Assert.NotNull(response);
        Assert.Equal("httpbin.org", response.headers.Host);
    }
    
    [Fact]
    public async Task CanUseCustomHttpClient()
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri(ApiBaseUrl)
        };
        
        var actor = new Actor("Andy", new XunitLogger(_output));
        actor.Can(CallRestApi.Using(httpClient));

        var request = HttpBinApiCalls.Get();
        var response = await actor.CallsAsync(Rest.Request(request));
        
        Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
    }
    
    [Fact]
    public async Task CanSetCustomHeaders()
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri(ApiBaseUrl),
            DefaultRequestHeaders =
            {
                Accept = { new MediaTypeWithQualityHeaderValue("application/json") }
            }
        };
        
        var actor = new Actor("Andy", new XunitLogger(_output));
        actor.Can(CallRestApi.Using(httpClient));

        var request = HttpBinApiCalls.Get();
        var response = await actor.CallsAsync(Rest.Request<HttpBinApiResult>(request));
        
        Assert.Equal("application/json", response.headers.Accept);
    }

    [Fact]
    public async Task PostRestCallShouldReturnOk()
    {
        var actor = new Actor("Andy", new XunitLogger(_output));
        actor.Can(CallRestApi.Using(ApiBaseUrl));
    
        var request = HttpBinApiCalls.Post();
        var response = await actor.CallsAsync(Rest.Request(request));
        await actor.AttemptsToAsync()
        
        Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode); 
    }
   
}