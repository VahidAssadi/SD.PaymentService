namespace PaymentService.Domain.PaymentAggregate.Events;

public record PaymentSucceededEvent(long PaymentId, string ReferenceNumber, DateTime CompletedAt);