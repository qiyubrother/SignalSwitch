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
                frmEBlackboard.SetDataSource(VideoDataSource.Camera);
                frmEBlackboard.SetVideoSource(cameraTeacherNum);
            };
            #endregion
            #region 显示实物摄像头按钮
            btnShowObject.Click += (o, ex) =>
            {
                frmEBlackboard.SetDataSource(VideoDataSource.Camera);
                frmEBlackboard.SetVideoSource(cameraObjectNum);
            };
            #endregion
            #region 显示到提示屏按钮
            btnShowPrompt.Click += (o, ex) =>
            {
                frmPrompt.EnableCapturesScreen = true;
                frmEBlackboard.SetDataSource(VideoDataSource.Bitmap);


                //var g = frmPrompt.CreateGraphics();
                //Rectangle rect = new Rectangle();
                //rect = Screen.GetWorkingArea(this);
                //var image = new Bitmap(rect.Width, rect.Height, g);
                frmPrompt.EnableCapturesScreen = true;
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
    }
}
