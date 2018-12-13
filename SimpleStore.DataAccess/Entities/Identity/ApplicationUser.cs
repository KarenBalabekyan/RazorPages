using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleStore.DataAccess.Entities.Identity
{
    //https://docs.microsoft.com/en-us/aspnet/core/migration/1x-to-2x/identity-2x
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(128)]
        public string FullName { get; set; }

        [Required]
        public DateTime JoinDate { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public DateTime? LastAccessDate { get; set; }

        public IEnumerable<Order> Orders { get; set; }


        public ApplicationUser()
        {  
            if (Orders == null)
            {
                Orders = new List<Order>();
            }
        }
    }
}
