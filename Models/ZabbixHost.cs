public enum HostStatus
{
    MONITORED = 0,
    UNMONITORED = 1
}

public enum IpmiAuthType {
    DEFAULT = -1,
    NONE = 0,
    MD2 = 1,
    MD5 = 2,
    STRAIGHT = 4,
    OEM = 5,
    RMCP = 6
}

public class ZabbixHost {
    public int HostId { get; set; }
    public int ProxyHostid { get; set; }
    public String Host { get; set; }
    public HostStatus Status { get; set; }
    public IpmiAuthType IpmiAuthType { get; set; }
    
}

{
  "jsonrpc": "2.0",
  "result": [
    {
      "hostid": "10084",
      "proxy_hostid": "0",
      "host": "Zabbix server",
      "status": "0",
      "ipmi_authtype": "-1",
      "ipmi_privilege": "2",
      "ipmi_username": "",
      "ipmi_password": "",
      "maintenanceid": "0",
      "maintenance_status": "0",
      "maintenance_type": "0",
      "maintenance_from": "0",
      "name": "Zabbix server",
      "flags": "0",
      "templateid": "0",
      "description": "",
      "tls_connect": "1",
      "tls_accept": "1",
      "tls_issuer": "",
      "tls_subject": "",
      "proxy_address": "",
      "auto_compress": "1",
      "custom_interfaces": "0",
      "uuid": "",
      "inventory_mode": "1",
      "active_available": "1"
    }
  ],
  "id": 1
}