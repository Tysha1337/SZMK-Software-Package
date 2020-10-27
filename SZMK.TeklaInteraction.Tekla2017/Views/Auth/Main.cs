using NLog;
using System;
using System.Windows.Forms;
using SZMK.TeklaInteraction.Tekla2017.Views.Auth.Interfaces;

namespace SZMK.TeklaInteraction.Tekla2017.Views.Auth
{
    public partial class Main : Form, IMain
    {
        private readonly ApplicationContext _context;
        private readonly Logger logger;

        public event Action StartedProgram;

        public Main(ApplicationContext context)
        {
            try
            {
                _context = context;
                logger = LogManager.GetCurrentClassLogger();

                InitializeComponent();

                logger.Info("Инициализация успешно пройдена");
            }
            catch
            {
                Error("Ошибка инициализации программы");
                this.Close();
            }
        }

        public new void Show()
        {
            try
            {
                _context.MainForm = this;

                Application.Run(_context);
            }
            catch
            {
                Error("Ошибка запуска программы");
                this.Close();
            }
        }

        public void Info(string Message)
        {
            logger.Info(Message);
            MessageBox.Show(Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Warning(string Message)
        {
            logger.Warn(Message);
            MessageBox.Show(Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void Error(string Message)
        {
            logger.Error(Message);
            MessageBox.Show(Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            logger.Info("Закрытие программы успешно пройдено");
        }

        private void Main_Load(object sender, EventArgs e)
        {
            StartedProgram?.Invoke();
        }
    }
}
