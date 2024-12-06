using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab03_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.Text = "Tahoma";
            toolStripComboBox2.Text = "14";
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
            }
            List<int> listSize = new List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in listSize)
            {
                toolStripComboBox2.Items.Add(s);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void nTạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.ForeColor = fontDlg.Color;
                richTextBox1.Font = fontDlg.Font;
            }
        }

        private string filePath = null;
        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf|Text File (*.txt)|*.txt";
                    saveFileDialog.DefaultExt = "rtf";
                    saveFileDialog.Title = "Lưu tập tin";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = saveFileDialog.FileName;
                        SaveToFile(filePath);
                        MessageBox.Show("Đã lưu tập tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                SaveToFile(filePath);
                MessageBox.Show("Đã lưu tập tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveToFile(string path)
        {
            if (Path.GetExtension(path).ToLower() == ".rtf")
            {
                richTextBox1.SaveFile(path, RichTextBoxStreamType.RichText);
            }
            else
            {
                File.WriteAllText(path, richTextBox1.Text);
            }
        }

        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf|Text File (*.txt)|*.txt";
                openFileDialog.Title = "Mở tập tin";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;

                    if (Path.GetExtension(filePath).ToLower() == ".rtf")
                    {
                        richTextBox1.LoadFile(filePath, RichTextBoxStreamType.RichText);
                    }
                    else if (Path.GetExtension(filePath).ToLower() == ".txt")
                    {
                        richTextBox1.Text = File.ReadAllText(filePath);
                    }
                }
            }
        }

        private void bold_Click_1(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;

                FontStyle newStyle = currentFont.Bold
                    ? currentFont.Style & ~FontStyle.Bold
                    : currentFont.Style | FontStyle.Bold;

                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newStyle);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn văn bản trước khi áp dụng định dạng!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;

                FontStyle newStyle = currentFont.Italic
                    ? currentFont.Style & ~FontStyle.Italic
                    : currentFont.Style | FontStyle.Italic;

                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newStyle);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn văn bản trước khi áp dụng định dạng!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;

                FontStyle newStyle = currentFont.Underline
                    ? currentFont.Style & ~FontStyle.Underline
                    : currentFont.Style | FontStyle.Underline;

                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newStyle);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn văn bản trước khi áp dụng định dạng!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf|Text File (*.txt)|*.txt";
                    saveFileDialog.DefaultExt = "rtf";
                    saveFileDialog.Title = "Lưu tập tin";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = saveFileDialog.FileName;
                        SaveToFile(filePath);
                        MessageBox.Show("Đã lưu tập tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                SaveToFile(filePath);
                MessageBox.Show("Đã lưu tập tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
