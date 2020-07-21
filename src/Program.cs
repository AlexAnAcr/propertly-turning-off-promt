using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LaptopPropertlyTurningOffPromt
{
    static class Program
    {
        public static int npof;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Microsoft.Win32.RegistryKey un_true_off = Microsoft.Win32.Registry.CurrentUser;
            un_true_off = un_true_off.OpenSubKey("SOFTWARE", true); bool entry_finded = false;
            foreach (string i in un_true_off.GetSubKeyNames())
            {
                if (i == "LPTOP{29732-75953-75739-51753797}")
                {
                    entry_finded = true;
                }
            }
            if (entry_finded)
            {

                un_true_off = un_true_off.OpenSubKey("LPTOP{29732-75953-75739-51753797}",true);
                string r_state = (string)un_true_off.GetValue("state");
                npof = int.Parse((string)un_true_off.GetValue("count"));
                un_true_off.SetValue("state", "launched", Microsoft.Win32.RegistryValueKind.String);
                if (r_state == "launched")
                {
                    npof++;
                    un_true_off.SetValue("count", npof, Microsoft.Win32.RegistryValueKind.String);
                    un_true_off.Close();
                    Application.Run(new context(true));
                }
                else
                {
                    un_true_off.Close();
                    Application.Run(new context(false));
                }
            }
            else
            {
                un_true_off = un_true_off.CreateSubKey("LPTOP{29732-75953-75739-51753797}");
                un_true_off.SetValue("state", "launched",Microsoft.Win32.RegistryValueKind.String);
                un_true_off.SetValue("count", "0", Microsoft.Win32.RegistryValueKind.String);
                un_true_off.Close();
                Application.Run(new context(false));
            }
        }

        public static void Application_ApplicationExit()
        {
            Microsoft.Win32.RegistryKey un_true_off = Microsoft.Win32.Registry.CurrentUser;
            un_true_off = un_true_off.OpenSubKey("SOFTWARE\\LPTOP{29732-75953-75739-51753797}", true);
            un_true_off.SetValue("state", "closed", Microsoft.Win32.RegistryValueKind.String);
            un_true_off.Close();
        }
        public static void Open_MainForm()
        {
            Form st_form = new Main();
            st_form.Show();
        }
    }
    class context : ApplicationContext
    {
        public context(bool state) {
            if (state == true) {
                Form st_form = new Start();
                Form wait_form = new wait();
                st_form.Show();
                wait_form.Show();
            } else {
                Form st_form = new wait();
                st_form.Show();
            }
            
        }
        
    }
}
