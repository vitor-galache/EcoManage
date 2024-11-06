using EcoManage.Domain.Common;
using EcoManage.Domain.Enums;
using Flunt.Validations;

namespace EcoManage.Domain.ValueObjects;

public class Document : ValueObject
{
    #region Constructors

    public Document(string number,EDocumentType type)
    {
        Number = number;
        Type = type;
        
        AddNotifications(new Contract()
            .Requires()
            .IsNotNullOrEmpty(number,"Document.Number","Documento Inválido")
            .IsTrue(Validate(),"Document.Type","Documento inválido")
            .IsNotNullOrWhiteSpace(number,"Document.Number","Documento vazio ou com espaços")
        );
    }

    #endregion
    
    #region Properties
    public string Number { get; private set; }
    public EDocumentType Type { get; private set; }
    #endregion

    #region Private Methods
    private bool Validate()
    {
        if (Type == EDocumentType.Cnpj && Number.Length == 14)
            return true;
        
        if (Type == EDocumentType.Cpf && Number.Length == 11)
            return true;
        
        return false;
    }
    #endregion

    #region Overrides 
   public override string ToString()
   {
       return Convert.ToUInt64(Number).ToString(@"00\.000\.000\/0000\-00");
   }
   #endregion
}