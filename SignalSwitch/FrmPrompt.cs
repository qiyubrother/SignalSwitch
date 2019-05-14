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
    public delegate void FormCaptureEventHandler(Bitmap image, EventArgs e);
    public partial class FrmPrompt : BaseForm
    {
        public FormCaptureEventHandler OnCapturesScreen;
        public FrmPrompt()
        {
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnClose.Click += (object sender, EventArgs e2) => Application.Exit();
            btnFullScreen.Click += (s, e2) =>
            {
                ShowInTaskbar = false;
                MaximizeBox = false;
                MinimizeBox = false;
                Text = string.Empty;
                ControlBox = false;
                BackColor = Color.DimGray;
                WindowState = FormWindowState.Maximized;
            };
            btnExitFullScreen.Click += (s, e2) =>
            {
                ShowInTaskbar = true;
                MaximizeBox = false;
                MinimizeBox = false;
                Text = string.Empty;
                ControlBox = true;
                BackColor = Color.DimGray;
                WindowState = FormWindowState.Normal;
            };
        }

        private void FormCapture(Bitmap image, EventArgs e)
        {
            var g = this.CreateGraphics();
            Rectangle rect = new Rectangle();
            rect = Screen.GetWorkingArea(this);
            image = new Bitmap(rect.Width, rect.Height, g);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (OnCapturesScreen != null) {
                var width = Width;
                var height = Height;
                var xOffset = Left + 3;
                var yOffset = Top + 15;
                var bitmap = new Bitmap(width, height);
                Graphics g = Graphics.FromImage(bitmap);
                //g.CopyFromScreen((new System.Drawing.Point(xOffset, yOffset)), new System.Drawing.Point(0, 0), bitmap.Size);
                g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height));
                g.Dispose();

                OnCapturesScreen(bitmap, null);
            }
        }

        public bool EnableCapturesScreen { get => timer1.Enabled; 
            set
            {
                if (!value)
                    timer1.Stop();
                else
                    timer1.Start();
            }
        }
    }
}
