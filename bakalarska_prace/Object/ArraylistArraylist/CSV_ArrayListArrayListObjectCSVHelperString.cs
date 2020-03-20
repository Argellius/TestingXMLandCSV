using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayListArrayListObject
{
    class CSV_ArrayListArrayListObjectCSVHelperString : Tools, ITester
    {
        private ArrayList ArrayListArrayListObject;
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;


        public CSV_ArrayListArrayListObjectCSVHelperString()
        {
            this.NumberOfCollections = 0;
            this.ElementsInCollection = 0;
            this.ElementsInLastCollection = 0;
        }

        private void Inicialize(bool Write)
        {
            ArrayListArrayListObject = new ArrayList();

            if (Write)
            {
                ArrayList ArrayListIntreger = new ArrayList();

                for (int i = 0; i < ElementsInCollection; i++)
                    ArrayListIntreger.Add(new EmployeeRecord(true));

                for (int i = 0; i < NumberOfCollections; i++)
                    ArrayListArrayListObject.Add(new ArrayList(ArrayListIntreger));

                ArrayListIntreger.Clear();

                if (ElementsInLastCollection > 0)
                {
                    for (int i = 0; i < ElementsInLastCollection; i++)
                        ArrayListIntreger.Add(new EmployeeRecord(true));
                    ArrayListArrayListObject.Add(new ArrayList(ArrayListIntreger));
                }

            }
        }

        public void CSV_WriteListListObjectCSVHelperString()
        {
            foreach (ArrayList record in ArrayListArrayListObject)
            {
                csvWriter.WriteRecords(record);
                csvWriter.NextRecord();
            }
        }


        public void CSV_ReadListListObjectCSVHelperString()
        {
            ArrayList ArrayListObject = new ArrayList();
            while (csvReader.Read())
            {
                if (csvReader.Context.Record.Count() == 0) 
                {
                    ArrayListArrayListObject.Add(new ArrayList(ArrayListObject));
                    ArrayListObject.Clear();
                    continue;
                }
                ArrayListObject.Add(csvReader.GetRecord<EmployeeRecord>());
            }
            ;
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
            csvReader.Configuration.IgnoreBlankLines = false;
        }
        void ITester.SetupWriteEnd()
        {
            base.ToolsSetupEndString(true);
        }
        void ITester.SetupReadEnd()
        {
            base.ToolsSetupEndString(false);
            ArrayListArrayListObject = null;
            csvWriter = null;
            csvReader = null;
        }
        void ITester.TestWrite()
        {
            CSV_WriteListListObjectCSVHelperString();
        }
        void ITester.TestRead()
        {
            CSV_ReadListListObjectCSVHelperString();

        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfString();
        }

        void ITester.SetNumberOfElements(int NumberOfElements)
        {
            this.NumberOfCollections = (int)Math.Sqrt(NumberOfElements);
            this.ElementsInCollection = NumberOfElements / NumberOfCollections;
            this.ElementsInLastCollection = NumberOfElements % NumberOfCollections;
        }
    }
}
