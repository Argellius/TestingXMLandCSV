using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayObject
{
    class CSV_ArrayObjectFile : Tools, ITester
    {
        private RecordOfEmployee[] ArrayObject;
        private int NumberOfElements;

        public CSV_ArrayObjectFile(int Number)
        { 
            this.NumberOfElements = Number;
        }

        private void Inicialize(bool Write)
        {
            ArrayObject = new RecordOfEmployee[this.NumberOfElements];
            if (Write)
                for (int i = 0; i < NumberOfElements; i++)
                    ArrayObject[i] = new RecordOfEmployee(true);

        }

        public void CSV_WriteArrayObjectFile()
        {
            base.StringBuilder.AppendLine("ID, Money, Age, Children, FirstName, FamilyName, PIN, Residence, Ready, License, Indisposed");

            for (int o = 0; o < this.NumberOfElements; o++)
            {
                base.StringBuilder.Append(ArrayObject[o].ID);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].Money);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].Age);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].Children);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].FirstName);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].FamilyName);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].PIN);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].Residence);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].Ready);
                base.StringBuilder.Append(",");
                base.StringBuilder.Append(ArrayObject[o].License);
                base.StringBuilder.Append(",");
                base.StringBuilder.AppendLine(ArrayObject[o].Indisposed.ToString());
            }

            base.StreamWriter.Write(base.StringBuilder);


        }
        public void CSV_ReadArrayObjectFile()
        {
            RecordOfEmployee EmployeeObj;

            //read header
            base.StreamReader.ReadLine();
            int i = 0;

            //read records
            //try catch bool, int exc

            

            while (base.StreamReader.Peek() > 0)
            {
                EmployeeObj = new RecordOfEmployee(false);
                var line = base.StreamReader.ReadLine();
                var values = line.Split(',');
                EmployeeObj.ID = Convert.ToInt64(values[0]);
                EmployeeObj.Money = Convert.ToInt64(values[1]);
                EmployeeObj.Age = Convert.ToInt64(values[2]);
                EmployeeObj.Children = Convert.ToInt64(values[3]);
                EmployeeObj.FirstName = values[4];
                EmployeeObj.FamilyName = values[5];
                EmployeeObj.PIN = values[6];
                EmployeeObj.Residence = values[7];
                EmployeeObj.Ready = bool.Parse(values[8]);
                EmployeeObj.License = bool.Parse(values[9]);
                EmployeeObj.Indisposed = bool.Parse(values[10]);
                ArrayObject[i] = EmployeeObj;
                i++;
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
            CSV_WriteArrayObjectFile();
        }
        void ITester.TestRead()
        {
            CSV_ReadArrayObjectFile();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile(this.GetType());
        }
    }
}
