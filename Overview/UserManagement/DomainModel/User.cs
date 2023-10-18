using System.ComponentModel.DataAnnotations;
using DataAccess;

namespace UserManagement.DomainModel;

public class User
{
    public Guid Id { get; set; }
    
    [MaxLength(100)]
    public string? Name { get; set; } = "";
}