namespace EcoManage.Tests.DomainTests.Entities;

[Trait("Production","UnitTest")]
public class ProductionTests
{
 [Fact]
    public void Deve_Instanciar_Production_Valida_Ao_Criar_Production_Programmed_Com_EndDate_Valido()
    {
        var title = "Produção Teste";
        var product = new Product("Produto Teste","Descrição de Produto Teste");
        var quantityInKg = 50.000m;
        var endDate = DateTime.UtcNow.AddMonths(6);
        
        var productionProgrammed = ProductionProgrammed.Factories.Create(title,product,quantityInKg,endDate);
        
        Assert.True(productionProgrammed.Valid);
    }

    [Fact]
    public void Deve_Instanciar_Production_Valida_Ao_Criar_Production_Unexpected_Sem_EndDate()
    {
        var title = "Produção Imprevista Teste";
        var product = new Product("Produto Teste","Descrição de Produto Teste");
        var quantityInKg = 50.000m;

        var productionUnexpected = ProductionUnexpected.Factories.Create(title,product,quantityInKg);
        Assert.True(productionUnexpected.Valid);
    }

    [Fact]
    public void Deve_Atribuir_Status_Planting_Ao_Instanciar_Production()
    {
        var title = "Produção Imprevista Teste";
        var product = new Product("Produto Teste","Descrição de Produto Teste");
        var quantityInKg = 50.000m;

        var productionUnexpected = ProductionUnexpected.Factories.Create(title,product,quantityInKg);
        
        Assert.Equal(EProductionStatus.Planting,productionUnexpected.Status);
    }
    
    [Fact]
    public void Deve_Alterar_Status_Para_Cultivation_Ao_Chamar_Metodo_ToCultivation()
    {
        var title = "Produção Imprevista Teste";
        var product = new Product("Produto Teste","Descrição de Produto Teste");
        var quantityInKg = 50.000m;

        var productionUnexpected = ProductionUnexpected.Factories.Create(title,product,quantityInKg);
        productionUnexpected.ToCultivation();
        
        Assert.Equal(EProductionStatus.Cultivation,productionUnexpected.Status);
    }
    
    [Fact]
    public void Deve_Alterar_Status_Para_Harvesting_Ao_Chamar_Metodo_ToHarvesting()
    {
        var title = "Produção Imprevista Teste";
        var product = new Product("Produto Teste","Descrição de Produto Teste");
        var quantityInKg = 50.000m;

        var productionUnexpected = ProductionUnexpected.Factories.Create(title,product,quantityInKg);
        productionUnexpected.ToHarvesting();
        
        Assert.Equal(EProductionStatus.Harvesting,productionUnexpected.Status);
    }
       
    [Fact]
    public void Deve_Alterar_Status_Para_Finished_Ao_Chamar_Metodo_Finish()
    {
        var title = "Produção Imprevista Teste";
        var product = new Product("Produto Teste","Descrição de Produto Teste");
        var quantityInKg = 50.000m;

        var productionUnexpected = ProductionUnexpected.Factories.Create(title,product,quantityInKg);
        productionUnexpected.Finish();
        
        Assert.Equal(EProductionStatus.Finished,productionUnexpected.Status);
    }
    
    [Fact]
    public void Deve_Alterar_Status_Para_CropLoss_Ao_Chamar_Metodo_Cancel()
    {
        var title = "Produção Imprevista Teste";
        var product = new Product("Produto Teste","Descrição de Produto Teste");
        var quantityInKg = 50.000m;

        var productionUnexpected = ProductionUnexpected.Factories.Create(title,product,quantityInKg);
        productionUnexpected.Cancel();
        
        Assert.Equal(EProductionStatus.CropLoss,productionUnexpected.Status);
    }   
}