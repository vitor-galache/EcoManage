using EcoManage.Domain.Common;
using Flunt.Validations;

namespace EcoManage.Domain.ValueObjects;

public class Name : ValueObject
{
    public Name(string firstName,string lastName)
    {
        FirstName = firstName.Trim();
        LastName = lastName;
        AddNotifications(new Contract()
            .Requires()
            .HasMinLen(FirstName,1,"Name.FirstName","O nome deve conter no minimo 1 caracter")
            .IsNotNullOrWhiteSpace(FirstName,"Name.FirstName","O nome não pode ser vazio")
            .IsNotNullOrWhiteSpace(LastName,"Name.LastName","O sobrenome não pode ser vazio"));
    }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }


    #region Overrides

    public override string ToString()
    {
        return $"{FirstName} + {LastName}";
    }

    #endregion
}