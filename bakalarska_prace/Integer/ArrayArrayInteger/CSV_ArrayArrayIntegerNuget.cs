using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayArrayInteger
{
    class CSV_ArrayArrayIntegerNuget : Tools, ITester
    {
        private System.Int32[][] ArrayArray_Integer;
        private int pocetKolekci;
        private int pocetPrvkuVKolekci;
        private int pocetPrvkuVPosledniKolekci;

        public CSV_ArrayArrayIntegerNuget(int NumberOfElements)
        {
            this.pocetKolekci = (int)Math.Sqrt(NumberOfElements);
            this.pocetPrvkuVKolekci = NumberOfElements / pocetKolekci;
            this.pocetPrvkuVPosledniKolekci = NumberOfElements % pocetKolekci;
        }
        private void Inicialize(bool Write)
        {
            if (pocetPrvkuVPosledniKolekci > 0)
            {
                ArrayArray_Integer = new Int32[this.pocetKolekci + 1][];

                for (int i = 0; i < pocetKolekci; i++)
                    ArrayArray_Integer[i] = new int[pocetPrvkuVKolekci];
                ArrayArray_Integer[pocetKolekci] = new int[pocetPrvkuVPosledniKolekci];
            }
            else
            {
                ArrayArray_Integer = new Int32[this.pocetKolekci][];

                for (int i = 0; i < pocetKolekci; i++)
                    ArrayArray_Integer[i] = new int[pocetPrvkuVKolekci];
            }

            if (Write)
            {
                for (int j = 0; j < pocetKolekci; j++)
                    for (int i = 0; i < pocetPrvkuVKolekci; i++)
                        ArrayArray_Integer[j][i] = int.MaxValue;
                if (pocetPrvkuVPosledniKolekci > 0)
                {
                    for (int j = 0; j < pocetPrvkuVPosledniKolekci; j++)
                        ArrayArray_Integer[pocetKolekci][j] = int.MaxValue;
                }

            }
        }
        public void CSV_WriteArrayArrayIntegerNuget()
        {
            foreach (Int32[] array in ArrayArray_Integer)
            {
                csvWriter.WriteRecords(array);
                csvWriter.NextRecord();
            }
        }
        public void CSV_ReadArrayArrayIntegerNuget()
        {
            int index_pole = 0;
            int i = 0;

            while (csvReader.Read())
            {
                if (csvReader.Context.Record.Count() > 0) //------
                {
                    index_pole++;
                    i = 0;
                    continue;
                }
                ArrayArray_Integer[index_pole][i] = csvReader.GetRecord<Int32>();
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
            csvReader.Configuration.HasHeaderRecord = false;
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
            CSV_WriteArrayArrayIntegerNuget();
        }
        void ITester.TestRead()
        {
            CSV_ReadArrayArrayIntegerNuget();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile(this.GetType());
        }
    }
}
