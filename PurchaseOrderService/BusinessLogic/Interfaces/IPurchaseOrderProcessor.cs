using PurchaseOrderService.Models;

namespace PurchaseOrderService.BusinessLogic.Interfaces
{
    /// <summary>
    /// The purchase order processor.
    /// </summary>
    public interface IPurchaseOrderProcessor
    {
        /// <summary>
        /// Processes a purchase order.
        /// </summary>
        /// <param name="purchaseOrder">The purchase order to process.</param>
        void ProcessOrder(PurchaseOrder purchaseOrder);
    }
}
