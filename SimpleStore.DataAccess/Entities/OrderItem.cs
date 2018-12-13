using SimpleStore.DataAccess.Annotations;
using SimpleStore.DataAccess.Entities.GeneralModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.DataAccess.Entities
{
    [Table("OrderItems")]
    public class OrderItem : Entity<long>
    {
        /// <summary>
        ///Ordered product name
        /// </summary>
        [Required, StringLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// Ordered product unit price
        /// </summary>
        [Precision(12, 2)]
        public decimal Price { get; set; }

        /// <summary>
        ///Ordered product description
        /// </summary>
        [Required, StringLength(2048)]
        public string Description { get; set; }

        /// <summary>
        /// Ordered product images
        /// </summary>
        public IEnumerable<Image> Images { get; set; }



        [Required]
        public byte CategoryId { get; set; }

        /// <summary>
        /// Ordered product category
        /// </summary>
        [ForeignKey("CategoryId")]
        public virtual ProductCategory Category { get; set; }

        [Required, MinLength(1)]
        public long OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
    }
}