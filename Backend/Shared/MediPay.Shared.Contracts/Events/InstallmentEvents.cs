namespace MediPay.Shared.Contracts.Events;

// پلن اقساط ایجاد شد
public record InstallmentPlanCreatedEvent
{
    public Guid InstallmentPlanId { get; init; }
    public Guid CreditRequestId { get; init; }
    public Guid PatientUserId { get; init; } 
    public Guid DoctorUserId { get; init; }
    public decimal TotalAmount { get; init; }       
    public decimal FeeAmount { get; init; }       
    public decimal FeePercentage { get; init; }    
    public decimal InstallmentAmount { get; init; } // مبلغ هر قسط
    public DateTime CreatedAt { get; init; }
}

// قسط پرداخت شد
public record InstallmentPaidEvent
{
    public Guid InstallmentId { get; init; }
    public Guid InstallmentPlanId { get; init; }
    public Guid PatientUserId { get; init; }
    public int InstallmentNumber { get; init; }     // شماره قسط (1 تا 4)
    public decimal Amount { get; init; }
    public string PaymentReference { get; init; } = default!;
    public DateTime PaidAt { get; init; }
}

// قسط دیرکرد داره
public record InstallmentOverdueEvent
{
    public Guid InstallmentId { get; init; }
    public Guid InstallmentPlanId { get; init; }
    public Guid PatientUserId { get; init; }
    public int InstallmentNumber { get; init; }
    public decimal Amount { get; init; }
    public DateTime DueDate { get; init; }
    public int DaysOverdue { get; init; }
}

// همه اقساط پرداخت شد
public record InstallmentPlanCompletedEvent
{
    public Guid InstallmentPlanId { get; init; }
    public Guid CreditRequestId { get; init; }
    public Guid PatientUserId { get; init; }
    public decimal TotalPaid { get; init; }
    public DateTime CompletedAt { get; init; }
}