namespace EcoManage.Tests.DomainTests.ValueObjects;

[Trait("Document","UnitTest")]
public class DocumentTests
{
    [Theory]
    [InlineData(" ",true)]
    [InlineData("           ",true)]
    [InlineData("   ",true)]
    public void Deve_retornar_erro_ao_inserir_cpf_vazio_(string nullEmpty,bool expectedResult)
    {
        var document = new Document(nullEmpty,EDocumentType.Cpf);
        
        Assert.Equal(expectedResult,document.Invalid);
    }
    
    [Theory]
    [InlineData(" ",true)]
    [InlineData("            ",true)]
    [InlineData("    ",true)]
    public void Deve_retornar_erro_ao_inserir_cnpj_vazio(string nullEmpty,bool expectedResult)
    {
        var document = new Document(nullEmpty, EDocumentType.Cnpj);
        
        Assert.Equal(expectedResult,document.Invalid);
    }
    
    [Theory]
    [InlineData("12345678910",true)]
    [InlineData("11987654321",true)]
    public void Deve_retornar_sucesso_ao_inserir_cpf_com_11_caracteres(string cpfNumber,bool expectedResult)
    {
        var document = new Document(cpfNumber,EDocumentType.Cpf);
        
        Assert.Equal(expectedResult,document.Valid);
    }
    
    [Theory]
    [InlineData("12345678912345",true)]
    [InlineData("67894721000163",true)]
    [InlineData("18386325000110",true)]
    public void Deve_retornar_sucesso_ao_inserir_cnpj_com_14_caracteres(string cnpjNumber,bool expectedResult)
    {
        var document = new Document(cnpjNumber,EDocumentType.Cnpj);
        Assert.Equal(expectedResult,document.Valid);
    }
}