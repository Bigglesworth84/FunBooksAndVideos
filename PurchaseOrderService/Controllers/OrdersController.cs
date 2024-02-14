using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PurchaseOrderService.BusinessLogic.Interfaces;
using PurchaseOrderService.Dtos;
using PurchaseOrderService.Models;

namespace PurchaseOrderService.Controllers
{
    /// <summary>
    /// The purchase order controller.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IPurchaseOrderProcessor _orderProcessor;
        private readonly IMapper _mapper;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IPurchaseOrderProcessor orderProcessor, IMapper mapper, ILogger<OrdersController> logger)
        {
            _orderProcessor = orderProcessor;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Submit a purchase order for processing.
        /// </summary>
        /// <param name="orderDto">The purchase order.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult CreateOrder([FromBody] PurchaseOrderCreateDto orderDto)
        {
            if (orderDto == null)
                return BadRequest();

            var orderModel = _mapper.Map<PurchaseOrder>(orderDto);

            try
            {
                _orderProcessor.ProcessOrder(orderModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the order.");
                return new StatusCodeResult(500);
            }

            return Created();
        }
    }
}
