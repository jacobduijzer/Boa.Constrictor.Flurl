using System.Net.Http;
using Flurl.Http;

namespace Boa.Constrictor.Flurl.Abilities
{
    public class CallRestApi : AbstractFlurlAbility
    {
        private CallRestApi(IFlurlClient flurlClient) : base(flurlClient)
        {
            
        }

        public static CallRestApi Using(string baseUrl) =>
            new CallRestApi(new FlurlClient(baseUrl));

        public static CallRestApi Using(HttpClient httpClient) =>
            new CallRestApi(new FlurlClient(httpClient));
    }
}