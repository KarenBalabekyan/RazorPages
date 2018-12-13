using System;

namespace SimpleStore.DataAccess.Entities.Interfaces
{
    public interface IAuditableEntity
    {
        DateTime CreatedDate { get; set; }

        DateTime? UpdatedDate { get; set; }

        string UpdatedBy { get; set; }
    }
}