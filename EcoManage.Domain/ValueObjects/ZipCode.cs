using EcoManage.Domain.Common;
using Flunt.Validations;

namespace EcoManage.Domain.ValueObjects;

public class ZipCode : ValueObject
{
    public ZipCode(string code)
    {
        Code = code;
        AddNotifications(new Contract().Requires()
            .HasLen(Code,8,"ZipCode.Number","CEP INVÁLIDO"));
    }

    public string Code { get; set; } 

    public override string ToString()
    {
        return $"{Code}";
    }
}