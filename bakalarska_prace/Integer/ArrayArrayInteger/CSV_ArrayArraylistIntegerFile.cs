using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayArrayInteger
{
    class CSV_ArrayArrayIntegerFile : Tools, ITester
    {
        private System.Int32[][] ArrayArray_Integer;
        private int pocetKolekci;
        private int pocetPrvkuVKolekci;
        private int pocetPrvkuVPosledniKolekci;

        public CSV_ArrayArrayIntegerFile(int NumberOfElements)
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
        public void CSV_WriteArrayArrayIntegerFile()
        {
            foreach (Int32[] array in ArrayArray_Integer)
            {
                foreach (var (value, index) in array.Select((v, i) => (v, i)))
                {
                    if (index != 0)
                        StringBuilder.Append(";");
                    StringBuilder.Append(value);
                    
                }
                StringBuilder.AppendLine();
            }
            StreamWriter.Write(StringBuilder);

        }
        public void CSV_ReadArrayArrayIntegerFile()
        {
            int index_pole = 0;
            while (StreamReader.Peek() > 0)
            {
                string line = StreamReader.ReadLine();
                string[] values = line.Split(';'); // moc se mi nelíbí

                foreach (var (value, index) in values.Select((v, i) => (v, i)))
                {
                    ArrayArray_Integer[index_pole][index] = Convert.ToInt32(value);
                }
                index_pole++;
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
            CSV_WriteArrayArrayIntegerFile();
        }
        void ITester.TestRead()
        {
            CSV_ReadArrayArrayIntegerFile();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile(this.GetType());
        }
    }
}
