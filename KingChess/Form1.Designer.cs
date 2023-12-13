namespace KingChess
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pnlChessBoard = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            lblLogo = new Label();
            imageList1 = new ImageList(components);
            btnExit = new Button();
            btnSetting = new Button();
            btnSave = new Button();
            btnStart = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlChessBoard
            // 
            pnlChessBoard.Location = new Point(535, 159);
            pnlChessBoard.Name = "pnlChessBoard";
            pnlChessBoard.Size = new Size(900, 900);
            pnlChessBoard.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.AliceBlue;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblLogo);
            panel1.Controls.Add(btnExit);
            panel1.Controls.Add(btnSetting);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnStart);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1582, 125);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.Font = new Font("Showcard Gothic", 48F, FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.InactiveCaptionText;
            label1.Location = new Point(1182, 9);
            label1.Name = "label1";
            label1.Size = new Size(516, 102);
            label1.TabIndex = 5;
            label1.Text = "KING CHESS";
            // 
            // lblLogo
            // 
            lblLogo.ImageKey = "logokingchess.png";
            lblLogo.ImageList = imageList1;
            lblLogo.Location = new Point(1008, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(174, 125);
            lblLogo.TabIndex = 4;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth16Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "button.png");
            imageList1.Images.SetKeyName(1, "logokingchess.png");
            // 
            // btnExit
            // 
            btnExit.BackgroundImageLayout = ImageLayout.Stretch;
            btnExit.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnExit.ForeColor = SystemColors.ButtonFace;
            btnExit.ImageKey = "button.png";
            btnExit.ImageList = imageList1;
            btnExit.Location = new Point(643, 22);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(154, 75);
            btnExit.TabIndex = 3;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // btnSetting
            // 
            btnSetting.BackgroundImageLayout = ImageLayout.Stretch;
            btnSetting.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSetting.ForeColor = SystemColors.ButtonFace;
            btnSetting.ImageKey = "button.png";
            btnSetting.ImageList = imageList1;
            btnSetting.Location = new Point(430, 22);
            btnSetting.Name = "btnSetting";
            btnSetting.Size = new Size(154, 75);
            btnSetting.TabIndex = 2;
            btnSetting.Text = "Cài Đặt";
            btnSetting.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.BackgroundImageLayout = ImageLayout.Stretch;
            btnSave.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.ForeColor = SystemColors.ButtonFace;
            btnSave.ImageKey = "button.png";
            btnSave.ImageList = imageList1;
            btnSave.Location = new Point(229, 22);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(154, 75);
            btnSave.TabIndex = 1;
            btnSave.Text = "Lưu Game";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            btnStart.BackgroundImageLayout = ImageLayout.Stretch;
            btnStart.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnStart.ForeColor = SystemColors.ButtonHighlight;
            btnStart.ImageKey = "button.png";
            btnStart.ImageList = imageList1;
            btnStart.Location = new Point(22, 22);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(154, 75);
            btnStart.TabIndex = 0;
            btnStart.Text = "Chơi Mới";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSlateGray;
            ClientSize = new Size(1582, 1055);
            Controls.Add(panel1);
            Controls.Add(pnlChessBoard);
            Name = "Form1";
            Text = "King Chess";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlChessBoard;
        private Panel panel1;
        private Button btnStart;
        private Button btnExit;
        private ImageList imageList1;
        private Button btnSetting;
        private Button btnSave;
        private Label lblLogo;
        private Label label1;
    }
}