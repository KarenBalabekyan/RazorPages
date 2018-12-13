using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SimpleStore.DataAccess.Annotations;
using SimpleStore.DataAccess.Entities.GeneralModels;

namespace SimpleStore.DataAccess.Entities
{
    [Table("Products")]
    public class Product : Entity<int>
    {
        /// <summary>
        /// Product name
        /// </summary>
        [Required, StringLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// Product unit price
        /// </summary>
        [Precision(12, 2)]
        public decimal Price { get; set; }

        /// <summary>
        /// Product description
        /// </summary>
        [Required, StringLength(2048)]
        public string Description { get; set; }

        /// <summary>
        /// Product images
        /// </summary>
        public IEnumerable<Image> Images { get; set; }

        public DateTime DateCreated { get; set; }


        [Required]
        public byte CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ProductCategory Category { get; set; }

        public Product()
        {
            if (Images == null)
            {
                Images = new List<Image>();
            }
        }
    }
}