using PaymentService.Contracts.Repositories;

namespace PaymentService.Application.UseCases.PaymentUseCase;

public class ConfirmPaymentHandler(IPaymentRepository paymentRepository)
{
    public async Task Handle(ConfirmPaymentCommand command, CancellationToken cancellationToken)
    {
        var payment = await paymentRepository.GetByIdAsync(command.PaymentId, cancellationToken);
        if (payment == null)
            throw new InvalidOperationException("Payment not found.");

        var transaction = payment.Transactions.FirstOrDefault(t => t.Id == command.TransactionId);
        if (transaction == null)
            throw new InvalidOperationException("Transaction not found.");

        if (command.IsSuccess)
        {
            transaction.MarkAsSucceeded(
                command.ReferenceNumber,
                command.TrackingCode,
                command.CardNumberMasked,
                command.RRN,
                command.IssuerBank,
                command.TerminalId,
                command.RawResponse);

            payment.MarkAsSucceeded();
        }
        else
        {
            transaction.MarkAsFailed(
                command.ErrorCode,
                command.ErrorMessage,
                command.RawResponse);

            payment.MarkAsFailed();
        }

        await paymentRepository.UpdateAsync(payment, cancellationToken);
    }
}