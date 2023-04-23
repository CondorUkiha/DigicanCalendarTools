namespace DigicanCalendarTools
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileButton = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.Label();
            this.openFileLabel = new System.Windows.Forms.Label();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(599, 105);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(85, 31);
            this.openFileButton.TabIndex = 0;
            this.openFileButton.Text = "選択";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFile
            // 
            this.openFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.openFile.Location = new System.Drawing.Point(86, 106);
            this.openFile.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.openFile.Name = "openFile";
            this.openFile.Padding = new System.Windows.Forms.Padding(5);
            this.openFile.Size = new System.Drawing.Size(500, 30);
            this.openFile.TabIndex = 1;
            this.openFile.Text = "ファイルが選択されていません";
            this.openFile.Click += new System.EventHandler(this.label1_Click);
            // 
            // openFileLabel
            // 
            this.openFileLabel.AutoSize = true;
            this.openFileLabel.Location = new System.Drawing.Point(83, 83);
            this.openFileLabel.Name = "openFileLabel";
            this.openFileLabel.Size = new System.Drawing.Size(237, 18);
            this.openFileLabel.TabIndex = 2;
            this.openFileLabel.Text = "デジキャン出欠状況確認ファイル";
            this.openFileLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // saveFileButton
            // 
            this.saveFileButton.Location = new System.Drawing.Point(358, 305);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(85, 31);
            this.saveFileButton.TabIndex = 5;
            this.saveFileButton.Text = "実行";
            this.saveFileButton.UseVisualStyleBackColor = true;
            this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.saveFileButton);
            this.Controls.Add(this.openFileLabel);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.openFileButton);
            this.Name = "Form1";
            this.Text = "デジキャンカレンダーツール";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label openFile;
        private System.Windows.Forms.Label openFileLabel;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Button saveFileButton;
    }
}

