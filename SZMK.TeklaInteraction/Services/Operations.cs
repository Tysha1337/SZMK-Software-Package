using System;
using System.Collections.Generic;
using System.Linq;
using SZMK.TeklaInteraction.Services.Interfaces;
using SZMK.TeklaInteraction.Shared.Models;
using SZMK.TeklaInteraction.Shared.Services;

namespace SZMK.TeklaInteraction.Services
{
    class Operations : IOperations
    {
        private Request request;
        public bool Authrozation(string Login, string HashPass)
        {
            if (GetUser(Login).HashPassword == HashPass)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public User GetUser(string Login)
        {
            User user = GetUsers().Where(p => p.Login == Login).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new Exception("Пользователь не найден");
            }
        }

        public List<User> GetUsers()
        {
            request = new Request();

            List<User> users = request.GetAllUsers();

            if (users.Count > 0)
            {
                return users;
            }
            else
            {
                throw new Exception("Пользователи не найдены");
            }
        }
        public bool UpdatePassword(User user, string HasPass)
        {
            try
            {
                request = new Request();

                if (request.UpdatePasswordText(HasPass, user))
                {
                    request.UpdatePassword(user, true);
                }

                return true;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
    }
}
