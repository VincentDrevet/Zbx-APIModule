using System.Text.Json.Serialization;

class ZAbbixResponse {
    
    [JsonPropertyName("jsonrpc")]
    public String JsonRPC { get; set; } = "2.0";

    [JsonPropertyName("result")]
    public dynamic Result { get; set; }

    [JsonPropertyName("error")]
    public ZabbixApiError Error { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    public override String ToString() {
        return string.Format("jsonrpc : {0}, result : {1}, id : {2}", this.JsonRPC, this.Result, this.Id);
    }

}