using EcoManage.Domain.Entities;
using EcoManage.Domain.Enums;
using EcoManage.Domain.ValueObjects;

namespace EcoManage.Tests.DomainTests.Entities;

[TestClass]
[TestCategory("Suppliers")]
public class SupplierTests
{
    [TestMethod]
    public void CriarFornecedorComValueObjectsValidos()
    {
        var name = "Fornecedor Teste";
        var email = new Email("fornecedorteste@ecomanage.io");
        var address = new Address("Rua dos Anjos","198");
        var zipCode = new ZipCode("12345123");
        var document = new Document("12345678901234",EDocumentType.Cnpj);
        var contact = "12345678910";
        
        var supplier = new Supplier(name,document,address,zipCode,email,contact);
        Assert.AreEqual(supplier.Valid,true);
    }
    
    [TestMethod]
    public void Retornar_Fornecedor_Invalido_Ao_Criar_Fornecedor_Com_Email_Invalido()
    {
        var name = "Fornecedor Teste";
        var email = new Email("fornecedorteste");
        var address = new Address("Rua dos Anjos","198");
        var zipCode = new ZipCode("12345123");
        var document = new Document("12345678901234",EDocumentType.Cnpj);
        var contact = "12345678910";

        var supplier = new Supplier(name,document,address,zipCode,email,contact);
        
        Assert.AreEqual(supplier.Invalid,true);
    }
    
    
    [TestMethod]
    public void Retornar_Fornecedor_Invalido_Ao_Tentar_Criar_Fornecedor_Com_Documento_Cpf()
    {
        var name = "Fornecedor Teste";
        var email = new Email("fornecedorteste@ecomanage.io");
        var address = new Address("Rua dos Anjos","198");
        var zipCode = new ZipCode("12345-123");
        var document = new Document("12345678901",EDocumentType.Cpf);
        var contact = "12345678910";

        var supplier = new Supplier(name,document,address,zipCode,email,contact);
        
        Assert.AreEqual(supplier.Valid,false);
    }
}