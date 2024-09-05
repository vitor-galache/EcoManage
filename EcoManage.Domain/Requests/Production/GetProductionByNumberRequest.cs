namespace EcoManage.Domain.Requests.Production;

public class GetProductionByNumberRequest : Request
{
    public string Number { get; set; } = string.Empty;
}