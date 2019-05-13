using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Controls;
using AForge.Imaging;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;

namespace SignalSwitch
{
    public partial class FrmEBlackboard : BaseForm
    {
        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoSource;
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

            if (videoSourcePlayer.IsRunning)
            {

                //拍照完成后关摄像头并刷新同时关窗体
                if (videoSourcePlayer != null && videoSourcePlayer.IsRunning)
                {
                    videoSourcePlayer.SignalToStop();
                    videoSourcePlayer.WaitForStop();
                }
            }
            #region 调试用代码
            btnClose.BackColor = Color.Red;
            btnClose.ForeColor = Color.Yellow;
            btnClose.Click += (object sender, EventArgs e)=> Close();
            #endregion

            #region 处理每一针数据
            Player.NewFrame += (object sender, ref Bitmap image) =>
            {
                //string fileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff") + ".jpg";
                //image.Save(@"d:\temp\" + fileName, ImageFormat.Jpeg);
                //image.Dispose();
            };
            #endregion
        }

        public void SetVideoSource(int index)
        {
            videoSourcePlayer.SignalToStop();
            videoSourcePlayer.WaitForStop();
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            videoSource = new VideoCaptureDevice(videoDevices[index].MonikerString);//连接摄像头。
            videoSource.VideoResolution = videoSource.VideoCapabilities[0];
            videoSourcePlayer.VideoSource = videoSource;
            videoSourcePlayer.Start();
        }

        public void CloseVideo()
        {
            if (videoSourcePlayer != null && videoSourcePlayer.IsRunning)
            {
                videoSourcePlayer.SignalToStop();
                videoSourcePlayer.WaitForStop();
            }
        }

        public VideoSourcePlayer Player { get => videoSourcePlayer; set=> videoSourcePlayer = value; }
    }
}
