using Microsoft.AspNet.Identity.EntityFramework;
using SZMK.Domain.Models;

namespace SZMK.Api.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base($@"Server=localhost\SQLEXPRESS;Database=TestDB;Trusted_Connection=True;User Id = sa;Password = askede12AS!", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<SZMK.Domain.Models.BlankOrder> BlankOrders { get; set; }

        public System.Data.Entity.DbSet<SZMK.Domain.Models.Detail> Details { get; set; }

        public System.Data.Entity.DbSet<SZMK.Domain.Models.Drawing> Drawings { get; set; }

        public System.Data.Entity.DbSet<SZMK.Domain.Models.MarkSteel> MarkSteels { get; set; }

        public System.Data.Entity.DbSet<SZMK.Domain.Models.Profile> Profiles { get; set; }

        public System.Data.Entity.DbSet<SZMK.Domain.Models.Model> Models { get; set; }

        public System.Data.Entity.DbSet<SZMK.Domain.Models.Mail> Mails { get; set; }

        public System.Data.Entity.DbSet<SZMK.Domain.Models.ModifyDrawing> ModifyDrawings { get; set; }

        public System.Data.Entity.DbSet<SZMK.Domain.Models.Status> Status { get; set; }
    }
}