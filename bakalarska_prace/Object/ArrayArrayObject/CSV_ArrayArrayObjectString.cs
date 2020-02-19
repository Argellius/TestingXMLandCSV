using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayArrayObject
{
    class CSV_ArrayArrayObjectString : Tools, ITester
    {
        private RecordOfEmployee[][] ArrayArrayObject;
        private int pocetKolekci;
        private int pocetPrvkuVKolekci;
        private int pocetPrvkuVPosledniKolekci;

        public CSV_ArrayArrayObjectString(int NumberOfElements)
        {
            this.pocetKolekci = (int)Math.Sqrt(NumberOfElements);
            this.pocetPrvkuVKolekci = NumberOfElements / pocetKolekci;
            this.pocetPrvkuVPosledniKolekci = NumberOfElements % pocetKolekci;
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
        public void CSV_WriteArrayArrayObjectString()
        {
            StringBuilder.AppendLine("ID, Money, Age, Children, FirstName, FamilyName, PIN, Residence, Ready, License, Indisposed");
            foreach(RecordOfEmployee[] array in ArrayArrayObject)
            {
                foreach(RecordOfEmployee record in array)
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
            StringWriter.Write(StringBuilder);
        }

        public void CSV_ReadArrayArrayObjectString()
        {
            int index_pole = 0;
            int j = 0;
            string line = string.Empty;
            string[] values = null;

            //read header
            StringReader.ReadLine();

            while (StringReader.Peek() > 0)
            {

                line = StringReader.ReadLine();
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
            CSV_WriteArrayArrayObjectString();
        }
        void ITester.TestRead()
        {
            CSV_ReadArrayArrayObjectString();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfString();
        }
    }
}
