namespace PaymentService.Application.UseCases.PaymentUseCase;

public record ConfirmPaymentCommand(
    long PaymentId,
    Guid TransactionId,
    bool IsSuccess,
    string ReferenceNumber,
    string TrackingCode,
    string CardNumberMasked,
    string RRN,
    string IssuerBank,
    string TerminalId,
    string RawResponse,
    string ErrorCode,
    string ErrorMessage);