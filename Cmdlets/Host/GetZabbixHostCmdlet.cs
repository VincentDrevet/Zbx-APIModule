using System.Collections;
using System.Management.Automation;

[Cmdlet(VerbsCommon.Get, "ZabbixHost")]
public class GetZabbixHostCmdlet : PSCmdlet, IZabbixCmdlet
{
    private readonly HttpClient _client = ZabbixApiUtils.InitHttpClient(Constants.HttpTimeout);

    protected override void BeginProcessing()
    {
        if(SessionState.PSVariable.Get(Constants.ZabbixServerKeyNameVariable) == null) {
            WriteDebug(String.Format("Internal variable {0} not set", Constants.ZabbixServerKeyNameVariable));
            throw new ZabbixApiNotConnectedException("Authentication required.");
        }

        if(SessionState.PSVariable.Get(Constants.TokenKeyNameVariable) == null) {
            WriteDebug(String.Format("Internal variable {0} not set", Constants.TokenKeyNameVariable));
            throw new ZabbixApiNotConnectedException("Authentication required.");
        }

    }

    protected override void ProcessRecord()
    {
        var result = ZabbixApiUtils.SendRequest(SessionState.PSVariable.Get(Constants.ZabbixServerKeyNameVariable).Value.ToString(), new ZabbixRequest {
            Method = "host.get",
            Auth = SessionState.PSVariable.Get(Constants.TokenKeyNameVariable).Value.ToString()
        }, _client);

        if(result.Error != null) {
            throw new ZabbixApiAuthenticationException(result.Error);
        }

        WriteDebug(result.ToString());

        WriteObject(result);
    }
}