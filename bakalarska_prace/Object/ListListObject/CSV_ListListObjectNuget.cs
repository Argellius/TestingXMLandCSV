using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ListListObject
{
    class CSV_ListListObjectNuget : Tools, ITester
    {
        private List<List<RecordOfEmployee>> ListListObject;
        private int pocetKolekci;
        private int pocetPrvkuVKolekci;
        private int pocetPrvkuVPosledniKolekci;


        public CSV_ListListObjectNuget(int NumberOfElements)
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

        public void CSV_WriteListListObjectNuget()
        {
            foreach (var record in ListListObject)
            {
                csvWriter.WriteRecords(record);
                csvWriter.NextRecord();
            }
        }
        public void CSV_ReadListListObjectNuget()
        {
            var ListObject = new List<RecordOfEmployee>();
            while (csvReader.Read())
            {
                if (csvReader.Context.Record.Count() > 0) //------
                {
                    ListListObject.Add(new List<RecordOfEmployee>(ListObject));
                    ListObject.Clear();
                    continue;
                }
                ListObject.Add(csvReader.GetRecord<RecordOfEmployee>());
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
            CSV_WriteListListObjectNuget();
        }
        void ITester.TestRead()
        {
            CSV_ReadListListObjectNuget();

        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile(this.GetType());
        }
    }
}
