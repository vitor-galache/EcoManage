namespace EcoManage.Domain.Common;

public static class SlugGenerator
{
    public static string GenerateSlug(string title)
    {
        // Converte para minúsculas
        string slug = title.ToLowerInvariant();
    
        // Normaliza o título para decompor os caracteres acentuados
        slug = slug.Normalize(System.Text.NormalizationForm.FormD);
    
        // Remove os diacríticos (acentos)
        slug = System.Text.RegularExpressions.Regex.Replace(slug, @"\p{IsCombiningDiacriticalMarks}+", "");
    
        // Substitui espaços por hífens
        slug = System.Text.RegularExpressions.Regex.Replace(slug, @"\s", "-");

        // Remove caracteres não alfanuméricos, exceto hífens
        slug = System.Text.RegularExpressions.Regex.Replace(slug, @"[^\w\-]", "");

        // Remove hífens duplicados
        slug = System.Text.RegularExpressions.Regex.Replace(slug, @"-+", "-");

        return slug.Trim('-'); // Remove qualquer hífen no início ou final da string
    }

}