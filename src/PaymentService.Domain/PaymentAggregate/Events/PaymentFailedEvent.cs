namespace PaymentService.Domain.PaymentAggregate.Events;

public record PaymentFailedEvent(long PaymentId, string ErrorCode, string ErrorMessage);