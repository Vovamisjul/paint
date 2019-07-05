namespace vovan2 {
    partial class Paint {
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RussianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnglishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonPtr = new System.Windows.Forms.Button();
            this.btnSaveFig = new System.Windows.Forms.Button();
            this.FigName = new System.Windows.Forms.TextBox();
            this.btnDeleteFig = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnBgColor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox.Location = new System.Drawing.Point(12, 61);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(805, 419);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseUp);
            this.pictureBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pictureBox_PreviewKeyDown);
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(12, 31);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(149, 24);
            this.comboBox.TabIndex = 8;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.LanguageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(829, 28);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.ClearToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.OpenToolStripMenuItem.Text = "Открыть";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.SaveToolStripMenuItem.Text = "Сохранить";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // ClearToolStripMenuItem
            // 
            this.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem";
            this.ClearToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.ClearToolStripMenuItem.Text = "Очистить";
            this.ClearToolStripMenuItem.Click += new System.EventHandler(this.Clear_Click);
            // 
            // LanguageToolStripMenuItem
            // 
            this.LanguageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RussianToolStripMenuItem,
            this.EnglishToolStripMenuItem});
            this.LanguageToolStripMenuItem.Name = "LanguageToolStripMenuItem";
            this.LanguageToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.LanguageToolStripMenuItem.Text = "Язык";
            // 
            // RussianToolStripMenuItem
            // 
            this.RussianToolStripMenuItem.Name = "RussianToolStripMenuItem";
            this.RussianToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.RussianToolStripMenuItem.Text = "Русский";
            // 
            // EnglishToolStripMenuItem
            // 
            this.EnglishToolStripMenuItem.Name = "EnglishToolStripMenuItem";
            this.EnglishToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.EnglishToolStripMenuItem.Text = "Английский";
            // 
            // openDialog
            // 
            this.openDialog.FileName = "openFileDialog1";
            // 
            // buttonPtr
            // 
            this.buttonPtr.Image = global::vovan2.Properties.Resources.ptr;
            this.buttonPtr.Location = new System.Drawing.Point(266, 33);
            this.buttonPtr.Name = "buttonPtr";
            this.buttonPtr.Size = new System.Drawing.Size(22, 23);
            this.buttonPtr.TabIndex = 11;
            this.buttonPtr.UseVisualStyleBackColor = true;
            this.buttonPtr.Click += new System.EventHandler(this.buttonPtr_Click);
            // 
            // btnSaveFig
            // 
            this.btnSaveFig.Location = new System.Drawing.Point(459, 32);
            this.btnSaveFig.Name = "btnSaveFig";
            this.btnSaveFig.Size = new System.Drawing.Size(143, 23);
            this.btnSaveFig.TabIndex = 12;
            this.btnSaveFig.Text = "Сохранить фигуру";
            this.btnSaveFig.UseVisualStyleBackColor = true;
            this.btnSaveFig.Click += new System.EventHandler(this.button1_Click);
            // 
            // FigName
            // 
            this.FigName.Location = new System.Drawing.Point(294, 33);
            this.FigName.Name = "FigName";
            this.FigName.Size = new System.Drawing.Size(159, 22);
            this.FigName.TabIndex = 13;
            // 
            // btnDeleteFig
            // 
            this.btnDeleteFig.Location = new System.Drawing.Point(608, 31);
            this.btnDeleteFig.Name = "btnDeleteFig";
            this.btnDeleteFig.Size = new System.Drawing.Size(122, 23);
            this.btnDeleteFig.TabIndex = 14;
            this.btnDeleteFig.Text = "Удалить фигуру";
            this.btnDeleteFig.UseVisualStyleBackColor = true;
            this.btnDeleteFig.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            // 
            // btnBgColor
            // 
            this.btnBgColor.Location = new System.Drawing.Point(167, 32);
            this.btnBgColor.Name = "btnBgColor";
            this.btnBgColor.Size = new System.Drawing.Size(93, 23);
            this.btnBgColor.TabIndex = 15;
            this.btnBgColor.Text = "Цвет фона";
            this.btnBgColor.UseVisualStyleBackColor = true;
            this.btnBgColor.Click += new System.EventHandler(this.btnBgColor_Click);
            // 
            // Paint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(829, 484);
            this.Controls.Add(this.btnBgColor);
            this.Controls.Add(this.btnDeleteFig);
            this.Controls.Add(this.FigName);
            this.Controls.Add(this.btnSaveFig);
            this.Controls.Add(this.buttonPtr);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Paint";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Paint_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Paint_KeyDown);
            this.Resize += new System.EventHandler(this.Paint_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.Button buttonPtr;
        private System.Windows.Forms.Button btnSaveFig;
        private System.Windows.Forms.TextBox FigName;
        private System.Windows.Forms.Button btnDeleteFig;
        private System.Windows.Forms.ToolStripMenuItem ClearToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnBgColor;
        private System.Windows.Forms.ToolStripMenuItem LanguageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RussianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EnglishToolStripMenuItem;
    }
}

