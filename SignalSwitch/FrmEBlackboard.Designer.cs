namespace SignalSwitch
{
    partial class FrmEBlackboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClose = new System.Windows.Forms.Button();
            this.videoSourcePlayerObject = new AForge.Controls.VideoSourcePlayer();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(611, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(177, 43);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "关闭电子白板屏幕窗口";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // videoSourcePlayerObject
            // 
            this.videoSourcePlayerObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoSourcePlayerObject.Location = new System.Drawing.Point(0, 0);
            this.videoSourcePlayerObject.Name = "videoSourcePlayerObject";
            this.videoSourcePlayerObject.Size = new System.Drawing.Size(800, 450);
            this.videoSourcePlayerObject.TabIndex = 7;
            this.videoSourcePlayerObject.Text = "videoSourcePlayerObject";
            this.videoSourcePlayerObject.VideoSource = null;
            // 
            // FrmEBlackboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.videoSourcePlayerObject);
            this.Name = "FrmEBlackboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "电子白板屏";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayerObject;
    }
}