using PurchaseOrderService.Models;

namespace PurchaseOrderService.Services.Interfaces
{
    /// <summary>
    /// The shipping service.
    /// </summary>
    public interface IShippingService
    {
        /// <summary>
        /// Generates a shipping slip for a purchase order.
        /// </summary>
        /// <param name="purchaseOrder">The purchase order.</param>
        void GenerateShippingSlip(PurchaseOrder purchaseOrder);
    }
}
