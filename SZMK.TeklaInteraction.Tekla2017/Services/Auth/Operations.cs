using System;
using System.Collections.Generic;
using System.Linq;
using SZMK.TeklaInteraction.Shared.Models;
using SZMK.TeklaInteraction.Shared.Services;
using SZMK.TeklaInteraction.Tekla2017.Services.Auth.Interfaces;

namespace SZMK.TeklaInteraction.Tekla2017.Services.Auth
{
    class Operations : IOperations
    {
        List<User> users;
        private readonly Request request = new Request();
        public bool Authrozation(string Login, string HashPass)
        {
            try
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
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
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
            users = request.GetAllUsers();

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
                if (request.UpdatePasswordText(HasPass, user))
                {
                    request.UpdatePassword(user, true);
                }

                return true;
            }
            catch (Exception E)
            {
                throw new Exception(E.Message, E);
            }
        }
    }
}
