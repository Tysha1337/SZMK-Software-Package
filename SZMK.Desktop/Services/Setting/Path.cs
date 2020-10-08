using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.Services.Setting
{
    public class Path
    {
        #region Поля основных файлов с параметрами подключения

        private readonly String _MainConnectDBPath;
        private readonly String _MainConnectMobilePath;
        private readonly String _MainConnectServerMails;
        private readonly String _MainConnectDecodePath;

        #endregion

        #region Поля основных файлов настроек

        private readonly String _MainSettingsPath;

        private readonly String _EmailGeneralConstructorPath;

        #endregion

        #region Поля основных файлов параметров должностей

        private readonly String _KBSettingsPath;

        #endregion

        #region Поля пользовательских файлов

        private readonly String _UserSettingsPath;
        private readonly String _UserArchivePath;
        private readonly String _UserAvtorizationPath;
        private readonly String _UserVisualColumnsPath;
        private readonly String _UserWebCamDevicePath;
        private readonly String _UserScannerPortPath;

        #endregion

        #region Поля шаблонов

        private readonly String _TemplateReportPastTimeofDate;
        private readonly String _TemplateActUniquePath;
        private readonly String _TemplateActNoUniquePath;
        private readonly String _TemplateReportOrderOfDatePath;
        private readonly String _TemplateReportSteelPath;
        private readonly String _TemplateReportCompleteStatusesPath;

        #endregion

        private readonly String _LogPath;

        private readonly String _AboutProgram;


        public Path()
        {
            #region Пути основных файлов с параметрами подключения

            _MainConnectDBPath = $@"Program\Settings\Main\Connect\DataBase\connect.conf"; //Параметры подключения к базе данных
            _MainConnectMobilePath = $@"Program\Settings\Main\Connect\Mobile\connect.conf"; //Параметры подключения к приложению
            _MainConnectDecodePath = $@"Program\Settings\Main\Connect\Decode\connect.conf"; //Параметры подключения к программе распознавания
            _MainConnectServerMails = $@"Program\Settings\Main\Connect\Mails\connect.conf"; //Конфигурация почтового сервера

            #endregion

            #region Пути основных файлов настроек

            _MainSettingsPath = $@"Program\Settings\Main\Settings.conf"; //Путь до файла с настройкой конфигурации ПО

            #endregion

            #region Пути основных файлов параметров должностей

            _KBSettingsPath = $@"Program\Settings\Position\KB\Settings.conf"; //Путь до файла с настройками должности Начальник Групп КБ

            #endregion

            #region Пути пользовательских файлов

            _UserSettingsPath = $@"Program\Settings\User\Settings.conf"; //Путь до файла с настройкой конфигурации ПО
            _UserArchivePath = $@"Program\Settings\User\Path\Archive.conf";//Путь к архиву
            _UserAvtorizationPath = $@"Program\Settings\User\Avtorization.conf";//Путь до сохранненых данных авторизации
            _UserWebCamDevicePath = $@"Program\Settings\User\WebCamDevice.conf";//Путь до выбора девайса с камерой
            _UserScannerPortPath = $@"Program\Settings\User\ScannerPort.conf"; //Путь до файла с настройкой конфигурации ПО
            _UserVisualColumnsPath = $@"Program\Settings\User\ColumnSetting.conf"; //Путь до файла с параметрами отображения столбцов
            _EmailGeneralConstructorPath = $@"Program\Settings\Main\Email\GeneralConstructor.conf";// Путь до файла с почтой главного конструткора

            #endregion

            #region Пути шаблонов

            _TemplateActUniquePath = $@"Program\Templates\ActTemplateUnique.xlsx";//Путь до шаблона акта уникальных чертежей
            _TemplateActNoUniquePath = $@"Program\Templates\ActTemplateNoUnique.xlsx";//Путь до шаблона акта не уникальных чертежей
            _TemplateReportOrderOfDatePath = $@"Program\Templates\ReportOrderOfDateTemplate.xlsx";//Путь до шаблона отчета по дате
            _TemplateReportPastTimeofDate = $@"Program\Templates\ReportPastTimeofDateTemplate.xlsx";//Путь до шаблона отчета по времени
            _TemplateReportSteelPath = $@"Program\Templates\ReportSteelTemplate.xlsx";//Путь до шаблона отчета выборки металла
            _TemplateReportCompleteStatusesPath = $@"Program\Templates\ReportCompleteStatusesTemplate.xlsx";//Путь до шаблона отчета прохождения статусов

            #endregion

            _LogPath = $@"Program\Log"; //Путь к директории хранения логов

            _AboutProgram = $@"AboutProgram.conf"; //Путь до файла с информацией о программе
        }
        #region Свойства основных файлов с параметрами подключения

        public String MainConnectProgramPath
        {
            get
            {
                return _MainConnectDecodePath;
            }
        }

        public String EmailGeneralConstructorPath
        {
            get
            {
                return _EmailGeneralConstructorPath;
            }
        }

        public String MainConnectMobilePath
        {
            get
            {
                return _MainConnectMobilePath;
            }
        }
        public String MainConnectServerMails
        {
            get
            {
                return _MainConnectServerMails;
            }
        }
        public String MainConnectDBPath
        {
            get
            {
                return _MainConnectDBPath;
            }
        }

        #endregion

        #region Свойства основных файлов настроек

        public String MainSettingsPath
        {
            get
            {
                return _MainSettingsPath;
            }
        }

        #endregion

        #region Свойства основных файлов параметров должностей

        public String KBSettingsPath
        {
            get
            {
                return _KBSettingsPath;
            }
        }

        #endregion

        #region Свойства пользовательских файлов

        public String UserSettingsPath
        {
            get
            {
                return _UserSettingsPath;
            }
        }
        public String UserAvtorizationPath
        {
            get
            {
                return _UserAvtorizationPath;
            }
        }

        public String UserVisualColumnsPath
        {
            get
            {
                return _UserVisualColumnsPath;
            }
        }

        public String UserWebCamDevice
        {
            get
            {
                return _UserWebCamDevicePath;
            }
        }

        public String UserScannerPort
        {
            get
            {
                return _UserScannerPortPath;
            }
        }
        public String UserArhivePath
        {
            get
            {
                return _UserArchivePath;
            }
        }

        #endregion

        #region Свойства шаблонов

        public String TemplateActUniquePath
        {
            get
            {
                return _TemplateActUniquePath;
            }
        }
        public String TemplateActNoUniquePath
        {
            get
            {
                return _TemplateActNoUniquePath;
            }
        }
        public String TemplateReportOrderOfDatePath
        {
            get
            {
                return _TemplateReportOrderOfDatePath;
            }
        }
        public String TemplateReportPastTimeofDate
        {
            get
            {
                return _TemplateReportPastTimeofDate;
            }
        }
        public String TemplateReportSteel
        {
            get
            {
                return _TemplateReportSteelPath;
            }
        }
        public String TemplateReportCompleteStatuses
        {
            get
            {
                return _TemplateReportCompleteStatusesPath;
            }
        }

        #endregion

        #region Методы получения директории и имени файла
        public String GetDirectory(String Path)
        {
            String[] Temp = Path.Split('\\');
            String Directory = String.Empty;

            for (Int32 i = 0; i < Temp.Length - 1; i++)
            {
                Directory += Temp[i] + @"\";
            }

            return Directory;
        }

        public String GetFileName(String Path)
        {
            String[] Temp = Path.Split('\\');
            String FileName = String.Empty;
            FileName += Temp[Temp.Length - 1];
            return FileName;
        }
        #endregion

        #region Пути до файлов
        public String LogPath
        {
            get
            {
                return _LogPath;
            }
        }
        #endregion

        #region Свойство файла информации о программе

        public String AboutProgram
        {
            get
            {
                return _AboutProgram;
            }
        }

        #endregion
    }
}
