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
            this.runButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveFilelabel = new System.Windows.Forms.Label();
            this.SaveFile = new System.Windows.Forms.Label();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.DataGetSelect = new System.Windows.Forms.ComboBox();
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
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(344, 340);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(85, 31);
            this.runButton.TabIndex = 5;
            this.runButton.Text = "実行";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.saveFileButton_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(83, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "読み込み授業選択";
            this.label1.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // SaveFilelabel
            // 
            this.SaveFilelabel.AutoSize = true;
            this.SaveFilelabel.Location = new System.Drawing.Point(83, 224);
            this.SaveFilelabel.Name = "SaveFilelabel";
            this.SaveFilelabel.Size = new System.Drawing.Size(149, 18);
            this.SaveFilelabel.TabIndex = 10;
            this.SaveFilelabel.Text = "出力ファイル保存先";
            // 
            // SaveFile
            // 
            this.SaveFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SaveFile.Location = new System.Drawing.Point(86, 247);
            this.SaveFile.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.SaveFile.Name = "SaveFile";
            this.SaveFile.Padding = new System.Windows.Forms.Padding(5);
            this.SaveFile.Size = new System.Drawing.Size(500, 30);
            this.SaveFile.TabIndex = 9;
            this.SaveFile.Text = "保存先が選択されていません";
            // 
            // saveFileButton
            // 
            this.saveFileButton.Location = new System.Drawing.Point(599, 246);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(85, 31);
            this.saveFileButton.TabIndex = 8;
            this.saveFileButton.Text = "選択";
            this.saveFileButton.UseVisualStyleBackColor = true;
            this.saveFileButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // DataGetSelect
            // 
            this.DataGetSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataGetSelect.FormattingEnabled = true;
            this.DataGetSelect.Items.AddRange(new object[] {
            "全ての授業",
            "開始時間が回っていない授業",
            "終了時間が回っていない授業"});
            this.DataGetSelect.Location = new System.Drawing.Point(86, 181);
            this.DataGetSelect.Name = "DataGetSelect";
            this.DataGetSelect.Size = new System.Drawing.Size(598, 26);
            this.DataGetSelect.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DataGetSelect);
            this.Controls.Add(this.SaveFilelabel);
            this.Controls.Add(this.SaveFile);
            this.Controls.Add(this.saveFileButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.runButton);
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
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label SaveFilelabel;
        private System.Windows.Forms.Label SaveFile;
        private System.Windows.Forms.Button saveFileButton;
        private System.Windows.Forms.ComboBox DataGetSelect;
    }
}

