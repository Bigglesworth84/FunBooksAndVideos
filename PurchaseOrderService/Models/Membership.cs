using PurchaseOrderService.Models.Interfaces;

namespace PurchaseOrderService.Models
{
    /// <summary>
    /// A membership.
    /// </summary>
    public class Membership : IMembershipLineItem
    {
        /// <summary>
        /// The membership name.
        /// </summary>
        public required string Name { get; set; }
    }
}
