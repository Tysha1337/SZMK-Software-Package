using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SZMK.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Здесь добавьте настраиваемые утверждения пользователя
            return userIdentity;
        }

        public string Name { get; set; }
        public string MidName { get; set; }
        public string SurName { get; set; }

        public DateTime DateCreate { get; set; }

        public bool Enable { get; set; }

        public virtual ICollection<Mail> Mails { get; set; }
        public virtual ICollection<ModifyDrawing> ModifyDrawings { get; set; }

        public ApplicationUser()
        {
            Mails = new List<Mail>();
            ModifyDrawings = new List<ModifyDrawing>();
        }
    }
}