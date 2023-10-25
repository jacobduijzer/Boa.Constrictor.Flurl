using System;
using System.Net.Http;
using System.Threading.Tasks;
using Boa.Constrictor.Flurl.Abilities;
using Boa.Constrictor.Screenplay;
using Flurl.Http;
using Flurl.Http.Content;

namespace Boa.Constrictor.Flurl.Interactions
{
    public class RestApiCall<TAbility> : AbstractRestQuestion<TAbility, IFlurlResponse>
        where TAbility : IFlurlAbility
    {
        internal RestApiCall(IRestAction restAction) : base(restAction)
        {
        }

        protected override async Task<IFlurlResponse> ExecuteAsync(IFlurlClient flurlClient)
        {
            var response = await flurlClient.Request(RestAction.Path).SendAsync(RestAction.Verb);
            return response;
        }

        public override async Task<IFlurlResponse> RequestAsAsync(IActor actor) =>
            await CallRequestAsync(actor);
    }

    public class RestApiCall<TAbility, TData> : AbstractRestQuestion<TAbility, TData>
        where TAbility : IFlurlAbility
    {
        internal RestApiCall(IRestAction restAction) : base(restAction)
        {
        }
    
        protected override async Task<IFlurlResponse> ExecuteAsync(IFlurlClient flurlClient) =>
            await flurlClient.Request(RestAction.Path).SendAsync(RestAction.Verb);

        public override async Task<TData> RequestAsAsync(IActor actor)
        {
            var ability = actor.Using<TAbility>();

            if (typeof(TData) != typeof(string)) 
                return await ability.Client.Request(RestAction.Path).GetJsonAsync<TData>();
            
            var value = await ability.Client.Request(RestAction.Path).GetStringAsync();
            return (TData)Convert.ChangeType(value, typeof(TData));
        }
    }

    public class RestApiTask<TAbility, TPayload> : AbstractRestTask<TAbility, TPayload>
        where TAbility : IFlurlAbility
    {
        public RestApiTask(PostRequest<TPayload> request) : base(request)
        {
            
        }

        protected override async Task<IFlurlResponse> ExecuteAsync(IFlurlClient flurlClient)
        {
            var body = new { name = "Jacob" };
            // return await flurlClient
            //     .Request(Request.Path)
            //     .PostUrlEncodedAsync(body);

            return await flurlClient
                .Request(Request.Path)
                .SetQueryParam("name", "Jacob")
                .PostAsync();

            // await "http://some-api.com".PostUrlEncodedAsync(body);

        }
        //     await flurlClient.Request(Request.Path)
        //         .PostStringAsync()
        //         .PostStringAsync(Request.Payload.ToString());
        // var body = new { a = 1, b = 2, c = "hi there", d = new[] { 1, 2, 3 } };
        // await "http://some-api.com".PostUrlEncodedAsync(body);
        // .PostMultipartAsync(x => x.AddString("name", "Jacob"));
        // .PostAsync(new StringContent(Request.Payload.ToString()));
        // .SendAsync(Request.Verb, new (Request.Payload.ToString()));
    }
}