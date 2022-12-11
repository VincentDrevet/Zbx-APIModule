using System.Collections;
using System.Text;
using System.Text.Json;
class ZabbixApiUtils
{
    public static ZAbbixResponse SendRequest(String ZabbixServer, ZabbixRequest request, HttpClient _client) {

        var payload = JsonSerializer.Serialize(request);

        var response = _client.PostAsync(ZabbixServer, new StringContent(payload, Encoding.UTF8, "application/json")).Result;

        var content = response.Content.ReadAsStringAsync().Result;

        var result = JsonSerializer.Deserialize<ZAbbixResponse>(response.Content.ReadAsStream());

        return result;

    }

    public static HttpClient InitHttpClient(TimeSpan timeout) {
        var client = new HttpClient();

        client.Timeout = timeout;

        return client;
    }
}