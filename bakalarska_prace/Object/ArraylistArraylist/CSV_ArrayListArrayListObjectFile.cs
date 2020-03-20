using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayListArrayListObject
{
    class CSV_ArrayListArrayListObjectFile : Tools, ITester
    {
        private ArrayList ArrayListArrayListObject;
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;


        public CSV_ArrayListArrayListObjectFile()
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

        public void CSV_WriteArrayListArrayListObjectFile()
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
            StreamWriter.Write(StringBuilder);
        }

        public void CSV_ReadArrayListArrayListObjectFile()
        {
            ArrayList List_Obj = new ArrayList();
            //read header
            var line = StreamReader.ReadLine();

            while (StreamReader.Peek() > 0)
            {
                String[] values = null;
                EmployeeRecord Zamestnanec = new EmployeeRecord(false);
                line = StreamReader.ReadLine();
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
            CSV_WriteArrayListArrayListObjectFile();
        }
        void ITester.TestRead()
        {
            CSV_ReadArrayListArrayListObjectFile();
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
