using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Data;
using System.IO;
using System.Xml.Serialization;

namespace Butar_Prelim
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        private const string RichTextBoxPlaceholder = "Start typing your notes here...";
        private Color PlaceholderColor = Color.Gray;
        private Color TextColor = Color.Black;

        private DataTable table;
        private const string filePath = "notes.xml";

        public Form1()
        {
            InitializeComponent();
            SetPlaceholder(textBoxTitle, "Enter Title");
            InitializeRichTextBoxPlaceholder();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTheme();
            table = new DataTable();
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Body", typeof(string));
            dataGridViewNotes.DataSource = table;

            dataGridViewNotes.Columns["Body"].Visible = false;
            dataGridViewNotes.ColumnHeadersVisible = false;
            dataGridViewNotes.RowHeadersVisible = false;
            dataGridViewNotes.AllowUserToAddRows = false;

            dataGridViewNotes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewNotes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewNotes.MultiSelect = false;
            dataGridViewNotes.CellMouseDown += dataGridViewNotes_CellMouseDown;
            dataGridViewNotes.CellClick += dataGridViewNotes_CellClick;

            LoadData();

            if (dataGridViewNotes.Rows.Count > 0)
            {
                dataGridViewNotes.Rows[0].Selected = true;
                dataGridViewNotes_CellClick(this, new DataGridViewCellEventArgs(0, 0));
            }
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, (IntPtr)1, placeholder);
        }

        private void InitializeRichTextBoxPlaceholder()
        {
            richTextBoxBody.Text = RichTextBoxPlaceholder;
            richTextBoxBody.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            richTextBoxBody.Enter += RichTextBox_Enter;
            richTextBoxBody.Leave += RichTextBox_Leave;
        }

        private void RichTextBox_Enter(object sender, EventArgs e)
        {
            if (richTextBoxBody.Text == RichTextBoxPlaceholder)
            {
                richTextBoxBody.Text = "";
                richTextBoxBody.ForeColor = TextColor;
            }
        }

        private void RichTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(richTextBoxBody.Text))
            {
                richTextBoxBody.Text = RichTextBoxPlaceholder;
                richTextBoxBody.ForeColor = PlaceholderColor;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewNotes.SelectedRows.Count > 0)
            {
                int index = dataGridViewNotes.SelectedRows[0].Index;
                table.Rows[index]["Title"] = textBoxTitle.Text;
                table.Rows[index]["Body"] = richTextBoxBody.Text;
            }
            else
            {
                table.Rows.Add(textBoxTitle.Text, richTextBoxBody.Text);
            }

            SaveData();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isTitleValid = textBoxTitle.Text != "Enter Title" && !string.IsNullOrWhiteSpace(textBoxTitle.Text);
            bool isBodyValid = richTextBoxBody.Text != RichTextBoxPlaceholder && !string.IsNullOrWhiteSpace(richTextBoxBody.Text);

            if (isTitleValid || isBodyValid)
            {
                if (dataGridViewNotes.SelectedRows.Count > 0)
                {
                    int index = dataGridViewNotes.SelectedRows[0].Index;

                    if (string.IsNullOrWhiteSpace(textBoxTitle.Text) && string.IsNullOrWhiteSpace(richTextBoxBody.Text))
                    {
                        table.Rows[index].Delete();
                    }
                    else
                    {
                        table.Rows[index]["Title"] = textBoxTitle.Text;
                        table.Rows[index]["Body"] = richTextBoxBody.Text;
                    }
                }

                DataRow newRow = table.NewRow();
                table.Rows.Add(newRow);

                int newRowIndex = table.Rows.IndexOf(newRow);
                dataGridViewNotes.Rows[newRowIndex].Selected = true;

                textBoxTitle.Clear();
                richTextBoxBody.Clear();
                InitializeRichTextBoxPlaceholder();
            }

            SaveData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewNotes.SelectedRows.Count > 0)
            {
                int index = dataGridViewNotes.SelectedRows[0].Index;
                table.Rows[index].Delete();

                textBoxTitle.Clear();
                richTextBoxBody.Clear();
            }

            SaveData();
        }

        private void dataGridViewNotes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    dataGridViewNotes.ClearSelection();
                    dataGridViewNotes.Rows[e.RowIndex].Selected = true;

                    dataGridViewNotes.ContextMenuStrip = contextMenuStripNotesList;

                    contextMenuStripNotesList.Show(dataGridViewNotes, e.Location);
                }
            }
        }

        private void dataGridViewNotes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBoxTitle.Text = table.Rows[e.RowIndex]["Title"].ToString();
                richTextBoxBody.Text = table.Rows[e.RowIndex]["Body"].ToString();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleanUpEmptyRows();
            SaveData();
            Application.Exit();
        }

        private void SaveData()
        {
            table.TableName = "MyNotes";
            XmlSerializer serializer = new XmlSerializer(typeof(DataTable));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, table);
            }
        }

        private void LoadData()
        {
            if (File.Exists(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DataTable));
                using (StreamReader reader = new StreamReader(filePath))
                {
                    try
                    {
                        table = (DataTable)serializer.Deserialize(reader);
                        CleanUpEmptyRows();
                        dataGridViewNotes.DataSource = table;
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show("Failed to load data: " + ex.Message);
                        // Handle the exception or log it
                    }
                }
            }
            else
            {
                MessageBox.Show("File not found: " + filePath);
            }
        }

        // MenuStrip Handlers
        // Cut
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBoxBody.SelectedText != "")
            {
                richTextBoxBody.Cut();
            }
            else if (textBoxTitle.Focused && textBoxTitle.SelectedText != "")
            {
                textBoxTitle.Cut();
            }
        }

        // Copy
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBoxBody.SelectedText != "")
            {
                richTextBoxBody.Copy();
            }
            else if (textBoxTitle.Focused && textBoxTitle.SelectedText != "")
            {
                textBoxTitle.Copy();
            }
        }

        // Paste
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                if (textBoxTitle.Focused)
                {
                    textBoxTitle.Paste();
                }
                else if (richTextBoxBody.Focused)
                {
                    richTextBoxBody.Paste();
                }
            }
        }

        // Select All
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBoxBody.Focused)
            {
                richTextBoxBody.SelectAll();
            }
            else if (textBoxTitle.Focused)
            {
                textBoxTitle.SelectAll();
            }
        }

        // ContextMenuStrip Handlers

        private void Cut_Click(object sender, EventArgs e)
        {
            cutToolStripMenuItem_Click(sender, e);
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem_Click(sender, e);
        }

        private void Paste_Click(object sender, EventArgs e)
        {
            pasteToolStripMenuItem_Click(sender, e);
        }

        private void SelectAll_Click(object sender, EventArgs e)
        {
            selectAllToolStripMenuItem_Click(sender, e);
        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/darylbutarcitu";

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void SnowyTheme_Click(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#D9D9E5");
            dataGridViewNotes.BackgroundColor = ColorTranslator.FromHtml("#485E6D");
            dataGridViewNotes.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#485E6D");
            dataGridViewNotes.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#A8B0BF");
            dataGridViewNotes.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#A8B0BF");
            dataGridViewNotes.DefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#1D363A");
            dataGridViewNotes.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#A8B0BF");
            dataGridViewNotes.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#1D363A");

            textBoxTitle.BackColor = ColorTranslator.FromHtml("#A8B0BF");
            textBoxTitle.ForeColor = ColorTranslator.FromHtml("#1D363A");
            richTextBoxBody.BackColor = ColorTranslator.FromHtml("#D9D9E5");
            richTextBoxBody.ForeColor = ColorTranslator.FromHtml("#1D363A");

            Font defaultFont = new Font("Segoe UI", 10, FontStyle.Regular);
            textBoxTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            richTextBoxBody.Font = defaultFont;
            dataGridViewNotes.Font = defaultFont;

            menuStrip1.BackColor = ColorTranslator.FromHtml("#D9D9E5");
            menuStrip1.ForeColor = ColorTranslator.FromHtml("#1D363A");
            contextMenuStripNotesList.BackColor = ColorTranslator.FromHtml("#D9D9E5");
            contextMenuStripNotesList.ForeColor = ColorTranslator.FromHtml("#1D363A");
            contextMenuStripTextBox.BackColor = ColorTranslator.FromHtml("#D9D9E5");
            contextMenuStripTextBox.ForeColor = ColorTranslator.FromHtml("#1D363A");
            SaveTheme("Snowy");
        }

        private void DesertNightTheme_Click(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#1C120D");
            dataGridViewNotes.BackgroundColor = ColorTranslator.FromHtml("#2B1D0E");
            dataGridViewNotes.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2B1D0E");
            dataGridViewNotes.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#E6C89C");
            dataGridViewNotes.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#3A2F2A");
            dataGridViewNotes.DefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#F4E7C3");
            dataGridViewNotes.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#3A2F2A");
            dataGridViewNotes.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#F4E7C3");

            textBoxTitle.BackColor = ColorTranslator.FromHtml("#3A2F2A");
            textBoxTitle.ForeColor = ColorTranslator.FromHtml("#F4E7C3");
            richTextBoxBody.BackColor = ColorTranslator.FromHtml("#1C120D");
            richTextBoxBody.ForeColor = ColorTranslator.FromHtml("#D9A066");

            Font defaultFont = new Font("Segoe UI", 10, FontStyle.Regular);
            textBoxTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            richTextBoxBody.Font = defaultFont;
            dataGridViewNotes.Font = defaultFont;

            menuStrip1.BackColor = ColorTranslator.FromHtml("#1C120D");
            menuStrip1.ForeColor = ColorTranslator.FromHtml("#D9A066");
            contextMenuStripNotesList.BackColor = ColorTranslator.FromHtml("#1C120D");
            contextMenuStripNotesList.ForeColor = ColorTranslator.FromHtml("#D9A066");
            contextMenuStripTextBox.BackColor = ColorTranslator.FromHtml("#1C120D");
            contextMenuStripTextBox.ForeColor = ColorTranslator.FromHtml("#D9A066");
            SaveTheme("DesertNight");
        }
        private void LimeLightTheme_Click(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#D1F2A5");
            dataGridViewNotes.BackgroundColor = ColorTranslator.FromHtml("#D1F2A5");
            dataGridViewNotes.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D1F2A5");
            dataGridViewNotes.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#2F4F4F");
            dataGridViewNotes.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#E0FFB3");
            dataGridViewNotes.DefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#2F4F4F");
            dataGridViewNotes.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#E0FFB3");
            dataGridViewNotes.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#2F4F4F");

            textBoxTitle.BackColor = ColorTranslator.FromHtml("#E0FFB3");
            textBoxTitle.ForeColor = ColorTranslator.FromHtml("#2F4F4F");
            richTextBoxBody.BackColor = ColorTranslator.FromHtml("#F0F8C0");
            richTextBoxBody.ForeColor = ColorTranslator.FromHtml("#2F4F4F");

            Font defaultFont = new Font("Segoe UI", 10, FontStyle.Regular);
            textBoxTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            richTextBoxBody.Font = defaultFont;
            dataGridViewNotes.Font = defaultFont;

            menuStrip1.BackColor = ColorTranslator.FromHtml("#D1F2A5");
            menuStrip1.ForeColor = ColorTranslator.FromHtml("#2F4F4F");
            contextMenuStripNotesList.BackColor = ColorTranslator.FromHtml("#D1F2A5");
            contextMenuStripNotesList.ForeColor = ColorTranslator.FromHtml("#2F4F4F");
            contextMenuStripTextBox.BackColor = ColorTranslator.FromHtml("#D1F2A5");
            contextMenuStripTextBox.ForeColor = ColorTranslator.FromHtml("#2F4F4F");
            SaveTheme("LimeLight");
        }

        private void DefaultTheme_Click(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#FFFACD");
            dataGridViewNotes.BackgroundColor = ColorTranslator.FromHtml("#FFFACD");
            dataGridViewNotes.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFFACD");
            dataGridViewNotes.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#333333");
            dataGridViewNotes.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFFBBD");
            dataGridViewNotes.DefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#222222");
            dataGridViewNotes.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFFBBD");
            dataGridViewNotes.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#222222");

            textBoxTitle.BackColor = ColorTranslator.FromHtml("#FFFBBD");
            textBoxTitle.ForeColor = ColorTranslator.FromHtml("#222222");
            richTextBoxBody.BackColor = ColorTranslator.FromHtml("#FFF9C4");
            richTextBoxBody.ForeColor = ColorTranslator.FromHtml("#1F1F1F");

            Font defaultFont = new Font("Segoe UI", 10, FontStyle.Regular);
            textBoxTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            richTextBoxBody.Font = defaultFont;
            dataGridViewNotes.Font = defaultFont;

            menuStrip1.BackColor = ColorTranslator.FromHtml("#FFFACD");
            menuStrip1.ForeColor = ColorTranslator.FromHtml("#333333");
            contextMenuStripNotesList.BackColor = ColorTranslator.FromHtml("#FFFACD");
            contextMenuStripNotesList.ForeColor = ColorTranslator.FromHtml("#333333");
            contextMenuStripTextBox.BackColor = ColorTranslator.FromHtml("#FFFACD");
            contextMenuStripTextBox.ForeColor = ColorTranslator.FromHtml("#333333");
            SaveTheme("Default");
        }

        private void VolcanicTheme_Click(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#1A0D08");
            dataGridViewNotes.BackgroundColor = ColorTranslator.FromHtml("#2C0A02");
            dataGridViewNotes.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2C0A02");
            dataGridViewNotes.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#FF5F1F");
            dataGridViewNotes.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#3E1F12");
            dataGridViewNotes.DefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#FFC77F");
            dataGridViewNotes.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#3E1F12");
            dataGridViewNotes.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#FFC77F");

            textBoxTitle.BackColor = ColorTranslator.FromHtml("#3E1F12");
            textBoxTitle.ForeColor = ColorTranslator.FromHtml("#FFC77F");
            richTextBoxBody.BackColor = ColorTranslator.FromHtml("#1A0D08");
            richTextBoxBody.ForeColor = ColorTranslator.FromHtml("#FF784E");

            Font defaultFont = new Font("Segoe UI", 10, FontStyle.Regular);
            textBoxTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            richTextBoxBody.Font = defaultFont;
            dataGridViewNotes.Font = defaultFont;

            menuStrip1.BackColor = ColorTranslator.FromHtml("#1A0D08");
            menuStrip1.ForeColor = ColorTranslator.FromHtml("#FF784E");
            contextMenuStripNotesList.BackColor = ColorTranslator.FromHtml("#1A0D08");
            contextMenuStripNotesList.ForeColor = ColorTranslator.FromHtml("#FF784E");
            contextMenuStripTextBox.BackColor = ColorTranslator.FromHtml("#1A0D08");
            contextMenuStripTextBox.ForeColor = ColorTranslator.FromHtml("#FF784E");
            SaveTheme("Volcanic");
        }
        private void CleanUpEmptyRows()
        {
            for (int i = table.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = table.Rows[i];
                if (row.RowState != DataRowState.Deleted &&
                    string.IsNullOrWhiteSpace(row["Title"].ToString()) &&
                    (string.IsNullOrWhiteSpace(row["Body"].ToString()) || row["Body"].ToString() == RichTextBoxPlaceholder))
                {
                    table.Rows[i].Delete();
                }
            }
            table.AcceptChanges();
        }
        private void SaveTheme(string themeName)
        {
            File.WriteAllText("theme.txt", themeName);
        }
        private void LoadTheme()
        {
            if (File.Exists("theme.txt"))
            {
                string themeName = File.ReadAllText("theme.txt");
                switch (themeName)
                {
                    case "Snowy":
                        SnowyTheme_Click(this, EventArgs.Empty);
                        break;
                    case "DesertNight":
                        DesertNightTheme_Click(this, EventArgs.Empty);
                        break;
                    case "LimeLight":
                        LimeLightTheme_Click(this, EventArgs.Empty);
                        break;
                    case "Default":
                        DefaultTheme_Click(this, EventArgs.Empty);
                        break;
                    case "Volcanic":
                        VolcanicTheme_Click(this, EventArgs.Empty);
                        break;
                }
            }
        }
    }
}
