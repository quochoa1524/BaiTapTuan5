using System;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class        formCha1 : Form
    {
        private bool isDirty = false;
        private string? currentFilePath = null;

        public formCha1()
        {
            InitializeComponent();
            this.Load += formCha1_Load;
            this.FormClosing += formCha1_FormClosing;
            this.KeyDown += formCha1_KeyDown;
        }

        private void formCha1_Load(object? sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;
            // Populate fonts
            var fonts = new InstalledFontCollection();
            foreach (var f in fonts.Families.OrderBy(ff => ff.Name))
            {
                cmbFont.Items.Add(f.Name);
            }
            // Default selection
            if (cmbFont.Items.Count > 0)
                cmbFont.SelectedIndex = cmbFont.Items.IndexOf("Tahoma") >= 0 ? cmbFont.Items.IndexOf("Tahoma") : 0;

            // Populate sizes (common sizes)
            int[] sizes = new int[] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in sizes)
                cmbSize.Items.Add(s.ToString());
            cmbSize.Text = "14";

            // Wire events
            cmbFont.SelectedIndexChanged += CmbFont_SelectedIndexChanged;
            cmbSize.TextChanged += CmbSize_TextChanged;
            btnBold.Click += BtnBold_Click;
            btnItalic.Click += BtnItalic_Click;
            btnUnderline.Click += BtnUnderline_Click;
            btnColor.Click += BtnColor_Click;
            btnFontDialog.Click += BtnFontDialog_Click;
            btnOpen.Click += BtnOpen_Click;
            btnNew.Click += BtnNew_Click;
            btnSave.Click += BtnSave_Click;
            // Menu items
            newToolStripMenuItem.Click += BtnNew_Click;
            openToolStripMenuItem.Click += BtnOpen_Click;
            saveToolStripMenuItem.Click += BtnSave_Click;
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;

            // keyboard and key preview
            this.KeyPreview = true;

            // richTextBox events
            richTextBox1.TextChanged += RichTextBox1_TextChanged;
            richTextBox1.SelectionChanged += RichTextBox1_SelectionChanged;

            // assign simple icons from SystemIcons
            try
            {
                btnNew.Image = SystemIcons.Application.ToBitmap();
                btnOpen.Image = SystemIcons.Asterisk.ToBitmap();
                btnSave.Image = SystemIcons.Shield.ToBitmap();
            }
            catch { }

            UpdateStatus();
        }

        private void CmbFont_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ApplySelectedFont();
        }

        private void CmbSize_TextChanged(object? sender, EventArgs e)
        {
            ApplySelectedFont();
        }

        private void ApplySelectedFont()
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;
            try
            {
                if (cmbFont.SelectedItem == null && string.IsNullOrWhiteSpace(cmbSize.Text))
                    return;

                string fontName = cmbFont.SelectedItem?.ToString() ?? richTextBox1.SelectionFont?.FontFamily.Name ?? richTextBox1.Font.FontFamily.Name;
                float size = 12f;
                if (!float.TryParse(cmbSize.Text, out size))
                {
                    if (richTextBox1.SelectionFont != null) size = richTextBox1.SelectionFont.Size;
                    else size = richTextBox1.Font.Size;
                }

                var current = richTextBox1.SelectionFont ?? richTextBox1.Font;
                FontStyle style = current.Style;
                var newFont = new Font(fontName, size, style);
                richTextBox1.SelectionFont = newFont;
                isDirty = true;
                UpdateStatus();
            }
            catch
            {
                // ignore invalid font operations
            }
        }

        private void BtnBold_Click(object? sender, EventArgs e)
        {
            ToggleSelectionStyle(FontStyle.Bold);
        }

        private void BtnItalic_Click(object? sender, EventArgs e)
        {
            ToggleSelectionStyle(FontStyle.Italic);
        }

        private void BtnUnderline_Click(object? sender, EventArgs e)
        {
            ToggleSelectionStyle(FontStyle.Underline);
        }

        private void ToggleSelectionStyle(FontStyle style)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;
            var selFont = richTextBox1.SelectionFont ?? richTextBox1.Font;
            FontStyle newStyle;
            if (selFont.Style.HasFlag(style))
                newStyle = selFont.Style & ~style;
            else
                newStyle = selFont.Style | style;

            richTextBox1.SelectionFont = new Font(selFont.FontFamily, selFont.Size, newStyle);
            isDirty = true;
            UpdateStatus();
        }

        private void BtnColor_Click(object? sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;
            using var cd = new ColorDialog();
            if (cd.ShowDialog(this) == DialogResult.OK)
            {
                richTextBox1.SelectionColor = cd.Color;
                isDirty = true;
                UpdateStatus();
            }
        }

        private void BtnFontDialog_Click(object? sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;
            using var fd = new FontDialog();
            fd.ShowColor = true;
            fd.Font = richTextBox1.SelectionFont ?? richTextBox1.Font;
            if (fd.ShowDialog(this) == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fd.Font;
                richTextBox1.SelectionColor = fd.Color;
                isDirty = true;
                UpdateStatus();
            }
        }

        private void BtnOpen_Click(object? sender, EventArgs e)
        {
            if (!PromptToSaveIfDirty()) return;
            using var ofd = new OpenFileDialog();
            ofd.Filter = "Rich Text Format|*.rtf|Text Files|*.txt|All Files|*.*";
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    if (System.IO.Path.GetExtension(ofd.FileName).Equals(".rtf", StringComparison.OrdinalIgnoreCase))
                        richTextBox1.LoadFile(ofd.FileName, RichTextBoxStreamType.RichText);
                    else
                        richTextBox1.LoadFile(ofd.FileName, RichTextBoxStreamType.PlainText);
                    currentFilePath = ofd.FileName;
                    isDirty = false;
                    UpdateStatus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Could not open file: " + ex.Message, "Open", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            SaveExisting();
        }

        private void SaveExisting()
        {
            try
            {
                if (string.IsNullOrEmpty(currentFilePath))
                {
                    using var sfd = new SaveFileDialog();
                    sfd.Filter = "Rich Text Format|*.rtf|Text Files|*.txt|All Files|*.*";
                    if (sfd.ShowDialog(this) != DialogResult.OK) return;
                    currentFilePath = sfd.FileName;
                }

                if (System.IO.Path.GetExtension(currentFilePath).Equals(".rtf", StringComparison.OrdinalIgnoreCase))
                    richTextBox1.SaveFile(currentFilePath, RichTextBoxStreamType.RichText);
                else
                    richTextBox1.SaveFile(currentFilePath, RichTextBoxStreamType.PlainText);

                isDirty = false;
                UpdateStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Could not save file: " + ex.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNew_Click(object? sender, EventArgs e)
        {
            if (!PromptToSaveIfDirty()) return;
            richTextBox1.Clear();
            currentFilePath = null;
            isDirty = false;
            UpdateStatus();
        }

        private bool PromptToSaveIfDirty()
        {
            if (!isDirty) return true;
            var dr = MessageBox.Show(this, "The document has unsaved changes. Save now?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.Cancel) return false;
            if (dr == DialogResult.Yes)
            {
                SaveExisting();
                return !isDirty; // if save succeeded isDirty == false
            }
            return true;
        }

        private void formCha1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!PromptToSaveIfDirty()) e.Cancel = true;
        }

        private void ExitToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            // Ask to save if dirty, then close the form (which ends the app for the main form)
            if (PromptToSaveIfDirty())
            {
                this.Close();
            }
        }

        private void formCha1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                BtnNew_Click(sender, e);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.O)
            {
                BtnOpen_Click(sender, e);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                SaveExisting();
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.B)
            {
                ToggleSelectionStyle(FontStyle.Bold);
                btnBold.Checked = richTextBox1.SelectionFont?.Bold ?? false;
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.I)
            {
                ToggleSelectionStyle(FontStyle.Italic);
                btnItalic.Checked = richTextBox1.SelectionFont?.Italic ?? false;
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.U)
            {
                ToggleSelectionStyle(FontStyle.Underline);
                btnUnderline.Checked = richTextBox1.SelectionFont?.Underline ?? false;
                e.Handled = true;
            }
        }

        private void RichTextBox1_TextChanged(object? sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;
            isDirty = true;
            UpdateStatus();
        }

        private void RichTextBox1_SelectionChanged(object? sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;
            var f = richTextBox1.SelectionFont ?? richTextBox1.Font;
            btnBold.Checked = f.Bold;
            btnItalic.Checked = f.Italic;
            btnUnderline.Checked = f.Underline;
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            int index = richTextBox1.SelectionStart;
            int line = richTextBox1.GetLineFromCharIndex(index);
            int col = index - richTextBox1.GetFirstCharIndexFromLine(line);
            toolStripStatusLabelPosition.Text = $"Ln {line + 1}, Col {col + 1}";
            toolStripStatusLabelSelection.Text = $"Sel: {richTextBox1.SelectionLength}";
        }
    }
}
