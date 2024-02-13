using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PurchaseOrderService.BusinessLogic.Interfaces;
using PurchaseOrderService.Controllers;
using PurchaseOrderService.Dtos;
using PurchaseOrderService.Models;

namespace PurchaseOrderService.Tests.Controllers
{
    [TestFixture]
    public class OrdersControllerTests
    {
        private Mock<IPurchaseOrderProcessor> _orderProcessorMock;
        private Mock<IMapper> _mapperMock;
        private Mock<ILogger<OrdersController>> _loggerMock;
        
        private OrdersController _controller;

        [SetUp]
        public void Setup()
        {
            _orderProcessorMock = new Mock<IPurchaseOrderProcessor>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<OrdersController>>();

            _controller = new OrdersController(_orderProcessorMock.Object, _mapperMock.Object, _loggerMock.Object);
        }

        [Test]
        public void CreateOrder_WithValidOrder_ReturnsCreatedResult()
        {
            // Arrange
            var orderDto = new PurchaseOrderCreateDto();
            var orderModel = new PurchaseOrder();

            _mapperMock.Setup(m => m.Map<PurchaseOrder>(orderDto)).Returns(orderModel);

            // Act
            var result = _controller.CreateOrder(orderDto);

            // Assert
            Assert.IsInstanceOf<CreatedResult>(result);
        }

        [Test]
        public void CreateOrder_WithNullOrderDto_ReturnsBadRequestResult()
        {
            // Arrange
            PurchaseOrderCreateDto orderDto = null!;

            // Act
            var result = _controller.CreateOrder(orderDto!);

            // Assert
            Assert.IsInstanceOf<BadRequestResult>(result);
        }

        [Test]
        public void CreateOrder_ThrowsException_ReturnsInternalServerErrorResult()
        {
            // Arrange
            var orderDto = new PurchaseOrderCreateDto();
            var orderModel = new PurchaseOrder();

            _mapperMock.Setup(m => m.Map<PurchaseOrder>(orderDto)).Returns(orderModel);
            _orderProcessorMock.Setup(op => op.ProcessOrder(orderModel)).Throws(new Exception());

            // Act
            var result = _controller.CreateOrder(orderDto);

            // Assert
            Assert.IsInstanceOf<StatusCodeResult>(result);
            var statusCodeResult = (StatusCodeResult)result;
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(500));
        }
    }
}
