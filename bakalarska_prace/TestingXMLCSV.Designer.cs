namespace bakalarska_prace
{
    partial class TestingXMLCSV
    {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestingXMLCSV));
            this.groupBox_testovani = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox_selected = new System.Windows.Forms.ListBox();
            this.treeView_Tests = new System.Windows.Forms.TreeView();
            this.button_Start = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aplikaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nastaveníToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_NumberOfElements = new System.Windows.Forms.TextBox();
            this.label_numberElements = new System.Windows.Forms.Label();
            this.label_repeat = new System.Windows.Forms.Label();
            this.textBox_repeat = new System.Windows.Forms.TextBox();
            this.zavřítToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox_testovani.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_testovani
            // 
            this.groupBox_testovani.Controls.Add(this.label2);
            this.groupBox_testovani.Controls.Add(this.label1);
            this.groupBox_testovani.Controls.Add(this.listBox_selected);
            this.groupBox_testovani.Controls.Add(this.treeView_Tests);
            this.groupBox_testovani.Location = new System.Drawing.Point(47, 42);
            this.groupBox_testovani.Name = "groupBox_testovani";
            this.groupBox_testovani.Size = new System.Drawing.Size(854, 443);
            this.groupBox_testovani.TabIndex = 0;
            this.groupBox_testovani.TabStop = false;
            this.groupBox_testovani.Text = "Testování";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(481, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Vybrané testovací případy:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(14, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Testovací případy:";
            // 
            // listBox_selected
            // 
            this.listBox_selected.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.listBox_selected.FormattingEnabled = true;
            this.listBox_selected.ItemHeight = 17;
            this.listBox_selected.Location = new System.Drawing.Point(484, 60);
            this.listBox_selected.Name = "listBox_selected";
            this.listBox_selected.Size = new System.Drawing.Size(332, 361);
            this.listBox_selected.TabIndex = 3;
            // 
            // treeView_Tests
            // 
            this.treeView_Tests.CheckBoxes = true;
            this.treeView_Tests.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView_Tests.Location = new System.Drawing.Point(17, 60);
            this.treeView_Tests.Name = "treeView_Tests";
            this.treeView_Tests.Size = new System.Drawing.Size(403, 367);
            this.treeView_Tests.TabIndex = 2;
            this.treeView_Tests.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Tests_AfterCheck_1);
            this.treeView_Tests.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Tests_AfterSelect_1);
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(64, 547);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(222, 23);
            this.button_Start.TabIndex = 1;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(106, 26);
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aplikaceToolStripMenuItem,
            this.nastaveníToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(936, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aplikaceToolStripMenuItem
            // 
            this.aplikaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zavřítToolStripMenuItem});
            this.aplikaceToolStripMenuItem.Name = "aplikaceToolStripMenuItem";
            this.aplikaceToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.aplikaceToolStripMenuItem.Text = "Aplikace";
            // 
            // nastaveníToolStripMenuItem
            // 
            this.nastaveníToolStripMenuItem.Name = "nastaveníToolStripMenuItem";
            this.nastaveníToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.nastaveníToolStripMenuItem.Text = "Nastavení";
            // 
            // textBox_NumberOfElements
            // 
            this.textBox_NumberOfElements.Location = new System.Drawing.Point(186, 490);
            this.textBox_NumberOfElements.Name = "textBox_NumberOfElements";
            this.textBox_NumberOfElements.Size = new System.Drawing.Size(100, 20);
            this.textBox_NumberOfElements.TabIndex = 4;
            // 
            // label_numberElements
            // 
            this.label_numberElements.AutoSize = true;
            this.label_numberElements.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.label_numberElements.Location = new System.Drawing.Point(64, 491);
            this.label_numberElements.Name = "label_numberElements";
            this.label_numberElements.Size = new System.Drawing.Size(84, 16);
            this.label_numberElements.TabIndex = 5;
            this.label_numberElements.Text = "Počet prvků";
            // 
            // label_repeat
            // 
            this.label_repeat.AutoSize = true;
            this.label_repeat.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.label_repeat.Location = new System.Drawing.Point(64, 522);
            this.label_repeat.Name = "label_repeat";
            this.label_repeat.Size = new System.Drawing.Size(116, 16);
            this.label_repeat.TabIndex = 7;
            this.label_repeat.Text = "Počet opakování";
            // 
            // textBox_repeat
            // 
            this.textBox_repeat.Location = new System.Drawing.Point(186, 518);
            this.textBox_repeat.Name = "textBox_repeat";
            this.textBox_repeat.Size = new System.Drawing.Size(100, 20);
            this.textBox_repeat.TabIndex = 6;
            // 
            // zavřítToolStripMenuItem
            // 
            this.zavřítToolStripMenuItem.Name = "zavřítToolStripMenuItem";
            this.zavřítToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.zavřítToolStripMenuItem.Text = "Zavřít";
            this.zavřítToolStripMenuItem.Click += new System.EventHandler(this.zavřítToolStripMenuItem_Click);
            // 
            // TestingXMLCSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 614);
            this.Controls.Add(this.label_repeat);
            this.Controls.Add(this.textBox_repeat);
            this.Controls.Add(this.label_numberElements);
            this.Controls.Add(this.textBox_NumberOfElements);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.groupBox_testovani);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TestingXMLCSV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Testing XML and CSV";
            this.Load += new System.EventHandler(this.TestingXMLCSV_Load);
            this.groupBox_testovani.ResumeLayout(false);
            this.groupBox_testovani.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_testovani;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aplikaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nastaveníToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView_Tests;
        private System.Windows.Forms.ListBox listBox_selected;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_NumberOfElements;
        private System.Windows.Forms.Label label_numberElements;
        private System.Windows.Forms.Label label_repeat;
        private System.Windows.Forms.TextBox textBox_repeat;
        private System.Windows.Forms.ToolStripMenuItem zavřítToolStripMenuItem;
    }
}