using System.Text.Json.Serialization;

namespace PurchaseOrderService.Dtos
{
    /// <summary>
    /// A purchase order data transfer object.
    /// </summary>
    public class PurchaseOrderCreateDto
    {
        /// <summary>
        /// The purchase order identifier.
        /// </summary>
        /// <example>123456</example>
        [JsonPropertyName("id")]
        [JsonRequired]
        public long Id { get; set; }

        /// <summary>
        /// The purchase order total.
        /// </summary>
        /// <example>89.99</example>
        [JsonPropertyName("total")]
        [JsonRequired]
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// The customer identifier.
        /// </summary>
        /// <example>654321</example>
        [JsonPropertyName("customerId")]
        [JsonRequired]
        public long CustomerId { get; set; }

        /// <summary>
        /// The line items in the purchase order.
        /// </summary>
        [JsonPropertyName("lineItems")]
        [JsonRequired]
        public List<PurchaseOrderLineItemCreateDto> LineItems { get; set; } = new List<PurchaseOrderLineItemCreateDto>();
    }
}
