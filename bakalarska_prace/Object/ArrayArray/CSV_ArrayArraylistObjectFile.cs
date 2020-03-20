using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayArrayObject
{
    class CSV_ArrayArrayObjectFile : Tools, ITester
    {
        private EmployeeRecord[][] ArrayArrayObject;
        private int NumberOfCollections;
        private int ElementsInCollection;
        private int ElementsInLastCollection;

        public CSV_ArrayArrayObjectFile()
        {
            this.NumberOfCollections = 0;
            this.ElementsInCollection = 0;
            this.ElementsInLastCollection = 0;
        }

        private void Inicialize(bool Write)
        {
            if (ElementsInLastCollection > 0)
            {
                ArrayArrayObject = new EmployeeRecord[this.NumberOfCollections + 1][];

                for (int i = 0; i < NumberOfCollections; i++)
                    ArrayArrayObject[i] = new EmployeeRecord[ElementsInCollection];
                ArrayArrayObject[NumberOfCollections] = new EmployeeRecord[ElementsInLastCollection];
            }
            else
            {
                ArrayArrayObject = new EmployeeRecord[this.NumberOfCollections][];

                for (int i = 0; i < NumberOfCollections; i++)
                    ArrayArrayObject[i] = new EmployeeRecord[ElementsInCollection];
            }

            if (Write)
            {
                for (int j = 0; j < NumberOfCollections; j++)
                    for (int i = 0; i < ElementsInCollection; i++)
                        ArrayArrayObject[j][i] = new EmployeeRecord(true);
                if (ElementsInLastCollection > 0)
                {
                    for (int j = 0; j < ElementsInLastCollection; j++)
                        ArrayArrayObject[NumberOfCollections][j] = new EmployeeRecord(true);
                }

            }
        }
        public void CSV_WriteArrayArrayObjectFile()
        {
            StringBuilder.AppendLine("ID, Money, Age, Children, FirstName, FamilyName, PIN, Residence, Ready, License, Indisposed");
            foreach (EmployeeRecord[] array in ArrayArrayObject)
            {
                foreach (EmployeeRecord record in array)
                {

                    StringBuilder.Append(record.ID);
                    StringBuilder.Append(",");
                    StringBuilder.Append(record.Money);
                    StringBuilder.Append(",");
                    StringBuilder.Append(record.Age);
                    StringBuilder.Append(",");
                    StringBuilder.Append(record.Children);
                    StringBuilder.Append(",");
                    StringBuilder.Append(record.FirstName);
                    StringBuilder.Append(",");
                    StringBuilder.Append(record.FamilyName);
                    StringBuilder.Append(",");
                    StringBuilder.Append(record.PIN);
                    StringBuilder.Append(",");
                    StringBuilder.Append(record.Residence);
                    StringBuilder.Append(",");
                    StringBuilder.Append(record.Ready);
                    StringBuilder.Append(",");
                    StringBuilder.Append(record.License);
                    StringBuilder.Append(",");
                    StringBuilder.Append(record.Indisposed);
                    StringBuilder.AppendLine();
                }
                StringBuilder.AppendLine();
            }
            StreamWriter.Write(StringBuilder);

        }
        public void CSV_ReadArrayArrayObjectFile()
        {
            int index_pole = 0;
            int j = 0;
            string line = string.Empty;
            string[] values = null;

            //read header
            StreamReader.ReadLine();

            while (StreamReader.Peek() > 0)
            {

                line = StreamReader.ReadLine();                
                if (line.Trim() == String.Empty)
                {
                    index_pole++;
                    j = 0;
                    continue;
                }
                else
                {
                    values = line.Split(',');
                }

                var Zamestnanec = new EmployeeRecord(false);
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
                ArrayArrayObject[index_pole][j++] = Zamestnanec;
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
            CSV_WriteArrayArrayObjectFile();
        }
        void ITester.TestRead()
        {
            CSV_ReadArrayArrayObjectFile();
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
