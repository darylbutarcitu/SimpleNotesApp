namespace Butar_Prelim
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dataGridViewNotes = new DataGridView();
            contextMenuStripNotesList = new ContextMenuStrip(components);
            deleteToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStripTextBox = new ContextMenuStrip(components);
            Cut = new ToolStripMenuItem();
            Copy = new ToolStripMenuItem();
            Paste = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            SelectAll = new ToolStripMenuItem();
            textBoxTitle = new TextBox();
            richTextBoxBody = new RichTextBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator = new ToolStripSeparator();
            saveToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            selectAllToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            themeToolStripMenuItem = new ToolStripMenuItem();
            SnowyTheme = new ToolStripMenuItem();
            LimeLightTheme = new ToolStripMenuItem();
            DesertNightTheme = new ToolStripMenuItem();
            VolcanicTheme = new ToolStripMenuItem();
            DefaultTheme = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            contactToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridViewNotes).BeginInit();
            contextMenuStripNotesList.SuspendLayout();
            contextMenuStripTextBox.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewNotes
            // 
            dataGridViewNotes.AllowUserToResizeRows = false;
            dataGridViewNotes.BackgroundColor = Color.FromArgb(255, 250, 205);
            dataGridViewNotes.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(255, 251, 189);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(34, 34, 34);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewNotes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewNotes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewNotes.ContextMenuStrip = contextMenuStripNotesList;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(255, 250, 205);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(51, 51, 51);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 251, 189);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(34, 34, 34);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewNotes.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewNotes.Dock = DockStyle.Left;
            dataGridViewNotes.Location = new Point(0, 24);
            dataGridViewNotes.Name = "dataGridViewNotes";
            dataGridViewNotes.ReadOnly = true;
            dataGridViewNotes.Size = new Size(119, 364);
            dataGridViewNotes.TabIndex = 0;
            dataGridViewNotes.CellClick += dataGridViewNotes_CellClick;
            // 
            // contextMenuStripNotesList
            // 
            contextMenuStripNotesList.BackColor = Color.FromArgb(255, 250, 205);
            contextMenuStripNotesList.ForeColor = Color.FromArgb(51, 51, 51);
            contextMenuStripNotesList.Items.AddRange(new ToolStripItem[] { deleteToolStripMenuItem });
            contextMenuStripNotesList.Name = "contextMenuStripNotestList";
            contextMenuStripNotesList.Size = new Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(107, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // contextMenuStripTextBox
            // 
            contextMenuStripTextBox.BackColor = Color.FromArgb(255, 250, 205);
            contextMenuStripTextBox.ForeColor = Color.FromArgb(51, 51, 51);
            contextMenuStripTextBox.Items.AddRange(new ToolStripItem[] { Cut, Copy, Paste, toolStripSeparator3, SelectAll });
            contextMenuStripTextBox.Name = "contextMenuStripTextBox";
            contextMenuStripTextBox.Size = new Size(165, 98);
            // 
            // Cut
            // 
            Cut.Name = "Cut";
            Cut.ShortcutKeys = Keys.Control | Keys.X;
            Cut.Size = new Size(164, 22);
            Cut.Text = "Cut";
            Cut.Click += Cut_Click;
            // 
            // Copy
            // 
            Copy.Name = "Copy";
            Copy.ShortcutKeys = Keys.Control | Keys.C;
            Copy.Size = new Size(164, 22);
            Copy.Text = "Copy";
            Copy.Click += Copy_Click;
            // 
            // Paste
            // 
            Paste.Name = "Paste";
            Paste.ShortcutKeys = Keys.Control | Keys.V;
            Paste.Size = new Size(164, 22);
            Paste.Text = "Paste";
            Paste.Click += Paste_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(161, 6);
            // 
            // SelectAll
            // 
            SelectAll.Name = "SelectAll";
            SelectAll.ShortcutKeys = Keys.Control | Keys.A;
            SelectAll.Size = new Size(164, 22);
            SelectAll.Text = "Select All";
            SelectAll.Click += SelectAll_Click;
            // 
            // textBoxTitle
            // 
            textBoxTitle.BackColor = Color.FromArgb(255, 251, 189);
            textBoxTitle.BorderStyle = BorderStyle.None;
            textBoxTitle.ContextMenuStrip = contextMenuStripTextBox;
            textBoxTitle.Dock = DockStyle.Top;
            textBoxTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            textBoxTitle.ForeColor = Color.FromArgb(34, 34, 34);
            textBoxTitle.Location = new Point(119, 24);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(361, 32);
            textBoxTitle.TabIndex = 1;
            // 
            // richTextBoxBody
            // 
            richTextBoxBody.BackColor = Color.FromArgb(255, 249, 196);
            richTextBoxBody.BorderStyle = BorderStyle.None;
            richTextBoxBody.ContextMenuStrip = contextMenuStripTextBox;
            richTextBoxBody.Dock = DockStyle.Fill;
            richTextBoxBody.ForeColor = Color.FromArgb(31, 31, 31);
            richTextBoxBody.Location = new Point(119, 56);
            richTextBoxBody.Name = "richTextBoxBody";
            richTextBoxBody.Size = new Size(361, 332);
            richTextBoxBody.TabIndex = 2;
            richTextBoxBody.Text = "";
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(255, 250, 205);
            menuStrip1.ForeColor = Color.FromArgb(51, 51, 51);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(480, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, toolStripSeparator, saveToolStripMenuItem, toolStripSeparator2, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Image = (Image)resources.GetObject("newToolStripMenuItem.Image");
            newToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(141, 22);
            newToolStripMenuItem.Text = "&New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new Size(138, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Image = (Image)resources.GetObject("saveToolStripMenuItem.Image");
            saveToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(141, 22);
            saveToolStripMenuItem.Text = "&Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(138, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(141, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, toolStripSeparator5, selectAllToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "&Edit";
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Image = (Image)resources.GetObject("cutToolStripMenuItem.Image");
            cutToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            cutToolStripMenuItem.Size = new Size(164, 22);
            cutToolStripMenuItem.Text = "Cu&t";
            cutToolStripMenuItem.Click += cutToolStripMenuItem_Click;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Image = (Image)resources.GetObject("copyToolStripMenuItem.Image");
            copyToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyToolStripMenuItem.Size = new Size(164, 22);
            copyToolStripMenuItem.Text = "&Copy";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Image = (Image)resources.GetObject("pasteToolStripMenuItem.Image");
            pasteToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            pasteToolStripMenuItem.Size = new Size(164, 22);
            pasteToolStripMenuItem.Text = "&Paste";
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(161, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            selectAllToolStripMenuItem.Size = new Size(164, 22);
            selectAllToolStripMenuItem.Text = "Select &All";
            selectAllToolStripMenuItem.Click += selectAllToolStripMenuItem_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { themeToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(47, 20);
            toolsToolStripMenuItem.Text = "&Tools";
            // 
            // themeToolStripMenuItem
            // 
            themeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { SnowyTheme, LimeLightTheme, DesertNightTheme, VolcanicTheme, DefaultTheme });
            themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            themeToolStripMenuItem.Size = new Size(111, 22);
            themeToolStripMenuItem.Text = "&Theme";
            // 
            // SnowyTheme
            // 
            SnowyTheme.Name = "SnowyTheme";
            SnowyTheme.Size = new Size(140, 22);
            SnowyTheme.Text = "Snowy";
            SnowyTheme.Click += SnowyTheme_Click;
            // 
            // LimeLightTheme
            // 
            LimeLightTheme.Name = "LimeLightTheme";
            LimeLightTheme.Size = new Size(140, 22);
            LimeLightTheme.Text = "Lime Light";
            LimeLightTheme.Click += LimeLightTheme_Click;
            // 
            // DesertNightTheme
            // 
            DesertNightTheme.Name = "DesertNightTheme";
            DesertNightTheme.Size = new Size(140, 22);
            DesertNightTheme.Text = "Desert Night";
            DesertNightTheme.Click += DesertNightTheme_Click;
            // 
            // VolcanicTheme
            // 
            VolcanicTheme.Name = "VolcanicTheme";
            VolcanicTheme.Size = new Size(140, 22);
            VolcanicTheme.Text = "Volcanic";
            VolcanicTheme.Click += VolcanicTheme_Click;
            // 
            // DefaultTheme
            // 
            DefaultTheme.Name = "DefaultTheme";
            DefaultTheme.Size = new Size(140, 22);
            DefaultTheme.Text = "Default";
            DefaultTheme.Click += DefaultTheme_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripSeparator6, contactToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(104, 6);
            // 
            // contactToolStripMenuItem
            // 
            contactToolStripMenuItem.Name = "contactToolStripMenuItem";
            contactToolStripMenuItem.Size = new Size(107, 22);
            contactToolStripMenuItem.Text = "&About";
            contactToolStripMenuItem.Click += contactToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(255, 250, 205);
            ClientSize = new Size(480, 388);
            Controls.Add(richTextBoxBody);
            Controls.Add(textBoxTitle);
            Controls.Add(dataGridViewNotes);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "My Notes App";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewNotes).EndInit();
            contextMenuStripNotesList.ResumeLayout(false);
            contextMenuStripTextBox.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewNotes;
        private TextBox textBoxTitle;
        private RichTextBox richTextBoxBody;
        private MenuStrip menuStrip1;
        private ContextMenuStrip contextMenuStripTextBox;
        private ToolStripMenuItem Copy;
        private ToolStripMenuItem Paste;
        private ToolStripMenuItem Cut;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem themeToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem contactToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ContextMenuStrip contextMenuStripNotesList;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem SelectAll;
        private ToolStripMenuItem SnowyTheme;
        private ToolStripMenuItem DefaultTheme;
        private ToolStripMenuItem LimeLightTheme;
        private ToolStripMenuItem DesertNightTheme;
        private ToolStripMenuItem VolcanicTheme;
    }
}
