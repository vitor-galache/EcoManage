using EcoManage.Domain.Entities;

namespace EcoManage.Tests.DomainTests.Entities;

[TestClass]
[TestCategory("Products")]
public class ProductTests
{
    private const string TitleValid = "Produto Teste";
    private const string DescriptionValid = "Descrição do Produto Teste";
    private readonly Product _productValid = new Product(TitleValid,DescriptionValid);
    private readonly Product _productInvalid = new Product("","Descrição Teste");
    
    [TestMethod]
    public void CadastrarProdutoComTituloValido()
    {
        var product = new Product(TitleValid,DescriptionValid);
        Assert.AreEqual(product.Valid,true);
    }

    [TestMethod]
    public void AlterarInformacoesDeProdutoExistente()
    {
        _productValid.ChangeInfo("Produto Teste Atualizado","Descrição do Produto Teste Atualizada");
        Assert.AreEqual(_productValid.Valid,true);
    }
    
    [TestMethod]
    public void AlterarInformacoesDeProdutoExistenteComDadosInvalidos()
    {
        _productValid.ChangeInfo("P"," ");
        Assert.AreEqual(_productValid.Invalid,true);
    }

    [TestMethod]
    public void InativarProdutoExistente()
    {
        _productValid.Inactivate();
        Assert.AreEqual(_productValid.IsActive,false);
    }
    
    [TestMethod]
    public void RetornarErroAoCadastrarProdutoComTituloInvalido()
    {
        Assert.AreEqual(_productInvalid.Invalid,true);
    }

    [TestMethod]
    public void RetornarErroAoCadastrarProdutoSemDescricao()
    {
        var product = new Product(TitleValid, " ");
        Assert.AreEqual(product.Invalid,true);
    }
}