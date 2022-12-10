using System.Collections;
using System.Text;
using System.Text.Json;
class ZabbixApiUtils
{
    public static ZAbbixResponse SendRequest(String ZabbixServer, Hashtable parameters, String method, HttpClient _client) {

        var payload = JsonSerializer.Serialize(new ZabbixRequest {
            Params = parameters,
            Method = method
        });

        var response = _client.PostAsync(ZabbixServer, new StringContent(payload, Encoding.UTF8, "application/json")).Result;

        var content = response.Content.ReadAsStringAsync().Result;

        var result = JsonSerializer.Deserialize<ZAbbixResponse>(response.Content.ReadAsStream());

        return result;

    }
}