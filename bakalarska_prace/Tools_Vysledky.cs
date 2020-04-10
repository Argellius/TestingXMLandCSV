using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace
{
    public struct Zaznam
    {
        public string name { set; get; }
        public TimeSpan time { set; get; }
        public long size { set; get; }



        public Zaznam(string name, TimeSpan time, long size)
        {
            this.name = name;
            this.time = time;
            this.size = size;

        }

    }

    public class Tools_Vysledky
    {
        private List<Zaznam> LZaznamy;
        public int pocetPrvku { set; get; }
        public int pocetTestu { set; get; }

        public string path { private set; get; }

        private NumberFormatInfo customNumFormat;

        public Tools_Vysledky()
        {
            LZaznamy = new List<Zaznam>();
            this.pocetPrvku = 0;
            this.pocetTestu = 0;
            this.path = String.Empty;

            
            customNumFormat = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
            customNumFormat.NumberGroupSeparator = ".";
            customNumFormat.NumberDecimalSeparator = ",";
        }

        public void SetPath(string path)
        {
            this.path = path;

            var destinationDirectory = new DirectoryInfo(Path.GetDirectoryName(path));

            if (!destinationDirectory.Exists)
                destinationDirectory.Create();
        }

        public void Add(string name, TimeSpan time, long size)
        {
            LZaznamy.Add(new Zaznam(name, time, size));

        }

        public List<Zaznam> GetListZaznamy()
        {
            return LZaznamy;
        }


        public void ExportToCSVFile(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field is decimal || field is int || field is double ?  string.Format(customNumFormat, "{0:N}", field.ToString()).Replace(",",".") : field.ToString());
                sb.AppendLine(string.Join(",", fields));
            }

            File.WriteAllText(this.path + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + dt.TableName + this.pocetPrvku + ".csv", sb.ToString(),Encoding.UTF8);

        }

        public void ExportToExcelFile(DataTable dt)
        {
            //Export into excel with NuGet ClosedXML
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, dt.TableName);
                wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                wb.Style.Font.Bold = true;
                wb.SaveAs(path + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + dt.TableName + this.pocetPrvku + ".xlsx");
            }
        }

    


    public void Print()
    {
        StringBuilder printString = new StringBuilder();
        var results = LZaznamy.GroupBy(
        p => p.name,
        (key, g) => new { Name = key, Properties = g.ToList() });

        foreach (var result in results)
        {
            printString.Append(result.Name);
            foreach (var it in result.Properties)
            {
                printString.Append(";");
                printString.Append(it.time.TotalMilliseconds);
                printString.Append(";");
                printString.Append(it.size);
            }
            printString.AppendLine();

        }
        Console.WriteLine(printString);
    }

    /* public void Print()
     {

         foreach (Record it_record in List_Records)
         {
             Console.WriteLine(it_record.name);
             foreach (double it in it_record.List_Time)
             {
                 Console.WriteLine(it);
             }
         }
     }

     public void Zapis_Vysledku(int pocet_prvku, int pocet_prvku_v_kolekci, int pocet_testu)
     {

         using (var sw = new StreamWriter(@"..\..\..\Testing_Files\VysledkyTools.csv"))
         {
             StringBuilder _string = new StringBuilder();
             _string.Append("Pocet prvku:;");
             _string.Append(pocet_prvku);
             _string.Append(";");
             _string.Append("Pocet prvku v kolekci:;");
             _string.Append(pocet_prvku_v_kolekci);
             _string.Append(";");
             _string.Append("Pocet testu:;");
             _string.Append(pocet_testu);
             _string.AppendLine();
             _string.AppendLine();

             foreach (var it in List_Records)
             {

                 _string.Append(it.name);
                 _string.Append(";");
                 foreach (Double record in it.List_Time)
                     _string.Append(record.ToString() + ";");
                 _string.AppendLine();
             }
             sw.Write(_string);
         }
     }

 */
}
}
