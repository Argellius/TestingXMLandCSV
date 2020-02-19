using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayListObject
{
    class CSV_ArrayListObjectString : Tools, ITester
    {
        private ArrayList ArrayListObject;
        private int NumberOfElements;

        public CSV_ArrayListObjectString(int Number)
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
        public void CSV_WriteArrayListObjectString()
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

            StringWriter.Write(StringBuilder);
        }

        public void CSV_ReadArrayListObjectString()
        {
            RecordOfEmployee Employee;
            //read header
            StringReader.ReadLine();

            //read records
            //try catch bool, int exc
            while (StringReader.Peek() > 0)
            {
                Employee = new RecordOfEmployee(false);
                var line = StringReader.ReadLine();
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
            CSV_WriteArrayListObjectString();
        }
        void ITester.TestRead()
        {
            CSV_ReadArrayListObjectString();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfString();
        }
    }
}
