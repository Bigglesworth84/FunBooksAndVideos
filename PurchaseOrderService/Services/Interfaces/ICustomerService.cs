namespace PurchaseOrderService.Services.Interfaces
{
    /// <summary>
    /// The customer service.
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Activate a membership for a customer.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="membership">The membership to activate.</param>
        void ActivateMembership(long customerId, string membership);
    }
}
