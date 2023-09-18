using Boa.Constrictor.Screenplay;
using Flurl.Http;

namespace Boa.Constrictor.Flurl.Abilities
{
    public interface IFlurlAbility : IAbility
    {
       IFlurlClient Client { get; } 
    }
}