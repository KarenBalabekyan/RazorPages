using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SimpleStore.DataAccess.Entities.Interfaces;

namespace SimpleStore.DataAccess.Entities.GeneralModels
{
    public abstract class BaseEntity { }

    public abstract class Entity<T> : BaseEntity, IEntity<T> where T : new()
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public virtual T Id { get; set; }
    }
}
