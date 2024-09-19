using EcoManage.Domain.Entities;
using EcoManage.Domain.Enums;

namespace EcoManage.Tests.DomainTests.Entities;

[TestClass]
[TestCategory("Productions")]
public class ProductionTests
{
    [TestMethod]
    public void Cadastrar_Producao_Agendada_Com_EndDate_Valido()
    {
        var title = "Produção Teste";
        var product = new Product("Produto Teste","Descrição de Produto Teste");
        var quantityInKg = 50.000m;
        var endDate = DateTime.UtcNow.AddMonths(6);
        
        var productionProgrammed = new Production(title,product,quantityInKg,endDate);
        Assert.AreEqual(productionProgrammed.Valid,true);
    }

    [TestMethod]
    public void Cadastrar_Producao_Imprevista_Sem_EndDate()
    {
        var title = "Produção Imprevista Teste";
        var product = new Product("Produto Teste","Descrição de Produto Teste");
        var quantityInKg = 50.000m;

        var productionUnexpected = new Production(title,product,quantityInKg);
        Assert.AreEqual(productionUnexpected.Valid,true);
    }

    [TestMethod]
    public void Ao_Criar_Producao_Atribuir_Status_Planting()
    {
        var title = "Produção Imprevista Teste";
        var product = new Product("Produto Teste","Descrição de Produto Teste");
        var quantityInKg = 50.000m;

        var productionUnexpected = new Production(title,product,quantityInKg);
        Assert.AreEqual(productionUnexpected.Status,EProductionStatus.Planting);
    }
    
    [TestMethod]
    public void Alterar_Status_Para_Cultivation()
    {
        var title = "Produção Imprevista Teste";
        var product = new Product("Produto Teste","Descrição de Produto Teste");
        var quantityInKg = 50.000m;

        var productionUnexpected = new Production(title,product,quantityInKg);
        productionUnexpected.ToCultivation();
        
        Assert.AreEqual(productionUnexpected.Status,EProductionStatus.Cultivation);
    }
    
    [TestMethod]
    public void Alterar_Status_Para_Harvesting()
    {
        var title = "Produção Imprevista Teste";
        var product = new Product("Produto Teste","Descrição de Produto Teste");
        var quantityInKg = 50.000m;

        var productionUnexpected = new Production(title,product,quantityInKg);
        productionUnexpected.ToHarvesting();
        
        Assert.AreEqual(productionUnexpected.Status,EProductionStatus.Harvesting);
    }
       
    [TestMethod]
    public void Alterar_Status_Para_Finished_Ao_Finalizar_Producao()
    {
        var title = "Produção Imprevista Teste";
        var product = new Product("Produto Teste","Descrição de Produto Teste");
        var quantityInKg = 50.000m;

        var productionUnexpected = new Production(title,product,quantityInKg);
        productionUnexpected.Finish();
        
        Assert.AreEqual(productionUnexpected.Status,EProductionStatus.Finished);
    }
    
    [TestMethod]
    public void Alterar_Status_Para_CropLoss_Ao_Cancelar_Producao()
    {
        var title = "Produção Imprevista Teste";
        var product = new Product("Produto Teste","Descrição de Produto Teste");
        var quantityInKg = 50.000m;

        var productionUnexpected = new Production(title,product,quantityInKg);
        productionUnexpected.Cancel();
        
        Assert.AreEqual(productionUnexpected.Status,EProductionStatus.CropLoss);
    }
    
}