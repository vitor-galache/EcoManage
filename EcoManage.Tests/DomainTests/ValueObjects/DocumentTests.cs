using EcoManage.Domain.Enums;
using EcoManage.Domain.ValueObjects;

namespace EcoManage.Tests.DomainTests.ValueObjects;

[TestClass]
public class DocumentTests
{
    [TestMethod]
    public void Deve_retornar_erro_ao_inserir_cpf_vazio_()
    {
        var document = new Document("",EDocumentType.Cpf);
        Assert.AreEqual(document.Invalid,true);
    }

    [TestMethod]
    public void Deve_retornar_erro_ao_inserir_cnpj_vazior()
    {
        var document = new Document("", EDocumentType.Cnpj);
        Assert.AreEqual(document.Invalid,true);
    }

    [TestMethod]
    public void Deve_retornar_sucesso_ao_inserir_cpf_com_11_caracteres()
    {
        var document = new Document("12345678910",EDocumentType.Cpf);
        Assert.AreEqual(document.Valid,true);
    }

    [TestMethod]
    public void Deve_retornar_sucesso_ao_inserir_cnpj_com_14_caracteres()
    {
        var document = new Document("12345678912345",EDocumentType.Cnpj);
        Assert.AreEqual(document.Valid,true);
    }
    
}