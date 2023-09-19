using System.Text.Json.Serialization;

namespace Boa.Constrictor.Flurl.UnitTests;

public class HttpBinApiResult
{
    [JsonPropertyName("args")]
    public Args args { get; set; }

    [JsonPropertyName("headers")]
    public Headers headers { get; set; }

    [JsonPropertyName("origin")]
    public string origin { get; set; }

    [JsonPropertyName("url")]
    public string url { get; set; }
}

public class Args
{
    [JsonPropertyName("second-test-param")]
    public string secondtestparam { get; set; }

    [JsonPropertyName("test-param")]
    public string testparam { get; set; }
}

public class Headers
{
    [JsonPropertyName("Accept")]
    public string Accept { get; set; }

    [JsonPropertyName("Accept-Encoding")]
    public string AcceptEncoding { get; set; }

    [JsonPropertyName("Accept-Language")]
    public string AcceptLanguage { get; set; }

    [JsonPropertyName("Host")]
    public string Host { get; set; }

    [JsonPropertyName("Referer")]
    public string Referer { get; set; }

    [JsonPropertyName("Sec-Ch-Ua")]
    public string SecChUa { get; set; }

    [JsonPropertyName("Sec-Ch-Ua-Mobile")]
    public string SecChUaMobile { get; set; }

    [JsonPropertyName("Sec-Ch-Ua-Platform")]
    public string SecChUaPlatform { get; set; }

    [JsonPropertyName("Sec-Fetch-Dest")]
    public string SecFetchDest { get; set; }

    [JsonPropertyName("Sec-Fetch-Mode")]
    public string SecFetchMode { get; set; }

    [JsonPropertyName("Sec-Fetch-Site")]
    public string SecFetchSite { get; set; }

    [JsonPropertyName("User-Agent")]
    public string UserAgent { get; set; }

    [JsonPropertyName("X-Amzn-Trace-Id")]
    public string XAmznTraceId { get; set; }
}