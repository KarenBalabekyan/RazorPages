using SimpleStore.DataAccess.Entities.GeneralModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.DataAccess.Entities
{
    [Table("Cities")]
    public class City : Entity<int>
    {
        [Required, StringLength(128)]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
    }
}