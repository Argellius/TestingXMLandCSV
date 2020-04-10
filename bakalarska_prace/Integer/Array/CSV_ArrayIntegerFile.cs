using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayInteger
{
    class CSV_ArrayIntegerFile : Tools, ITester
    {
        private Int32[] ArrayInteger;
        private int NumberOfElements;

        public CSV_ArrayIntegerFile()
        { 
            this.NumberOfElements = 0;
        }

        private void Inicialize(bool write)
        {
            ArrayInteger = new Int32[this.NumberOfElements];
            if (write)
                for (int i = 0; i < NumberOfElements; i++)
                    ArrayInteger[i] = int.MaxValue;
        }

        public void CSV_WriteArrayIntegerFile()
        {
            StringBuilder.AppendLine("Integer");
            foreach (int it in ArrayInteger)
            {
                StringBuilder.AppendLine(it.ToString());
            }
            StreamWriter.Write(StringBuilder);

        }
        public void CSV_ReadArrayIntegerFile()
        {
            //read header
            StreamReader.ReadLine();
            int i = 0;
            //read records
            //try catch bool, int exc

            while (!StreamReader.EndOfStream)
            {
                var line = StreamReader.ReadLine();
                ArrayInteger[i] = Convert.ToInt32(line);
                i++;
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
            ArrayInteger = null;
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
        void ITester.SetPath(string path)
        {
            base.SetPath(path);
        }
    }
}
