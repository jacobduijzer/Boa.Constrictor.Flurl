using System;
using System.Threading.Tasks;
using Boa.Constrictor.Flurl.Abilities;
using Boa.Constrictor.Screenplay;
using Flurl.Http;

namespace Boa.Constrictor.Flurl.Interactions
{
    public abstract class AbstractRestQuestion<TAbility, TAnswer> : IQuestionAsync<TAnswer>
        where TAbility : IFlurlAbility
    {
        /// <summary>
        /// The REST request to call.
        /// </summary>

        public IRestAction RestAction { get; set; }
        
        protected AbstractRestQuestion(IRestAction restAction) => RestAction = restAction;

        protected abstract Task<IFlurlResponse> ExecuteAsync(IFlurlClient flurlClient);

        public abstract Task<TAnswer> RequestAsAsync(IActor actor);

        protected async Task<IFlurlResponse> CallRequestAsync(IActor actor)
        {
            // Prepare variables
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

            // Return the response object
            return response;
        }
    }
}