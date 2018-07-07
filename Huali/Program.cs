using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Ray.Framework.Config;

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
                Application.Run(new CheckQRCodeState());
            }
            else
            {
                Application.Run(new Form_Main());
            }
            
        }
    }
}
