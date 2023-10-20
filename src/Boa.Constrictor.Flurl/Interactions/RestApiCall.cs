using System;
using System.Threading.Tasks;
using Boa.Constrictor.Flurl.Abilities;
using Boa.Constrictor.Screenplay;
using Flurl.Http;

namespace Boa.Constrictor.Flurl.Interactions
{
    public class RestApiCall<TAbility> : AbstractRestQuestion<TAbility, IFlurlResponse>
        where TAbility : IFlurlAbility
    {
        internal RestApiCall(IFlurlRequest request) : base(request)
        {
        }

        protected override async Task<IFlurlResponse> ExecuteAsync(IFlurlClient flurlClient)
        {
            var response = await flurlClient.Request(Request.Url).SendAsync(Request.Verb);
            return response;
        }

        public override async Task<IFlurlResponse> RequestAsAsync(IActor actor) =>
            await CallRequestAsync(actor);
    }

    public class RestApiCall<TAbility, TData> : AbstractRestQuestion<TAbility, TData>
        where TAbility : IFlurlAbility
    {
        internal RestApiCall(IFlurlRequest request) : base(request)
        {
        }
    
        protected override async Task<IFlurlResponse> ExecuteAsync(IFlurlClient flurlClient) =>
            await flurlClient.Request(Request.Url).SendAsync(Request.Verb);

        public override async Task<TData> RequestAsAsync(IActor actor)
        {
            var ability = actor.Using<TAbility>();

            if (typeof(TData) != typeof(string)) 
                return await ability.Client.Request(Request.Url).GetJsonAsync<TData>();
            
            var value = await ability.Client.Request(Request.Url).GetStringAsync();
            return (TData)Convert.ChangeType(value, typeof(TData));
        }
    }

    // public class RestApiTask<TAbility, TData> : AbstractRestTask<TAbility>
    //     where TAbility : IFlurlAbility
    // {
    //     private readonly PostRequest<TData> _data;
    //     public RestApiTask(PostRequest<TData> request) : base(request);
    // }
}