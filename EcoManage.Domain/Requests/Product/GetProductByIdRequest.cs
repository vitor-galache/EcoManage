namespace EcoManage.Domain.Requests.Product;

public class GetProductByIdRequest : Request
{
    public long Id { get; set; }
}