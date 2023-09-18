using Flurl.Http;

namespace Boa.Constrictor.Flurl.UnitTests;

public class FirstTests
{
    [Fact]
    public async Task First()
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://dog.ceo/api")
        };

        IFlurlClient client = new FlurlClient(httpClient);
        
        

        var request = client.Request("/breeds/list/all");

        var result = await request.SendAsync(HttpMethod.Get);
        var json = await result.GetJsonAsync();
    }
}