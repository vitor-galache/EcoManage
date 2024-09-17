using EcoManage.Domain.Common;
using EcoManage.Domain.Enums;
using EcoManage.Domain.ValueObjects;
using Flunt.Validations;

namespace EcoManage.Domain.Entities;

public class Supplier : Entity
{
    public Supplier(string companyName,Document document,Address address,ZipCode zipCode,Email email,string? contact = "")
    {
        CompanyName = companyName;
        Document = document;
        Address = address;
        Email = email;
        Contact = contact;
        ZipCode = zipCode;
        AddNotifications(new Contract().Requires()
            .IsTrue(Document.Valid,"Supplier.Document","Documento Inválido")
            .IsTrue(Address.Valid,"Supplier.Address","Endereço inválido")
            .IsTrue(Email.Valid,"Supplier.Email","E-mail inválido")
            .IsTrue(ZipCode.Valid,"Supplier.ZipCode","Cep Inválido")
            .AreEquals(Document.Type,EDocumentType.Cnpj,"Supplier.Document","Um fornecedor deve ter um CNPJ"));
    }

    private Supplier()
    {
        
    }
    public string CompanyName { get; private set; } = string.Empty;
    public Document Document { get; private set; } = null!;
    public Address Address { get; private set; } = null!;
    public ZipCode ZipCode { get; private set; } = null!;
    public Email Email { get; private set; } = null!;
    public string? Contact { get; private set; }


    public void ChangeCompanyName(string newValue)
    {
        CompanyName = newValue;
    }
    
    public void ChangeContact(string? newValue)
    {
        Contact = newValue;
    }

    public void ChangeEmail(string newAddress)
    {
        Email = new Email(newAddress);
    }
}