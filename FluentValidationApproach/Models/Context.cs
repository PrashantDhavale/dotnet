namespace FluentValidationApproach.Models;

public class Context : IOrderId,
                       IOrderItemIds,
                       IOrderLocation,
                       IJsonPayload
{
    public string? OrderId { get; set; }
    public string? OrderLocation { get; set; }
    public string[]? OrderItemIds { get; set; }
    public byte[]? JsonPayload { get; set; }
}
