namespace WinFormsApp1
{
    partial class formCha1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox cmbFont;
        private System.Windows.Forms.ToolStripComboBox cmbSize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnBold;
        private System.Windows.Forms.ToolStripButton btnItalic;
        private System.Windows.Forms.ToolStripButton btnUnderline;
        private System.Windows.Forms.ToolStripButton btnColor;
        private System.Windows.Forms.ToolStripButton btnFontDialog;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelPosition;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSelection;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem địnhDạngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

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
            toolStrip1 = new ToolStrip();
            btnNew = new ToolStripButton();
            btnOpen = new ToolStripButton();
            btnSave = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            cmbFont = new ToolStripComboBox();
            cmbSize = new ToolStripComboBox();
            toolStripSeparator2 = new ToolStripSeparator();
            btnBold = new ToolStripButton();
            btnItalic = new ToolStripButton();
            btnUnderline = new ToolStripButton();
            btnColor = new ToolStripButton();
            btnFontDialog = new ToolStripButton();
            richTextBox1 = new RichTextBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabelPosition = new ToolStripStatusLabel();
            toolStripStatusLabelSelection = new ToolStripStatusLabel();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(16, 16);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNew, btnOpen, btnSave, toolStripSeparator1, cmbFont, cmbSize, toolStripSeparator2, btnBold, btnItalic, btnUnderline, btnColor, btnFontDialog });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1024, 28);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnOpen
            // 
            // 
            // btnNew
            // 
            btnNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNew.ImageTransparentColor = Color.Magenta;
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(29, 25);
            btnNew.Text = "New";
            // 
            btnOpen.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnOpen.ImageTransparentColor = Color.Magenta;
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(29, 25);
            btnOpen.Text = "Open";
            // 
            // btnSave
            // 
            btnSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSave.ImageTransparentColor = Color.Magenta;
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(29, 25);
            btnSave.Text = "Save";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 28);
            // 
            // cmbFont
            // 
            cmbFont.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFont.Name = "cmbFont";
            cmbFont.Size = new Size(160, 28);
            // 
            // cmbSize
            // 
            cmbSize.Name = "cmbSize";
            cmbSize.Size = new Size(50, 28);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 28);
            // 
            // btnBold
            // 
            btnBold.CheckOnClick = true;
            btnBold.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnBold.Name = "btnBold";
            btnBold.Size = new Size(29, 25);
            btnBold.Text = "B";
            btnBold.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            // 
            // btnItalic
            // 
            btnItalic.CheckOnClick = true;
            btnItalic.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnItalic.Name = "btnItalic";
            btnItalic.Size = new Size(29, 25);
            btnItalic.Text = "I";
            btnItalic.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            // 
            // btnUnderline
            // 
            btnUnderline.CheckOnClick = true;
            btnUnderline.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnUnderline.Name = "btnUnderline";
            btnUnderline.Size = new Size(29, 25);
            btnUnderline.Text = "U";
            btnUnderline.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            // 
            // btnColor
            // 
            btnColor.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(49, 25);
            btnColor.Text = "Color";
            // 
            // btnFontDialog
            // 
            btnFontDialog.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnFontDialog.Name = "btnFontDialog";
            btnFontDialog.Size = new Size(51, 25);
            btnFontDialog.Text = "Font...";
            // 
            // menuStrip1
            // 
            menuStrip1 = new MenuStrip();
            hệThốngToolStripMenuItem = new ToolStripMenuItem();
            địnhDạngToolStripMenuItem = new ToolStripMenuItem();
            fontToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.Items.AddRange(new ToolStripItem[] { hệThốngToolStripMenuItem, địnhDạngToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1024, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            hệThốngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, exitToolStripMenuItem });
            hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            hệThốngToolStripMenuItem.Text = "Hệ thống";
            địnhDạngToolStripMenuItem.Name = "địnhDạngToolStripMenuItem";
            địnhDạngToolStripMenuItem.Text = "Định dạng";
            // add Font menu item under Định dạng
            địnhDạngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { fontToolStripMenuItem });
            fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            fontToolStripMenuItem.Text = "Font...";
            // wire to existing Font dialog handler
            fontToolStripMenuItem.Click += BtnFontDialog_Click;
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Text = "Tạo văn bản mới";
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Text = "Mở tập tin";
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Text = "Lưu nội dung văn bản";
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Text = "Thoát";
            // wire menu clicks to existing handlers
            newToolStripMenuItem.Click += BtnNew_Click;
            openToolStripMenuItem.Click += BtnOpen_Click;
            saveToolStripMenuItem.Click += BtnSave_Click;
            btnFontDialog.Name = "btnFontDialog";
            btnFontDialog.Size = new Size(51, 25);
            btnFontDialog.Text = "Font...";
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Location = new Point(0, 52);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1024, 518);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // statusStrip1
            // 
            statusStrip1 = new StatusStrip();
            toolStripStatusLabelPosition = new ToolStripStatusLabel();
            toolStripStatusLabelSelection = new ToolStripStatusLabel();
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelPosition, toolStripStatusLabelSelection });
            statusStrip1.Location = new Point(0, 570);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1024, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            toolStripStatusLabelPosition.Text = "Ln 1, Col 1";
            toolStripStatusLabelSelection.Text = "Sel: 0";
            // 
            // formCha1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 592);
            Controls.Add(richTextBox1);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            Name = "formCha1";
            Text = "Text Editor";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
