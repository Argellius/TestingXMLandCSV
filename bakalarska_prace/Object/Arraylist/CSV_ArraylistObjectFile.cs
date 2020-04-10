using System;
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

        public CSV_ArrayListObjectFile()
        { 
            this.NumberOfElements = 0;
        }

        private void Inicialize(bool Write)
        {
            ArrayListObject = new ArrayList();

            if (Write)
                for (int i = 0; i < NumberOfElements; i++)
                    ArrayListObject.Add(new EmployeeRecord(true));
        }

        public void CSV_WriteArrayListObjectFile()
        {
            StringBuilder.AppendLine("ID, vyplata, pocet_let, pocet_deti, Jmeno, Prijmeni, Rodne_cislo, Bydliste, uzpusobily, ridicak, kurak");
            for (int o = 0; o < ArrayListObject.Count; o++)
            {
                StringBuilder.Append((ArrayListObject[o] as EmployeeRecord).ID);
                StringBuilder.Append(",");
                StringBuilder.Append((ArrayListObject[o] as EmployeeRecord).Money);
                StringBuilder.Append(",");
                StringBuilder.Append((ArrayListObject[o] as EmployeeRecord).Age);
                StringBuilder.Append(",");
                StringBuilder.Append((ArrayListObject[o] as EmployeeRecord).Children);
                StringBuilder.Append(",");
                StringBuilder.Append((ArrayListObject[o] as EmployeeRecord).FirstName);
                StringBuilder.Append(",");
                StringBuilder.Append((ArrayListObject[o] as EmployeeRecord).FamilyName);
                StringBuilder.Append(",");
                StringBuilder.Append((ArrayListObject[o] as EmployeeRecord).PIN);
                StringBuilder.Append(",");
                StringBuilder.Append((ArrayListObject[o] as EmployeeRecord).Residence);
                StringBuilder.Append(",");
                StringBuilder.Append((ArrayListObject[o] as EmployeeRecord).Ready);
                StringBuilder.Append(",");
                StringBuilder.Append((ArrayListObject[o] as EmployeeRecord).License);
                StringBuilder.Append(",");
                StringBuilder.AppendLine((ArrayListObject[o] as EmployeeRecord).Indisposed.ToString());
            }

            StreamWriter.Write(StringBuilder);

        }
        public void CSV_ReadArrayListObjectFile()
        {
            EmployeeRecord Employee;
            //read header
            StreamReader.ReadLine();

            //read records
            //try catch bool, int exc
            while (StreamReader.Peek() > 0)
            {
                Employee = new EmployeeRecord(false);
                var line = StreamReader.ReadLine();
                var values = line.Split(',');
                Employee.ID = Convert.ToInt32(values[0]);
                Employee.Money = Convert.ToInt32(values[1]);
                Employee.Age = Convert.ToInt32(values[2]);
                Employee.Children = Convert.ToInt32(values[3]);
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
            ArrayListObject = null;

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
        void ITester.SetNumberOfElements(int NumberOfElements)
        {
            this.NumberOfElements = NumberOfElements;
        }
        void ITester.SetPath(string path)
        {
            base.SetPath(path);
        }
    }
}
