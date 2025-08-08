using PaymentService.Domain.PaymentAggregate.Entities;

namespace PaymentService.Domain.PaymentAggregate.Events;

public record PaymentCreatedEvent(long PaymentId, Money Amount, string ReferenceType, Guid ReferenceId);