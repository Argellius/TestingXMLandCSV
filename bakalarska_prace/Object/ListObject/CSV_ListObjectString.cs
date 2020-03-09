using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ListObject
{
    class CSV_ListObjectString : Tools, ITester
    {
        private List<EmployeeRecord> ListObject;
        private int NumberOfElements;


        public CSV_ListObjectString()
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

        public void CSV_WriteListObjectString()
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

            StringWriter.Write(StringBuilder);
        }
        public void CSV_ReadListObjectString()
        {
            EmployeeRecord EmployeeObj;
            //read header
            StringReader.ReadLine();

            //read records
            //try catch bool, int exc
            while (StringReader.Peek() > 0)
            {
                EmployeeObj = new EmployeeRecord(false);
                var line = StringReader.ReadLine();
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
            base.ToolsInicializeString(true);
        }
        void ITester.SetupReadStart()
        {
            Inicialize(false);
            base.ToolsInicializeString(false, base.StringData);
        }
        void ITester.SetupWriteEnd()
        {
            base.ToolsSetupEndString(true);
        }
        void ITester.SetupReadEnd()
        {
            base.ToolsSetupEndString(false);
        }
        void ITester.TestWrite()
        {
            CSV_WriteListObjectString();
        }
        void ITester.TestRead()
        {
            CSV_ReadListObjectString();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfString();
        }
        void ITester.SetNumberOfElements(int NumberOfElements)
        {
            this.NumberOfElements = NumberOfElements;
        }
    }
}
