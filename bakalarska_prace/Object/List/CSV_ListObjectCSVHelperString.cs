using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ListObject
{
    class CSV_ListObjectCSVHelperString : Tools, ITester
    {
        private List<EmployeeRecord> ListObject;
        private int NumberOfElements;


        public CSV_ListObjectCSVHelperString()
        {
            this.NumberOfElements = 0;
        }

        private void Inicialize(bool Write)
        {
            ListObject = new List<EmployeeRecord>();
            if (Write)
                for (int i = 0; i < NumberOfElements; i++)
                    ListObject.Add(new EmployeeRecord(true));

        }

        public void CSV_WriteListObjectCSVHelperString()
        {
            csvWriter.WriteRecords(this.ListObject);
        }
        public void CSV_ReadListObjectCSVHelperString()
        {
            ListObject = csvReader.GetRecords<EmployeeRecord>().ToList();            
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
            CSV_WriteListObjectCSVHelperString();
        }
        void ITester.TestRead()
        {
            CSV_ReadListObjectCSVHelperString();

        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile();
        }
        void ITester.SetNumberOfElements(int NumberOfElements)
        {
            this.NumberOfElements = NumberOfElements;
        }
    }
}
