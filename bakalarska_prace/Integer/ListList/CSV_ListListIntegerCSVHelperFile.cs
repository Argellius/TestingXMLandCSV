using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ListListInteger
{
    class CSV_ListListIntegerCSVHelperFile : Tools, ITester
    {
        private List<List<System.Int32>> ListListInteger;
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;


        public CSV_ListListIntegerCSVHelperFile()
        {
            this.NumberOfCollections = 0;
            this.ElementsInCollection = 0;
            this.ElementsInLastCollection = 0;
        }

        private void Inicialize(bool Write)
        {
            ListListInteger = new List<List<System.Int32>>();

            if (Write)
            {
                List<int> ListInteger = new List<int>();
                for (int i = 0; i < ElementsInCollection; i++)
                    ListInteger.Add(System.Int32.MaxValue);

                for (int i = 0; i < NumberOfCollections; i++)
                    ListListInteger.Add(new List<int>(ListInteger));
                ListInteger.Clear();
                if (ElementsInLastCollection > 0)
                {
                    for (int i = 0; i < ElementsInLastCollection; i++)
                        ListInteger.Add(Int32.MaxValue);
                    ListListInteger.Add(new List<int>(ListInteger));
                }

            }
        }

        public void CSV_WriteListListIntegerCSVHelperFile()
        {
            foreach(List<System.Int32> item in ListListInteger)
            {
                csvWriter.WriteField(item);
                csvWriter.NextRecord();
            }
            
        }
        public void CSV_ReadListListIntegerCSVHelperFile()
        {
            List<int> result = new List<int>();
            int recordValue;
            while (csvReader.Read())
            {
                for (var i = 0; csvReader.TryGetField(i, out recordValue); i++)
                {
                    result.Add(recordValue);                    
                }
                ListListInteger.Add(new List<int>(result));
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
            ListListInteger = null;
            csvWriter = null;
            csvReader = null;
        }
        void ITester.TestWrite()
        {
            CSV_WriteListListIntegerCSVHelperFile();
        }
        void ITester.TestRead()
        {
            CSV_ReadListListIntegerCSVHelperFile();
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
    }
}
