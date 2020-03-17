using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayListInteger
{
    class CSV_ArrayListIntegerFile : Tools, ITester
    {
        private ArrayList ArrayListInteger;
        private int NumberOfElements;

        public CSV_ArrayListIntegerFile()
        { 
            this.NumberOfElements = 0;
        }

        private void Inicialize(bool write)
        {
            ArrayListInteger = new ArrayList();

            if (write)
                for (int i = 0; i < NumberOfElements; i++)
                    ArrayListInteger.Add(int.MaxValue);
        }

        public void CSV_WriteArrayIntegerFile()
        {
            StringBuilder.AppendLine("Integer");
            foreach (int it in ArrayListInteger)
            {
                StringBuilder.AppendLine(it.ToString());
            }
            StreamWriter.Write(StringBuilder);

        }
        public void CSV_ReadArrayIntegerFile()
        {
            //read header
            StreamReader.ReadLine();

            //read records
            //try catch bool, int exc
            while (!StreamReader.EndOfStream)
            {
                var line = StreamReader.ReadLine();
                ArrayListInteger.Add(Convert.ToInt32(line));

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
            CSV_WriteArrayIntegerFile();
        }
        void ITester.TestRead()
        {
            CSV_ReadArrayIntegerFile();
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
