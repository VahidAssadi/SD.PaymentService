namespace PaymentService.Application.UseCases.PaymentUseCase;

public record InitiatePaymentCommand(
    long PaymentId,
    string Gateway);