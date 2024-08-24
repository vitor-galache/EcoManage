using EcoManage.Domain.Common;
using Flunt.Validations;

namespace EcoManage.Domain.ValueObjects;

public class Email : ValueObject
{
    public Email(string address)
    {
        Address = address;
        AddNotifications(new Contract()
            .Requires()
            .IsEmail(Address,"Email.Address","E-mail inválido")
            .IsNotNullOrWhiteSpace(Address,"Email.Address","O E-mail é obrigatório")
        );
    }
    public string Address { get; private set; }

    public override string ToString()
    {
        return $"{Address}";
    }
}