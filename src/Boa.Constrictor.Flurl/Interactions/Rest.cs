using Boa.Constrictor.Flurl.Abilities;
using Flurl.Http;

namespace Boa.Constrictor.Flurl.Interactions
{
    public static class Rest
    {
        public static RestApiCall<CallRestApi> Request(IRestAction restAction) =>
            new RestApiCall<CallRestApi>(restAction);
        
        public static RestApiCall<CallRestApi, TData> Request<TData>(IRestAction restAction) =>
            new RestApiCall<CallRestApi, TData>(restAction);

        // public static RestApiTask<CallRestApi> Submit<TData>(PostRequest<TData> request) =>
        //     new RestApiTask<CallRestApi>(request);
    }
}