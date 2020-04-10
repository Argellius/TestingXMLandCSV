using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayArrayInteger
{
    class CSV_ArrayArrayIntegerCSVHelperString : Tools, ITester
    {
        private System.Int32[][] ArrayArrayInteger;
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;

        public CSV_ArrayArrayIntegerCSVHelperString()
        {
            NumberOfCollections = 0;
            ElementsInCollection = 0;
            ElementsInLastCollection = 0;
        }
        private void Inicialize(bool Write)
        {
            if (ElementsInLastCollection > 0)
            {
                ArrayArrayInteger = new Int32[this.NumberOfCollections + 1][];

                for (int i = 0; i < NumberOfCollections; i++)
                    ArrayArrayInteger[i] = new int[ElementsInCollection];
                ArrayArrayInteger[NumberOfCollections] = new int[ElementsInLastCollection];
            }
            else
            {
                ArrayArrayInteger = new Int32[this.NumberOfCollections][];

                for (int i = 0; i < NumberOfCollections; i++)
                    ArrayArrayInteger[i] = new int[ElementsInCollection];
            }

            if (Write)
            {
                for (int j = 0; j < NumberOfCollections; j++)
                    for (int i = 0; i < ElementsInCollection; i++)
                        ArrayArrayInteger[j][i] = int.MaxValue;
                if (ElementsInLastCollection > 0)
                {
                    for (int j = 0; j < ElementsInLastCollection; j++)
                        ArrayArrayInteger[NumberOfCollections][j] = int.MaxValue;
                }

            }
        }

        public void CSV_WriteArrayArrayIntegerCSVHelperString()
        {
            foreach (Int32[] array in ArrayArrayInteger)
            {
                csvWriter.WriteRecords(array);
                csvWriter.NextRecord();
            }
        }

        public void CSV_ReadArrayArrayIntegerCSVHelperString()
        {
            int index_pole = 0;
            int i = 0;

            while (csvReader.Read())
            {
                if (csvReader.Context.Record.Count() == 0) //------
                {
                    index_pole++;
                    i = 0;
                    continue;
                }
                ArrayArrayInteger[index_pole][i] = csvReader.GetRecord<Int32>();
                i++;
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
            base.ToolsInicializeString(false, base.StringData);
            csvReader = new CsvReader(base.StringReader, CultureInfo.InvariantCulture);
            csvReader.Configuration.IgnoreBlankLines = false;
            csvReader.Configuration.HasHeaderRecord = false;
        }
        void ITester.SetupWriteEnd()
        {
            base.ToolsSetupEndString(true);
        }
        void ITester.SetupReadEnd()
        {
            base.ToolsSetupEndString(false);
            ArrayArrayInteger = null;
            csvWriter = null;
            csvReader = null;
        }
        void ITester.TestWrite()
        {
            CSV_WriteArrayArrayIntegerCSVHelperString();
        }
        void ITester.TestRead()
        {
            CSV_ReadArrayArrayIntegerCSVHelperString();
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

        void ITester.SetPath(string path)
        {
            base.SetPath(path);
        }
    }
}
