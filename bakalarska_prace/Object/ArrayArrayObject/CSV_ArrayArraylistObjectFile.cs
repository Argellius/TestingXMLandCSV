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
        private RecordOfEmployee[][] ArrayArrayObject;
        private int pocetKolekci;
        private int pocetPrvkuVKolekci;
        private int pocetPrvkuVPosledniKolekci;

        public CSV_ArrayArrayObjectFile()
        {
            this.pocetKolekci = 0;
            this.pocetPrvkuVKolekci = 0;
            this.pocetPrvkuVPosledniKolekci = 0;
        }

        private void Inicialize(bool Write)
        {
            if (pocetPrvkuVPosledniKolekci > 0)
            {
                ArrayArrayObject = new RecordOfEmployee[this.pocetKolekci + 1][];

                for (int i = 0; i < pocetKolekci; i++)
                    ArrayArrayObject[i] = new RecordOfEmployee[pocetPrvkuVKolekci];
                ArrayArrayObject[pocetKolekci] = new RecordOfEmployee[pocetPrvkuVPosledniKolekci];
            }
            else
            {
                ArrayArrayObject = new RecordOfEmployee[this.pocetKolekci][];

                for (int i = 0; i < pocetKolekci; i++)
                    ArrayArrayObject[i] = new RecordOfEmployee[pocetPrvkuVKolekci];
            }

            if (Write)
            {
                for (int j = 0; j < pocetKolekci; j++)
                    for (int i = 0; i < pocetPrvkuVKolekci; i++)
                        ArrayArrayObject[j][i] = new RecordOfEmployee(true);
                if (pocetPrvkuVPosledniKolekci > 0)
                {
                    for (int j = 0; j < pocetPrvkuVPosledniKolekci; j++)
                        ArrayArrayObject[pocetKolekci][j] = new RecordOfEmployee(true);
                }

            }
        }
        public void CSV_WriteArrayArrayObjectFile()
        {
            StringBuilder.AppendLine("ID, Money, Age, Children, FirstName, FamilyName, PIN, Residence, Ready, License, Indisposed");
            foreach (RecordOfEmployee[] array in ArrayArrayObject)
            {
                foreach (RecordOfEmployee record in array)
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

                var Zamestnanec = new RecordOfEmployee(false);
                Zamestnanec.ID = Convert.ToInt64(values[0]);
                Zamestnanec.Money = Convert.ToInt64(values[1]);
                Zamestnanec.Age = Convert.ToInt64(values[2]);
                Zamestnanec.Children = Convert.ToInt64(values[3]);
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
            this.pocetKolekci = (int)Math.Sqrt(NumberOfElements);
            this.pocetPrvkuVKolekci = NumberOfElements / pocetKolekci;
            this.pocetPrvkuVPosledniKolekci = NumberOfElements % pocetKolekci;
        }
    }
}
