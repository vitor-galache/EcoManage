using EcoManage.Domain.Common;

namespace EcoManage.Tests.DomainTests.Common;

[Trait("SlugGenerator","UnitTest")]
public class SlugGeneratorTests
{
    [Theory]
    [InlineData("Agrião", "agriao")]
    [InlineData("Café","cafe")]
    [InlineData("Banana Nanica","banana-nanica")]
    public void Gerar_Slug_Minusculo_E_Sem_Acentos_Ao_Passar_Titulo_De_Um_Produto(string productTitle,string expectedSlug)
    {
        
        var slug = SlugGenerator.GenerateSlug(productTitle);
        
        Assert.Equal(expectedSlug, slug);
    }
}