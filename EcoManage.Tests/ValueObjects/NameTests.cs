using EcoManage.Domain.ValueObjects;

namespace EcoManage.Tests.ValueObjects;

[TestClass]
public class NameTests
{
    [TestMethod]
    public void Deve_retornar_erro_ao_inserir_nome_em_branco()
    {
        var name = new Name(" "," ");
        Assert.AreEqual(name.Invalid,true);
    }
    
    [TestMethod]
    public void Deve_retornar_erro_ao_inserir_sobrenome_em_branco()
    {
        var name = new Name("Vitor","  ");
        Assert.AreEqual(name.Invalid,true);
    }
}