namespace SignalSwitch
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.videoSourcePlayerTeacher = new AForge.Controls.VideoSourcePlayer();
            this.videoSourcePlayerObject = new AForge.Controls.VideoSourcePlayer();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "显示主控屏画面";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(163, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 40);
            this.button2.TabIndex = 1;
            this.button2.Text = "显示提示屏画面";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(314, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 40);
            this.button3.TabIndex = 2;
            this.button3.Text = "显示1#摄像机画面";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(465, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(211, 40);
            this.button4.TabIndex = 3;
            this.button4.Text = "显示实物展示摄像头画面";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(923, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(145, 40);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭主控屏画面";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // videoSourcePlayerTeacher
            // 
            this.videoSourcePlayerTeacher.Location = new System.Drawing.Point(12, 58);
            this.videoSourcePlayerTeacher.Name = "videoSourcePlayerTeacher";
            this.videoSourcePlayerTeacher.Size = new System.Drawing.Size(400, 300);
            this.videoSourcePlayerTeacher.TabIndex = 5;
            this.videoSourcePlayerTeacher.Text = "videoSourcePlayer1";
            this.videoSourcePlayerTeacher.VideoSource = null;
            // 
            // videoSourcePlayerObject
            // 
            this.videoSourcePlayerObject.Location = new System.Drawing.Point(418, 58);
            this.videoSourcePlayerObject.Name = "videoSourcePlayerObject";
            this.videoSourcePlayerObject.Size = new System.Drawing.Size(400, 300);
            this.videoSourcePlayerObject.TabIndex = 6;
            this.videoSourcePlayerObject.Text = "videoSourcePlayerObject";
            this.videoSourcePlayerObject.VideoSource = null;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 502);
            this.Controls.Add(this.videoSourcePlayerObject);
            this.Controls.Add(this.videoSourcePlayerTeacher);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FrmMain";
            this.Text = "主程序画面";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnClose;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayerTeacher;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayerObject;
    }
}

