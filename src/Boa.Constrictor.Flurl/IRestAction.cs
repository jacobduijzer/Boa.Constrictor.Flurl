using System.Net.Http;

namespace Boa.Constrictor.Flurl
{
    public interface IRestAction
    {
       HttpMethod Verb { get; set; } 
       
       string Url { get; set; }
    }
}