using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayListArrayListInteger
{
    class CSV_ArrayListArrayListIntegerCSVHelperFile : Tools, ITester
    {
        private ArrayList ArrayListArrayListInteger;
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;


        public CSV_ArrayListArrayListIntegerCSVHelperFile()
        {
            this.NumberOfCollections = 0;
            this.ElementsInCollection = 0;
            this.ElementsInLastCollection = 0;
        }

        private void Inicialize(bool Write)
        {
            ArrayListArrayListInteger = new ArrayList();

            if (Write)
            {
                ArrayList ArrayListIntreger = new ArrayList();
                for (int i = 0; i < ElementsInCollection; i++)
                    ArrayListIntreger.Add(System.Int32.MaxValue);

                for (int i = 0; i < NumberOfCollections; i++)
                    ArrayListArrayListInteger.Add(new ArrayList(ArrayListIntreger));
                ArrayListIntreger.Clear();
                if (ElementsInLastCollection > 0)
                {
                    for (int i = 0; i < ElementsInLastCollection; i++)
                        ArrayListIntreger.Add(Int32.MaxValue);
                    ArrayListArrayListInteger.Add(new ArrayList(ArrayListIntreger));
                }

            }
        }

        public void CSV_WriteArrayListArrayListIntegerCSVHelperFile()
        {
            foreach(ArrayList item in ArrayListArrayListInteger)
            {
                csvWriter.WriteRecords(item);
                csvWriter.NextRecord();
            }
            
        }
        public void CSV_ReadArrayListArrayListIntegerCSVHelperFile()
        {
            ArrayList result = new ArrayList();
            int recordValue;
            while (csvReader.Read())
            {
                for (var i = 0; csvReader.TryGetField(i, out recordValue); i++)
                {
                    result.Add(recordValue);                    
                }
                ArrayListArrayListInteger.Add(new ArrayList(result));
                result.Clear();
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
            csvReader.Configuration.HasHeaderRecord = false;
        }
        void ITester.SetupWriteEnd()
        {
            base.ToolsSetupEndFile(true);
        }
        void ITester.SetupReadEnd()
        {
            base.ToolsSetupEndFile(false);
            ArrayListArrayListInteger = null;
            csvWriter = null;
            csvReader = null;
        }
        void ITester.TestWrite()
        {
            CSV_WriteArrayListArrayListIntegerCSVHelperFile();
        }
        void ITester.TestRead()
        {
            CSV_ReadArrayListArrayListIntegerCSVHelperFile();
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
