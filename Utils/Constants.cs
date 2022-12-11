public static class Constants {
    public static TimeSpan HttpTimeout { get; } = TimeSpan.FromSeconds(30);

    public static String TokenKeyNameVariable {get;} = "ZbxToken";

    public static String ZabbixServerKeyNameVariable {get;} = "ZbxServer";
}