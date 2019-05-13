using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignalSwitch
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 指定窗口在哪个屏幕显示
        /// </summary>
        /// <param name="showOnMonitor"></param>
        /// <param name="frm"></param>
        protected void ShowOnMonitor(int showOnMonitor)
        {
            Screen[] sc;
            sc = Screen.AllScreens;
            if (showOnMonitor >= sc.Length)
            {
                showOnMonitor = 0;
            }

            StartPosition = FormStartPosition.Manual;
            Location = new Point(sc[showOnMonitor].Bounds.Left, sc[showOnMonitor].Bounds.Top);
            // If you intend the form to be maximized, change it to normal then maximized.  
            WindowState = FormWindowState.Normal;
            WindowState = FormWindowState.Maximized;
        }
    }


}
