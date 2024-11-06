using EcoManage.Domain.Common;
using Flunt.Validations;

namespace EcoManage.Domain.Entities;

public class Product : Entity
{
    #region Constructors

    public Product(string title,string description)
    {
        Title = title;
        Description = description;
        Slug = SlugGenerator.GenerateSlug(title);
        AddNotifications(new Contract().Requires()
            .HasMinLen(Title,
                1,
                "Product.Title",
                "O título deve ter no mínimo um caracter")
            .IsNotNullOrWhiteSpace(Description,"Product.Description","A descrição não pode ser nula"));
    }

    #endregion
    
    #region Properties
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Slug { get; private set; }
    public bool IsActive { get; private set; } = true;
    #endregion
    
    #region Public Methods
    public void Inactivate()
    {
        IsActive = false;
    }
    public void ChangeInfo(string newTitle,string newDescription)
    {
        Title = newTitle;
        Description = newDescription;
        Slug = SlugGenerator.GenerateSlug(newTitle);
        AddNotifications(new Contract().Requires()
            .HasMinLen(Title,
                1,
                "Product.Title",
                "O título deve ter no mínimo um caracter")
            .IsNotNullOrWhiteSpace(Description,"Product.Description","A descrição não pode ser nula"));
    }
    #endregion
}