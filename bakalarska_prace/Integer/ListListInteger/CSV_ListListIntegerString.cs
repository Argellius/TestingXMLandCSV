﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ListListInteger
{
    class CSV_ListListIntegerString : Tools, ITester
    {
        private List<List<System.Int32>> ListListInteger;
        private int pocetKolekci;
        private int pocetPrvkuVKolekci;
        private int pocetPrvkuVPosledniKolekci;

        public CSV_ListListIntegerString(int NumberOfElements)
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
        public void CSV_WriteListListIntegerString()
        {
            StringBuilder.AppendLine("Integer");
            foreach (List<int> List_Item in ListListInteger)
            {
                foreach (int Item in List_Item)
                {
                    StringBuilder.AppendLine(Item.ToString());
                }
                StringBuilder.AppendLine(";");

            }
            StringWriter.Write(StringBuilder);
        }

        public void CSV_ReadListListIntegerString()
        {
            while (StringReader.Peek() > 0)
            {
                string line = StringReader.ReadLine();
                ListListInteger.Add(line.Split(';').ToList().ConvertAll(int.Parse));
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
            CSV_WriteListListIntegerString();
        }
        void ITester.TestRead()
        {
            CSV_ReadListListIntegerString();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfString();
        }
    }
}