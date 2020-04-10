using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ListObject
{
    class CSV_ListObjectCSVHelperFile : Tools, ITester
    {
        private List<EmployeeRecord> ListObject;
        private int NumberOfElements;


        public CSV_ListObjectCSVHelperFile()
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

        public void CSV_WriteListObjectCSVHelperFile()
        {
            csvWriter.WriteRecords(this.ListObject);
        }
        public void CSV_ReadListObjectCSVHelperFile()
        {
            ListObject = csvReader.GetRecords<EmployeeRecord>().ToList();            
        }


        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            base.ToolsInicializeFile(this.GetType(), true);
            csvWriter = new CsvWriter(base.StreamWriter, CultureInfo.InvariantCulture);
        }
        void ITester.SetupReadStart()
        {
            Inicialize(false);
            base.ToolsInicializeFile(this.GetType(), false);
            csvReader = new CsvReader(StreamReader, CultureInfo.InvariantCulture);
        }
        void ITester.SetupWriteEnd()
        {
            base.ToolsSetupEndFile(true);
        }
        void ITester.SetupReadEnd()
        {
            base.ToolsSetupEndFile(false);
            ListObject = null;
            csvWriter = null;
            csvReader = null;
        }
        void ITester.TestWrite()
        {
            CSV_WriteListObjectCSVHelperFile();
        }
        void ITester.TestRead()
        {
            CSV_ReadListObjectCSVHelperFile();

        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile(this.GetType());
        }
        void ITester.SetNumberOfElements(int NumberOfElements)
        {
            this.NumberOfElements = NumberOfElements;
        }
        void ITester.SetPath(string path)
        {
            base.SetPath(path);
        }
    }
}
