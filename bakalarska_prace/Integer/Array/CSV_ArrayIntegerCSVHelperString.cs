using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayInteger
{
    class CSV_ArrayIntegerCSVHelperString : Tools, ITester
    {
        private Int32[] ArrayInteger;
        private int NumberOfElements;


        public CSV_ArrayIntegerCSVHelperString()
        {
            this.NumberOfElements = 0;
        }

        private void Inicialize(bool write)
        {
            ArrayInteger = new Int32[this.NumberOfElements];
            if (write)
                for (int i = 0; i < NumberOfElements; i++)
                    ArrayInteger[i] = int.MaxValue;
        }

        public void CSV_WriteArrayIntegerCSVHelperString()
        {
            csvWriter.WriteRecords(this.ArrayInteger);
        }
        public void CSV_ReadArrayIntegerCSVHelperString()
        {
            ArrayInteger = csvReader.GetRecords<System.Int32>().ToArray();            
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
            csvReader = new CsvReader(base.StringReader, CultureInfo.InvariantCulture);
            csvReader.Configuration.HasHeaderRecord = false;
        }
        void ITester.SetupWriteEnd()
        {
            base.ToolsSetupEndString(true);
        }
        void ITester.SetupReadEnd()
        {
            base.ToolsSetupEndString(false);
            ArrayInteger = null;
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
