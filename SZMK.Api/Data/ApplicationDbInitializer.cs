using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using SZMK.Domain.Models;

namespace SZMK.Api.Data
{
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext db)
        {

            #region Manager

            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(db));

            #endregion

            #region Roles Creation

            var roleAdmin = new ApplicationRole { Name = "Администратор" };
            var roleDesignEngineer = new ApplicationRole { Name = "Инженер конструктор" };
            var roleKB = new ApplicationRole { Name = "Начальник групп КБ" };
            var roleArhive = new ApplicationRole { Name = "Архивариус" };
            var rolePDO = new ApplicationRole { Name = "Сотрудник ПДО" };
            var roleChiefPDO = new ApplicationRole { Name = "Начальник ПДО" };
            var roleOPP = new ApplicationRole { Name = "Сотрудник ОПП" };

            roleManager.Create(roleAdmin);
            roleManager.Create(roleDesignEngineer);
            roleManager.Create(roleKB);
            roleManager.Create(roleArhive);
            roleManager.Create(rolePDO);
            roleManager.Create(roleChiefPDO);
            roleManager.Create(roleOPP);

            #endregion

            #region User Creation

            var admin = new ApplicationUser { UserName = "ROOT", Name = "ROOT", MidName = "ROOT", SurName = "ROOT", DateCreate = DateTime.Now, Enable = true };
            string passwordAdmin = "askede12AS!";
            var resultAdmin = userManager.Create(admin, passwordAdmin);

            if (resultAdmin.Succeeded)
            {
                userManager.AddToRole(admin.Id, roleAdmin.Name);
            }

            #endregion

            #region Statuses Creation

            Status statusDesingEngineer = new Status { Name = "Добавлен инженером конструктором", Role = roleDesignEngineer };
            Status statusKB = new Status { Name = "Добавлен начальником групп КБ", Role = roleKB };
            Status statusArhive = new Status { Name = "Передан в архив", Role = roleArhive };
            Status statusSubContractor = new Status { Name = "ПДО-Субподряд", Role = rolePDO };
            Status statusСreditOrder = new Status { Name = "ПДО-Приходный ордер", Role = rolePDO };
            Status statusPDO = new Status { Name = "Передан в ПДО", Role = rolePDO };
            Status statusOPP = new Status { Name = "Передан в ОПП", Role = roleOPP };

            db.Status.Add(statusDesingEngineer);
            db.Status.Add(statusKB);
            db.Status.Add(statusArhive);
            db.Status.Add(statusSubContractor);
            db.Status.Add(statusСreditOrder);
            db.Status.Add(statusPDO);
            db.Status.Add(statusOPP);

            db.SaveChanges();

            #endregion

            base.Seed(db);
        }
    }
}