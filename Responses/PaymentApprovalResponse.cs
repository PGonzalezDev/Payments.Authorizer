namespace Payments.Authorizer.Responses;

public class PaymentApprovalResponse
{
    public decimal Amount { get; set; }
    public bool Approved { get; set; }
}
