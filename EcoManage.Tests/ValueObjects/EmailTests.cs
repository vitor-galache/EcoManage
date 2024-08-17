using EcoManage.Domain.ValueObjects;

namespace EcoManage.Tests.ValueObjects;

[TestClass]
public class EmailTests
{
    [TestMethod]
    public void Deve_retornar_erro_ao_inserir_email_invalido()
    {
        var email = new Email("email.invalido");
        Assert.AreEqual(email.Invalid,true);
    }

    [TestMethod]
    public void Deve_retornar_sucesso_ao_inserir_email_valido()
    {
        var email = new Email("teste@gmail.com");
        Assert.AreEqual(email.Valid,true);
    }
    
    [TestMethod]
    public void Deve_retornar_erro_ao_inserir_email_vazio()
    {
        var email = new Email("  ");
        Assert.AreEqual(email.Invalid,true);
    }
}