using PurchaseOrderService.Models.Interfaces;

namespace PurchaseOrderService.Models
{
    /// <summary>
    /// A video.
    /// </summary>
    public class Video : ILineItem
    {
        /// <summary>
        /// The name of the video.
        /// </summary>
        public required string Name { get; set; }
    }
}
