using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ListInteger
{
    class CSV_ListIntegerCSVHelperString : Tools, ITester
    {
        private List<System.Int32> ListInteger;
        private int NumberOfElements;


        public CSV_ListIntegerCSVHelperString()
        {
            this.NumberOfElements = 0;
        }

        private void Inicialize(bool Write)
        {
            ListInteger = new List<Int32>();
            if (Write)
                for (int i = 0; i < NumberOfElements; i++)
                    ListInteger.Add(int.MaxValue);

        }

        public void CSV_WriteListIntegerCSVHelperString()
        {
            csvWriter.WriteField("Integer");
            csvWriter.NextRecord();
            csvWriter.WriteRecords(this.ListInteger);
        }


        public void CSV_ReadListIntegerCSVHelperString()
        {
            ListInteger = csvReader.GetRecords<Int32>().ToList();            
        }


        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            base.ToolsInicializeString(true);
            csvWriter = new CsvWriter(base.StringWriter, CultureInfo.InvariantCulture);
        }
        void ITester.SetupReadStart()
        {
            Inicialize(false);
            base.ToolsInicializeString(false, StringData);
            csvReader = new CsvReader(StringReader, CultureInfo.InvariantCulture);
        }
        void ITester.SetupWriteEnd()
        {
            base.ToolsSetupEndString(true);
        }
        void ITester.SetupReadEnd()
        {
            base.ToolsSetupEndString(false);
        }
        void ITester.TestWrite()
        {
            CSV_WriteListIntegerCSVHelperString();
        }
        void ITester.TestRead()
        {
            CSV_ReadListIntegerCSVHelperString();

        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfString();
        }

        void ITester.SetNumberOfElements(int NumberOfElements)
        {
            this.NumberOfElements = NumberOfElements;
        }
    }
}
