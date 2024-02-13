using PurchaseOrderService.Models.Interfaces;

namespace PurchaseOrderService.Models
{
    /// <summary>
    /// A book.
    /// </summary>
    public class Book : IPhysicalLineItem
    {
        /// <summary>
        /// The name of the book.
        /// </summary>
        public required string Name { get; set; }
    }
}
