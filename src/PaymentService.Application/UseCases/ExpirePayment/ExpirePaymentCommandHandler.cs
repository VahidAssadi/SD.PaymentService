

using PaymentService.Contracts.Repositories;

namespace PaymentService.Application.UseCases.PaymentUseCase;

public class ExpirePaymentCommandHandler(IPaymentRepository paymentRepository)
{
    public async Task Handle(CancelPaymentCommand command, CancellationToken cancellationToken)
    {
        var payment = await paymentRepository.GetByIdAsync(command.PaymentId, cancellationToken);
        if (payment == null)
            throw new InvalidOperationException("Payment not found.");

        payment.MarkAsCancelled();

        await paymentRepository.UpdateAsync(payment, cancellationToken);
    }
}