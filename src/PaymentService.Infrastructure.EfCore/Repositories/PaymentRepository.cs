

using PaymentService.Domain.PaymentAggregate.Entities;
using PaymentService.Contracts.Repositories;

namespace PaymentService.Infrastructure.Repositories;

public class PaymentRepository : IPaymentRepository
{
    public Task<Payment> GetByIdAsync(long paymentId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Payment payment, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Payment payment, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}