using AutoMapper;
using PurchaseOrderService.Dtos;
using PurchaseOrderService.Models;
using PurchaseOrderService.Models.Interfaces;

namespace PurchaseOrderService.Profiles
{
    /// <summary>
    /// The mapping profile for order items.
    /// </summary>
    public class PurchaseOrderItemProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseOrderItemProfile"/> class.
        /// </summary>
        public PurchaseOrderItemProfile()
        {
            CreateMap<PurchaseOrderLineItemCreateDto, Video>();
            CreateMap<PurchaseOrderLineItemCreateDto, Book>();
            CreateMap<PurchaseOrderLineItemCreateDto, Membership>();
        }
    }
}
