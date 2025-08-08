namespace PaymentService.Domain.PaymentAggregate.Enums;

public enum TransactionStatus
{
    Initiated = 0,
    Pending = 1,
    Succeeded = 2,
    Failed = 3,
    Timeout = 4
}