using Flurl.Http;

namespace Boa.Constrictor.Flurl.Abilities
{
    public class AbstractFlurlAbility : IFlurlAbility
    {
        public IFlurlClient Client { get; }

        protected AbstractFlurlAbility(IFlurlClient flurlClient) =>
            Client = flurlClient;
    }
}