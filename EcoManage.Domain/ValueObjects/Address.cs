using EcoManage.Domain.Common;

namespace EcoManage.Domain.ValueObjects;

public class Address : ValueObject
{
    public Address(string street,string number)
    {
        Street = street;
        Number = number;
    }
    public string Street { get; private set; } 
    public string Number { get; private set; }
    public override string ToString()
    {
        return $"{Street},{Number}";
    }
}
