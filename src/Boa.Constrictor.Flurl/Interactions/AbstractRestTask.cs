using System.Threading.Tasks;
using Boa.Constrictor.Flurl.Abilities;
using Boa.Constrictor.Screenplay;
using Flurl.Http;

namespace Boa.Constrictor.Flurl.Interactions
{
    public abstract class AbstractRestTask<TAbility, TData> : ITaskAsync
        where TAbility : IFlurlAbility
    {
        public IFlurlRequest Request { get; set; }
        protected AbstractRestTask(IFlurlRequest request) => Request = request;

        public Task PerformAsAsync(IActor actor)
        {
            throw new System.NotImplementedException();
        }
    }
}