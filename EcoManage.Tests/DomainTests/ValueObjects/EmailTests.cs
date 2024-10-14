
namespace EcoManage.Tests.DomainTests.ValueObjects;

[Trait("Email","UnitTest")]
public class EmailTests
{
    [Theory]
    [InlineData("email.invalido",true)]
    [InlineData("email.invalido.com",true)]
    [InlineData("email@invalido",true)]
    [InlineData("",true)]
    [InlineData(" ",true)]
    public void Deve_retornar_erro_ao_inserir_email_invalido_ou_vazio(string emailAddress,bool expectedResult)
    {
        var email = new Email(emailAddress);
        
        Assert.Equal(expectedResult,email.Invalid);
    } 
    
    [Theory]
    [InlineData("email@teste.io",true)]
    [InlineData("email@gmail.com",true)]
    [InlineData("email@hotmail.com",true)]
    [InlineData("email@yahoo.com",true)]
    public void Deve_retornar_sucesso_ao_inserir_email_valido(string emailAddress,bool expectedResult)
    {
        var email = new Email(emailAddress);
        
        Assert.Equal(expectedResult,email.Valid);
    }
}