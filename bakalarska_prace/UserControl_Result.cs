using System;
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
        DataTable table;
        public UserControl_Result()
        {
            InitializeComponent();
        }

        private void UserControl_Result_Load(object sender, EventArgs e)
        {
        }

        public void Set_ToolsVysledky(Tools_Vysledky vysledky)
        {
            this._vysledky = vysledky;
        }

        public void SetNumberOfTests(int value)
        {
            for (int i = 0; i < value; i++)
            {
                ;
                //metroGrid_Result.Columns.Add(String.Format("Collumn_{0}", i + 1), String.Format("{0}.", i + 1));
            }
        }

        public static decimal GetMedian(IEnumerable<decimal> source)
        {
            // Create a copy of the input, and sort the copy
            decimal[] temp = source.ToArray();
            Array.Sort(temp);

            int count = temp.Length;
            if (count == 0)
            {
                throw new InvalidOperationException("Empty collection");
            }
            else if (count % 2 == 0)
            {
                // count is even, average two middle elements
                int a = temp[count / 2 - 1];
                int b = temp[count / 2];
                return (a + b) / 2m;
            }
            else
            {
                // count is odd, return the middle element
                return temp[count / 2];
            }
        }

        public void InitGridView_ToolsVysledky_Statistika(Tools_Vysledky _Vysledky)
        {
            var results = _Vysledky.GetListZaznamy().GroupBy(p => p.name,
           (key, g) => new { Name = key, Properties = g.ToList() }).OrderBy(s => s.Name.Substring(4));//order by XML_... || CSV_....

            DataTable table = new DataTable("TestingCSVXMLStatistika");
            DataColumn column_nazev = new DataColumn("Název testu");
            column_nazev.DataType = typeof(string);
            table.Columns.Add(column_nazev);
            //Založení sloupců
            DataColumn column_prumer = new DataColumn("Průměr");
            column_nazev.DataType = typeof(string);
            table.Columns.Add(column_prumer);

            DataColumn column_median = new DataColumn("Median");
            column_nazev.DataType = typeof(string);
            table.Columns.Add(column_median);


            foreach (var result in results)
            {
                DataRow row = table.NewRow();
                row[0] = result.Name;
                row[1] = result.Properties.Select(r => r.time.TotalMilliseconds).Average();
                row[2] = GetMedian(result.Properties.Select(r => r.time.TotalMilliseconds));
                table.Rows.Add(row);

            }

            metroGrid_Result.DataSource = table;

        }

        //Init gridview
        public void InitGridView_ToolsVysledky_MeziVysledky(Tools_Vysledky _Vysledky)
        {


            //seskupení a seřazení
            var results = _Vysledky.GetListZaznamy().GroupBy(p => p.name,
           (key, g) => new { Name = key, Properties = g.ToList() }).OrderBy(s => s.Name.Substring(4));//order by XML_... || CSV_....



            //Inicializace tabulky
            table = new DataTable("TestingCSVXML");
            DataColumn column_nazev = new DataColumn("Název testu");
            column_nazev.DataType = typeof(string);
            table.Columns.Add(column_nazev);

            //Založení sloupců
            for (int i = 0; i < _Vysledky.pocetTestu; i++)
            {
                DataColumn column = new DataColumn(String.Format("{0}.", i + 1));
                column.DataType = typeof(Decimal);
                table.Columns.Add(column);
                DataColumn column2 = new DataColumn(String.Format("Size_{0}.", i + 1));
                column2.DataType = typeof(int);
                table.Columns.Add(column2);
            }

            //Přidání řádků s daty
            foreach (var result in results)
            {
                DataRow row = table.NewRow();
                row[0] = result.Name;
                for (int i = 0; i < result.Properties.Count; i++)
                {
                    row[i * 2 + 1] = result.Properties[i].time.TotalMilliseconds;
                    row[i * 2 + 2] = result.Properties[i].size;
                }
                table.Rows.Add(row);

            }


            if (table.Columns.Count > 100)
            {
                var copyDt = new DataTable();
                for (var i = 0; i < 101; i++)
                {
                    copyDt.Columns.Add(table.Columns[i].ColumnName, table.Columns[i].DataType);
                }
                copyDt.BeginLoadData();
                foreach (DataRow dr in table.Rows)
                {
                    copyDt.Rows.Add(Enumerable.Range(0, 101).Select(i => dr[i]).ToArray());
                }
                copyDt.EndLoadData();


                //Propojení tabulky s gridem
                metroGrid_Result.DataSource = copyDt;
            }
            else
                metroGrid_Result.DataSource = table;


            //Autosize šířky sloupců
            for (int i = 0; i < metroGrid_Result.Columns.Count; i++)
                metroGrid_Result.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {




        }

        private void metroButton_ExportCSV_Click(object sender, EventArgs e)
        {
            _vysledky.ExportToCSVFile();
            MessageBox.Show("Done");
        }

        private void metroButton_ExportXML_Click(object sender, EventArgs e)
        {
            _vysledky.ExportToExcelFile(table);
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
    }
}
