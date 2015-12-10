using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace authmanager
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
           //cs.SplashFadeAppContext splashContext = new cs.SplashFadeAppContext(new login(), new start());
           //Application.Run(splashContext);
           Application.Run(new login());
        }
    }
}