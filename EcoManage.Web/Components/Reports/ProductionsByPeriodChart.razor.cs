using EcoManage.Domain.Entities.Reports;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Reports;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace EcoManage.Web.Components.Reports;

public class ProductionsByPeriodComponent : ComponentBase
{
    #region Properties

    public List<double> Data { get; set; } = [];
    public List<string> Labels { get; set; } = [];

    public List<ProductionsByPeriod> Productions { get; set; } = [];
    #endregion
    
    #region Services

    [Inject] public IReportHandler Handler { get; set; } = null!;
    [Inject] public ISnackbar Snackbar { get; set; } = null!;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        await GetProductionsAsync();
    }

    private async Task GetProductionsAsync()
    {
        var request = new GetProductionsByPeriodRequest();
        var result = await Handler.GetProductionsByPeriodAsync(request);
        
        if (!result.IsSuccess || result.Data is null)
        {
            Snackbar.Add("Falha ao obter os dados", Severity.Error);
            return;
        }

        Productions = result.Data;
        foreach (var item in result.Data)
        {
            Labels.Add($"{GetMonthName(item.Month)}");
            Data.Add(item.TotalProductions);
        }
    }

    public string GetMonthName(int month) 
        => System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);

    #endregion
}