﻿using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ListObject
{
    class CSV_ListObjectNuget : Tools, ITester
    {
        private List<RecordOfEmployee> ListObject;
        private int NumberOfElements;


        public CSV_ListObjectNuget(int Number)
        {
            this.NumberOfElements = Number;
        }

        private void Inicialize(bool Write)
        {
            ListObject = new List<RecordOfEmployee>();
            if (Write)
                for (int i = 0; i < NumberOfElements; i++)
                    ListObject.Add(new RecordOfEmployee(true));

        }

        public void CSV_WriteListObjectNuget()
        {
            csvWriter.WriteRecords(this.ListObject);
        }
        public void CSV_ReadListObjectFile()
        {
            ListObject = csvReader.GetRecords<RecordOfEmployee>().ToList();
            
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
            CSV_WriteListObjectNuget();
        }
        void ITester.TestRead()
        {
            CSV_ReadListObjectFile();

        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile(this.GetType());
        }
    }
}