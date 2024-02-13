using AutoMapper;
using PurchaseOrderService.Dtos;
using PurchaseOrderService.Models;
using PurchaseOrderService.Profiles;

namespace PurchaseOrderService.Tests
{
    [TestFixture]
    public class PurchaseOrderProfileTests
    {
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PurchaseOrderProfile>();
                cfg.AddProfile<PurchaseOrderItemProfile>();
            });
            _mapper = new Mapper(configuration);
        }

        [Test]
        public void Configuration_IsValid()
        {
            // Assert
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void Map_PurchaseOrderCreateDtoToPurchaseOrder_CorrectMapping()
        {
            // Arrange
            var orderDto = new PurchaseOrderCreateDto
            {
                Id = 1,
                CustomerId = 2,
                TotalPrice = 100,
                LineItems = new List<PurchaseOrderLineItemCreateDto>
                {
                    new PurchaseOrderLineItemCreateDto { Name = "Video 1", Type = LineItemType.Video },
                    new PurchaseOrderLineItemCreateDto { Name = "Book 1", Type = LineItemType.Book },
                    new PurchaseOrderLineItemCreateDto { Name = "Membership 1", Type = LineItemType.Membership }
                }
            };

            // Act
            var order = _mapper.Map<PurchaseOrder>(orderDto);

            // Assert
            Assert.IsNotNull(order);
            Assert.That(order.Id, Is.EqualTo(1));
            Assert.That(order.CustomerId, Is.EqualTo(2));
            Assert.That(order.TotalPrice, Is.EqualTo(100));
            Assert.That(order.LineItems.Count, Is.EqualTo(3));
            Assert.IsTrue(order.LineItems[0] is Video);
            Assert.IsTrue(order.LineItems[1] is Book);
            Assert.IsTrue(order.LineItems[2] is Membership);
        }
    }
}
