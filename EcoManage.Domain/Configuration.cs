namespace EcoManage.Domain;

public class Configuration
{
    public const int DefaultPageSize = 25;
    public const int DefaultPageNumber = 1;
    public const int DefaultStatusCode = 200;
    
    public static string ConnectionString = string.Empty;
    public static string BackendUrl = string.Empty;
    public static string FrontendUrl = string.Empty;
}