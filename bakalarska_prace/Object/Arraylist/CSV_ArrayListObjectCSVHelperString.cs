using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayListObject
{
    class CSV_ArrayListObjectCSVHelperString : Tools, ITester
    {
        private ArrayList ArrayListObject;
        private int NumberOfElements;


        public CSV_ArrayListObjectCSVHelperString()
        {
            this.NumberOfElements = 0;
        }

        private void Inicialize(bool Write)
        {
            ArrayListObject = new ArrayList();

            if (Write)
                for (int i = 0; i < NumberOfElements; i++)
                    ArrayListObject.Add(new EmployeeRecord(true));
        }

        public void CSV_WriteArrayListObjectCSVHelperString()
        {
            csvWriter.WriteRecords(this.ArrayListObject);
        }
        public void CSV_ReadArrayListObjectCSVHelperString()
        {
            ArrayListObject = new ArrayList(csvReader.GetRecords<EmployeeRecord>().ToArray());
            
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
            ArrayListObject = null;
            csvWriter = null;
            csvReader = null;
        }
        void ITester.TestWrite()
        {
            CSV_WriteArrayListObjectCSVHelperString();
        }
        void ITester.TestRead()
        {
            CSV_ReadArrayListObjectCSVHelperString();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfString();
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
