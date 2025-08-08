using PaymentService.Domain.PaymentAggregate.Entities;

namespace PaymentService.Contracts.Repositories;

public interface IPaymentRepository
{
    Task<Payment> GetByIdAsync(long paymentId, CancellationToken cancellationToken);
    Task AddAsync(Payment payment, CancellationToken cancellationToken);
    Task UpdateAsync(Payment payment, CancellationToken cancellationToken);
}