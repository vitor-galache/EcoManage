using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Reports;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace EcoManage.Web.Components.Reports;

public class TotalProductsChartComponent : ComponentBase
{
    #region Properties

    public List<double> Data { get; set; } = [];
    public List<string> Labels { get; set; } = [];

    #endregion

    #region Services

    [Inject] public IReportHandler Handler { get; set; } = null!;
    [Inject] public ISnackbar Snackbar { get; set; } = null!;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        await GetTotalProductsAsync();
    }

    private async Task GetTotalProductsAsync()
    {
        var request = new GetTotalProductsRequest();
        var result = await Handler.GetTotalProductsAsync(request);
        if (!result.IsSuccess || result.Data is null)
        {
            Snackbar.Add("Falha ao obter os dados", Severity.Error);
            return;
        }
        
        foreach (var item in result.Data)
        {
            Labels.Add($"{item.Product}");
            Data.Add((double)item.TotalProduced);
        }
    }

    #endregion
}