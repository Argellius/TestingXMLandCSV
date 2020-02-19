﻿using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayListInteger
{
    class CSV_ArrayListIntegerNuget : Tools, ITester
    {
        private ArrayList ArrayListInteger;
        private int NumberOfElements;


        public CSV_ArrayListIntegerNuget(int Number)
        {
            this.NumberOfElements = Number;
        }

        private void Inicialize(bool write)
        {
            ArrayListInteger = new ArrayList();

            if (write)
                for (int i = 0; i < NumberOfElements; i++)
                    ArrayListInteger.Add(int.MaxValue);
        }

        public void CSV_WriteArrayIntegerNuget()
        {
            csvWriter.WriteRecords(this.ArrayListInteger);
        }
        public void CSV_ReadArrayIntegerFile()
        {
            ArrayListInteger = new ArrayList(csvReader.GetRecords<Int32>().ToArray());
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