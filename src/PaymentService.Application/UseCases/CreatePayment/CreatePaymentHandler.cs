using PaymentService.Domain.PaymentAggregate.Entities;
using PaymentService.Contracts.Repositories;

namespace PaymentService.Application.UseCases.PaymentUseCase;

public class CreatePaymentHandler(IPaymentRepository paymentRepository)
{
    public async Task<long> Handle(CreatePaymentCommand command, CancellationToken cancellationToken)
    {
        var payment = new Payment(
            command.InvoiceId,
            new Money(command.Amount, command.Currency),
            command.Description,
            command.CallbackUrl,
            command.ReferenceType,
            command.ReferenceId,
            command.CheckSum);

        await paymentRepository.AddAsync(payment, cancellationToken);
        
        return payment.Id;
    }
}