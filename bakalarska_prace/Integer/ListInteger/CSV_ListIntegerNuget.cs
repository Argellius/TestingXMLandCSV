using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ListInteger
{
    class CSV_ListIntegerNuget : Tools, ITester
    {
        private List<System.Int32> ListInteger;
        private int Number;


        public CSV_ListIntegerNuget(int Number)
        {
            this.Number = Number;
        }

        private void Inicialize(bool Write)
        {
            ListInteger = new List<Int32>();
            if (Write)
                for (int i = 0; i < Number; i++)
                    ListInteger.Add(int.MaxValue);

        }

        public void CSV_WriteListIntegerNuget()
        {
            csvWriter.WriteField("Integer");
            csvWriter.NextRecord();
            csvWriter.WriteRecords(this.ListInteger);
        }
        public void CSV_ReadListIntegerFile()
        {
            ListInteger = csvReader.GetRecords<Int32>().ToList();
            
        }


        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            base.ToolsInicializeStream(this.GetType(), true);
            csvWriter = new CsvWriter(base.StreamWriter, CultureInfo.InvariantCulture);
        }
        void ITester.SetupReadStart()
        {
            Inicialize(false);
            base.ToolsInicializeStream(this.GetType(), false);
            csvReader = new CsvReader(StreamReader, CultureInfo.InvariantCulture);
        }
        void ITester.SetupWriteEnd()
        {
            base.ToolsSetupEndFile(true);
        }
        void ITester.SetupReadEnd()
        {
            base.ToolsSetupEndFile(false);
        }
        void ITester.TestWrite()
        {
            CSV_WriteListIntegerNuget();
        }
        void ITester.TestRead()
        {
            CSV_ReadListIntegerFile();

        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile(this.GetType());
        }
    }
}
