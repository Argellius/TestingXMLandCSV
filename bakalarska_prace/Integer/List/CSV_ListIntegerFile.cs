using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ListInteger
{
    class CSV_ListIntegerFile : Tools, ITester
    {
        private List<System.Int32> ListInteger;
        private int NumberOfElements;


        public CSV_ListIntegerFile()
        {
            this.NumberOfElements = 0;
        }

        private void Inicialize(bool Write)
        {
            ListInteger = new List<Int32>();
            if (Write)
                for (int i = 0; i < NumberOfElements; i++)
                    ListInteger.Add(int.MaxValue);

        }

        public void CSV_WriteListIntegerFile()
        {
            StringBuilder.AppendLine("Integer");
            foreach (int it in ListInteger)
            {
                StringBuilder.AppendLine(it.ToString());
            }
            StreamWriter.Write(StringBuilder);

        }
        public void CSV_ReadListIntegerFile()
        {
            //read header
            StreamReader.ReadLine();

            //read records
            while (!StreamReader.EndOfStream)
            {
                string line = StreamReader.ReadLine();
                ListInteger.Add(Convert.ToInt32(line));

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
            ListInteger = null;
        }
        void ITester.TestWrite()
        {
            CSV_WriteListIntegerFile();
        }
        void ITester.TestRead()
        {
            CSV_ReadListIntegerFile();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfFile(this.GetType());
        }
        void ITester.SetNumberOfElements(int NumberOfElements)
        {
            this.NumberOfElements = NumberOfElements;
        }
    }
}
