using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EMS
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //直接进入主界面
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Main());

            //以下为启动登陆用
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            cs.SplashFadeAppContext splashContext = new cs.SplashFadeAppContext(new login(), new start());
            Application.Run(splashContext);
        }
    }
}
