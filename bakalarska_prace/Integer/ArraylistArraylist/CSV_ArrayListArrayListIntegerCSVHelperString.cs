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
    class CSV_ArrayListArrayListIntegerCSVHelperString : Tools, ITester
    {
        private ArrayList ArrayListArrayListInteger;
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;


        public CSV_ArrayListArrayListIntegerCSVHelperString()
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

        public void CSV_WriteArrayListArrayListIntegerCSVHelperString()
        {
            foreach(ArrayList item in ArrayListArrayListInteger)
            {
                csvWriter.WriteRecords(item);
                csvWriter.NextRecord();
            }
            
        }
        public void CSV_ReadArrayListArrayListIntegerCSVHelperString()
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
            ArrayListArrayListInteger = null;
            csvWriter = null;
            csvReader = null;
        }
        void ITester.TestWrite()
        {
            CSV_WriteArrayListArrayListIntegerCSVHelperString();
        }
        void ITester.TestRead()
        {
            CSV_ReadArrayListArrayListIntegerCSVHelperString();
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
