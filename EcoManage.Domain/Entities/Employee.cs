using EcoManage.Domain.Common;
using EcoManage.Domain.Enums;
using EcoManage.Domain.ValueObjects;

namespace EcoManage.Domain.Entities;

public class Employee : Entity
{
    public Employee(Name name,Email email,Document document,EDepartament departament)
    {
        Name = name;
        Email = email;
        Document = document;
        Departament = departament;
    }
    public Name Name { get; private set; } 
    public Email Email { get; private set; } 
    public Document Document { get; private set; }
    public EDepartament Departament { get; private set; }
    
}