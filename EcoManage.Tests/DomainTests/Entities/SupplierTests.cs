namespace EcoManage.Tests.DomainTests.Entities;

[Trait("Supplier","UnitTest")]
public class SupplierTests
{
    [Fact]
    public void Deve_retornar_fornecedor_valido_ao_intanciar_fornecedor_com_value_objects_validos()
    {
        var name = "Fornecedor Teste";
        var email = new Email("fornecedorteste@ecomanage.io");
        var address = new Address("Rua dos Anjos","198");
        var zipCode = new ZipCode("12345123");
        var document = new Document("12345678901234",EDocumentType.Cnpj);
        var contact = "12345678910";
        
        
        var supplier = new Supplier(name,document,address,zipCode,email,contact);
        
        Assert.True(supplier.Valid);
    }
    
    [Fact]
    public void Deve_retornar_fornecedor_invalido_ao_intanciar_fornecedor_com_email_invalido()
    {
        var name = "Fornecedor Teste";
        
        var email = new Email("EmailInvalidoTeste");
        
        var address = new Address("Rua dos Anjos","198");
        var zipCode = new ZipCode("12345123");
        var document = new Document("12345678901234",EDocumentType.Cnpj);
        var contact = "12345678910";
        
        
        var supplier = new Supplier(name,document,address,zipCode,email,contact);
        
        Assert.True(supplier.Invalid);
    }
    
    [Fact]
    public void Deve_retornar_fornecedor_invalido_ao_intanciar_fornecedor_com_documento_cpf()
    {
        var name = "Fornecedor Teste";
        var email = new Email("fornecedorteste@ecomanage.io");
        var address = new Address("Rua dos Anjos","198");
        var zipCode = new ZipCode("12345123");
        var document = new Document("12345678901",EDocumentType.Cpf);
        var contact = "12345678910";
        
        
        var supplier = new Supplier(name,document,address,zipCode,email,contact);
        
        Assert.True(supplier.Invalid);
    }
    
}