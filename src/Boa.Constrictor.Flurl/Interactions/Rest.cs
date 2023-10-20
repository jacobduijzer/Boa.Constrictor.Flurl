using Boa.Constrictor.Flurl.Abilities;
using Flurl.Http;

namespace Boa.Constrictor.Flurl.Interactions
{
    public static class Rest
    {
        public static RestApiCall<CallRestApi> Request(IFlurlRequest request) =>
            new RestApiCall<CallRestApi>(request);
        
        public static RestApiCall<CallRestApi, TData> Request<TData>(IFlurlRequest request) =>
            new RestApiCall<CallRestApi, TData>(request);

        // public static RestApiTask<CallRestApi> Submit<TData>(PostRequest<TData> request) =>
        //     new RestApiTask<CallRestApi>(request);
    }
}