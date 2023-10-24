using System.Net.Http;
using System.Threading.Tasks;
using Boa.Constrictor.Flurl.Abilities;
using Boa.Constrictor.Screenplay;
using Flurl.Http;

namespace Boa.Constrictor.Flurl.Interactions
{
    // public abstract class AbstractRestTask<TAbility, TData> : ITaskAsync
    //     where TAbility : IFlurlAbility
    // {
    //     public IFlurlRequest Request { get; set; }
    //     protected AbstractRestTask(IFlurlRequest request) => Request = request;
    //
    //     public async Task PerformAsAsync(IActor actor)
    //     {
    //         var client = actor.Using<IFlurlAbility>().Client;
    //         var response = await client.Request(Request.Url).SendAsync(HttpMethod.Post, );
    //
    //         await actor.Using<IFlurlAbility>().Client.Request().SendAsync(Request.Verb, Request.C)
    //         // await url.PostAsync(content); // a System.Net.Http.HttpContent object?/**/
    //         throw new System.NotImplementedException();
    //     }
    // }
}