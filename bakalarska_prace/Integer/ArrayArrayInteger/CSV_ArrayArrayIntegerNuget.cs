﻿using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayArrayInteger
{
    class CSV_ArrayArrayIntegerNuget : Tools, ITester
    {
        private System.Int32[][] ArrayArray_Integer;
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;

        public CSV_ArrayArrayIntegerNuget()
        {
            NumberOfCollections = 0;
            ElementsInCollection = 0;
            ElementsInLastCollection = 0;
        }
        private void Inicialize(bool Write)
        {
            if (ElementsInLastCollection > 0)
            {
                ArrayArray_Integer = new Int32[this.NumberOfCollections + 1][];

                for (int i = 0; i < NumberOfCollections; i++)
                    ArrayArray_Integer[i] = new int[ElementsInCollection];
                ArrayArray_Integer[NumberOfCollections] = new int[ElementsInLastCollection];
            }
            else
            {
                ArrayArray_Integer = new Int32[this.NumberOfCollections][];

                for (int i = 0; i < NumberOfCollections; i++)
                    ArrayArray_Integer[i] = new int[ElementsInCollection];
            }

            if (Write)
            {
                for (int j = 0; j < NumberOfCollections; j++)
                    for (int i = 0; i < ElementsInCollection; i++)
                        ArrayArray_Integer[j][i] = int.MaxValue;
                if (ElementsInLastCollection > 0)
                {
                    for (int j = 0; j < ElementsInLastCollection; j++)
                        ArrayArray_Integer[NumberOfCollections][j] = int.MaxValue;
                }

            }
        }

        public void CSV_WriteArrayArrayIntegerNuget()
        {
            foreach (Int32[] array in ArrayArray_Integer)
            {
                csvWriter.WriteRecords(array);
                csvWriter.NextRecord();
            }
        }

        public void CSV_ReadArrayArrayIntegerNuget()
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
                ArrayArray_Integer[index_pole][i] = csvReader.GetRecord<Int32>();
                i++;
            }
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
            csvReader.Configuration.IgnoreBlankLines = false;
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
            CSV_WriteArrayArrayIntegerNuget();
        }
        void ITester.TestRead()
        {
            CSV_ReadArrayArrayIntegerNuget();
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
