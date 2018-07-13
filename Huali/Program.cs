using Huali.CheckMailStat;
using Ray.Framework.Config;
using System;
using System.Windows.Forms;

namespace Huali
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();            
            Application.SetCompatibleTextRenderingDefault(false);
            string modelName = ConfigHelper.ReadValueByKey(ConfigHelper.ConfigurationFile.AppConfig, "ModelName");
            if (modelName.ToLower() == "checkmailstat")
            {
                Application.Run(new FrmCheckQRCodeState());
            }
            else
            {
                Application.Run(new FrmMain());
            }
            
        }
    }
}
