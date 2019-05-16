using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using AForge;
using AForge.Video;
using AForge.Controls;
using AForge.Imaging;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;

namespace SignalSwitch
{
    public partial class FrmMain : Form
    {
        VideoCaptureDevice videoSource;
        public FormCaptureEventHandler OnCapturesScreen;

        public FrmMain()
        {
            InitializeComponent();
        }
        // 定义电子白板屏对象
        FrmEBlackboard frmEBlackboard = new FrmEBlackboard();
        // 定义提示屏对象
        FrmPrompt frmPrompt = new FrmPrompt();

        int cameraTeacherNum = 1;
        int cameraObjectNum = 0;

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            //frmPrompt.Show();
            var slaves = Screen.AllScreens.Where(x => !x.Primary).ToList();

            int slaveEBlackboardNum = 0; // 电子白板屏屏幕编号
            int slavePromptNum = 1; // 提示屏屏幕编号

            #region 显示电子白板屏窗口
            if (slaves.Count > 0)
            {
                frmEBlackboard.Top = 0;
                frmEBlackboard.Left = slaves[slaveEBlackboardNum].Bounds.Width;
                frmEBlackboard.Size = new System.Drawing.Size(slaves[slaveEBlackboardNum].Bounds.Width, slaves[slaveEBlackboardNum].Bounds.Height);
            }
            frmEBlackboard.Show();
            #endregion
            #region 显示提示屏窗口
            if (slaves.Count > 1)
            {
                frmPrompt.Top = 0;
                frmPrompt.Left = slaves[slavePromptNum].Bounds.Width;
                frmPrompt.Size = new System.Drawing.Size(slaves[slavePromptNum].Bounds.Width, slaves[slaveEBlackboardNum].Bounds.Height);
            }
            frmPrompt.Show();
            #endregion

            MaximizeBox = false;
            MinimizeBox = false;
            Text = string.Empty;
            ControlBox = false;
            BackColor = Color.DimGray;
            WindowState = FormWindowState.Maximized;
            this.TopMost = false;
            frmPrompt.TopMost = true;
            #region 调试用代码
            btnClose.BackColor = Color.Red;
            btnClose.ForeColor = Color.Yellow;
            btnClose.Click += (object sender, EventArgs e2) => Close();
            #endregion

            #region 输出屏幕信息
            using (var sw = new StreamWriter(@"d:\screenLog.log"))
            {
                sw.WriteLine($"Screen.AllScreens.Length={Screen.AllScreens.Length}");
                foreach(var sc in Screen.AllScreens)
                {
                    sw.WriteLine($"sc.DeviceName={sc.DeviceName}");
                    sw.WriteLine($"sc.BitsPerPixel={sc.BitsPerPixel}");
                    sw.WriteLine($"sc.Bounds={sc.Bounds.ToString()}");
                    sw.WriteLine($"sc.Primary={sc.Primary}");
                }
            }
            #endregion

            #region 初始化摄像头
            FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);//摄像头实例对象
            int sumVideo = videoDevices.Count;//找到计算机所有的摄像头 数量 ,没有摄像头的话 就等于 0
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            #endregion

            #region 显示教师画像（1#摄像机）按钮
            btnShowTeacher.Click += (o, ex) =>
            {
                frmEBlackboard.SetDataSourceType(VideoDataSourceType.Camera);
                frmEBlackboard.SetVideoSource(cameraTeacherNum);
            };
            #endregion
            #region 显示实物摄像头按钮
            btnShowObject.Click += (o, ex) =>
            {
                frmEBlackboard.SetDataSourceType(VideoDataSourceType.Camera);
                frmEBlackboard.SetVideoSource(cameraObjectNum);
            };
            #endregion

            #region 显示主控屏
            btnShowMainScreen.Click += (o, ex) =>
            {
                frmPrompt.EnableCapturesScreen = false;
                EnableCapturesScreen = true;
                frmEBlackboard.SetDataSourceType(VideoDataSourceType.Bitmap);

                OnCapturesScreen += (i, ex2) =>
                {
                    frmEBlackboard.SetImage(i);
                };
            };
            #endregion
            #region 显示到提示屏按钮
            btnShowPrompt.Click += (o, ex) =>
            {
                EnableCapturesScreen = false;
                frmPrompt.EnableCapturesScreen = true;
                frmEBlackboard.SetDataSourceType(VideoDataSourceType.Bitmap);

                frmPrompt.OnCapturesScreen += (i, ex2) =>
                {
                    frmEBlackboard.SetImage(i);
                };
            };
            #endregion

            #region 画中画
            btnPictureInPicture.Click += (s, ex)=> 
            {
                if (btnPictureInPicture.Tag == null || btnPictureInPicture.Tag.ToString() == "Disable")
                {
                    btnPictureInPicture.Text = "关闭画中画";
                    btnPictureInPicture.Tag = "Enable";
                    frmEBlackboard.EnablePictureInPicture(1);
                }
                else
                {
                    btnPictureInPicture.Text = "打开画中画";
                    btnPictureInPicture.Tag = "Disable";
                    frmEBlackboard.DisablePictureInPicture();
                }
            };
            #endregion
            #region 截屏
            btnScreen2Bmp.Click += (o, ex) =>
            {

                Bitmap bitmap = frmEBlackboard.Player.GetCurrentVideoFrame();
                string fileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-ff") + ".jpg";
                bitmap.Save(@"d:\temp\" + fileName, ImageFormat.Jpeg);
                bitmap.Dispose();
            };
            #endregion
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            frmEBlackboard.CloseVideo();
            frmEBlackboard.Dispose();
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
            if (OnCapturesScreen != null)
            {
                var width = pnlMain.Width;
                var height = pnlMain.Height;
                var xOffset = Left + pnlMain.Left + 3 + 6;
                var yOffset = Top + pnlMain.Top + 15 + 4;
                var bitmap = new Bitmap(width, height);
                Graphics g = Graphics.FromImage(bitmap);
                g.CopyFromScreen(new System.Drawing.Point(xOffset, yOffset), new System.Drawing.Point(0, 0), new Size(width, height));
                //g.Dispose();

                OnCapturesScreen(bitmap, null);
                //bitmap.Dispose();
            }
        }
        public bool EnableCapturesScreen
        {
            get => timer1.Enabled;
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
