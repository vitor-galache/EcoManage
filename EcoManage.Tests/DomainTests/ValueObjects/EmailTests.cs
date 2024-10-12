using EcoManage.Domain.ValueObjects;

namespace EcoManage.Tests.DomainTests.ValueObjects;

[TestClass]
public class EmailTests
{
    [TestMethod]
    
    [DataRow("email@invalid",true)]
    [DataRow("email.com",true)]
    [DataRow("emailteste",true)]
    [DataRow("   ",true)]
    public void Deve_retornar_erro_ao_inserir_email_invalido(string address,bool expectedResult)
    {
        var email = new Email(address);

        var result = email.Invalid; 
        
        Assert.AreEqual(expectedResult,result);
    }

    [TestMethod]
    [DataRow("teste@gmail.com",true)]
    [DataRow("teste@hotmail.com",true)]
    [DataRow("emailteste@yahoo.com",true)]
    [DataRow("email@outlook.com.br",true)]
    public void Deve_retornar_sucesso_ao_inserir_email_valido(string address,bool expectedResult)
    {
        var email = new Email(address);

        var result = email.Valid;
        
        Assert.AreEqual(expectedResult,result);
    }
    
}