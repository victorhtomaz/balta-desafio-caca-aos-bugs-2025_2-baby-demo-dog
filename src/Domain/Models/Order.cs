namespace BugStore.Domain.Models;

public class Order
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public List<OrderLine> Lines { get; set; } = [];
}