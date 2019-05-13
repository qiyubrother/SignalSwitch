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

namespace SignalSwitch
{
    public partial class FrmMain : Form
    {
        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoSourceTeacher;
        VideoCaptureDevice videoSourceObject;
        public int selectedDeviceIndex = 0;

        public FrmMain()
        {
            InitializeComponent();
        }
        // 定义电子白板屏对象
        FrmEBlackboard frmEBlackboard = new FrmEBlackboard();
        // 定义提示屏对象
        FrmPrompt frmPrompt = new FrmPrompt();

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
            int cameraTeacherNum = 0;
            int cameraObjectNum = 1;

            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            videoSourceTeacher = new VideoCaptureDevice(videoDevices[cameraTeacherNum].MonikerString);//连接摄像头。
            videoSourceTeacher.VideoResolution = videoSourceTeacher.VideoCapabilities[cameraTeacherNum];
            videoSourcePlayerTeacher.VideoSource = videoSourceTeacher;
            // set NewFrame event handler
            videoSourcePlayerTeacher.Start();

            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            videoSourceObject = new VideoCaptureDevice(videoDevices[cameraObjectNum].MonikerString);//连接摄像头。
            videoSourceObject.VideoResolution = videoSourceObject.VideoCapabilities[cameraObjectNum];
            videoSourcePlayerObject.VideoSource = videoSourceObject;
            // set NewFrame event handler
            videoSourcePlayerObject.Start();

            #endregion
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            videoSourcePlayerTeacher.Stop();
            videoSourcePlayerObject.Stop();
        }
    }
}
