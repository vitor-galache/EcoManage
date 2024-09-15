using EcoManage.Domain.Common;

namespace EcoManage.Domain.Entities;

public class Product 
{
    public Product(string title,string description)
    {
        Title = title;
        Description = description;
        Slug = SlugGenerator.GenerateSlug(title);
    }
    
    public long Id { get; init; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Slug { get; private set; }
    public bool IsActive { get; private set; } = true;
    
    public void Inactivate()
    {
        IsActive = false;
    }
    public void ChangeInfo(string newTitle,string newDescription)
    {
        Title = newTitle;
        Description = newDescription;
        Slug = SlugGenerator.GenerateSlug(newTitle);
    }
    
}