using System.Net;
using System.Net.Http.Headers;
using Boa.Constrictor.Flurl.Abilities;
using Boa.Constrictor.Flurl.Interactions;
using Boa.Constrictor.Screenplay;
using Boa.Constrictor.Xunit;
using Xunit.Abstractions;

namespace Boa.Constrictor.Flurl.UnitTests.Abilities;

public class GetMethodTests
{
    private const string ApiBaseUrl = "https://httpbin.org";
    private readonly ITestOutputHelper _output;
    
    public GetMethodTests(ITestOutputHelper output) =>
        _output = output;

    [Fact]
    public async Task GetRestCallShouldReturnOk()
    {
        // ARRANGE
        var actor = new Actor("Andy", new XunitLogger(_output));
        actor.Can(CallRestApi.At(ApiBaseUrl));

        var request = HttpBinApiCalls.GetRequest();
        var question = Rest.Request(request);
        
        // ACT
        var response = await actor.CallsAsync(question);
        
        // ASSERT
        Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
    }

    [Fact]
    public async Task GetRestCallShouldReturnResult()
    {
        // ARRANGE
        var actor = new Actor("Andy", new XunitLogger(_output));
        actor.Can(CallRestApi.At(ApiBaseUrl));

        var request = HttpBinApiCalls.GetRequest();
        var question = Rest.Request<HttpBinApiResult>(request);
        
        // ACT
        var response = await actor.CallsAsync(question);
        
        // ASSERT
        Assert.NotNull(response);
        Assert.Equal("httpbin.org", response.headers.Host);
    }
    
    [Fact]
    public async Task CanUseCustomHttpClient()
    {
        // ARRANGE
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri(ApiBaseUrl)
        };
        
        var actor = new Actor("Andy", new XunitLogger(_output));
        actor.Can(CallRestApi.Using(httpClient));
        var request = HttpBinApiCalls.GetRequest();
        var question = Rest.Request(request);
        
        // ACT
        var response = await actor.CallsAsync(question);
        
        // ASSERT
        Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
    }
    
    [Fact]
    public async Task CanSetCustomHeaders()
    {
        // ARRANGE
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
        var request = HttpBinApiCalls.GetRequest();
        var question = Rest.Request<HttpBinApiResult>(request);
        
        // ACT
        var response = await actor.CallsAsync(question);
        
        // ASSERT
        Assert.Equal("application/json", response.headers.Accept);
    }
}