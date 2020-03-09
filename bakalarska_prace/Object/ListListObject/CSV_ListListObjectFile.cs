using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ListListObject
{
    class CSV_ListListObjectFile : Tools, ITester
    {
        private List<List<EmployeeRecord>> ListListObject;
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;


        public CSV_ListListObjectFile()
        {
            this.NumberOfCollections = 0;
            this.ElementsInCollection = 0;
            this.ElementsInLastCollection = 0;
        }

        private void Inicialize(bool Write)
        {

            ListListObject = new List<List<EmployeeRecord>>();

            if (Write)
            {
                List<EmployeeRecord> List_Object = new List<EmployeeRecord>();
                for (int i = 0; i < ElementsInCollection; i++)
                    List_Object.Add(new EmployeeRecord(true));

                for (int i = 0; i < NumberOfCollections; i++)
                    ListListObject.Add(new List<EmployeeRecord>(List_Object));
                List_Object.Clear();
                if (ElementsInLastCollection > 0)
                {
                    for (int i = 0; i < ElementsInLastCollection; i++)
                        List_Object.Add(new EmployeeRecord(true));
                    ListListObject.Add(new List<EmployeeRecord>(List_Object));
                }
            }
            ;
        }

        public void CSV_WriteListListObjectFile()
        {
            StringBuilder.AppendLine("ID, Money, Age, Children, FirstName, FamilyName, PIN, Residence, Ready, License, Indisposed");
            foreach (List<EmployeeRecord> List_Object in ListListObject)
            {
                foreach (EmployeeRecord it in List_Object)
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
                StringBuilder.AppendLine();
            }
            StreamWriter.Write(StringBuilder);

        }
        public void CSV_ReadListListObjectFile()
        {
            List<EmployeeRecord> List_Obj = new List<EmployeeRecord>();
            //read header
            var line = StreamReader.ReadLine();

            while (StreamReader.Peek() > 0)
            {
                String[] values = null;
                EmployeeRecord Zamestnanec = new EmployeeRecord(false);
                line = StreamReader.ReadLine();
                if (line == String.Empty)
                {
                    ListListObject.Add(List_Obj);
                    List_Obj = new List<EmployeeRecord>();
                    continue;
                }
                else
                {
                    values = line.Split(',');
                }


                Zamestnanec = new EmployeeRecord(false);
                Zamestnanec.ID = Convert.ToInt32(values[0]);
                Zamestnanec.Money = Convert.ToInt32(values[1]);
                Zamestnanec.Age = Convert.ToInt32(values[2]);
                Zamestnanec.Children = Convert.ToInt32(values[3]);
                Zamestnanec.FirstName = values[4];
                Zamestnanec.FamilyName = values[5];
                Zamestnanec.PIN = values[6];
                Zamestnanec.Residence = values[7];
                Zamestnanec.Ready = bool.Parse(values[8]);
                Zamestnanec.License = bool.Parse(values[9]);
                Zamestnanec.Indisposed = bool.Parse(values[10]);
                List_Obj.Add(Zamestnanec);
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
            CSV_WriteListListObjectFile();
        }
        void ITester.TestRead()
        {
            CSV_ReadListListObjectFile();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile(this.GetType());
        }

        void ITester.SetNumberOfElements(int NumberOfElements)
        {
            this.NumberOfCollections = (int)Math.Sqrt(NumberOfElements);
            this.ElementsInCollection = NumberOfElements / NumberOfCollections;
            this.ElementsInLastCollection = NumberOfElements % NumberOfCollections;
        }
    }
}
