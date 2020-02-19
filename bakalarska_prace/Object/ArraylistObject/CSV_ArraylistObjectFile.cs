﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayListObject
{
    class CSV_ArrayListObjectFile : Tools, ITester
    {
        private ArrayList ArrayListObject;
        private int NumberOfElements;

        public CSV_ArrayListObjectFile(int Number)
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

        public void CSV_WriteArrayListObjectFile()
        {
            StringBuilder.AppendLine("ID, vyplata, pocet_let, pocet_deti, Jmeno, Prijmeni, Rodne_cislo, Bydliste, uzpusobily, ridicak, kurak");
            for (int o = 0; o < ArrayListObject.Count; o++)
            {
                StringBuilder.Append((ArrayListObject[o] as RecordOfEmployee).ID);
                StringBuilder.Append(",");
                StringBuilder.Append((ArrayListObject[o] as RecordOfEmployee).Money);
                StringBuilder.Append(",");
                StringBuilder.Append((ArrayListObject[o] as RecordOfEmployee).Age);
                StringBuilder.Append(",");
                StringBuilder.Append((ArrayListObject[o] as RecordOfEmployee).Children);
                StringBuilder.Append(",");
                StringBuilder.Append((ArrayListObject[o] as RecordOfEmployee).FirstName);
                StringBuilder.Append(",");
                StringBuilder.Append((ArrayListObject[o] as RecordOfEmployee).FamilyName);
                StringBuilder.Append(",");
                StringBuilder.Append((ArrayListObject[o] as RecordOfEmployee).PIN);
                StringBuilder.Append(",");
                StringBuilder.Append((ArrayListObject[o] as RecordOfEmployee).Residence);
                StringBuilder.Append(",");
                StringBuilder.Append((ArrayListObject[o] as RecordOfEmployee).Ready);
                StringBuilder.Append(",");
                StringBuilder.Append((ArrayListObject[o] as RecordOfEmployee).License);
                StringBuilder.Append(",");
                StringBuilder.AppendLine((ArrayListObject[o] as RecordOfEmployee).Indisposed.ToString());
            }

            StreamWriter.Write(StringBuilder);

        }
        public void CSV_ReadArrayListObjectFile()
        {
            RecordOfEmployee Employee;
            //read header
            StreamReader.ReadLine();

            //read records
            //try catch bool, int exc
            while (StreamReader.Peek() > 0)
            {
                Employee = new RecordOfEmployee(false);
                var line = StreamReader.ReadLine();
                var values = line.Split(',');
                Employee.ID = Convert.ToInt64(values[0]);
                Employee.Money = Convert.ToInt64(values[1]);
                Employee.Age = Convert.ToInt64(values[2]);
                Employee.Children = Convert.ToInt64(values[3]);
                Employee.FirstName = values[4];
                Employee.FamilyName = values[5];
                Employee.PIN = values[6];
                Employee.Residence = values[7];
                Employee.Ready = bool.Parse(values[8]);
                Employee.License = bool.Parse(values[9]);
                Employee.Indisposed = bool.Parse(values[10]);
                ArrayListObject.Add(Employee);

            }
        }


        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            base.ToolsInicializeStream(this.GetType(), true);
        }
        void ITester.SetupReadStart()
        {
            Inicialize(false);
            base.ToolsInicializeStream(this.GetType(), false);
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
            CSV_WriteArrayListObjectFile();
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