namespace EcoManage.Domain.Common;

public static class SlugGenerator
{
    public static string GenerateSlug(string title)
    {
        string slug = title.ToLowerInvariant();
        slug = System.Text.RegularExpressions.Regex.Replace(slug, @"\s", "-"); 
        slug = System.Text.RegularExpressions.Regex.Replace(slug, @"[^\w\-]", ""); 
        slug = System.Text.RegularExpressions.Regex.Replace(slug, @"-+", "-");
        return slug;
    }
}