namespace DoctorDoctor
{
    partial class DoctorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctorForm));
            this.buttonClose = new System.Windows.Forms.Button();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.propertyGrid2 = new System.Windows.Forms.PropertyGrid();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBoxComments = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorCodingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxProjects = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(1139, 679);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(94, 29);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.Location = new System.Drawing.Point(295, 57);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGrid1.Size = new System.Drawing.Size(938, 125);
            this.propertyGrid1.TabIndex = 1;
            this.propertyGrid1.ToolbarVisible = false;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 208);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(277, 465);
            this.treeView1.TabIndex = 2;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // propertyGrid2
            // 
            this.propertyGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid2.HelpVisible = false;
            this.propertyGrid2.Location = new System.Drawing.Point(295, 208);
            this.propertyGrid2.Name = "propertyGrid2";
            this.propertyGrid2.Size = new System.Drawing.Size(938, 287);
            this.propertyGrid2.TabIndex = 3;
            this.propertyGrid2.ToolbarVisible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 681);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 29);
            this.button3.TabIndex = 6;
            this.button3.Text = "Expand All";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(119, 681);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(101, 29);
            this.button4.TabIndex = 7;
            this.button4.Text = "Collapse All";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBoxComments
            // 
            this.textBoxComments.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBoxComments.Location = new System.Drawing.Point(295, 521);
            this.textBoxComments.Multiline = true;
            this.textBoxComments.Name = "textBoxComments";
            this.textBoxComments.Size = new System.Drawing.Size(938, 152);
            this.textBoxComments.TabIndex = 8;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.instructionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1245, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFolderToolStripMenuItem,
            this.loadFileToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadFolderToolStripMenuItem
            // 
            this.loadFolderToolStripMenuItem.Name = "loadFolderToolStripMenuItem";
            this.loadFolderToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.loadFolderToolStripMenuItem.Text = "Load Folder";
            this.loadFolderToolStripMenuItem.Click += new System.EventHandler(this.loadProjectToolStripMenuItem_Click);
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.loadFileToolStripMenuItem.Text = "Load File Only";
            this.loadFileToolStripMenuItem.Click += new System.EventHandler(this.loadFileToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // instructionsToolStripMenuItem
            // 
            this.instructionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFilesToolStripMenuItem,
            this.colorCodingToolStripMenuItem});
            this.instructionsToolStripMenuItem.Name = "instructionsToolStripMenuItem";
            this.instructionsToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.instructionsToolStripMenuItem.Text = "Instructions";
            // 
            // importFilesToolStripMenuItem
            // 
            this.importFilesToolStripMenuItem.Name = "importFilesToolStripMenuItem";
            this.importFilesToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.importFilesToolStripMenuItem.Text = "Import Files";
            this.importFilesToolStripMenuItem.Click += new System.EventHandler(this.importFilesToolStripMenuItem_Click);
            // 
            // colorCodingToolStripMenuItem
            // 
            this.colorCodingToolStripMenuItem.Name = "colorCodingToolStripMenuItem";
            this.colorCodingToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.colorCodingToolStripMenuItem.Text = "Color Coding";
            this.colorCodingToolStripMenuItem.Click += new System.EventHandler(this.colorCodingToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Comments";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "XML Metadata";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Selected Comment Data";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 498);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Comment Text";
            // 
            // listBoxProjects
            // 
            this.listBoxProjects.AllowDrop = true;
            this.listBoxProjects.FormattingEnabled = true;
            this.listBoxProjects.ItemHeight = 20;
            this.listBoxProjects.Location = new System.Drawing.Point(12, 57);
            this.listBoxProjects.Name = "listBoxProjects";
            this.listBoxProjects.Size = new System.Drawing.Size(277, 124);
            this.listBoxProjects.TabIndex = 14;
            this.listBoxProjects.SelectedIndexChanged += new System.EventHandler(this.listBoxProjects_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Projects";
            // 
            // DoctorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1245, 722);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBoxProjects);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxComments);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.propertyGrid2);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DoctorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DoctorDoctor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonClose;
        private PropertyGrid propertyGrid1;
        private TreeView treeView1;
        private PropertyGrid propertyGrid2;
        private Button button3;
        private Button button4;
        private TextBox textBoxComments;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem loadFolderToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ListBox listBoxProjects;
        private Label label5;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem instructionsToolStripMenuItem;
        private ToolStripMenuItem loadFileToolStripMenuItem;
        private ToolStripMenuItem importFilesToolStripMenuItem;
        private ToolStripMenuItem colorCodingToolStripMenuItem;
    }
}