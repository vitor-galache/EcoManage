namespace EcoManage.Domain.Requests.Product;

public class UpdateProductRequest : Request
{
    public long Id { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}