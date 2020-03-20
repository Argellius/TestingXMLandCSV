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
    class CSV_ListListIntegerCSVHelperString : Tools, ITester
    {
        private List<List<System.Int32>> ListListInteger;
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;


        public CSV_ListListIntegerCSVHelperString()
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

        public void CSV_WriteListListIntegerCSVHelperString()
        {
            foreach(List<System.Int32> item in ListListInteger)
            {
                csvWriter.WriteField(item);
                csvWriter.NextRecord();
            }
            
        }
        public void CSV_ReadListListIntegerCSVHelperString()
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
            ListListInteger = null;
            csvWriter = null;
            csvReader = null;
        }
        void ITester.TestWrite()
        {
            CSV_WriteListListIntegerCSVHelperString();
        }
        void ITester.TestRead()
        {
            CSV_ReadListListIntegerCSVHelperString();
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
