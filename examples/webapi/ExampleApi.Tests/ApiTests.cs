using System.Net;
using Boa.Constrictor.Flurl;
using Boa.Constrictor.Flurl.Abilities;
using Boa.Constrictor.Flurl.Interactions;
using Boa.Constrictor.Screenplay;
using Boa.Constrictor.Xunit;
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
        var question = Rest.Request(GetRequest.WithPath("/"));
        
        var response = await _actor.CallsAsync(question);

        Assert.Equal(HttpStatusCode.OK, (HttpStatusCode) response.StatusCode);
    }

    [Fact]
    public async Task GetShouldReturnAResult()
    {
        var question = Rest.Request<string>(GetRequest.WithPath("/"));
        
        var response = await _actor.CallsAsync(question);
        
        Assert.Equal("Hello World!", response);
    }

    [Fact]
    public async Task PostCanSendData()
    {
        var answer = Rest.Submit(new PostRequest<string>("/hello", "Jacob"));

        await _actor.CallsAsync(answer);
    }
}