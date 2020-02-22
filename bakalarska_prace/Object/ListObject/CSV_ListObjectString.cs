using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ListObject
{
    class CSV_ListObjectString : Tools, ITester
    {
        private List<RecordOfEmployee> ListObject;
        private int NumberOfElements;


        public CSV_ListObjectString()
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

        public void CSV_WriteListObjectString()
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

            StringWriter.Write(StringBuilder);
        }
        public void CSV_ReadListObjectString()
        {
            RecordOfEmployee EmployeeObj;
            //read header
            StringReader.ReadLine();

            //read records
            //try catch bool, int exc
            while (StringReader.Peek() > 0)
            {
                EmployeeObj = new RecordOfEmployee(false);
                var line = StringReader.ReadLine();
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
