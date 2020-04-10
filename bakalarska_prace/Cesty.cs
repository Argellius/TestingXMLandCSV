using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bakalarska_prace
{
    public partial class Cesty : MetroFramework.Forms.MetroForm
    {
        public string PathTestName { get; private set; }
        public string PathVysledkyName { get; private set; }

        public Cesty()
        {
            InitializeComponent();
            this.PathTestName = @"C:\XML&CSVTesting\Tests";
            this.PathVysledkyName = @"C:\XML&CSVTesting\Results";
        }



        private void Cesty_Load(object sender, EventArgs e)
        {          

            this.metroTextBox_testy.Text = this.PathTestName;
            this.metroTextBox_vysledky.Text = this.PathVysledkyName;
        }

        private void metroButton_testy_Click(object sender, EventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                this.metroTextBox_testy.Text = dialog.SelectedPath;
            }
        }

        private void metroButton_vysledky_Click(object sender, EventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                this.metroTextBox_vysledky.Text = dialog.SelectedPath;
            }
        }

        private void Cesty_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
