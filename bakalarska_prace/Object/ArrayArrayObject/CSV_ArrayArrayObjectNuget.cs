using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayArrayObject
{
    class CSV_ArrayArrayObjectNuget : Tools, ITester
    {
        private RecordOfEmployee[][] ArrayArrayObject;
        private int pocetKolekci;
        private int pocetPrvkuVKolekci;
        private int pocetPrvkuVPosledniKolekci;

        public CSV_ArrayArrayObjectNuget() {
            pocetKolekci = 0;
            pocetPrvkuVKolekci = 0;
            pocetPrvkuVPosledniKolekci = 0;
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

        public void CSV_WriteArrayArrayObjectNuget()
        {
            foreach (RecordOfEmployee[] record in ArrayArrayObject)
            {
                csvWriter.WriteRecords<RecordOfEmployee>(record);
                csvWriter.NextRecord();
            }
        }
        public void CSV_ReadArrayArrayObjectNuget()
        {
            int index_pole = 0;
            int i = 0;

            while (csvReader.Read())
            {
                if (csvReader.Context.Record.Count() == 0) //------
                {
                    index_pole++;
                    i = 0;
                    continue;
                }
                ArrayArrayObject[index_pole][i] = csvReader.GetRecord<RecordOfEmployee>();
                i++;
            }

        }


        void ITester.SetupWriteStart()
        {
            Inicialize(true);
            base.ToolsInicializeStream(this.GetType(), true);
            csvWriter = new CsvWriter(base.StreamWriter, CultureInfo.InvariantCulture);
        }
        void ITester.SetupReadStart()
        {
            Inicialize(false);
            base.ToolsInicializeStream(this.GetType(), false);
            csvReader = new CsvReader(StreamReader, CultureInfo.InvariantCulture);
            csvReader.Configuration.IgnoreBlankLines = false;
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
            CSV_WriteArrayArrayObjectNuget();
        }
        void ITester.TestRead()
        {
            CSV_ReadArrayArrayObjectNuget();
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
