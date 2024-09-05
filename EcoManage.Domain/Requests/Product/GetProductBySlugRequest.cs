namespace EcoManage.Domain.Requests.Product;

public class GetProductBySlugRequest : Request
{
    public string Slug { get; set; } = string.Empty;
}