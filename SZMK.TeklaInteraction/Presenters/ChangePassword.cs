using NLog;
using System;
using SZMK.TeklaInteraction.Common;
using SZMK.TeklaInteraction.Services.Interfaces;
using SZMK.TeklaInteraction.Shared.Models;
using SZMK.TeklaInteraction.Shared.Services.Interfaces;
using SZMK.TeklaInteraction.Views.Interfaces;

namespace SZMK.TeklaInteraction.Presenters
{
    class ChangePassword : BasePresener<IChangePassword, User>
    {
        private readonly IChangePassword view;
        private readonly IOperations model;
        private readonly IHash hash;
        private User user;

        private readonly Logger logger;

        public ChangePassword(IApplicationController controller, IChangePassword view, IOperations model, IHash hash) : base(controller, view)
        {
            try
            {
                this.view = view;
                this.model = model;
                this.hash = hash;

                logger = LogManager.GetCurrentClassLogger();

                view.UpdatePassword += () => VerificationPasswords(user, view.OldPassword, view.NewPassword, view.ComparePassword);

                logger.Info("Иницализация контроллера смены пароля успешна");
            }
            catch (Exception Ex)
            {
                View.Error(Ex.Message);
            }
        }
        public override void Run(User argument)
        {
            try
            {
                user = argument;
                view.Show();
                logger.Info("Смена пароля успешно начата");
            }
            catch (Exception Ex)
            {
                View.Error(Ex.Message);
            }
        }

        public void VerificationPasswords(User user, string OldPassword, string NewPassword, string ComparePassword)
        {
            try
            {
                logger.Info("Запущено обновление пароля");

                if (!String.IsNullOrEmpty(OldPassword))
                {
                    if (user.HashPassword == hash.GetSHA256(OldPassword))
                    {
                        if (!String.IsNullOrEmpty(NewPassword))
                        {
                            if (NewPassword == ComparePassword)
                            {
                                model.UpdatePassword(user, hash.GetSHA256(NewPassword));
                                user.UpdPassword = true;
                                view.Close();
                                view.Info("Обновление пароля успешно");
                            }
                            else
                            {
                                view.Error("Новый пароль не совпадает с подтверждением");
                            }
                        }
                        else
                        {
                            view.Error("Пустной новый пароль пользователя");
                        }
                    }
                    else
                    {
                        view.Error("Старый пароль пользователя неверный");
                    }
                }
                else
                {
                    view.Error("Пустой старый пароль пользователя");
                }
            }
            catch (Exception Ex)
            {
                View.Error(Ex.Message);
            }
        }
    }
}
