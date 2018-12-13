using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SimpleStore.DataAccess.Entities.Interfaces;

namespace SimpleStore.DataAccess.Entities.GeneralModels
{
    public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity where T : new()
    {
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [ScaffoldColumn(false)]
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [ScaffoldColumn(false)]
        public DateTime? UpdatedDate { get; set; }

        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string UpdatedBy { get; set; }
    }
}
