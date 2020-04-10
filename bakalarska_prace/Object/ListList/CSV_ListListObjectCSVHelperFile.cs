using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ListListObject
{
    class CSV_ListListObjectCSVHelperFile : Tools, ITester
    {
        private List<List<EmployeeRecord>> ListListObject;
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;


        public CSV_ListListObjectCSVHelperFile()
        {
            this.NumberOfCollections = 0;
            this.ElementsInCollection = 0;
            this.ElementsInLastCollection = 0;
        }

        private void Inicialize(bool Write)
        {
            ListListObject = new List<List<EmployeeRecord>>();

            if (Write)
            {
                List<EmployeeRecord> List_Object = new List<EmployeeRecord>();
                for (int i = 0; i < ElementsInCollection; i++)
                    List_Object.Add(new EmployeeRecord(true));

                for (int i = 0; i < NumberOfCollections; i++)
                    ListListObject.Add(new List<EmployeeRecord>(List_Object));
                List_Object.Clear();
                if (ElementsInLastCollection > 0)
                {
                    for (int i = 0; i < ElementsInLastCollection; i++)
                        List_Object.Add(new EmployeeRecord(true));
                    ListListObject.Add(new List<EmployeeRecord>(List_Object));
                }
            }
        }

        public void CSV_WriteListListObjectCSVHelperFile()
        {
            foreach (List<EmployeeRecord> record in ListListObject)
            {
                csvWriter.WriteRecords(record);
                csvWriter.NextRecord();
            }
        }


        public void CSV_ReadListListObjectCSVHelperFile()
        {
            var ListObject = new List<EmployeeRecord>();
            while (csvReader.Read())
            {
                if (csvReader.Context.Record.Count() == 0) //------
                {
                    ListListObject.Add(new List<EmployeeRecord>(ListObject));
                    ListObject.Clear();
                    continue;
                }
                ListObject.Add(csvReader.GetRecord<EmployeeRecord>());
            }
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
            csvReader.Configuration.IgnoreBlankLines = false;
        }
        void ITester.SetupWriteEnd()
        {
            base.ToolsSetupEndFile(true);
        }
        void ITester.SetupReadEnd()
        {
            base.ToolsSetupEndFile(false);
            ListListObject = null;
            csvWriter = null;
            csvReader = null;
        }
        void ITester.TestWrite()
        {
            CSV_WriteListListObjectCSVHelperFile();
        }
        void ITester.TestRead()
        {
            CSV_ReadListListObjectCSVHelperFile();

        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile(this.GetType());
        }

        void ITester.SetNumberOfElements(int NumberOfElements)
        {
            this.NumberOfCollections = (int)Math.Sqrt(NumberOfElements);
            this.ElementsInCollection = NumberOfElements / NumberOfCollections;
            this.ElementsInLastCollection = NumberOfElements % NumberOfCollections;
        }
        void ITester.SetPath(string path)
        {
            base.SetPath(path);
        }
    }
}
