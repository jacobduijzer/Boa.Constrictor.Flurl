using Flurl.Http;

namespace Boa.Constrictor.Flurl.UnitTests;

public static class HttpBinApiCalls
{
    public static IFlurlRequest GetRequest() => 
        new FlurlRequest("/get")
        {
            Verb = HttpMethod.Get
        };

    public static IFlurlRequest GetWithParameters() =>
        new FlurlRequest("/get?test-param=true&second-test-param=false")
        {
            Verb = HttpMethod.Get
        };

    public static IFlurlRequest Post() =>
        new FlurlRequest("/post")
        {
            Verb = HttpMethod.Post
        };

    public static IRestAction<TData> PostWithData<TData>(TData data) =>
        PostRequest<TData>.Create(data);
}