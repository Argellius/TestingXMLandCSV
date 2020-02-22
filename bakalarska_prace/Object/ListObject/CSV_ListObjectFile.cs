using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ListObject
{
    class CSV_ListObjectFile : Tools, ITester
    {
        private List<RecordOfEmployee> ListObject;
        private int NumberOfElements;


        public CSV_ListObjectFile()
        {
            this.NumberOfElements = 0;
        }

        private void Inicialize(bool Write)
        {
            ListObject = new List<RecordOfEmployee>();
            if (Write)
                for (int i = 0; i < NumberOfElements; i++)
                    ListObject.Add(new RecordOfEmployee(true));

        }

        public void CSV_WriteListObjectFile()
        {
            base.StringBuilder.AppendLine("ID, Money, Age, Children, FirstName, FamilyName, PIN, Residence, Ready, License, Indisposed");
            for (int o = 0; o < ListObject.Count; o++)
            {
                StringBuilder.Append(ListObject[o].ID);
                StringBuilder.Append(",");
                StringBuilder.Append(ListObject[o].Money);
                StringBuilder.Append(",");
                StringBuilder.Append(ListObject[o].Age);
                StringBuilder.Append(",");
                StringBuilder.Append(ListObject[o].Children);
                StringBuilder.Append(",");
                StringBuilder.Append(ListObject[o].FirstName);
                StringBuilder.Append(",");
                StringBuilder.Append(ListObject[o].FamilyName);
                StringBuilder.Append(",");
                StringBuilder.Append(ListObject[o].PIN);
                StringBuilder.Append(",");
                StringBuilder.Append(ListObject[o].Residence);
                StringBuilder.Append(",");
                StringBuilder.Append(ListObject[o].Ready);
                StringBuilder.Append(",");
                StringBuilder.Append(ListObject[o].License);
                StringBuilder.Append(",");
                StringBuilder.AppendLine(ListObject[o].Indisposed.ToString());
            }

            StreamWriter.Write(StringBuilder);

        }
        public void CSV_ReadListObjectFile()
        {
            RecordOfEmployee EmployeeObj;
            //read header
            StreamReader.ReadLine();
            
            //read records
            //try catch bool, int exc
            while (StreamReader.Peek() > 0)
            {
                EmployeeObj = new RecordOfEmployee(false);
                var line = StreamReader.ReadLine();
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
                ListObject.Add(EmployeeObj);

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
            CSV_WriteListObjectFile();
        }
        void ITester.TestRead()
        {
            CSV_ReadListObjectFile();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile(this.GetType());
        }

        void ITester.SetNumberOfElements(int NumberOfElements)
        {
            this.NumberOfElements = NumberOfElements;
        }
    }
}
