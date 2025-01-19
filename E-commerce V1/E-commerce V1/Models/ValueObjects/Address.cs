using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_V1.Models.ValueObjects;
[Owned]
public class Address
{
    [Required]
    [StringLength(100)]
    [Column("Street")]
    public string Street { get; set; }

    [Required]
    [StringLength(50)]
    [Column("City")]
    public string City { get; set; }

    [Required]
    [StringLength(50)]
    [Column("State")]
    public string State { get; set; }

    [Required]
    [StringLength(10)]
    [Column("ZipCode")]
    public string ZipCode { get; set; }
    [Required]
    [StringLength(30)]
    [Column("Country")]
    public string Country { get; set; }
}
