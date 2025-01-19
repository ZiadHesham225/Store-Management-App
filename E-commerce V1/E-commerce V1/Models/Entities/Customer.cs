using System.ComponentModel.DataAnnotations;
using E_commerce_V1.Models.ValueObjects;

namespace E_commerce_V1.Models.Entities;

public class Customer
{
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(20)]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public Address Address { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
}