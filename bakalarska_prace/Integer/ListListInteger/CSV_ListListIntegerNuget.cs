using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ListListInteger
{
    class CSV_ListListIntegerNuget : Tools, ITester
    {
        private List<List<System.Int32>> ListListInteger;
        private int pocetKolekci;
        private int pocetPrvkuVKolekci;
        private int pocetPrvkuVPosledniKolekci;


        public CSV_ListListIntegerNuget(int NumberOfElements)
        {
            this.pocetKolekci = (int)Math.Sqrt(NumberOfElements);
            this.pocetPrvkuVKolekci = NumberOfElements / pocetKolekci;
            this.pocetPrvkuVPosledniKolekci = NumberOfElements % pocetKolekci;
        }

        private void Inicialize(bool Write)
        {
            ListListInteger = new List<List<System.Int32>>();

            if (Write)
            {
                List<int> ListInteger = new List<int>();
                for (int i = 0; i < pocetPrvkuVKolekci; i++)
                    ListInteger.Add(System.Int32.MaxValue);

                for (int i = 0; i < pocetKolekci; i++)
                    ListListInteger.Add(new List<int>(ListInteger));
                ListInteger.Clear();
                if (pocetPrvkuVPosledniKolekci > 0)
                {
                    for (int i = 0; i < pocetPrvkuVPosledniKolekci; i++)
                        ListInteger.Add(Int32.MaxValue);
                    ListListInteger.Add(new List<int>(ListInteger));
                }

            }
        }

        public void CSV_WriteListListIntegerNuget()
        {
            foreach(List<System.Int32> item in ListListInteger)
            {
                csvWriter.WriteField(item);
                csvWriter.NextRecord();
            }
            
        }
        public void CSV_ReadListListIntegerNuget()
        {
            List<int> result = new List<int>();
            int recordValue;
            while (csvReader.Read())
            {
                for (var i = 0; csvReader.TryGetField(i, out recordValue); i++)
                {
                    result.Add(recordValue);                    
                }
                ListListInteger.Add(new List<int>(result));
                result.Clear();
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
            CSV_WriteListListIntegerNuget();
        }
        void ITester.TestRead()
        {
            CSV_ReadListListIntegerNuget();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile(this.GetType());
        }
    }
}
