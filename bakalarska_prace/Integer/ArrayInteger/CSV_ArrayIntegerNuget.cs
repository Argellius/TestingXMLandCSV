using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayInteger
{
    class CSV_ArrayIntegerNuget : Tools, ITester
    {
        private Int32[] ArrayInteger;
        private int NumberOfElements;


        public CSV_ArrayIntegerNuget(int Number)
        {
            this.NumberOfElements = Number;
        }

        private void Inicialize(bool write)
        {
            ArrayInteger = new Int32[this.NumberOfElements];
            if (write)
                for (int i = 0; i < NumberOfElements; i++)
                    ArrayInteger[i] = int.MaxValue;
        }

        public void CSV_WriteArrayIntegerNuget()
        {
            csvWriter.WriteRecords(this.ArrayInteger);
        }
        public void CSV_ReadArrayIntegerFile()
        {
            ArrayInteger = csvReader.GetRecords<System.Int32>().ToArray();            
        }


        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            base.ToolsInicializeStream(this.GetType(), true);
            csvWriter = new CsvWriter(base.StreamWriter, CultureInfo.InvariantCulture);
        }
        void ITester.SetupReadStart()
        {
            Inicialize(false);
            base.ToolsInicializeStream(this.GetType(), false);
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
        }
        void ITester.TestWrite()
        {
            CSV_WriteArrayIntegerNuget();
        }
        void ITester.TestRead()
        {
            CSV_ReadArrayIntegerFile();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile(this.GetType());
        }
    }
}
