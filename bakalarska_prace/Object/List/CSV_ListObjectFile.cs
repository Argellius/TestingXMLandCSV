using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ListObject
{
    class CSV_ListObjectFile : Tools, ITester
    {
        private List<EmployeeRecord> ListObject;
        private int NumberOfElements;


        public CSV_ListObjectFile()
        {
            this.NumberOfElements = 0;
        }

        private void Inicialize(bool Write)
        {
            ListObject = new List<EmployeeRecord>();
            if (Write)
                for (int i = 0; i < NumberOfElements; i++)
                    ListObject.Add(new EmployeeRecord(true));

        }

        public void CSV_WriteListObjectFile()
        {
            base.StringBuilder.AppendLine("ID, Money, Age, Children, FirstName, FamilyName, PIN, Residence, Ready, License, Indisposed");
            foreach (EmployeeRecord employee in ListObject)
            {
                StringBuilder.Append(employee.ID);
                StringBuilder.Append(",");
                StringBuilder.Append(employee.Money);
                StringBuilder.Append(",");
                StringBuilder.Append(employee.Age);
                StringBuilder.Append(",");
                StringBuilder.Append(employee.Children);
                StringBuilder.Append(",");
                StringBuilder.Append(employee.FirstName);
                StringBuilder.Append(",");
                StringBuilder.Append(employee.FamilyName);
                StringBuilder.Append(",");
                StringBuilder.Append(employee.PIN);
                StringBuilder.Append(",");
                StringBuilder.Append(employee.Residence);
                StringBuilder.Append(",");
                StringBuilder.Append(employee.Ready);
                StringBuilder.Append(",");
                StringBuilder.Append(employee.License);
                StringBuilder.Append(",");
                StringBuilder.AppendLine(employee.Indisposed.ToString());
            }

            StreamWriter.Write(StringBuilder);
        }

        public void CSV_ReadListObjectFile()
        {
            EmployeeRecord EmployeeObj;
            //read header
            StreamReader.ReadLine();
            
            //read records
            //try catch bool, int exc
            while (StreamReader.Peek() > 0)
            {
                EmployeeObj = new EmployeeRecord(false);
                var line = StreamReader.ReadLine();
                var values = line.Split(',');
                EmployeeObj.ID = Convert.ToInt32(values[0]);
                EmployeeObj.Money = Convert.ToInt32(values[1]);
                EmployeeObj.Age = Convert.ToInt32(values[2]);
                EmployeeObj.Children = Convert.ToInt32(values[3]);
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
            base.ToolsInicializeFile(this.GetType(), true);
        }
        void ITester.SetupReadStart()
        {
            Inicialize(false);
            base.ToolsInicializeFile(this.GetType(), false);
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
