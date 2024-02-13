using PurchaseOrderService.Models.Interfaces;

namespace PurchaseOrderService.Models
{
    /// <summary>
    /// A purchase order.
    /// </summary>
    public class PurchaseOrder
    {
        /// <summary>
        /// The purchase order identifier.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The purchase order total price.
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// The customer identifier.
        /// </summary>
        public long CustomerId { get; set; }

        /// <summary>
        /// The line items in the purchase order.
        /// </summary>
        public List<ILineItem> LineItems { get; set; } = new List<ILineItem>();
    }
}
