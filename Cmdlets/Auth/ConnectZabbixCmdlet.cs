using System.Collections;
using System.Management.Automation;
using System.Text.Json;
using System.Text;

namespace Zbx_APIModule;

[Cmdlet("Connect", "Zabbix")]
public class ConnectZabbixCmdlet : PSCmdlet, IZabbixCmdlet
{
    private readonly HttpClient _client = ZabbixApiUtils.InitHttpClient(Constants.HttpTimeout);

    [Parameter(Mandatory = true)]
    public String ZabbixServer { get; set; }

    [Parameter(Mandatory = true)]
    public PSCredential Credential { get; set; }

    protected override void ProcessRecord()
    {
        var parameters = new Hashtable();
        parameters.Add("user", Credential.UserName);
        parameters.Add("password", Credential.GetNetworkCredential().Password);
        
        var result = ZabbixApiUtils.SendRequest(ZabbixServer, new ZabbixRequest {
            Method = "user.login",
            Params = parameters
        }, _client);

        if(result.Error != null) {
            throw new ZabbixApiAuthenticationException(result.Error);
        }

        WriteDebug(result.ToString());

        SessionState.PSVariable.Set(new PSVariable(Constants.ZabbixServerKeyNameVariable, ZabbixServer, ScopedItemOptions.Private));
        SessionState.PSVariable.Set(new PSVariable(Constants.TokenKeyNameVariable, result.Result, ScopedItemOptions.Private));
    }
}
