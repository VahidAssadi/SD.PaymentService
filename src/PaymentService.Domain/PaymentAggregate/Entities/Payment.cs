using PaymentService.Domain.PaymentAggregate.Enums;

namespace PaymentService.Domain.PaymentAggregate.Entities;

public class Payment
{
    public long Id { get; private set; }
    public Guid InvoiceId { get; private set; }
    public Money Amount { get; private set; }
    public PaymentStatus Status { get; private set; }
    public string Description { get; private set; }
    public string CallbackUrl { get; private set; }
    public string ReferenceType { get; private set; }
    public Guid ReferenceId { get; private set; }
    public string CheckSum { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }

    private readonly List<Transaction> _transactions = [];
    
    public IReadOnlyCollection<Transaction> Transactions => _transactions;

    private Payment() { }

    public Payment(
        Guid invoiceId,
        Money amount,
        string description,
        string callbackUrl,
        string referenceType,
        Guid referenceId,
        string checkSum)
    {
        Id = 0; // DB Identity
        InvoiceId = invoiceId;
        Amount = amount ?? throw new ArgumentNullException(nameof(amount));
        Description = description;
        CallbackUrl = callbackUrl;
        ReferenceType = referenceType;
        ReferenceId = referenceId;
        CheckSum = checkSum;
        CreatedAt = DateTime.UtcNow;
        Status = PaymentStatus.Pending;
    }

    // ✅ State Transitions

    public void MarkAsInitiated()
    {
        if (Status != PaymentStatus.Pending)
            throw new InvalidOperationException("Only Pending payment can be initiated.");

        Status = PaymentStatus.Initiated;
    }

    public void MarkAsSucceeded()
    {
        if (Status != PaymentStatus.Initiated)
            throw new InvalidOperationException("Only Initiated payment can succeed.");

        Status = PaymentStatus.Succeeded;
        CompletedAt = DateTime.UtcNow;
    }

    public void MarkAsFailed()
    {
        if (Status != PaymentStatus.Initiated)
            throw new InvalidOperationException("Only Initiated payment can fail.");

        Status = PaymentStatus.Failed;
        CompletedAt = DateTime.UtcNow;
    }

    public void MarkAsCancelled()
    {
        if (Status != PaymentStatus.Pending && Status != PaymentStatus.Initiated)
            throw new InvalidOperationException("Only Pending or Initiated payment can be cancelled.");

        Status = PaymentStatus.Cancelled;
        CompletedAt = DateTime.UtcNow;
    }

    public void MarkAsExpired()
    {
        if (Status != PaymentStatus.Pending && Status != PaymentStatus.Initiated)
            throw new InvalidOperationException("Only Pending or Initiated payment can expire.");

        Status = PaymentStatus.Expired;
        CompletedAt = DateTime.UtcNow;
    }

    // ✅ Transaction Handling

    public void AddTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
    }
}