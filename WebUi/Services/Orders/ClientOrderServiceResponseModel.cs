using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebUi.Services.Orders
{
    /// <summary>
    /// Order Details.
    /// </summary>
    [DataContract(Name = "clientOrders")]
    [SwaggerSchemaFilter(typeof(ClientOrderServiceResponseModellSchemaFilter))]

    public class ClientOrderServiceResponseModel
    {
        /// <summary>
        /// The client ID that placed the order.
        /// </summary>
        [DataMember(Name = "clientId")]
        public int PersonID { get; set; }
        /// <summary>
        /// Client full name.
        /// </summary>
        [DataMember(Name = "name")]
        public string FullName { get; set; }
        /// <summary>
        /// The client email address.
        /// </summary>
        [DataMember(Name = "emailAddress")]
        public string EmailAddress { get; set; }
        /// <summary>
        /// Client phone number.
        /// </summary>
        [DataMember(Name = "phoneNumber")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Order ID.
        /// </summary>
        [DataMember(Name = "orderId")]
        public int OrderID { get; set; }
        /// <summary>
        /// Order Description.
        /// </summary>
        [DataMember(Name = "orderDescription")]
        public string Description { get; set; }
        /// <summary>
        /// Order price.
        /// </summary>
        [DataMember(Name = "orderPrice")]
        public decimal UnitPrice { get; set; }
    }

    public class ClientOrderServiceResponseModellSchemaFilter : ISchemaFilter
    {
        public void Apply(Schema schema, SchemaFilterContext context)
        {
            schema.Example = new ClientOrderServiceResponseModel
            {
                Description = "LG Double door fridge.",
                EmailAddress = "client@home.com",
                FullName = "David Jones",
                OrderID = 997,
                PersonID = 33776,
                PhoneNumber = "8474480214",
                UnitPrice = 1599
            };
        }
    }
}
