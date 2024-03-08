using System.Diagnostics;

namespace TextEditor
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public partial class Form1 : Form
    {
        private string currentFilePath = "";
        public Form1()
        {
            InitializeComponent();
            InitializeMenu();
            InitializeToolStrip();
            InitializeContextMenu();
        }
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
        private void InitializeMenu()
        {
            MenuStrip menuStrip = new();
            ToolStripMenuItem fileMenu = new("File");
            ToolStripMenuItem editMenu = new("Edit");

            ToolStripMenuItem newMenuItem = new("New");
            newMenuItem.Click += (sender, e) => { TextBox.Text = ""; };
            fileMenu.DropDownItems.Add(newMenuItem);

            ToolStripMenuItem openMenuItem = new("Open");
            openMenuItem.Click += (sender, e) =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    TextBox.Text = File.ReadAllText(openFileDialog.FileName);
                    currentFilePath = openFileDialog.FileName;
                    this.Text = currentFilePath;
                }
            };
            fileMenu.DropDownItems.Add(openMenuItem);

            ToolStripMenuItem saveMenuItem = new("Save");
            saveMenuItem.Click += (sender, e) =>
            {
                if (currentFilePath != "")
                {
                    File.WriteAllText(currentFilePath, TextBox.Text);
                }
                else
                {
                    SaveFileDialog saveFileDialog = new();
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, TextBox.Text);
                        currentFilePath = saveFileDialog.FileName;
                        this.Text = currentFilePath;
                    }
                }
            };
            fileMenu.DropDownItems.Add(saveMenuItem);

            menuStrip.Items.Add(fileMenu);

            ToolStripMenuItem copyMenuItem = new("Copy");
            copyMenuItem.Click += (sender, e) => TextBox.Copy();
            editMenu.DropDownItems.Add(copyMenuItem);

            ToolStripMenuItem cutMenuItem = new("Cut");
            cutMenuItem.Click += (sender, e) => { TextBox.Cut(); };
            editMenu.DropDownItems.Add(cutMenuItem);

            ToolStripMenuItem pasteMenuItem = new("Paste");
            pasteMenuItem.Click += (sender, e) => { TextBox.Paste(); };
            editMenu.DropDownItems.Add(pasteMenuItem);

            ToolStripMenuItem undoMenuItem = new("Undo");
            undoMenuItem.Click += (sender, e) => { TextBox.Undo(); };
            editMenu.DropDownItems.Add(undoMenuItem);

            menuStrip.Items.Add(editMenu);

            this.Controls.Add(menuStrip);
        }

        private void InitializeToolStrip()
        {
            ToolStrip toolStrip = new();

            ToolStripButton fontSettingsButton = new("Font Settings");
            fontSettingsButton.Click += (sender, e) =>
            {
                FontDialog fontDialog = new();
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    TextBox.Font = fontDialog.Font;
                    TextBox.ForeColor = fontDialog.Color;
                }
            };

            toolStrip.Items.Add(fontSettingsButton);
            this.Controls.Add(toolStrip);
        }

        private void InitializeContextMenu()
        {
            ContextMenuStrip contextMenuStrip = new();

            ToolStripMenuItem copyContextMenuItem = new("Copy");
            copyContextMenuItem.Click += (sender, e) => { TextBox.Copy(); };
            contextMenuStrip.Items.Add(copyContextMenuItem);

            ToolStripMenuItem cutContextMenuItem = new("Cut");
            cutContextMenuItem.Click += (sender, e) => { TextBox.Cut(); };
            contextMenuStrip.Items.Add(cutContextMenuItem);

            ToolStripMenuItem pasteContextMenuItem = new("Paste");
            pasteContextMenuItem.Click += (sender, e) => { TextBox.Paste(); };
            contextMenuStrip.Items.Add(pasteContextMenuItem);

            ToolStripMenuItem undoContextMenuItem = new("Undo");
            undoContextMenuItem.Click += (sender, e) => { TextBox.Undo(); };
            contextMenuStrip.Items.Add(undoContextMenuItem);

            TextBox.ContextMenuStrip = contextMenuStrip;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    internal class TextBox
    {
        public static string Text { get; internal set; }
        public static Font Font { get; internal set; }
        public static ContextMenuStrip ContextMenuStrip { get; internal set; }
        public static Color ForeColor { get; internal set; }

        internal static void Copy()
        {
            throw new NotImplementedException();
        }

        internal static void Cut()
        {
            throw new NotImplementedException();
        }

        internal static void Paste()
        {
            throw new NotImplementedException();
        }

        internal static void Undo()
        {
            throw new NotImplementedException();
        }
    }
}

