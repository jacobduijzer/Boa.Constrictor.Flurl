using System.Net;
using Boa.Constrictor.Flurl.Abilities;
using Boa.Constrictor.Flurl.Interactions;
using Boa.Constrictor.Screenplay;
using Boa.Constrictor.Xunit;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit.Abstractions;

namespace ExampleApi.Tests;

public class ApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly Actor _actor;

    public ApiTests(ITestOutputHelper output, WebApplicationFactory<Program> factory)
    {
        _actor = new Actor("Andy", new XunitLogger(output));
        _actor.Can(CallRestApi.Using(factory.CreateClient()));
    }

    [Fact]
    public async Task GetShouldReturnOk()
    {
        var request = GetRequest();
        var question = Rest.Request(request);
        
        var response = await _actor.CallsAsync(question);

        Assert.Equal(HttpStatusCode.OK, (HttpStatusCode) response.StatusCode);
    }

    [Fact]
    public async Task GetShouldReturnAResult()
    {
        var request = GetRequest();
        var question = Rest.Request<string>(request);
        
        var response = await _actor.CallsAsync(question);
        
        Assert.Equal("Hello World!", response);
    }
    
    private static IFlurlRequest GetRequest() => 
        new FlurlRequest("/")
        {
            Verb = HttpMethod.Get
        };
}