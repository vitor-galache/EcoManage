using EcoManage.Domain.Common;
using EcoManage.Domain.Enums;
using Flunt.Validations;

namespace EcoManage.Domain.ValueObjects;

public class Document : ValueObject
{
    public Document(string number,EDocumentType type)
    {
        Number = number;
        Type = type;
        
        AddNotifications(new Contract()
            .Requires()
            .IsNotNullOrEmpty(number,"Document.Number","Documento Inválido")
            .IsTrue(Validate(),"Document.Type","Documento inválido")
            //.IsNotNullOrWhiteSpace(number,"Document.Number","Documento vazio ou com espaços")
        );
    }
    public string Number { get; private set; }
    public EDocumentType Type { get; private set; }

    private bool Validate()
    {
        if (Type == EDocumentType.Cnpj && Number.Length == 14)
            return true;
        
        if (Type == EDocumentType.Cpf && Number.Length == 11)
            return true;
        
        return false;
    }

    public override string ToString()
    {
        return $"{Number}";
    }
}