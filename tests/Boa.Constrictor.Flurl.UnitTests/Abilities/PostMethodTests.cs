using Boa.Constrictor.Flurl.Abilities;
using Boa.Constrictor.Screenplay;

namespace Boa.Constrictor.Flurl.UnitTests.Abilities;

public class PostMethodTests
{
    // [Fact]
    // public async Task PostRestCallShouldReturnOk()
    // {
    //     var httpClient = new HttpClient
    //     {
    //         BaseAddress = new Uri(ApiBaseUrl),
    //         DefaultRequestHeaders =
    //         {
    //             Accept = { new MediaTypeWithQualityHeaderValue("application/json") }
    //         }
    //     };
    //     
    //     var actor = new Actor("Andy", new XunitLogger(_output));
    //     actor.Can(CallRestApi.Using(httpClient));
    //
    //     var postData = HttpBinApiCalls.PostWithData("test");
    //     // var response = await actor.CallsAsync(Rest.Request<HttpBinApiResult>(request));
    //     // new PostObject<IRestAction<string>>(postData)
    //     await actor.AttemptsToAsync(Rest.Submit(postData));
    //     // Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode); 
    // }
 
}

public class PostObject<T> : ITaskAsync
{
    private readonly T _data;

    // public Task<TAnswer> RequestAsAsync(IActor actor)
    // {
    //    var ability = actor.Using<IFlurlAbility>();
    //    return default;
    // }
    public PostObject(T data) => _data = data;

    public Task PerformAsAsync(IActor actor)
    {
        var test = actor.Using<IFlurlAbility>().Client.Request(_data);
        return default;
    }
}
    
// var result = await "https://api.mysite.com"
//     .AppendPathSegment("person")
//     .SetQueryParams(new { api_key = "xyz" })
//     .WithOAuthBearerToken("my_oauth_token")
//     .PostJsonAsync(new { first_name = firstName, last_name = lastName })
//     .ReceiveJson<T>();
// client.Request()