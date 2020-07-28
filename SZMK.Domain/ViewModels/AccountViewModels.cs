using System;
using System.Collections.Generic;

namespace SZMK.Domain.ViewModels
{
    // Модели, возвращаемые действиями AccountController.

    public class ManageInfoViewModel
    {
        public IEnumerable<UsersInfoViewModel> Users { get; set; }
    }

    public class UserInfoViewModel
    {
        public DateTime DateCreate { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }
        public string MidName { get; set; }
        public string SurName { get; set; }

        public IList<string> RoleNames { get; set; }

        public List<string> Statuses { get; set; }

        public bool Enable { get; set; }
    }

    public class UsersInfoViewModel
    {
        public DateTime DateCreate { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }
        public string MidName { get; set; }
        public string SurName { get; set; }

        public IList<string> RoleNames { get; set; }
        public bool Enable { get; set; }
    }
}
