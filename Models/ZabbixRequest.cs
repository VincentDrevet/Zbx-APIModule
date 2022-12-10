using System.Collections;
using System.Text.Json.Serialization;

class ZabbixRequest
{
    [JsonPropertyName("jsonrpc")]
    public String JsonRPC { get; set; } = "2.0";

    [JsonPropertyName("method")]
    public String Method { get; set; } = "";

    [JsonPropertyName("params")]
    public Hashtable Params { get; set; } = new Hashtable();

    [JsonPropertyName("id")]
    public int Id { get; set; } = 1;

    [JsonPropertyName("auth")]
    public String? Auth { get; set; } = null;
}