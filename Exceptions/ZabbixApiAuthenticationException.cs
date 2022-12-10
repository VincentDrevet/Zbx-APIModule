public class ZabbixApiAuthenticationException : Exception {
    public ZabbixApiAuthenticationException()
    {
        
    }

    public ZabbixApiAuthenticationException(ZabbixApiError error)
        : base(String.Format("{0} - {1} - {2}", error.Code, error.Message, error.Data))
    {
        
    }
}