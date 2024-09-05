namespace EcoManage.Domain.Entities;

public class Product
{

    public Product(string title,string slug,string description)
    {
        Title = title;
        Slug = slug;
        Description = description;
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
    public void ChangeInfo(string title,string slug,string description)
    {
        Title = title;
        Slug = slug;
        Description = description;
    }
    
}