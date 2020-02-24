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
        DataTable tb;
        public UserControl_Result()
        {
            InitializeComponent();
        }

        private void UserControl_Result_Load(object sender, EventArgs e)
        {

        }

        private void Set_ToolsVysledky(Tools_Vysledky vysledky)
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

        //Init gridview
        public void InitGridView_ToolsVysledky(Tools_Vysledky _Vysledky)
        {

            this.Set_ToolsVysledky(_Vysledky);

            //seskupení
            var results = _Vysledky.GetListZaznamy().GroupBy(p => p.name,
           (key, g) => new { Name = key, Properties = g.ToList() }).OrderBy(s => s.Name.Substring(4));

            ;            

            //Inicializace tabulky
            DataTable table = new DataTable("TestingCSVXML");
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
            
            this.tb = table;

            if (tb.Columns.Count > 100)
            {
                var copyDt = new DataTable();
                for (var i = 0; i < 101; i++)
                {
                    copyDt.Columns.Add(tb.Columns[i].ColumnName, tb.Columns[i].DataType);
                }
                copyDt.BeginLoadData();
                foreach (DataRow dr in tb.Rows)
                {
                    copyDt.Rows.Add(Enumerable.Range(0, 101).Select(i => dr[i]).ToArray());
                }
                copyDt.EndLoadData();


                //Propojení tabulky s gridem
                metroGrid_Result.DataSource = copyDt;
            }
            else
                metroGrid_Result.DataSource = tb;


            //Autosize šířky sloupců
            for (int i = 0; i < metroGrid_Result.Columns.Count; i++)
                metroGrid_Result.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            /*
            foreach (var result in results)
            {
                //Create the new row first and get the index of the new row
                int rowIndex = this.metroGrid_Result.Rows.Add();

                //Obtain a reference to the newly created DataGridViewRow 
                var row = this.metroGrid_Result.Rows[rowIndex];
                row.Cells[0].Value = result.Name;
                for (int i = 1; i <= _Vysledky.pocetTestu; i++)
                    row.Cells[i].Value = result.Properties[0].time;
                metroGrid_Result.Rows.Add(row);
            }*/


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
            _vysledky.ExportToExcelFile(tb);
        }

        private void metroGrid_Result_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.FillWeight = 1;
        }
    }
}
