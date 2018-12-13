using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.DataAccess.Entities
{
    [Table("Images")]
    public class Image
    {
        [Required, StringLength(128)]
        [Key]
        public string Name { get; set; } = DateTime.UtcNow.Ticks.ToString();

        [Required]
        public byte SortOrder { get; set; }
        

        [Required]
        public long ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}