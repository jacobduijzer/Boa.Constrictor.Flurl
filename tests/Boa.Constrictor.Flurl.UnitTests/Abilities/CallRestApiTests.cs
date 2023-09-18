using System.Net;
using Boa.Constrictor.Flurl.Abilities;
using Boa.Constrictor.Flurl.Interactions;
using Boa.Constrictor.Screenplay;
using Boa.Constrictor.Xunit;
using Flurl.Http;
using Xunit.Abstractions;

namespace Boa.Constrictor.Flurl.UnitTests.Abilities;

public class CallRestApiTests
{
    private readonly ITestOutputHelper _output;
    
    public CallRestApiTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async Task BasicRestCallShouldReturnOk()
    {
        var actor = new Actor("Andy", new XunitLogger(_output));
        actor.Can(CallRestApi.Using("https://dog.ceo/api"));

        var request = DogRequests.GetRandomDog();
        var response = await actor.CallsAsync(Rest.Request(request));
        
        Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
    }

    [Fact]
    public async Task BasicRestCallShouldReturnResult()
    {
        var actor = new Actor("Andy", new XunitLogger(_output));
        actor.Can(CallRestApi.Using("https://dog.ceo/api"));
    
        var request = DogRequests.GetRandomDog();
        var response = await actor.CallsAsync(Rest.Request<DogResponse>(request));
        Assert.Equal("success", response.Status);
        Assert.NotEmpty(response.Message);
    }

    public static class DogRequests
    {
        public static IFlurlRequest GetRandomDog()
        {
            var request = new FlurlRequest("/breeds/image/random");
            request.Verb = HttpMethod.Get;

            return request;
        }
    }
    
    public class DogResponse
    {
        public string Message { get; set; }
        public string Status { get; set; }
    }
}