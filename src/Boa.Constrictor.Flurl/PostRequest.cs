using Flurl.Http;

namespace Boa.Constrictor.Flurl
{
    public class PostRequest<TData> : IRestAction<TData>
    {
        public TData Data { get; }
        public IFlurlRequest FlurlRequest { get; }
        
        private PostRequest(TData data)
        {
            Data = data;
        }
        
        public static PostRequest<TData> Create(TData data) =>
            new PostRequest<TData>(data);
    }
}