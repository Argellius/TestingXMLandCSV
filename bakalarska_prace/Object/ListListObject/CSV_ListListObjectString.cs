using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ListListObject
{
    class CSV_ListListObjectString : Tools, ITester
    {
        private List<List<RecordOfEmployee>>ListListObject;
        private int pocetKolekci;
        private int pocetPrvkuVKolekci;
        private int pocetPrvkuVPosledniKolekci;


        public CSV_ListListObjectString(int NumberOfElements)
        {
            this.pocetKolekci = (int)Math.Sqrt(NumberOfElements);
            this.pocetPrvkuVKolekci = NumberOfElements / pocetKolekci;
            this.pocetPrvkuVPosledniKolekci = NumberOfElements % pocetKolekci;
        }

        private void Inicialize(bool Write)
        {
            ListListObject = new List<List<RecordOfEmployee>>();

            if (Write)
            {
                List<RecordOfEmployee> List_Object = new List<RecordOfEmployee>();
                for (int i = 0; i < pocetPrvkuVKolekci; i++)
                    List_Object.Add(new RecordOfEmployee(true));

                for (int i = 0; i < pocetKolekci; i++)
                    ListListObject.Add(new List<RecordOfEmployee>(List_Object));
                List_Object.Clear();
                if (pocetPrvkuVPosledniKolekci > 0)
                {
                    for (int i = 0; i < pocetPrvkuVPosledniKolekci; i++)
                        List_Object.Add(new RecordOfEmployee(true));
                    ListListObject.Add(new List<RecordOfEmployee>(List_Object));
                }
            }
        }

        public void CSV_WriteListListObjectString()
        {
            StringBuilder.AppendLine("ID, Money, Age, Children, FirstName, FamilyName, PIN, Residence, Ready, License, Indisposed");
            foreach (List<RecordOfEmployee> List_Object in ListListObject)
            {
                foreach (RecordOfEmployee it in List_Object)
                {
                    StringBuilder.Append(it.ID);
                    StringBuilder.Append(",");
                    StringBuilder.Append(it.Money);
                    StringBuilder.Append(",");
                    StringBuilder.Append(it.Age);
                    StringBuilder.Append(",");
                    StringBuilder.Append(it.Children);
                    StringBuilder.Append(",");
                    StringBuilder.Append(it.FirstName);
                    StringBuilder.Append(",");
                    StringBuilder.Append(it.FamilyName);
                    StringBuilder.Append(",");
                    StringBuilder.Append(it.PIN);
                    StringBuilder.Append(",");
                    StringBuilder.Append(it.Residence);
                    StringBuilder.Append(",");
                    StringBuilder.Append(it.Ready);
                    StringBuilder.Append(",");
                    StringBuilder.Append(it.License);
                    StringBuilder.Append(",");
                    StringBuilder.Append(it.Indisposed);
                    StringBuilder.AppendLine();
                }
                StringBuilder.AppendLine(";");

            }
        }
        public void CSV_ReadListListObjectString()
        {
            List<RecordOfEmployee> List_Obj = new List<RecordOfEmployee>();
            //read header
            var line = StringReader.ReadLine();

            while (StringReader.Peek() > 0)
            {
                String[] values = null;
                RecordOfEmployee Employee = new RecordOfEmployee(false);

                line = StringReader.ReadLine();
                if (line != ";")
                    values = line.Split(',');
                else if (line == ";")
                {
                    ListListObject.Add(List_Obj);
                    List_Obj = new List<RecordOfEmployee>();
                    continue;
                }
                else
                    return;

                Employee = new RecordOfEmployee(false);
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
                List_Obj.Add(Employee);
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
            CSV_WriteListListObjectString();
        }
        void ITester.TestRead()
        {
            CSV_ReadListListObjectString();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfString();
        }
    }
}
