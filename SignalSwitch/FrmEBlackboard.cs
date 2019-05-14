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
            int eBlackboardNumber = 1;
            ShowOnMonitor(eBlackboardNumber);
            ShowInTaskbar = false;
            MaximizeBox = false;
            MinimizeBox = false;
            Text = string.Empty;
            ControlBox = false;
            BackColor = Color.DimGray;
            WindowState = FormWindowState.Maximized;
            MainPanel.Dock = DockStyle.Fill;
            videoSourcePlayer.Dock = DockStyle.Fill;
            videoSourcePlayerSmallWindow.Visible = false;

            if (videoSourcePlayer.IsRunning)
            {
                //拍照完成后关摄像头并刷新同时关窗体
                if (videoSourcePlayer != null && videoSourcePlayer.IsRunning)
                {
                    videoSourcePlayer.SignalToStop();
                    videoSourcePlayer.WaitForStop();
                }
            }

            #region 处理每一针数据（不包含画中画）
            Player.NewFrame += (object sender, ref Bitmap image) =>
            {
                //image.Save(@"d:\temp\" + $"{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff")}.jpg", ImageFormat.Jpeg);
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

        public void EnablePictureInPicture(int index)
        {
            videoSourcePlayerSmallWindow.Visible = true;
            videoSourcePlayerSmallWindow.SignalToStop();
            videoSourcePlayerSmallWindow.WaitForStop();
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            videoSource = new VideoCaptureDevice(videoDevices[index].MonikerString);//连接摄像头。
            videoSource.VideoResolution = videoSource.VideoCapabilities[0];
            videoSourcePlayerSmallWindow.VideoSource = videoSource;
            videoSourcePlayerSmallWindow.Start();
        }

        public void DisablePictureInPicture()
        {
            if (videoSourcePlayerSmallWindow != null && videoSourcePlayerSmallWindow.IsRunning)
            {
                videoSourcePlayerSmallWindow.SignalToStop();
                videoSourcePlayerSmallWindow.WaitForStop();
            }
            videoSourcePlayerSmallWindow.Visible = false;
        }

        public void CloseVideo()
        {
            if (videoSourcePlayer != null && videoSourcePlayer.IsRunning)
            {
                videoSourcePlayer.SignalToStop();
                videoSourcePlayer.WaitForStop();
            }

            if (videoSourcePlayerSmallWindow != null && videoSourcePlayerSmallWindow.IsRunning)
            {
                videoSourcePlayerSmallWindow.SignalToStop();
                videoSourcePlayerSmallWindow.WaitForStop();
            }
        }

        public VideoSourcePlayer Player { get => videoSourcePlayer; set=> videoSourcePlayer = value; }

        public void SetDataSource(VideoDataSource source)
        {
            if (source == VideoDataSource.Camera)
            {
                MainPanel.Visible = false;
                videoSourcePlayer.Visible = true;
            }
            else if (source == VideoDataSource.Bitmap)
            {
                MainPanel.Visible = true;
                videoSourcePlayer.Visible = false;
            }
        }

        public void SetImage(Bitmap image)
        {
            image.Save(@"d:\temp\" + $"{DateTime.Now.ToString("PMPT-yyyy-MM-dd-HH-mm-ss-fff")}.jpg", ImageFormat.Jpeg);
            pictureBox1.Image = image;
        }
    }

    public enum VideoDataSource
    {
        Bitmap,
        Camera
    }
}
