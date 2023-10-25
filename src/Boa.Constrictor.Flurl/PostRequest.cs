using System.Net.Http;

namespace Boa.Constrictor.Flurl
{
    public record struct PostRequest<TPayload>(string Path, TPayload Payload) : IRestAction
    {
        public HttpMethod Verb => HttpMethod.Post;
    }
}