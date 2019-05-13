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
    public partial class FrmEBlackboard : BaseForm
    {
        public FrmEBlackboard()
        {
            InitializeComponent();

            // 指定显示器输出
            ShowOnMonitor(1);
            ShowInTaskbar = false;
            MaximizeBox = false;
            MinimizeBox = false;
            Text = string.Empty;
            ControlBox = false;
            BackColor = Color.DimGray;
            WindowState = FormWindowState.Maximized;

            #region 调试用代码
            btnClose.BackColor = Color.Red;
            btnClose.ForeColor = Color.Yellow;
            btnClose.Click += (object sender, EventArgs e)=> Close();
            #endregion

        }



    }
}
