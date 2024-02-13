using PurchaseOrderService.Models;
using PurchaseOrderService.Services.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace PurchaseOrderService.Services
{
    /// <inheritdoc cref="IShippingService"/>
    [ExcludeFromCodeCoverage]
    public class ShippingService : IShippingService
    {
        /// <inheritdoc cref="IShippingService.GenerateShippingSlip(PurchaseOrder)"/>
        public void GenerateShippingSlip(PurchaseOrder purchaseOrder)
        {
            // TODO: Asynchronous call to a bus / queue to to send a message to generate the shipping slip.
        }
    }
}
