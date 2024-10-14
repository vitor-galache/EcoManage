namespace EcoManage.Tests.DomainTests.Entities;

[Trait("Product","UnitTest")]
public class ProductTests
{
    private const string TitleValid = "Produto Teste";
    private const string DescriptionValid = "Descrição do Produto Teste";
    private readonly Product _productValid = new Product(TitleValid,DescriptionValid);
    private readonly Product _productInvalid = new Product("","Descrição Teste");
    
    [Fact]
    public void Deve_Instanciar_Produto_Valido_Ao_Cadastrar_Produto_Com_Titulo_Valido()
    {
        var product = new Product(TitleValid,DescriptionValid);
        
        Assert.True(product.Valid);
    }

    [Fact]
    public void Deve_Alterar_Informacoes_De_Produto_Existente()
    {
        _productValid.ChangeInfo("Produto Teste Atualizado","Descrição do Produto Teste Atualizada");
        Assert.True(_productValid.Valid);
    }
    
    [Fact]
    public void Deve_Tornar_ProdutoValido_Em_Invalido_Ao_Alterar_Informacoes_De_Produto_Existente_Com_Dados_Invalidos()
    {
        _productValid.ChangeInfo("P"," ");
        Assert.True(_productValid.Invalid);
    }

    [Fact]
    public void Deve_Inativar_Produto_Existente()
    {
        _productValid.Inactivate();
        
        Assert.False(_productValid.IsActive);
    }
    
    [Fact]
    public void Deve_Retornar_Produto_Invalido_Ao_Cadastrar_Produto_Com_Titulo_Invalido()
    {
        Assert.True(_productInvalid.Invalid);
    }

    [Fact]
    public void Deve_Retornar_Produto_Invalido_Ao_Cadastrar_Produto_Sem_Descricao()
    {
        var product = new Product(TitleValid, " ");
        
        Assert.True(product.Invalid);
    }
}