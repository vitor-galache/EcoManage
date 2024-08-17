using EcoManage.Domain.Common;

namespace EcoManage.Domain.ValueObjects;

public class Address : ValueObject
{
    public Address(string street,string number,string zipCode)
    {
        Street = street;
        Number = number;
        ZipCode = zipCode;
    }
    public string Street { get; private set; } 
    public string Number { get; private set; } 
    public string ZipCode { get; private set; }
}
