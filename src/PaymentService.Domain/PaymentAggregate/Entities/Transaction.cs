using PaymentService.Domain.PaymentAggregate;
using PaymentService.Domain.PaymentAggregate.Entities;
using PaymentService.Domain.PaymentAggregate.Enums;

namespace PaymentService.Domain;

public class Transaction
{
    public Guid Id { get; private set; }
    public long PaymentId { get; private set; }
    public string Gateway { get; private set; }
    public Money Amount { get; private set; }
    public TransactionStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }

    // اطلاعات Response بانک
    public string ReferenceNumber { get; private set; }
    public string TrackingCode { get; private set; }
    public string CardNumberMasked { get; private set; }
    public string RRN { get; private set; }
    public string IssuerBank { get; private set; }
    public string TerminalId { get; private set; }
    public string RawResponse { get; private set; }
    public string ErrorCode { get; private set; }
    public string ErrorMessage { get; private set; }

    private Transaction() { }

    public Transaction(string gateway, Money amount)
    {
        Id = Guid.NewGuid();
        Gateway = gateway;
        Amount = amount;
        Status = TransactionStatus.Pending;
        CreatedAt = DateTime.UtcNow;
    }

    public void MarkAsSucceeded(string referenceNumber, string trackingCode, string cardMasked, string rrn, string issuerBank, string terminalId, string rawResponse)
    {
        if (Status != TransactionStatus.Pending)
            throw new InvalidOperationException("Only Pending transaction can succeed.");

        Status = TransactionStatus.Succeeded;
        ReferenceNumber = referenceNumber;
        TrackingCode = trackingCode;
        CardNumberMasked = cardMasked;
        RRN = rrn;
        IssuerBank = issuerBank;
        TerminalId = terminalId;
        RawResponse = rawResponse;
        CompletedAt = DateTime.UtcNow;
    }

    public void MarkAsFailed(string errorCode, string errorMessage, string rawResponse)
    {
        if (Status != TransactionStatus.Pending)
            throw new InvalidOperationException("Only Pending transaction can fail.");

        Status = TransactionStatus.Failed;
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
        RawResponse = rawResponse;
        CompletedAt = DateTime.UtcNow;
    }
}