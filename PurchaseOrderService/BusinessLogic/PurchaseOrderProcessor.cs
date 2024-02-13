using PurchaseOrderService.BusinessLogic.Interfaces;
using PurchaseOrderService.Models;
using PurchaseOrderService.Models.Interfaces;
using PurchaseOrderService.Services.Interfaces;

namespace PurchaseOrderService.BusinessLogic
{
    /// <inheritdoc cref="IPurchaseOrderProcessor"/>
    public class PurchaseOrderProcessor : IPurchaseOrderProcessor
    {
        private readonly ICustomerService _customerService;
        private readonly IShippingService _shippingService;

        public PurchaseOrderProcessor(ICustomerService customerService, IShippingService shippingService)
        {
            _customerService = customerService;
            _shippingService = shippingService;
        }

        /// <inheritdoc cref="IPurchaseOrderProcessor.ProcessOrder(PurchaseOrder)"/>
        public virtual void ProcessOrder(PurchaseOrder purchaseOrder)
        {
            foreach (var item in purchaseOrder.LineItems.Where(i => i is IMembershipLineItem))
            {
                _customerService.ActivateMembership(purchaseOrder.CustomerId, item.Name);
            }

            if (purchaseOrder.LineItems.Exists(i => i is IPhysicalLineItem))
            {
                _shippingService.GenerateShippingSlip(purchaseOrder);
            }
        }
    }
}
