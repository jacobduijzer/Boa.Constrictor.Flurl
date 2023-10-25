using System;
using System.Threading.Tasks;
using Boa.Constrictor.Flurl.Abilities;
using Boa.Constrictor.Screenplay;
using Flurl.Http;

namespace Boa.Constrictor.Flurl.Interactions
{
    public abstract class AbstractRestTask<TAbility, TPayload> : ITaskAsync
        where TAbility : IFlurlAbility
    {
        public PostRequest<TPayload> Request { get; set; }
        
        protected AbstractRestTask(PostRequest<TPayload> request) => Request = request;
        
        protected abstract Task<IFlurlResponse> ExecuteAsync(IFlurlClient flurlClient);
       
        public async Task PerformAsAsync(IActor actor)
        {
            var ability = actor.Using<TAbility>();
            IFlurlResponse response = null;
            DateTime? start = null;
            DateTime? end = null;

            try
            {
                // Make the request
                start = DateTime.UtcNow;
                response = await ExecuteAsync(ability.Client);
                end = DateTime.UtcNow;

                // Log the response code
                actor.Logger.Info($"Response code: {(int)response.StatusCode}");
            }
            finally
            {
                // if (ability.CanDumpRequests())
                // {
                //     // Try to dump the request and the response
                //     string path = ability.RequestDumper.Dump(ability.Client, Request, response, start, end);
                //     actor.Logger.LogArtifact(ArtifactTypes.Requests, path);
                // }
                // else
                // {
                //     // Warn that the request will not be dumped
                //     actor.Logger.Debug("Request will not be dumped");
                // }
            }
        }
    }
}