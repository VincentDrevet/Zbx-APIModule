using System.Collections;
using System.Management.Automation;
using System.Text.Json;
using System.Text;

namespace Zbx_APIModule;

[Cmdlet("Connect", "Zabbix")]
public class ConnectZabbixCmdlet : PSCmdlet
{
    private readonly HttpClient _client = new HttpClient();

    [Parameter(Mandatory = true)]
    public String ZabbixServer { get; set; }

    [Parameter(Mandatory = true)]
    public PSCredential Credential { get; set; }

    protected override void ProcessRecord()
    {
        var parameters = new Hashtable();
        parameters.Add("user", Credential.UserName);
        parameters.Add("password", Credential.GetNetworkCredential().Password);
        
        var result = ZabbixApiUtils.SendRequest(ZabbixServer, parameters, "user.login", _client);

        if(result.Error != null) {
            throw new ZabbixApiAuthenticationException(result.Error);
        }

        WriteDebug(result.ToString());

        SessionState.PSVariable.Set(new PSVariable("apikey", result.Result, ScopedItemOptions.Private));
    }
}
