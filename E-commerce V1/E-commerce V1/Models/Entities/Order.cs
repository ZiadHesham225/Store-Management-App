using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_V1.Models.Entities;

public class Order
{
    public int Id { get; set; }

    [Required]
    public DateTime OrderDate { get; set; }

    [Required]
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; }

    public virtual ICollection<OrderDetails> OrderDetails { get; set; }
}