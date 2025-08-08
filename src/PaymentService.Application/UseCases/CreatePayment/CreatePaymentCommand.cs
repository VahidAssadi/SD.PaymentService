namespace PaymentService.Application.UseCases.PaymentUseCase;

public record CreatePaymentCommand(
    Guid InvoiceId,
    decimal Amount,
    string Currency,
    string Description,
    string CallbackUrl,
    string ReferenceType,
    Guid ReferenceId,
    string CheckSum);