using System.Text.Json.Serialization;

public class ZabbixApiError {

    [JsonPropertyName("code")]
    public int? Code { get; set; }

    [JsonPropertyName("message")]
    public String? Message { get; set; }

    [JsonPropertyName("data")]
    public String? Data { get; set; }
}