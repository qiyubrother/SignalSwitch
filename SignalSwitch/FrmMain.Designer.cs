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
            this.btnShowPrompt = new System.Windows.Forms.Button();
            this.btnShowTeacher = new System.Windows.Forms.Button();
            this.btnShowObject = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnScreen2Bmp = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPictureInPicture = new System.Windows.Forms.Button();
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
            // btnShowPrompt
            // 
            this.btnShowPrompt.Location = new System.Drawing.Point(163, 12);
            this.btnShowPrompt.Name = "btnShowPrompt";
            this.btnShowPrompt.Size = new System.Drawing.Size(145, 40);
            this.btnShowPrompt.TabIndex = 1;
            this.btnShowPrompt.Text = "显示提示屏画面";
            this.btnShowPrompt.UseVisualStyleBackColor = true;
            // 
            // btnShowTeacher
            // 
            this.btnShowTeacher.Location = new System.Drawing.Point(314, 12);
            this.btnShowTeacher.Name = "btnShowTeacher";
            this.btnShowTeacher.Size = new System.Drawing.Size(145, 40);
            this.btnShowTeacher.TabIndex = 2;
            this.btnShowTeacher.Text = "显示1#摄像机画面";
            this.btnShowTeacher.UseVisualStyleBackColor = true;
            // 
            // btnShowObject
            // 
            this.btnShowObject.Location = new System.Drawing.Point(465, 12);
            this.btnShowObject.Name = "btnShowObject";
            this.btnShowObject.Size = new System.Drawing.Size(211, 40);
            this.btnShowObject.TabIndex = 3;
            this.btnShowObject.Text = "显示实物展示摄像头画面";
            this.btnShowObject.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1237, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(145, 40);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭主控屏画面";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnScreen2Bmp
            // 
            this.btnScreen2Bmp.Location = new System.Drawing.Point(682, 12);
            this.btnScreen2Bmp.Name = "btnScreen2Bmp";
            this.btnScreen2Bmp.Size = new System.Drawing.Size(211, 40);
            this.btnScreen2Bmp.TabIndex = 7;
            this.btnScreen2Bmp.Text = "电子白板屏截屏";
            this.btnScreen2Bmp.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightCoral;
            this.panel1.Location = new System.Drawing.Point(12, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1195, 410);
            this.panel1.TabIndex = 8;
            // 
            // btnPictureInPicture
            // 
            this.btnPictureInPicture.Location = new System.Drawing.Point(899, 12);
            this.btnPictureInPicture.Name = "btnPictureInPicture";
            this.btnPictureInPicture.Size = new System.Drawing.Size(145, 40);
            this.btnPictureInPicture.TabIndex = 9;
            this.btnPictureInPicture.Text = "打开画中画";
            this.btnPictureInPicture.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 502);
            this.Controls.Add(this.btnPictureInPicture);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnScreen2Bmp);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnShowObject);
            this.Controls.Add(this.btnShowTeacher);
            this.Controls.Add(this.btnShowPrompt);
            this.Controls.Add(this.button1);
            this.Name = "FrmMain";
            this.Text = "主程序画面";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnShowPrompt;
        private System.Windows.Forms.Button btnShowTeacher;
        private System.Windows.Forms.Button btnShowObject;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnScreen2Bmp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPictureInPicture;
    }
}

