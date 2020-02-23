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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestingXMLCSV));
            this.groupBox_testovani = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox_selected = new System.Windows.Forms.ListBox();
            this.treeView_Tests = new System.Windows.Forms.TreeView();
            this.metroButton_Start = new MetroFramework.Controls.MetroButton();
            this.metroLabel_numberElements = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_repeat = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox_NumberOfElements = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox_repeat = new MetroFramework.Controls.MetroTextBox();
            this.userControl_Result1 = new bakalarska_prace.UserControl_Result();
            this.groupBox_testovani.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_testovani
            // 
            this.groupBox_testovani.Controls.Add(this.userControl_Result1);
            this.groupBox_testovani.Controls.Add(this.label2);
            this.groupBox_testovani.Controls.Add(this.label1);
            this.groupBox_testovani.Controls.Add(this.listBox_selected);
            this.groupBox_testovani.Controls.Add(this.treeView_Tests);
            this.groupBox_testovani.Location = new System.Drawing.Point(47, 51);
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
            this.label2.Location = new System.Drawing.Point(453, 38);
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
            this.listBox_selected.Location = new System.Drawing.Point(456, 63);
            this.listBox_selected.Name = "listBox_selected";
            this.listBox_selected.Size = new System.Drawing.Size(332, 361);
            this.listBox_selected.TabIndex = 3;
            // 
            // treeView_Tests
            // 
            this.treeView_Tests.CheckBoxes = true;
            this.treeView_Tests.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView_Tests.HideSelection = false;
            this.treeView_Tests.Location = new System.Drawing.Point(17, 60);
            this.treeView_Tests.Name = "treeView_Tests";
            this.treeView_Tests.Size = new System.Drawing.Size(403, 367);
            this.treeView_Tests.TabIndex = 2;
            this.treeView_Tests.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Tests_AfterCheck_1);
            this.treeView_Tests.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_Tests_BeforeSelect);
            this.treeView_Tests.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_Tests_NodeMouseDoubleClick);
            // 
            // metroButton_Start
            // 
            this.metroButton_Start.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton_Start.Highlight = true;
            this.metroButton_Start.Location = new System.Drawing.Point(67, 568);
            this.metroButton_Start.Name = "metroButton_Start";
            this.metroButton_Start.Size = new System.Drawing.Size(143, 23);
            this.metroButton_Start.TabIndex = 8;
            this.metroButton_Start.Text = "Spustit";
            this.metroButton_Start.UseSelectable = true;
            this.metroButton_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // metroLabel_numberElements
            // 
            this.metroLabel_numberElements.AutoSize = true;
            this.metroLabel_numberElements.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel_numberElements.Location = new System.Drawing.Point(67, 511);
            this.metroLabel_numberElements.Name = "metroLabel_numberElements";
            this.metroLabel_numberElements.Size = new System.Drawing.Size(91, 19);
            this.metroLabel_numberElements.TabIndex = 9;
            this.metroLabel_numberElements.Text = "Počet prvků";
            // 
            // metroLabel_repeat
            // 
            this.metroLabel_repeat.AutoSize = true;
            this.metroLabel_repeat.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel_repeat.Location = new System.Drawing.Point(67, 538);
            this.metroLabel_repeat.Name = "metroLabel_repeat";
            this.metroLabel_repeat.Size = new System.Drawing.Size(122, 19);
            this.metroLabel_repeat.TabIndex = 10;
            this.metroLabel_repeat.Text = "Počet opakování";
            // 
            // metroTextBox_NumberOfElements
            // 
            // 
            // 
            // 
            this.metroTextBox_NumberOfElements.CustomButton.Image = null;
            this.metroTextBox_NumberOfElements.CustomButton.Location = new System.Drawing.Point(78, 1);
            this.metroTextBox_NumberOfElements.CustomButton.Name = "";
            this.metroTextBox_NumberOfElements.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox_NumberOfElements.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox_NumberOfElements.CustomButton.TabIndex = 1;
            this.metroTextBox_NumberOfElements.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox_NumberOfElements.CustomButton.UseSelectable = true;
            this.metroTextBox_NumberOfElements.CustomButton.Visible = false;
            this.metroTextBox_NumberOfElements.Lines = new string[0];
            this.metroTextBox_NumberOfElements.Location = new System.Drawing.Point(213, 511);
            this.metroTextBox_NumberOfElements.MaxLength = 32767;
            this.metroTextBox_NumberOfElements.Name = "metroTextBox_NumberOfElements";
            this.metroTextBox_NumberOfElements.PasswordChar = '\0';
            this.metroTextBox_NumberOfElements.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox_NumberOfElements.SelectedText = "";
            this.metroTextBox_NumberOfElements.SelectionLength = 0;
            this.metroTextBox_NumberOfElements.SelectionStart = 0;
            this.metroTextBox_NumberOfElements.ShortcutsEnabled = true;
            this.metroTextBox_NumberOfElements.Size = new System.Drawing.Size(100, 23);
            this.metroTextBox_NumberOfElements.TabIndex = 11;
            this.metroTextBox_NumberOfElements.UseSelectable = true;
            this.metroTextBox_NumberOfElements.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox_NumberOfElements.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBox_repeat
            // 
            // 
            // 
            // 
            this.metroTextBox_repeat.CustomButton.Image = null;
            this.metroTextBox_repeat.CustomButton.Location = new System.Drawing.Point(78, 1);
            this.metroTextBox_repeat.CustomButton.Name = "";
            this.metroTextBox_repeat.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox_repeat.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox_repeat.CustomButton.TabIndex = 1;
            this.metroTextBox_repeat.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox_repeat.CustomButton.UseSelectable = true;
            this.metroTextBox_repeat.CustomButton.Visible = false;
            this.metroTextBox_repeat.Lines = new string[0];
            this.metroTextBox_repeat.Location = new System.Drawing.Point(213, 540);
            this.metroTextBox_repeat.MaxLength = 32767;
            this.metroTextBox_repeat.Name = "metroTextBox_repeat";
            this.metroTextBox_repeat.PasswordChar = '\0';
            this.metroTextBox_repeat.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox_repeat.SelectedText = "";
            this.metroTextBox_repeat.SelectionLength = 0;
            this.metroTextBox_repeat.SelectionStart = 0;
            this.metroTextBox_repeat.ShortcutsEnabled = true;
            this.metroTextBox_repeat.Size = new System.Drawing.Size(100, 23);
            this.metroTextBox_repeat.TabIndex = 12;
            this.metroTextBox_repeat.UseSelectable = true;
            this.metroTextBox_repeat.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox_repeat.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // userControl_Result1
            // 
            this.userControl_Result1.AutoScroll = true;
            this.userControl_Result1.BackColor = System.Drawing.Color.LightGray;
            this.userControl_Result1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl_Result1.Location = new System.Drawing.Point(3, 16);
            this.userControl_Result1.Name = "userControl_Result1";
            this.userControl_Result1.Size = new System.Drawing.Size(848, 424);
            this.userControl_Result1.TabIndex = 10;
            // 
            // TestingXMLCSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(958, 614);
            this.Controls.Add(this.metroTextBox_repeat);
            this.Controls.Add(this.metroTextBox_NumberOfElements);
            this.Controls.Add(this.metroButton_Start);
            this.Controls.Add(this.groupBox_testovani);
            this.Controls.Add(this.metroLabel_numberElements);
            this.Controls.Add(this.metroLabel_repeat);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TestingXMLCSV";
            this.Text = "Testing XML and CSV";
            this.Load += new System.EventHandler(this.TestingXMLCSV_Load);
            this.groupBox_testovani.ResumeLayout(false);
            this.groupBox_testovani.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_testovani;
        private System.Windows.Forms.TreeView treeView_Tests;
        private System.Windows.Forms.ListBox listBox_selected;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton metroButton_Start;
        private MetroFramework.Controls.MetroLabel metroLabel_numberElements;
        private MetroFramework.Controls.MetroLabel metroLabel_repeat;
        private MetroFramework.Controls.MetroTextBox metroTextBox_NumberOfElements;
        private MetroFramework.Controls.MetroTextBox metroTextBox_repeat;
        private UserControl_Result userControl_Result1;
    }
}