namespace Northwind.Domain;

public record Product
{
  public int Id { get; set; }
  public string Code { get; set; }
  public string Name { get; set; }
  public int SupplierId { get; set; }
  public int CategoryId { get; set; }
  public string QuantityPerUnit { get; set; }
  public decimal UnitPrice { get; set; }
  public short UnitsInStock { get; set; }
  public short UnitsOnOrder { get; set; }
  public short ReorderLevel { get; set; }
  public bool Discontinued { get; set; }
  
  public ICollection<OrderItem> OrderItems { get; private set; } = new HashSet<OrderItem>();
  public Category Category { get; set; }
  public Supplier Supplier { get; set; }
}
