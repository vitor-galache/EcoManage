namespace EcoManage.Domain.Requests.Production;

public class GetProductionByIdRequest : Request
{
    public long Id { get; set; }
}