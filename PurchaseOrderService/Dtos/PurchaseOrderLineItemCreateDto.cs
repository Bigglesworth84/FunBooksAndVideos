﻿using System.Text.Json.Serialization;

namespace PurchaseOrderService.Dtos
{
    /// <summary>
    /// A purchase order line item data transfer object.
    /// </summary>
    public class PurchaseOrderLineItemCreateDto
    {
        /// <summary>
        /// The name of the product.
        /// </summary>
        /// <example>How to Make a Cake: A Step by Step Tutorial</example>
        [JsonPropertyName("name")]
        [JsonRequired]
        public required string Name { get; set; }

        /// <summary>
        /// The type of product.
        /// </summary>
        /// <example>Video</example>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LineItemType Type { get; set; }
    }
}
