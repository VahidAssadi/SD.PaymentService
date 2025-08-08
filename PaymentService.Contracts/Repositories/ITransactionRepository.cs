namespace PaymentService.Domain.PaymentAggregate.Repositories;

public interface ITransactionRepository
{
    Task<Transaction> GetByIdAsync(Guid transactionId, CancellationToken cancellationToken);
    Task AddAsync(Transaction transaction, CancellationToken cancellationToken);
    Task UpdateAsync(Transaction transaction, CancellationToken cancellationToken);
}