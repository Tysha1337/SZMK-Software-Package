using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace SZMK.Domain.Models
{
    public class ApplicationRole : IdentityRole
    {
        public virtual ICollection<Status> Statuses { get; set; }
        public ApplicationRole()
        {
            Statuses = new List<Status>();
        }
    }
}
