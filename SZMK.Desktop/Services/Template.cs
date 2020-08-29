using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.Services
{
    /*Данный класс описывает проверку всех шаблонных файлов на их наличие в нужной директории,
     Проверка вызывается после создания объекта класса*/
    public class Template
    {
        public Template()
        {
            try 
            {
                CheckFiles();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void CheckFiles()
        {
            if (!File.Exists(SystemArgs.Path.TemplateActUniquePath))
            {
                throw new Exception("Не найден шаблон акта уникальных чертежей");
            }
            if (!File.Exists(SystemArgs.Path.TemplateActNoUniquePath))
            {
                throw new Exception("Не найден шаблон акта не уникальных чертежей");
            }
            if (!File.Exists(SystemArgs.Path.TemplateReportOrderOfDatePath))
            {
                throw new Exception("Не найден шаблон отчета за выбранный период чертежей");
            }
        }
    }
}
