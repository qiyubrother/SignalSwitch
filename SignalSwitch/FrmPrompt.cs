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

            //OnCapturesScreen += FormCapture;
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
                var g = this.CreateGraphics();
                Rectangle rect = new Rectangle();
                rect = Screen.GetWorkingArea(this);
                var image = new Bitmap(rect.Width, rect.Height, g);
                OnCapturesScreen(image, null);
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
