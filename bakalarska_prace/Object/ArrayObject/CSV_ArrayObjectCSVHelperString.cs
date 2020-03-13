using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayObject
{
    class CSV_ArrayObjectCSVHelperString : Tools, ITester
    {
        private EmployeeRecord[] ArrayObject;
        private int NumberOfElements;


        public CSV_ArrayObjectCSVHelperString()
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

        public void CSV_WriteArrayObjectCSVHelperString()
        {
            csvWriter.WriteRecords(this.ArrayObject);
        }
        public void CSV_ReadArrayObjectCSVHelperString()
        {
            csvReader.Read();
            ArrayObject = csvReader.GetRecords<EmployeeRecord>().ToArray();            
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
            csvReader.Configuration.HasHeaderRecord = false;
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
            CSV_WriteArrayObjectCSVHelperString();
        }
        void ITester.TestRead()
        {
            CSV_ReadArrayObjectCSVHelperString();
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
