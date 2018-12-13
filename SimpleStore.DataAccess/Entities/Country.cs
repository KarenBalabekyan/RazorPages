using System.Collections.Generic;
using SimpleStore.DataAccess.Entities.GeneralModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.DataAccess.Entities
{
    [Table("Countries")]
    public class Country : Entity<int>
    {
        /// <summary>
        /// Country Name
        /// </summary>
        [Required, StringLength(128)]
        public string Name { get; set; }

        public IEnumerable<City> Cities { get; set; }
    }
}