using SimpleStore.DataAccess.Annotations;
using SimpleStore.DataAccess.Entities.GeneralModels;
using SimpleStore.DataAccess.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleStore.DataAccess.Entities
{
    public class Order : AuditableEntity<long>
    {
        /// <summary>
        /// Order items
        /// </summary>
        public IEnumerable<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// Order shipping country
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// Order shipping city
        /// </summary>
        public City City { get; set; }

        /// <summary>
        /// Order shipping address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Order date/time
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Order user additional phone number
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Order state - approved/not approved
        /// </summary>
        public bool Status { get; set; } = false;

        /// <summary>
        /// Order total price
        /// </summary>
        [Precision(12, 2)]
        public decimal TotalPrice { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}