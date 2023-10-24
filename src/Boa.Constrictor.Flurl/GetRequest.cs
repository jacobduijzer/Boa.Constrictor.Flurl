using System.Net.Http;

namespace Boa.Constrictor.Flurl;

public record struct GetRequest(HttpMethod Verb, string Url) : IRestAction
{
}