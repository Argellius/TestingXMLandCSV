using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakalarska_prace.ArrayInteger
{
    class CSV_ArrayIntegerString : Tools, ITester
    {
        private Int32[] ArrayInteger;
        private int NumberOfElements;

        public CSV_ArrayIntegerString()
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

        public void CSV_WriteArrayIntegerString()
        {
            StringBuilder.AppendLine("Integer");
            foreach (int it in ArrayInteger)
            {
                StringBuilder.AppendLine(it.ToString());
            }
            StringWriter.Write(StringBuilder);
        }
        public void CSV_ReadArrayIntegerString()
        {
            //read header
            StringReader.ReadLine();
            int i = 0;
            //read records
            //try catch bool, int exc
            while (StringReader.Peek() > 0)
            {
                var line = StringReader.ReadLine();
                ArrayInteger[i] = Convert.ToInt32(line);
                i++;
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
            ArrayInteger = null;            
        }
        void ITester.TestWrite()
        {
            CSV_WriteArrayIntegerString();
        }
        void ITester.TestRead()
        {
            CSV_ReadArrayIntegerString();
        }
        long ITester.GetSize()
        {
            return ToolsGetSizeOfString();            
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
