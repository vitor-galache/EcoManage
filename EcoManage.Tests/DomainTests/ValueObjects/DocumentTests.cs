using EcoManage.Domain.Enums;
using EcoManage.Domain.ValueObjects;

namespace EcoManage.Tests.DomainTests.ValueObjects;

[TestClass]
public class DocumentTests
{
    [TestMethod]
    [DataRow("  ",true)]
    [DataRow("",true)]
    [DataRow("           ",true)]
    public void Deve_retornar_erro_ao_inserir_cpf_vazio_(string number,bool expectedResult)
    {
        var cpf = new Document(number,EDocumentType.Cpf);

        var result = cpf.Invalid;
        
        Assert.AreEqual(expectedResult,result);
    }

    [TestMethod]
    [DataRow("  ",true)]
    [DataRow("",true)]
    [DataRow("           ",true)]
    public void Deve_retornar_erro_ao_inserir_cnpj_vazio(string number, bool expectedResult)
    {
        var cnpj = new Document(number, EDocumentType.Cnpj);

        var result = cnpj.Invalid;
        
        Assert.AreEqual(expectedResult,result);
    }

    [TestMethod]
    [DataRow("12345678910",true)]
    [DataRow("11987654321",true)]
    
    public void Deve_retornar_sucesso_ao_inserir_cpf_com_11_caracteres(string number,bool expectedResult)
    {
        var cpf = new Document(number,EDocumentType.Cpf);

        var result = cpf.Valid;
        
        Assert.AreEqual(expectedResult,result);
    }

    [TestMethod]
    [DataRow("29398282000109",true)]
    [DataRow("12345678912345",true)]
    [DataRow("23023982000132",true)]
    public void Deve_retornar_sucesso_ao_inserir_cnpj_com_14_caracteres(string number,bool expectedResult)
    {
        var cnpj = new Document(number,EDocumentType.Cnpj);

        var result = cnpj.Valid;
        
        Assert.AreEqual(expectedResult,result);
    }
    
}