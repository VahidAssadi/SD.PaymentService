namespace PaymentService.Domain.PaymentAggregate.Enums;

public enum PaymentStatus
{
    Initiated,
    Pending,
    Succeeded,
    Failed,
    Cancelled,
    Expired
}