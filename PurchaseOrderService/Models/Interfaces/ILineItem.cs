namespace PurchaseOrderService.Models.Interfaces
{
    /// <summary>
    /// A line item in a purchase order.
    /// </summary>
    public interface ILineItem
    {
        /// <summary>
        /// The name of the line item.
        /// </summary>
        string Name { get; set; }
    }
}
