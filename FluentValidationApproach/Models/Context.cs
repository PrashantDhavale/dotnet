namespace FluentValidationApproach.Models;

public class Context: IOrderId,IOrderItemIds,IOrderLocation
{
    public string? OrderId { get; set; }
    public string? OrderLocation { get; set; }
    public string[]? OrderItemIds { get; set;}
}
