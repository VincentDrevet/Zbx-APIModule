public class ZabbixApiNotConnectedException : Exception {
    public ZabbixApiNotConnectedException()
    {
        
    }

    public ZabbixApiNotConnectedException(String error)
        : base(error)
    {
        
    }
}