using PaymentService.Application.UseCases.PaymentUseCase;
using PaymentService.Contracts.Repositories;
using PaymentService.Domain;

namespace PaymentService.Application.UseCases.InitiatePayment;

public class InitiatePaymentHandler(IPaymentRepository paymentRepository)
{
    public async Task<Guid> Handle(InitiatePaymentCommand command, CancellationToken cancellationToken)
    {
        var payment = await paymentRepository.GetByIdAsync(command.PaymentId, cancellationToken);
        if (payment == null)
            throw new InvalidOperationException("Payment not found.");

        payment.MarkAsInitiated();

        var transaction = new Transaction(command.Gateway, payment.Amount);
        payment.AddTransaction(transaction);

        await paymentRepository.UpdateAsync(payment, cancellationToken);

        // بازگشت شناسه Transaction
        return transaction.Id;
    }
}


