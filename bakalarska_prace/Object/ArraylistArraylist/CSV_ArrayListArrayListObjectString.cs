using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayListArrayListObject
{
    class CSV_ArrayListArrayListObjectString : Tools, ITester
    {
        private ArrayList ArrayListArrayListObject;
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;


        public CSV_ArrayListArrayListObjectString()
        {
            this.NumberOfCollections = 0;
            this.ElementsInCollection = 0;
            this.ElementsInLastCollection = 0;
        }

        private void Inicialize(bool Write)
        {
            ArrayListArrayListObject = new ArrayList();

            if (Write)
            {
                ArrayList ArrayListIntreger = new ArrayList();

                for (int i = 0; i < ElementsInCollection; i++)
                    ArrayListIntreger.Add(new EmployeeRecord(true));

                for (int i = 0; i < NumberOfCollections; i++)
                    ArrayListArrayListObject.Add(new ArrayList(ArrayListIntreger));

                ArrayListIntreger.Clear();

                if (ElementsInLastCollection > 0)
                {
                    for (int i = 0; i < ElementsInLastCollection; i++)
                        ArrayListIntreger.Add(new EmployeeRecord(true));
                    ArrayListArrayListObject.Add(new ArrayList(ArrayListIntreger));
                }

            }
        }

        public void CSV_WriteArrayListArrayListObjectString()
        {
            StringBuilder.AppendLine("ID, Money, Age, Children, FirstName, FamilyName, PIN, Residence, Ready, License, Indisposed");
            foreach (ArrayList list in ArrayListArrayListObject)
            {
                foreach (EmployeeRecord it in list)
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
            StringWriter.Write(StringBuilder);
        }

        public void CSV_ReadArrayListArrayListObjectString()
        {
            ArrayList List_Obj = new ArrayList();
            //read header
            var line = StringReader.ReadLine();

            while (StringReader.Peek() > 0)
            {
                String[] values = null;
                EmployeeRecord Zamestnanec = new EmployeeRecord(false);
                line = StringReader.ReadLine();
                if (line == String.Empty)
                {
                    ArrayListArrayListObject.Add(new ArrayList(List_Obj));
                    List_Obj.Clear();
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
            CSV_WriteArrayListArrayListObjectString();
        }
        void ITester.TestRead()
        {
            CSV_ReadArrayListArrayListObjectString();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile();
        }

        void ITester.SetNumberOfElements(int NumberOfElements)
        {
            this.NumberOfCollections = (int)Math.Sqrt(NumberOfElements);
            this.ElementsInCollection = NumberOfElements / NumberOfCollections;
            this.ElementsInLastCollection = NumberOfElements % NumberOfCollections;
        }
    }
}
