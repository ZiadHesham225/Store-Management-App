using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_V1.Models.Entities;

public class OrderDetails
{
    public int Id { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalPrice { get; set; }

    [Required]
    [ForeignKey("Order")]
    public int OrderId { get; set; }
    
    public virtual Order Order { get; set; }

    [Required]
    [ForeignKey("Product")]
    public int ProductId { get; set; }

    public virtual Product Product { get; set; }
}