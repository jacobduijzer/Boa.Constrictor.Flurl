using System.Net.Http;

namespace Boa.Constrictor.Flurl;

public record struct GetRequest(string Path) : IRestAction
{
    public HttpMethod Verb => HttpMethod.Get;

    public static GetRequest WithPath(string path) => new GetRequest(path);
}
