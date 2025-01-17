﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bakalarska_prace
{
    public partial class UserControl_Result : UserControl
    {
        Tools_Vysledky _vysledky;
        DataTable table_Mezivysledky;
        DataTable table_Statistika;
        private TestingXMLCSV ParentForm;
        public UserControl_Result()
        {
            InitializeComponent();
        }

        public UserControl_Result(TestingXMLCSV parentForm)
        {
            this.ParentForm = parentForm;
            InitializeComponent();

            panel1.HorizontalScroll.Enabled = false;

        }

        private void UserControl_Result_Load(object sender, EventArgs e)
        {
            metroGrid_Result.AlternatingRowsDefaultCellStyle.BackColor = Color.RosyBrown;
            metroGrid_Result.DefaultCellStyle.ForeColor = Color.Black;
            comboBox_Vyber.Items.Add("Mezivýsledky");
            comboBox_Vyber.Items.Add("Statistika");


        }

        public void SetToolsVysledky(Tools_Vysledky vysledky)
        {
            this._vysledky = vysledky;
        }

        public void SetParentForm(TestingXMLCSV form)
        {
            this.ParentForm = form;
        }

        public void ShowResultsComponent()
        {
            if (_vysledky != null)
            {
                this.Visible = true;
                this.BringToFront();
                comboBox_Vyber.SelectedIndex = 0;

            }
        }

        public void InitGridView_ToolsVysledky_Statistika(Tools_Vysledky _Vysledky)
        {
            var results = _Vysledky.GetListZaznamy().GroupBy(p => p.name,
           (key, g) => new { Name = key, Properties = g.ToList() }).OrderBy(s => s.Name.Substring(4));//order by XML_... || CSV_....

            table_Statistika = new DataTable("Statistika");

            table_Statistika.Columns.Add("Název testu", typeof(string));
            table_Statistika.Columns.Add("Průměrný čas[ms]", typeof(decimal));
            table_Statistika.Columns.Add("Počet znaků/bajtů", typeof(decimal));
            table_Statistika.Columns.Add("Median[ms]", typeof(decimal));
            table_Statistika.Columns.Add("Rozptyl[ms^2]", typeof(decimal));
            table_Statistika.Columns.Add("Směrodatná odchylka[ms]", typeof(decimal));
            table_Statistika.Columns.Add("Počet za 1 s[znaky/bajtů]", typeof(decimal));

            foreach (var result in results)
            {
                DataRow row = table_Statistika.NewRow();
                row[0] = result.Name;
                var prumerCas = MyMathLib.GetAverage(result.Properties.Select(r => r.time.TotalMilliseconds));
                row[1] = prumerCas;
                var prumerSize = MyMathLib.GetAverage(result.Properties.Select(r => Convert.ToDouble(r.size)));
                row[2] = prumerSize;
                row[3] = MyMathLib.GetMedian(result.Properties.Select(r => r.time.TotalMilliseconds));
                row[4] = MyMathLib.GetVariance(result.Properties.Select(r => r.time.TotalMilliseconds));
                row[5] = MyMathLib.GetStandardDeviation(result.Properties.Select(r => r.time.TotalMilliseconds));
                row[6] = MyMathLib.GetPomer1s(prumerCas, prumerSize);

                table_Statistika.Rows.Add(row);
            }

            metroGrid_Result.DataSource = table_Statistika;
            for (int i = 0; i < metroGrid_Result.Columns.Count; i++)
                metroGrid_Result.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        //Init gridview
        public void InitGridView_ToolsVysledky_MeziVysledky(Tools_Vysledky _Vysledky)
        {


            //seskupení a seřazení
            var results = _Vysledky.GetListZaznamy().GroupBy(p => p.name,
           (key, g) => new { Name = key, Properties = g.ToList() }).OrderBy(s => s.Name.Substring(4));//order by XML_... || CSV_....



            //Inicializace tabulky
            table_Mezivysledky = new DataTable("MeziVysledky");
            DataColumn column_nazev = new DataColumn("Název testu");
            column_nazev.DataType = typeof(string);
            table_Mezivysledky.Columns.Add(column_nazev);

            //Založení sloupců
            for (int i = 0; i < _Vysledky.pocetTestu; i++)
            {
                DataColumn column = new DataColumn(String.Format("{0}.[ms]", i + 1));
                column.DataType = typeof(Decimal);
                table_Mezivysledky.Columns.Add(column);
                DataColumn column2 = new DataColumn(String.Format("{0}.Počet[znaky/bajty]", i + 1));
                column2.DataType = typeof(int);
                table_Mezivysledky.Columns.Add(column2);
            }

            //Přidání řádků s daty
            foreach (var result in results)
            {
                DataRow row = table_Mezivysledky.NewRow();
                row[0] = result.Name;
                for (int i = 0; i < result.Properties.Count; i++)
                {
                    row[i * 2 + 1] = result.Properties[i].time.TotalMilliseconds;
                    row[i * 2 + 2] = result.Properties[i].size;
                }
                table_Mezivysledky.Rows.Add(row);


            }


            if (table_Mezivysledky.Columns.Count > 100)
            {
                var copyDt = new DataTable();
                for (var i = 0; i < 101; i++)
                {
                    copyDt.Columns.Add(table_Mezivysledky.Columns[i].ColumnName, table_Mezivysledky.Columns[i].DataType);
                }
                copyDt.BeginLoadData();
                foreach (DataRow dr in table_Mezivysledky.Rows)
                {
                    copyDt.Rows.Add(Enumerable.Range(0, 101).Select(i => dr[i]).ToArray());
                }
                copyDt.EndLoadData();


                //Propojení tabulky s gridem
                metroGrid_Result.DataSource = copyDt;
            }
            else
                metroGrid_Result.DataSource = table_Mezivysledky;


            //Autosize šířky sloupců
            for (int i = 0; i < metroGrid_Result.Columns.Count; i++)
                metroGrid_Result.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            metroGrid_Result.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

        }

        public void ExportAll()
        {
            _vysledky.ExportToCSVFile(table_Mezivysledky);
            _vysledky.ExportToCSVFile(table_Statistika);
            _vysledky.ExportToExcelFile(table_Mezivysledky);
            _vysledky.ExportToExcelFile(table_Statistika);

        }

        private void metroButton_ExportCSV_Click(object sender, EventArgs e)
        {
            if (comboBox_Vyber.SelectedIndex == 0)
                _vysledky.ExportToCSVFile(table_Mezivysledky);
            else
                _vysledky.ExportToCSVFile(table_Statistika);
            MessageBox.Show("Done");
        }



        private void metroButton_ExportXML_Click(object sender, EventArgs e)
        {
            if (comboBox_Vyber.SelectedIndex == 0)
                _vysledky.ExportToExcelFile(table_Mezivysledky);
            else
                _vysledky.ExportToExcelFile(table_Statistika);
            MessageBox.Show("Done");
        }

        private void metroGrid_Result_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.FillWeight = 1;
        }

        private void comboBox_Vyber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Vyber.SelectedIndex == 0)
                InitGridView_ToolsVysledky_MeziVysledky(this._vysledky);
            else
                InitGridView_ToolsVysledky_Statistika(this._vysledky);
        }

        private void UserControl_Result_Resize(object sender, EventArgs e)
        {

        }

        private void UserControl_Result_SizeChanged(object sender, EventArgs e)
        {
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ParentForm.VisibleComponentsForTesting(true);
        }
    }
}
