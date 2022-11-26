
namespace ALT
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._button_ConvertText = new System.Windows.Forms.Button();
            this._textBox_CellLen = new System.Windows.Forms.TextBox();
            this._button_SaveImage = new System.Windows.Forms.Button();
            this._button_LoadImage = new System.Windows.Forms.Button();
            this._textBox3 = new System.Windows.Forms.TextBox();
            this._textBox_str = new System.Windows.Forms.TextBox();
            this._button_ParseImage = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this._pictureBox_bmp = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this._textBox_imageInfo = new System.Windows.Forms.TextBox();
            this._textBox_imageInfo2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this._textBox_ParseResult = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this._button_LoadImage2 = new System.Windows.Forms.Button();
            this._textBox_InputBase64 = new System.Windows.Forms.TextBox();
            this._textBox_ParsedText64 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox_bmp)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1231, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.파일ToolStripMenuItem.Text = "파일";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1231, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.25926F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.74074F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 420F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1231, 404);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this._button_ConvertText);
            this.panel1.Controls.Add(this._textBox_CellLen);
            this.panel1.Controls.Add(this._button_SaveImage);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this._textBox3);
            this.panel1.Controls.Add(this._textBox_InputBase64);
            this.panel1.Controls.Add(this._textBox_str);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 398);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 366);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "셀 크기";
            // 
            // _button_ConvertText
            // 
            this._button_ConvertText.Location = new System.Drawing.Point(11, 280);
            this._button_ConvertText.Name = "_button_ConvertText";
            this._button_ConvertText.Size = new System.Drawing.Size(115, 23);
            this._button_ConvertText.TabIndex = 1;
            this._button_ConvertText.Text = "텍스트 변환";
            this._button_ConvertText.UseVisualStyleBackColor = true;
            this._button_ConvertText.Click += new System.EventHandler(this._button_ConvertText_Click);
            // 
            // _textBox_CellLen
            // 
            this._textBox_CellLen.Location = new System.Drawing.Point(92, 309);
            this._textBox_CellLen.Name = "_textBox_CellLen";
            this._textBox_CellLen.Size = new System.Drawing.Size(75, 21);
            this._textBox_CellLen.TabIndex = 1;
            this._textBox_CellLen.Text = "10";
            // 
            // _button_SaveImage
            // 
            this._button_SaveImage.Location = new System.Drawing.Point(132, 280);
            this._button_SaveImage.Name = "_button_SaveImage";
            this._button_SaveImage.Size = new System.Drawing.Size(115, 23);
            this._button_SaveImage.TabIndex = 1;
            this._button_SaveImage.Text = "이미지 저장";
            this._button_SaveImage.UseVisualStyleBackColor = true;
            this._button_SaveImage.Click += new System.EventHandler(this._button_SaveImage_Click);
            // 
            // _button_LoadImage
            // 
            this._button_LoadImage.Location = new System.Drawing.Point(14, 280);
            this._button_LoadImage.Name = "_button_LoadImage";
            this._button_LoadImage.Size = new System.Drawing.Size(115, 23);
            this._button_LoadImage.TabIndex = 1;
            this._button_LoadImage.Text = "이미지 불러오기";
            this._button_LoadImage.UseVisualStyleBackColor = true;
            this._button_LoadImage.Click += new System.EventHandler(this._button_LoadImage_Click);
            // 
            // _textBox3
            // 
            this._textBox3.Location = new System.Drawing.Point(92, 363);
            this._textBox3.Name = "_textBox3";
            this._textBox3.Size = new System.Drawing.Size(75, 21);
            this._textBox3.TabIndex = 3;
            // 
            // _textBox_str
            // 
            this._textBox_str.Location = new System.Drawing.Point(3, 3);
            this._textBox_str.Multiline = true;
            this._textBox_str.Name = "_textBox_str";
            this._textBox_str.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._textBox_str.Size = new System.Drawing.Size(387, 131);
            this._textBox_str.TabIndex = 0;
            this._textBox_str.Text = "Lorem Ipsum";
            // 
            // _button_ParseImage
            // 
            this._button_ParseImage.Location = new System.Drawing.Point(256, 280);
            this._button_ParseImage.Name = "_button_ParseImage";
            this._button_ParseImage.Size = new System.Drawing.Size(115, 23);
            this._button_ParseImage.TabIndex = 1;
            this._button_ParseImage.Text = "이미지 해석";
            this._button_ParseImage.UseVisualStyleBackColor = true;
            this._button_ParseImage.Click += new System.EventHandler(this._button_ParseImage_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Info;
            this.panel2.Controls.Add(this._pictureBox_bmp);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this._textBox_imageInfo);
            this.panel2.Controls.Add(this._textBox_imageInfo2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this._button_LoadImage);
            this.panel2.Controls.Add(this._button_LoadImage2);
            this.panel2.Controls.Add(this._button_ParseImage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(402, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(405, 398);
            this.panel2.TabIndex = 1;
            // 
            // _pictureBox_bmp
            // 
            this._pictureBox_bmp.Location = new System.Drawing.Point(3, 3);
            this._pictureBox_bmp.Name = "_pictureBox_bmp";
            this._pictureBox_bmp.Size = new System.Drawing.Size(399, 271);
            this._pictureBox_bmp.TabIndex = 0;
            this._pictureBox_bmp.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "이미지 크기";
            // 
            // _textBox_imageInfo
            // 
            this._textBox_imageInfo.Location = new System.Drawing.Point(93, 309);
            this._textBox_imageInfo.Name = "_textBox_imageInfo";
            this._textBox_imageInfo.Size = new System.Drawing.Size(291, 21);
            this._textBox_imageInfo.TabIndex = 1;
            // 
            // _textBox_imageInfo2
            // 
            this._textBox_imageInfo2.Location = new System.Drawing.Point(93, 336);
            this._textBox_imageInfo2.Name = "_textBox_imageInfo2";
            this._textBox_imageInfo2.Size = new System.Drawing.Size(291, 21);
            this._textBox_imageInfo2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this._textBox_ParsedText64);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this._textBox_ParseResult);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(813, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(415, 398);
            this.panel3.TabIndex = 2;
            // 
            // _textBox_ParseResult
            // 
            this._textBox_ParseResult.Location = new System.Drawing.Point(3, 140);
            this._textBox_ParseResult.Multiline = true;
            this._textBox_ParseResult.Name = "_textBox_ParseResult";
            this._textBox_ParseResult.ReadOnly = true;
            this._textBox_ParseResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._textBox_ParseResult.Size = new System.Drawing.Size(409, 131);
            this._textBox_ParseResult.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(253, 280);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(115, 23);
            this.button5.TabIndex = 1;
            this.button5.Text = "button";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // _button_LoadImage2
            // 
            this._button_LoadImage2.Location = new System.Drawing.Point(135, 280);
            this._button_LoadImage2.Name = "_button_LoadImage2";
            this._button_LoadImage2.Size = new System.Drawing.Size(115, 23);
            this._button_LoadImage2.TabIndex = 1;
            this._button_LoadImage2.Text = "이미지 불러오기2";
            this._button_LoadImage2.UseVisualStyleBackColor = true;
            this._button_LoadImage2.Click += new System.EventHandler(this._button_LoadImage2_Click);
            // 
            // _textBox_InputBase64
            // 
            this._textBox_InputBase64.Location = new System.Drawing.Point(3, 140);
            this._textBox_InputBase64.Multiline = true;
            this._textBox_InputBase64.Name = "_textBox_InputBase64";
            this._textBox_InputBase64.ReadOnly = true;
            this._textBox_InputBase64.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._textBox_InputBase64.Size = new System.Drawing.Size(387, 131);
            this._textBox_InputBase64.TabIndex = 0;
            // 
            // _textBox_ParsedText64
            // 
            this._textBox_ParsedText64.Location = new System.Drawing.Point(3, 3);
            this._textBox_ParsedText64.Multiline = true;
            this._textBox_ParsedText64.Name = "_textBox_ParsedText64";
            this._textBox_ParsedText64.ReadOnly = true;
            this._textBox_ParsedText64.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._textBox_ParsedText64.Size = new System.Drawing.Size(409, 131);
            this._textBox_ParsedText64.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "텍스트 변환";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(134, 280);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "이미지 저장";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(255, 280);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "button";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "한 도영의 String 2 Bitmap Converter";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox_bmp)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _button_ParseImage;
        private System.Windows.Forms.Button _button_LoadImage;
        private System.Windows.Forms.Button _button_SaveImage;
        private System.Windows.Forms.Button _button_ConvertText;
        private System.Windows.Forms.TextBox _textBox_str;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox _pictureBox_bmp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _textBox3;
        private System.Windows.Forms.TextBox _textBox_imageInfo2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _textBox_imageInfo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox _textBox_ParseResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _textBox_CellLen;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button _button_LoadImage2;
        private System.Windows.Forms.TextBox _textBox_InputBase64;
        private System.Windows.Forms.TextBox _textBox_ParsedText64;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

