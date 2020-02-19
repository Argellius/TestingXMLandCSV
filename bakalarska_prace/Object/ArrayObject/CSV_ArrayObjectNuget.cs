using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayObject
{
    class CSV_ArrayObjectNuget : Tools, ITester
    {
        private RecordOfEmployee[] ArrayObject;
        private int NumberOfElements;


        public CSV_ArrayObjectNuget(int Number)
        {
            this.NumberOfElements = Number;
        }

        private void Inicialize(bool Write)
        {
            ArrayObject = new RecordOfEmployee[this.NumberOfElements];
            if (Write)
                for (int i = 0; i < NumberOfElements; i++)
                    ArrayObject[i] = new RecordOfEmployee(true);

        }

        public void CSV_WriteArrayObjectNuget()
        {
            csvWriter.WriteRecords(this.ArrayObject);
        }
        public void CSV_ReadArrayObjectFile()
        {
            csvReader.Read();
            ArrayObject = csvReader.GetRecords<RecordOfEmployee>().ToArray();            
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
            CSV_WriteArrayObjectNuget();
        }
        void ITester.TestRead()
        {
            CSV_ReadArrayObjectFile();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile(this.GetType());
        }
    }
}
