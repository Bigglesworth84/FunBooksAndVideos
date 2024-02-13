using PurchaseOrderService.Services.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace PurchaseOrderService.Services
{
    /// <inheritdoc cref="ICustomerService"/>
    [ExcludeFromCodeCoverage]
    public class CustomerService : ICustomerService
    {
        /// <inheritdoc cref="ICustomerService.ActivateMembership(long, string)"/>
        public void ActivateMembership(long customerId, string membership)
        {
            // TODO: Synchronous call to activate the membership.
        }
    }
}
