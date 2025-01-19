using System.ComponentModel.DataAnnotations;

namespace E_commerce_V1.Models.Entities;

public class Category
{
    public int Id { get; set; }
    [Required]
    [StringLength(30)]
    public string Name { get; set; }

    public virtual ICollection<Product> Products { get; set; }
}