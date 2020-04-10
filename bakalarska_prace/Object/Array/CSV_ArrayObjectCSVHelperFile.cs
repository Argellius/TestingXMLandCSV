using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayObject
{
    class CSV_ArrayObjectCSVHelperFile : Tools, ITester
    {
        private EmployeeRecord[] ArrayObject;
        private int NumberOfElements;


        public CSV_ArrayObjectCSVHelperFile()
        {
            this.NumberOfElements = 0;
        }

        private void Inicialize(bool Write)
        {
            ArrayObject = new EmployeeRecord[this.NumberOfElements];
            if (Write)
                for (int i = 0; i < NumberOfElements; i++)
                    ArrayObject[i] = new EmployeeRecord(true);

        }

        public void CSV_WriteArrayObjectCSVHelperFile()
        {
            csvWriter.WriteRecords(this.ArrayObject);
        }
        public void CSV_ReadArrayObjectCSVHelperFile()
        {
            csvReader.Read();
            ArrayObject = csvReader.GetRecords<EmployeeRecord>().ToArray();            
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
            csvReader.Configuration.HasHeaderRecord = false;
        }
        void ITester.SetupWriteEnd()
        {
            base.ToolsSetupEndFile(true);
        }
        void ITester.SetupReadEnd()
        {
            base.ToolsSetupEndFile(false);
            ArrayObject = null;
            csvWriter = null;
            csvReader = null;
        }
        void ITester.TestWrite()
        {
            CSV_WriteArrayObjectCSVHelperFile();
        }
        void ITester.TestRead()
        {
            CSV_ReadArrayObjectCSVHelperFile();
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
