using Boa.Constrictor.Flurl.Abilities;
using Flurl.Http;

namespace Boa.Constrictor.Flurl.Interactions
{
    public static class Rest
    {
        public static RestApiCall<CallRestApi> Request(IRestAction restAction) =>
            new RestApiCall<CallRestApi>(restAction);
        
        public static RestApiCall<CallRestApi, TPayload> Request<TPayload>(IRestAction restAction) =>
            new RestApiCall<CallRestApi, TPayload>(restAction);

        public static RestApiTask<CallRestApi, TPayload> Submit<TPayload>(PostRequest<TPayload> request) =>
            new RestApiTask<CallRestApi, TPayload>(request);
    }
}