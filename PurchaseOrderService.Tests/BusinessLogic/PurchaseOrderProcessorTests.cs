using Moq;
using PurchaseOrderService.BusinessLogic;
using PurchaseOrderService.Models;
using PurchaseOrderService.Models.Interfaces;
using PurchaseOrderService.Services.Interfaces;

namespace PurchaseOrderService.Tests.BusinessLogic
{
    [TestFixture]
    public class PurchaseOrderProcessorTests
    {
        [Test]
        public void ProcessOrder_ActivatesMemberships_WhenMembershipLineItemExists()
        {
            // Arrange
            var customerServiceMock = new Mock<ICustomerService>();
            var shippingServiceMock = new Mock<IShippingService>();

            var processor = new PurchaseOrderProcessor(customerServiceMock.Object, shippingServiceMock.Object);

            var purchaseOrder = new PurchaseOrder
            {
                CustomerId = 123,
                LineItems = new List<ILineItem>
                {
                    new Membership { Name = "Premium Membership" }
                }
            };

            // Act
            processor.ProcessOrder(purchaseOrder);

            // Assert
            customerServiceMock.Verify(c => c.ActivateMembership(purchaseOrder.CustomerId, "Premium Membership"), Times.Once);
            shippingServiceMock.Verify(s => s.GenerateShippingSlip(It.IsAny<PurchaseOrder>()), Times.Never);
        }

        [Test]
        public void ProcessOrder_GeneratesShippingSlip_WhenPhysicalLineItemExists()
        {
            // Arrange
            var customerServiceMock = new Mock<ICustomerService>();
            var shippingServiceMock = new Mock<IShippingService>();

            var processor = new PurchaseOrderProcessor(customerServiceMock.Object, shippingServiceMock.Object);

            var purchaseOrder = new PurchaseOrder
            {
                CustomerId = 123,
                LineItems = new List<ILineItem>
                {
                    new Book { Name = "Product A" }
                }
            };

            // Act
            processor.ProcessOrder(purchaseOrder);

            // Assert
            customerServiceMock.Verify(c => c.ActivateMembership(It.IsAny<long>(), It.IsAny<string>()), Times.Never);
            shippingServiceMock.Verify(s => s.GenerateShippingSlip(purchaseOrder), Times.Once);
        }
    }
}
