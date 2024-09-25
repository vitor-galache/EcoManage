using EcoManage.Domain.Entities.Productions;
using EcoManage.Domain.Handlers;
using EcoManage.Domain.Requests.Production;
using EcoManage.Web.Pages.Productions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace EcoManage.Web.Components.Productions;

public partial class ProductionActionsComponent : ComponentBase
{
    #region Properties

    [CascadingParameter] public DetailsProductionPage Parent { get; set; } = null!;

    [Parameter, EditorRequired] public Production Production { get; set; } = null!;

    #endregion


    #region Services

    [Inject] public IDialogService DialogService { get; set; } = null!;

    [Inject] public IProductionHandler ProductionHandler { get; set; } = null!;

    [Inject] public ISnackbar Snackbar { get; set; } = null!;

    #endregion


    #region Public Methods
    
    
    public async void OnToCultivationButtonClickedAsync()
    {
        var result = await DialogService.ShowMessageBox("ATENÇÃO", "Deseja encaminhar está produção para cultivo?", "SIM", "NÃO");
        if (result is not null && result == true)
            await ToCultivation();
    }
    
    public async void OnToHarvestButtonClickedAsync()
    {
        var result = await DialogService.ShowMessageBox("ATENÇÃO", "Deseja encaminhar está produção para colheita?", "SIM", "NÃO");
        if (result is not null && result == true)
            await ToHarvestingAsync();
    }
    
    public async void OnCancelButtonClickedAsync()
    {
        var result = await DialogService.ShowMessageBox("ATENÇÃO", "A produção será cancelada, deseja realmente prosseguir?", "SIM", "NÃO");
        if (result is not null && result == true)
            await CancelProductionAsync();
    }

    public async void OnFinishButtonClickedAsync()
    {
        var result = await DialogService.ShowMessageBox("ATENÇÃO", "A produção será finalizada, deseja prosseguir?", "SIM", "NÃO");
        if (result is not null && result == true)
            await FinishProductionAsync();
    }
    
    #endregion


    #region Private Methods
    
    private async Task ToCultivation()
    {
        var request = new UpdateProductionToCultivationRequest { Id = Production.Id};
        var result = await ProductionHandler.ToCultivationAsync(request);
        if (result.IsSuccess)
        {
            Snackbar.Add($"Produção {Production.Number} em cultivo", Severity.Info);
            Parent.RefreshState(result.Data!);
        }
        else
            Snackbar.Add(result.Message, Severity.Error);
    }
    
    private async Task ToHarvestingAsync()
    { 
        var request = new UpdateProductionToHarvestRequest { Id = Production.Id };
        var result = await ProductionHandler.ToHarvestAsync(request);
        if (result.IsSuccess)
        {
            Snackbar.Add($"Produção {Production.Number} encaminhada para colheita", Severity.Info);
            Parent.RefreshState(result.Data!);
        }
        else
            Snackbar.Add(result.Message, Severity.Error);
    }

    private async Task FinishProductionAsync()
    {
        var request = new FinishProductionRequest() { Id = Production.Id };
        var result = await ProductionHandler.FinishAsync(request);
        if (result.IsSuccess)
        {
            Snackbar.Add("Produção finalizada com sucesso!", Severity.Success);
            Parent.RefreshState(result.Data!);
        }
        else
            Snackbar.Add(result.Message, Severity.Error);
    }

    private async Task CancelProductionAsync()
    {
        var request = new CancelProductionRequest { Id = Production.Id };
        var result = await ProductionHandler.CancelAsync(request);
        if (result.IsSuccess)
        {
            Snackbar.Add("Produção cancelada!!!", Severity.Info);
            Parent.RefreshState(result.Data!);
        }
        else
            Snackbar.Add(result.Message, Severity.Error);
    }

    #endregion
}