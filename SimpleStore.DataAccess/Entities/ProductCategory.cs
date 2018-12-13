using System.Collections.Generic;
using SimpleStore.DataAccess.Entities.GeneralModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.DataAccess.Entities
{
    [Table("Categories")]
    public class ProductCategory : Entity<byte>
    {
        [Required, StringLength(128)]
        public string Name { get; set; }
        

        public virtual IEnumerable<Product> Products { get; set; }
    }
}