using AutoMapper;
using PurchaseOrderService.Dtos;
using PurchaseOrderService.Models;
using PurchaseOrderService.Models.Interfaces;

namespace PurchaseOrderService.Profiles
{
    /// <summary>
    /// The mapping profile for purchase order.
    /// </summary>
    public class PurchaseOrderProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseOrderProfile"/> class.
        /// </summary>
        public PurchaseOrderProfile()
        {
            CreateMap<PurchaseOrderCreateDto, PurchaseOrder>()
                .ForMember(
                    o => o.LineItems, 
                    opt => opt.MapFrom((orderDto, order, i, context) => 
                    { 
                        return MapLineItems(orderDto.LineItems, context); 
                    }));
        }

        private List<ILineItem> MapLineItems(List<PurchaseOrderLineItemCreateDto> lineItems, ResolutionContext context)
        {
            var results = new List<ILineItem>();

            lineItems.ForEach(lineItem =>
            {
                results.Add(lineItem.Type switch
                {
                    LineItemType.Video => context.Mapper.Map<PurchaseOrderLineItemCreateDto, Video>(lineItem),
                    LineItemType.Book => context.Mapper.Map<PurchaseOrderLineItemCreateDto, Book>(lineItem),
                    LineItemType.Membership => context.Mapper.Map<PurchaseOrderLineItemCreateDto, Membership>(lineItem),
                    _ => throw new NotImplementedException($"Item type '{lineItem.Type}' is not supported.")
                });
            });

            return results;
        }
    }
}