using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayListInteger
{
    class CSV_ArrayListIntegerCSVHelperString : Tools, ITester
    {
        private ArrayList ArrayListInteger;
        private int NumberOfElements;


        public CSV_ArrayListIntegerCSVHelperString()
        {
            this.NumberOfElements = 0;
        }

        private void Inicialize(bool write)
        {
            ArrayListInteger = new ArrayList();

            if (write)
                for (int i = 0; i < NumberOfElements; i++)
                    ArrayListInteger.Add(int.MaxValue);
        }

        public void CSV_WriteArrayIntegerCSVHelperString()
        {
            csvWriter.WriteRecords(this.ArrayListInteger);
        }
        public void CSV_ReadArrayIntegerCSVHelperString()
        {
            ArrayListInteger = new ArrayList(csvReader.GetRecords<Int32>().ToArray());
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
            ArrayListInteger = null;
            csvWriter = null;
            csvReader = null;
        }
        void ITester.TestWrite()
        {
            CSV_WriteArrayIntegerCSVHelperString();
        }
        void ITester.TestRead()
        {
            CSV_ReadArrayIntegerCSVHelperString();
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
