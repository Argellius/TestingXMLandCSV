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
    class CSV_ArrayListObjectNuget : Tools, ITester
    {
        private ArrayList ArrayListObject;
        private int NumberOfElements;


        public CSV_ArrayListObjectNuget(int Number)
        {
            this.NumberOfElements = Number;
        }

        private void Inicialize(bool Write)
        {
            ArrayListObject = new ArrayList();

            if (Write)
                for (int i = 0; i < NumberOfElements; i++)
                    ArrayListObject.Add(new RecordOfEmployee(true));
        }

        public void CSV_WriteArrayListObjectNuget()
        {
            csvWriter.WriteRecords(this.ArrayListObject);
        }
        public void CSV_ReadArrayListObjectFile()
        {
            ArrayListObject = new ArrayList(csvReader.GetRecords<RecordOfEmployee>().ToArray());
            
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
            CSV_WriteArrayListObjectNuget();
        }
        void ITester.TestRead()
        {
            CSV_ReadArrayListObjectFile();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile(this.GetType());
        }
    }
}
