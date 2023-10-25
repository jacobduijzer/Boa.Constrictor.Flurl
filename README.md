[![.NET](https://github.com/jacobduijzer/Boa.Constrictor.Flurl/actions/workflows/dotnet.yml/badge.svg)](https://github.com/jacobduijzer/Boa.Constrictor.Flurl/actions/workflows/dotnet.yml)
# Boa.Constrictor.Flurl

This is a __work in progress__, please do __not__ use any of this code yet!. The aim of this project is to implement the Screenplay Pattern with Flurl. 
The already existing REST plugin, which uses RestSharp, can not be used with the `WebApplicationFactory`, because it is not possible to use an already existing HttpClient.

## Usage
 
Using the `HttpClient` from the `WebApplicationFactory`:
```csharp
// ARRANGE
Actor actor = new ("Andy", new XunitLogger(output));
actor.Can(CallRestApi.Using(factory.CreateClient()));
var question = Rest.Request(GetRequest.WithPath("/"));
    
// ACT
var response = await _actor.CallsAsync(question);

// ASSERT
Assert.Equal(HttpStatusCode.OK, (HttpStatusCode) response.StatusCode);
```

Using a custom url:
```csharp
// ARRANGE
Actor actor = new ("Andy", _logger);
actor.Can(CallRestApi.At("https://httpbin.org"));
var question = Rest.Request(GetRequest.WithPath("/get"));
        
// ACT
var response = await actor.CallsAsync(question);

// ASSERT
Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
```

## Links

* [Boa Constrictor - The .NET Screenplay Pattern](https://q2ebanking.github.io/boa-constrictor/)
* [Boa Constrictor GitHub repository](https://github.com/q2ebanking/boa-constrictor)
* [Flurl](https://flurl.dev)