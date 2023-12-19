namespace Northwind.Domain;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

[PrimaryKey(nameof(OrderId), nameof(ProductId))]
public record OrderItem
{
  public Order Order { get; set; }
  public Product Product { get; set; }
  
  // [Key]
  public int OrderId { get; set; }
  // [Key]
  public int ProductId { get; set; }
  public decimal UnitPrice { get; set; }
  public short Quantity { get; set; }
  public decimal Discount { get; set; }
}
