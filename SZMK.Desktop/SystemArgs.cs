using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZMK.Desktop.Models;
using SZMK.Desktop.Services;
using SZMK.Desktop.Services.Scan;
using SZMK.Desktop.Services.Setting;

namespace SZMK.Desktop
{
    public static class SystemArgs
    {
        static public Models.User User; // Пользователь, который зашел в систему

        static public Services.Setting.Path Path; //Системные пути
        static public Services.Setting.MobileApplication MobileApplication; //Конфигурация мобильного приложения
        static public Services.Setting.Program SettingsProgram; // Конфигурация клиентского программного обеспечения
        static public Services.Setting.User SettingsUser; // Конфигурация клиентского программного обеспечения
        static public Services.Setting.Position SettingsPosition; // Конфигурация клиентского программного обеспечения
        static public Services.Setting.ServerMail ServerMail; //Конфигурация почтового сервера
        static public Services.Setting.DataBase DataBase; //Конфигурация базы данных
        static public Services.Setting.SelectedColumn SelectedColumn;//Конфигурация отображения столбцов
        static public Services.Setting.AboutProgram About;//Информация о программе

        static public Services.Sleep Sleep;//Класс проверки неактивности пользователя

        static public Services.Request Request; //Слой запросов к базе данных
        static public Services.RequestLinq RequestLinq; //Слой запросов Linq к полученным из БД данным
        static public Services.Template Template;//Проверка шаблонов
        static public Services.Excel Excel;//Формирование Актов при добавлении чертежей
        static public Services.UnLoadSpecific UnLoadSpecific;//Проверка выгрузки деталей

        static public Services.Scan.ByteScout ByteScout; // Конфигурация программы распознавания
        static public Services.Scan.ServerMobileAppOrder ServerMobileAppOrder; //Сервер для получения данных с мобильного ПО чертежей
        static public Services.Scan.ServerMobileAppBlankOrder ServerMobileAppBlankOrder; //Сервер для получения данных с мобильного ПО бланков заказов
        static public Services.Scan.WebcamScanOrder WebcamScanOrder; //Класс получения распознования с вебкамеры по чертежам
        static public Services.Scan.WebcamScanBlankOrder WebcamScanBlankOrder; //Класс получения распознования с вебкамеры по чертежам
        static public Services.Scan.ScannerOrder ScannerOrder;//Класс получения распознования со сканера по чертежам
        static public Services.Scan.ScannerBlankOrder ScannerBlankOrder;//Класс получения распознования со сканера по бланкам заказов

        static public List<Models.Mail> Mails; //Общий список адресов почты
        static public List<Models.Position> Positions; //Общий список должностей
        static public List<Models.User> Users; //общий список пользователей в системе
        static public List<Models.Order> Orders; // Общий список заказов
        static public List<Models.BlankOrderOfOrder> BlankOrderOfOrders; //Общий список всех присвоенных бланков заказов к чертежам
        static public List<Models.StatusOfOrder> StatusOfOrders; //Общий список всех присвоенных статусов к чертежам
        static public List<Models.Status> Statuses;//Общий список возможных статусов
        static public List<Models.BlankOrder> BlankOrders;//Общий список возможных бланков заказа
        static public List<Models.TypeAdd> TypesAdds;//Общий типов добавления
        static public List<Models.Model> Models;//Общий список моделей

        public static void PrintLog(String Message)
        {
            Log Temp = new Log(Message);
            Temp.Print();
        }
    }
}
